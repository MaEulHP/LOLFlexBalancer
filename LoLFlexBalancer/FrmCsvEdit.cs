using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LoLFlexBalancer
{
	public partial class FrmCsvEdit : Form
	{
		private GoogleSheetsService sheetService = new GoogleSheetsService();

		public FrmCsvEdit()
		{
			InitializeComponent();
			LoadCsv();
		}

		private void LoadCsv()
		{
			dgv_csv.Rows.Clear();
			dgv_csv.Columns.Clear();

			dgv_csv.Columns.Add("Name", "이름");
			dgv_csv.Columns.Add("Account1", "계정1");
			dgv_csv.Columns.Add("Account2", "계정2");
			dgv_csv.Columns.Add("Account3", "계정3");

			var rows = sheetService.LoadData();
			foreach (var row in rows)
			{
				dgv_csv.Rows.Add(
					row.Count > 0 ? row[0] : "",
					row.Count > 1 ? row[1] : "",
					row.Count > 2 ? row[2] : "",
					row.Count > 3 ? row[3] : ""
				);
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			try
			{
				var newRows = new List<string[]>();

				foreach (DataGridViewRow row in dgv_csv.Rows)
				{
					if (row.IsNewRow) continue;

					newRows.Add(new string[]
					{
				row.Cells[0].Value?.ToString()?.Trim() ?? "",
				row.Cells[1].Value?.ToString()?.Trim() ?? "",
				row.Cells[2].Value?.ToString()?.Trim() ?? "",
				row.Cells[3].Value?.ToString()?.Trim() ?? ""
					});
				}

				sheetService.SaveData(newRows);
				MessageBox.Show("Google Sheet에 저장 완료!");

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("저장 실패: " + ex.Message);
			}
		}
	}
}
