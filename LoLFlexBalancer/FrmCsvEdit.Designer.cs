namespace LoLFlexBalancer
{
	partial class FrmCsvEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgv_csv = new System.Windows.Forms.DataGridView();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_exit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_csv)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_csv
			// 
			this.dgv_csv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_csv.Location = new System.Drawing.Point(12, 12);
			this.dgv_csv.Name = "dgv_csv";
			this.dgv_csv.RowTemplate.Height = 23;
			this.dgv_csv.Size = new System.Drawing.Size(760, 358);
			this.dgv_csv.TabIndex = 0;
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(616, 376);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 1;
			this.btn_save.Text = "저장";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_exit
			// 
			this.btn_exit.Location = new System.Drawing.Point(697, 376);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(75, 23);
			this.btn_exit.TabIndex = 2;
			this.btn_exit.Text = "취소";
			this.btn_exit.UseVisualStyleBackColor = true;
			// 
			// FrmCsvEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 411);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.dgv_csv);
			this.Name = "FrmCsvEdit";
			this.Text = "수정";
			((System.ComponentModel.ISupportInitialize)(this.dgv_csv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_csv;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_exit;
	}
}