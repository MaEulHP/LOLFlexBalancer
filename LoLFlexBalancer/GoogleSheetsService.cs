using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.IO;

namespace LoLFlexBalancer
{
	public class GoogleSheetsService
	{
		private readonly string SpreadsheetId = "1YfSzkUMfktmvjeKOO5y7Zfv-0kasN4r8IR9oFIUxQVE";
		private readonly string SheetName = "SearchBase"; // 기본 시트 이름
		private readonly SheetsService service;

		public GoogleSheetsService()
		{
			GoogleCredential credential;
			using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
			{
				credential = GoogleCredential.FromStream(stream)
					.CreateScoped(SheetsService.Scope.Spreadsheets);
			}

			service = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "LoLFlexBalancer"
			});
		}

		public IList<IList<object>> LoadData()
		{
			var request = service.Spreadsheets.Values.Get(SpreadsheetId, $"{SheetName}!A2:D");
			var response = request.Execute();
			return response.Values ?? new List<IList<object>>();
		}

		public void SaveData(List<string[]> data)
		{
			var valueRange = new ValueRange
			{
				Values = new List<IList<object>>()
			};

			foreach (var row in data)
			{
				valueRange.Values.Add(new List<object>(row));
			}

			var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, $"{SheetName}!A2:D");
			updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
			updateRequest.Execute();
		}
	}
}
