namespace LoLFlexBalancer
{
	partial class FrmMain
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBoxUsers = new System.Windows.Forms.ListBox();
			this.btn_search = new System.Windows.Forms.Button();
			this.dgv_result = new System.Windows.Forms.DataGridView();
			this.listBoxSelected = new System.Windows.Forms.ListBox();
			this.btn_add = new System.Windows.Forms.Button();
			this.btn_csv_edit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxUsers
			// 
			this.listBoxUsers.FormattingEnabled = true;
			this.listBoxUsers.ItemHeight = 12;
			this.listBoxUsers.Location = new System.Drawing.Point(12, 12);
			this.listBoxUsers.Name = "listBoxUsers";
			this.listBoxUsers.Size = new System.Drawing.Size(133, 184);
			this.listBoxUsers.TabIndex = 2;
			this.listBoxUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxUsers_MouseDoubleClick);
			// 
			// btn_search
			// 
			this.btn_search.Location = new System.Drawing.Point(371, 12);
			this.btn_search.Name = "btn_search";
			this.btn_search.Size = new System.Drawing.Size(75, 23);
			this.btn_search.TabIndex = 3;
			this.btn_search.Text = "검색";
			this.btn_search.UseVisualStyleBackColor = true;
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// dgv_result
			// 
			this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_result.Location = new System.Drawing.Point(13, 202);
			this.dgv_result.Name = "dgv_result";
			this.dgv_result.RowTemplate.Height = 23;
			this.dgv_result.Size = new System.Drawing.Size(759, 247);
			this.dgv_result.TabIndex = 4;
			// 
			// listBoxSelected
			// 
			this.listBoxSelected.FormattingEnabled = true;
			this.listBoxSelected.ItemHeight = 12;
			this.listBoxSelected.Location = new System.Drawing.Point(232, 12);
			this.listBoxSelected.Name = "listBoxSelected";
			this.listBoxSelected.Size = new System.Drawing.Size(133, 184);
			this.listBoxSelected.TabIndex = 5;
			this.listBoxSelected.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSelected_MouseDoubleClick);
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(151, 12);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(75, 23);
			this.btn_add.TabIndex = 6;
			this.btn_add.Text = "추가";
			this.btn_add.UseVisualStyleBackColor = true;
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// btn_csv_edit
			// 
			this.btn_csv_edit.Location = new System.Drawing.Point(151, 41);
			this.btn_csv_edit.Name = "btn_csv_edit";
			this.btn_csv_edit.Size = new System.Drawing.Size(75, 23);
			this.btn_csv_edit.TabIndex = 7;
			this.btn_csv_edit.Text = "수정";
			this.btn_csv_edit.UseVisualStyleBackColor = true;
			this.btn_csv_edit.Click += new System.EventHandler(this.btn_csv_edit_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.btn_csv_edit);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.listBoxSelected);
			this.Controls.Add(this.dgv_result);
			this.Controls.Add(this.btn_search);
			this.Controls.Add(this.listBoxUsers);
			this.Name = "FrmMain";
			this.Text = "내전 팀 검색기";
			((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox listBoxUsers;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.DataGridView dgv_result;
		private System.Windows.Forms.ListBox listBoxSelected;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Button btn_csv_edit;
	}
}

