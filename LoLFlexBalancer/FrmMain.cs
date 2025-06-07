using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoLFlexBalancer
{
	public partial class FrmMain : Form
	{
		private List<UserEntry> userList = new List<UserEntry>();
		private RiotApiService riotApi = new RiotApiService();
		private GoogleSheetsService sheetService = new GoogleSheetsService();

		public FrmMain()
		{
			InitializeComponent();
			this.LoadUserListFromSheet();
		}

		private void LoadUserListFromSheet()
		{
			try
			{
				var rows = sheetService.LoadData();
				foreach (var row in rows)
				{
					var entry = new UserEntry
					{
						Name = row.Count > 0 ? row[0].ToString() : "",
						Accounts = row.Skip(1).Where(cell => !string.IsNullOrWhiteSpace(cell.ToString())).Select(cell => cell.ToString()).ToList()
					};
					if (!string.IsNullOrWhiteSpace(entry.Name))
					{
						userList.Add(entry);
						listBoxUsers.Items.Add(entry.Name);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("시트 로드 실패: " + ex.Message);
			}
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			if (this.listBoxUsers.SelectedItem is string selectedName &&
				!this.listBoxSelected.Items.Contains(selectedName) &&
				this.listBoxSelected.Items.Count != 10)
			{
				this.listBoxSelected.Items.Add(selectedName);
			}
		}

		private async void btn_search_Click(object sender, EventArgs e)
		{
			if (this.listBoxSelected.Items.Count != 10)
			{
				MessageBox.Show("10명을 선택해야 전적 검색이 가능합니다.");
				return;
			}

			this.btn_search.Enabled = false;
			this.dgv_result.Rows.Clear();
			this.dgv_result.Columns.Clear();

			this.dgv_result.Columns.Add("Name", "이름");
			this.dgv_result.Columns.Add("Tier", "티어");
			this.dgv_result.Columns.Add("LP", "LP");
			this.dgv_result.Columns.Add("WinRate", "승률");
			this.dgv_result.Columns.Add("Score", "점수");

			foreach (string name in this.listBoxSelected.Items)
			{
				var user = userList.FirstOrDefault(u => u.Name == name);
				if (user == null) continue;

				var infos = new List<MatchInfo>();
				foreach (var acc in user.Accounts)
				{
					var info = await this.riotApi.GetRankAndStats(acc);
					if (info != null)
						infos.Add(info);
				}

				if (infos.Count > 0)
				{
					var avgTier = string.Join("/", infos.Select(i => i.Tier));
					var avgLP = (int)infos.Average(i => i.LP);
					var avgWR = infos.Average(i => i.WinRate);
					var avgScore = infos.Average(i => i.Score);

					this.dgv_result.Rows.Add(user.Name, avgTier, avgLP, $"{avgWR:F1}%", Math.Round(avgScore, 2));
				}
			}

			this.btn_search.Enabled = true;
		}

		private void btn_csv_edit_Click(object sender, EventArgs e)
		{
			Form frmCsvEdit = new FrmCsvEdit();
			var result = frmCsvEdit.ShowDialog();
			if(result == DialogResult.OK)
			{
				// 기존 데이터 초기화
				listBoxUsers.Items.Clear();
				listBoxSelected.Items.Clear();
				userList.Clear();

				// Google Sheets에서 다시 로드
				LoadUserListFromSheet();
			}
		}

		private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.listBoxUsers.SelectedItem is string selectedName &&
				!this.listBoxSelected.Items.Contains(selectedName) &&
				this.listBoxSelected.Items.Count != 10)
			{
				this.listBoxSelected.Items.Add(selectedName);
			}
		}

		private void listBoxSelected_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.listBoxSelected.SelectedItem is string selectedName)
			{
				this.listBoxSelected.Items.Remove(selectedName);
			}
		}
	}
}