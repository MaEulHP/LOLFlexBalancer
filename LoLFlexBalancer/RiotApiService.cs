using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoLFlexBalancer
{
	public class RiotApiService
	{
		private readonly string apiKey = "RGAPI-49c936a1-22ff-4e8a-9ad6-0709bfa25761";
		private readonly HttpClient client = new HttpClient();

		public RiotApiService()
		{
			client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
		}

		public async Task<MatchInfo> GetRankAndStats(string riotId)
		{
			try
			{
				var parts = riotId.Split('#');
				if (parts.Length != 2) return null;

				string gameName = Uri.EscapeDataString(parts[0]);
				string tagLine = Uri.EscapeDataString(parts[1]);

				// 1. PUUID
				var accRes = await client.GetAsync($"https://asia.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
				if (!accRes.IsSuccessStatusCode) return null;

				var accJson = await accRes.Content.ReadAsStringAsync();
				var acc = JsonSerializer.Deserialize<RiotAccountDto>(accJson);

				// 2. Summoner ID
				var summRes = await client.GetAsync($"https://kr.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{acc.puuid}");
				if (!summRes.IsSuccessStatusCode) return null;

				var summJson = await summRes.Content.ReadAsStringAsync();
				var summ = JsonSerializer.Deserialize<SummonerDto>(summJson);

				// 3. 랭크 정보
				var rankRes = await client.GetAsync($"https://kr.api.riotgames.com/lol/league/v4/entries/by-summoner/{summ.id}");
				if (!rankRes.IsSuccessStatusCode) return null;

				var rankJson = await rankRes.Content.ReadAsStringAsync();
				var ranks = JsonSerializer.Deserialize<RankDto[]>(rankJson);
				var flex = Array.Find(ranks, r => r.queueType == "RANKED_FLEX_SR");
				if (flex == null) return null;

				// 4. 점수 계산
				int baseScore = GetTierBaseScore(flex.tier);
				int divPenalty = GetDivisionPenalty(flex.rank);
				int lp = flex.leaguePoints;
				int totalRaw = baseScore - divPenalty + lp;

				double winRatio = (flex.wins + flex.losses) > 0 ? (double)flex.wins / (flex.wins + flex.losses) : 0.5;
				double finalScore = totalRaw * winRatio;

				return new MatchInfo
				{
					Tier = $"{flex.tier} {flex.rank}",
					LP = lp,
					WinRate = winRatio * 100,
					Score = finalScore
				};
			}
			catch
			{
				return null;
			}
		}

		public class RiotAccountDto { public string puuid { get; set; } }
		public class SummonerDto { public string id { get; set; } }
		public class RankDto
		{
			public string tier { get; set; }
			public string rank { get; set; }
			public int leaguePoints { get; set; }
			public int wins { get; set; }
			public int losses { get; set; }
			public string queueType { get; set; }
		}
		private int GetTierBaseScore(string tier)
		{
			switch (tier.ToUpper())
			{
				case "CHALLENGER": return 3000;
				case "GRANDMASTER": return 2900;
				case "MASTER": return 2800;
				case "DIAMOND": return 2700;
				case "EMERALD": return 2300;
				case "PLATINUM": return 2000;
				case "GOLD": return 1700;
				case "SILVER": return 1400;
				case "BRONZE": return 1100;
				case "IRON": return 800;
				default: return 0;
			}
		}

		private int GetDivisionPenalty(string division)
		{
			switch (division.ToUpper()) 
			{
				case "I": return 0;
				case "II": return 100;
				case "III": return 200;
				case "IV": return 300;
				default : return 0;
			}
		}
	}
}
