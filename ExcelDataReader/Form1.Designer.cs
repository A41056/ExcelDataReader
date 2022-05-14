namespace ExcelDataReader
{
    partial class Form1
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
            this.btn_nhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tenfile_txt = new System.Windows.Forms.TextBox();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.btn_xuat = new System.Windows.Forms.Button();
            this.data_CC = new System.Windows.Forms.DataGridView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.data_SV = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_mamon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_somon = new System.Windows.Forms.TextBox();
            this.tab_sv = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_export_sv = new System.Windows.Forms.Button();
            this.btn_SV = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_refresh_thk1 = new System.Windows.Forms.Button();
            this.btn_ok_thk1 = new System.Windows.Forms.Button();
            this.btn_export_thk1 = new System.Windows.Forms.Button();
            this.btn_refresh_qt = new System.Windows.Forms.Button();
            this.btn_ok_qt = new System.Windows.Forms.Button();
            this.btn_export_qt = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_sttmon = new System.Windows.Forms.TextBox();
            this.data_THK1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.data_QT = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_CC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_SV)).BeginInit();
            this.tab_sv.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_THK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_QT)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_nhap
            // 
            this.btn_nhap.Location = new System.Drawing.Point(549, 44);
            this.btn_nhap.Name = "btn_nhap";
            this.btn_nhap.Size = new System.Drawing.Size(42, 24);
            this.btn_nhap.TabIndex = 1;
            this.btn_nhap.Text = "..";
            this.btn_nhap.UseVisualStyleBackColor = true;
            this.btn_nhap.Click += new System.EventHandler(this.btn_nhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File đang mở:";
            // 
            // tenfile_txt
            // 
            this.tenfile_txt.Location = new System.Drawing.Point(110, 44);
            this.tenfile_txt.Name = "tenfile_txt";
            this.tenfile_txt.Size = new System.Drawing.Size(433, 22);
            this.tenfile_txt.TabIndex = 3;
            // 
            // cbSheet
            // 
            this.cbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(929, 148);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(121, 24);
            this.cbSheet.TabIndex = 4;
            this.cbSheet.SelectionChangeCommitted += new System.EventHandler(this.cbSheet_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(870, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sheet: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cột: ";
            // 
            // cbColumn
            // 
            this.cbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(382, 17);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(121, 24);
            this.cbColumn.TabIndex = 6;
            this.cbColumn.SelectionChangeCommitted += new System.EventHandler(this.cbColumn_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dữ Liệu: ";
            // 
            // cbData
            // 
            this.cbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(590, 17);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(121, 24);
            this.cbData.TabIndex = 8;
            // 
            // btn_xuat
            // 
            this.btn_xuat.Location = new System.Drawing.Point(1099, 110);
            this.btn_xuat.Name = "btn_xuat";
            this.btn_xuat.Size = new System.Drawing.Size(75, 75);
            this.btn_xuat.TabIndex = 11;
            this.btn_xuat.Text = "Xuất";
            this.btn_xuat.UseVisualStyleBackColor = true;
            this.btn_xuat.Click += new System.EventHandler(this.btn_xuat_Click);
            // 
            // data_CC
            // 
            this.data_CC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_CC.Location = new System.Drawing.Point(11, 110);
            this.data_CC.Name = "data_CC";
            this.data_CC.RowTemplate.Height = 24;
            this.data_CC.Size = new System.Drawing.Size(920, 169);
            this.data_CC.TabIndex = 12;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(937, 110);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 75);
            this.btn_ok.TabIndex = 13;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // data_SV
            // 
            this.data_SV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_SV.Location = new System.Drawing.Point(14, 178);
            this.data_SV.Name = "data_SV";
            this.data_SV.RowTemplate.Height = 24;
            this.data_SV.Size = new System.Drawing.Size(1036, 561);
            this.data_SV.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Danh sách sinh viên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Điểm CC";
            // 
            // txt_mamon
            // 
            this.txt_mamon.Location = new System.Drawing.Point(382, 47);
            this.txt_mamon.Name = "txt_mamon";
            this.txt_mamon.Size = new System.Drawing.Size(121, 22);
            this.txt_mamon.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Mã môn ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Số môn";
            // 
            // txt_somon
            // 
            this.txt_somon.Location = new System.Drawing.Point(193, 47);
            this.txt_somon.Name = "txt_somon";
            this.txt_somon.Size = new System.Drawing.Size(121, 22);
            this.txt_somon.TabIndex = 23;
            // 
            // tab_sv
            // 
            this.tab_sv.Controls.Add(this.tabPage1);
            this.tab_sv.Controls.Add(this.tabPage2);
            this.tab_sv.Location = new System.Drawing.Point(12, 10);
            this.tab_sv.Name = "tab_sv";
            this.tab_sv.SelectedIndex = 0;
            this.tab_sv.Size = new System.Drawing.Size(1207, 774);
            this.tab_sv.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_export_sv);
            this.tabPage1.Controls.Add(this.cbSheet);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btn_SV);
            this.tabPage1.Controls.Add(this.data_SV);
            this.tabPage1.Controls.Add(this.tenfile_txt);
            this.tabPage1.Controls.Add(this.btn_nhap);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1199, 745);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách sinh viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_export_sv
            // 
            this.btn_export_sv.Location = new System.Drawing.Point(1056, 259);
            this.btn_export_sv.Name = "btn_export_sv";
            this.btn_export_sv.Size = new System.Drawing.Size(100, 75);
            this.btn_export_sv.TabIndex = 23;
            this.btn_export_sv.Text = "Xuất danh sách";
            this.btn_export_sv.UseVisualStyleBackColor = true;
            this.btn_export_sv.Click += new System.EventHandler(this.btn_export_sv_Click);
            // 
            // btn_SV
            // 
            this.btn_SV.Location = new System.Drawing.Point(1056, 178);
            this.btn_SV.Name = "btn_SV";
            this.btn_SV.Size = new System.Drawing.Size(100, 75);
            this.btn_SV.TabIndex = 22;
            this.btn_SV.Text = "Tạo ds sv";
            this.btn_SV.UseVisualStyleBackColor = true;
            this.btn_SV.Click += new System.EventHandler(this.btn_SV_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_refresh_thk1);
            this.tabPage2.Controls.Add(this.btn_ok_thk1);
            this.tabPage2.Controls.Add(this.btn_export_thk1);
            this.tabPage2.Controls.Add(this.btn_refresh_qt);
            this.tabPage2.Controls.Add(this.btn_ok_qt);
            this.tabPage2.Controls.Add(this.btn_export_qt);
            this.tabPage2.Controls.Add(this.btn_refresh);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txt_sttmon);
            this.tabPage2.Controls.Add(this.data_THK1);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.data_QT);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.data_CC);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txt_somon);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cbColumn);
            this.tabPage2.Controls.Add(this.txt_mamon);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cbData);
            this.tabPage2.Controls.Add(this.btn_ok);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_xuat);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1199, 745);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Điểm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_refresh_thk1
            // 
            this.btn_refresh_thk1.Location = new System.Drawing.Point(1018, 529);
            this.btn_refresh_thk1.Name = "btn_refresh_thk1";
            this.btn_refresh_thk1.Size = new System.Drawing.Size(75, 75);
            this.btn_refresh_thk1.TabIndex = 37;
            this.btn_refresh_thk1.Text = "Tạo mới";
            this.btn_refresh_thk1.UseVisualStyleBackColor = true;
            this.btn_refresh_thk1.Click += new System.EventHandler(this.btn_refresh_thk1_Click);
            // 
            // btn_ok_thk1
            // 
            this.btn_ok_thk1.Location = new System.Drawing.Point(937, 529);
            this.btn_ok_thk1.Name = "btn_ok_thk1";
            this.btn_ok_thk1.Size = new System.Drawing.Size(75, 75);
            this.btn_ok_thk1.TabIndex = 36;
            this.btn_ok_thk1.Text = "OK";
            this.btn_ok_thk1.UseVisualStyleBackColor = true;
            this.btn_ok_thk1.Click += new System.EventHandler(this.btn_ok_thk1_Click);
            // 
            // btn_export_thk1
            // 
            this.btn_export_thk1.Location = new System.Drawing.Point(1099, 529);
            this.btn_export_thk1.Name = "btn_export_thk1";
            this.btn_export_thk1.Size = new System.Drawing.Size(75, 75);
            this.btn_export_thk1.TabIndex = 35;
            this.btn_export_thk1.Text = "Xuất";
            this.btn_export_thk1.UseVisualStyleBackColor = true;
            this.btn_export_thk1.Click += new System.EventHandler(this.btn_export_thk1_Click);
            // 
            // btn_refresh_qt
            // 
            this.btn_refresh_qt.Location = new System.Drawing.Point(1018, 318);
            this.btn_refresh_qt.Name = "btn_refresh_qt";
            this.btn_refresh_qt.Size = new System.Drawing.Size(75, 75);
            this.btn_refresh_qt.TabIndex = 34;
            this.btn_refresh_qt.Text = "Tạo mới";
            this.btn_refresh_qt.UseVisualStyleBackColor = true;
            this.btn_refresh_qt.Click += new System.EventHandler(this.btn_refresh_qt_Click);
            // 
            // btn_ok_qt
            // 
            this.btn_ok_qt.Location = new System.Drawing.Point(937, 318);
            this.btn_ok_qt.Name = "btn_ok_qt";
            this.btn_ok_qt.Size = new System.Drawing.Size(75, 75);
            this.btn_ok_qt.TabIndex = 33;
            this.btn_ok_qt.Text = "OK";
            this.btn_ok_qt.UseVisualStyleBackColor = true;
            this.btn_ok_qt.Click += new System.EventHandler(this.btn_ok_qt_Click);
            // 
            // btn_export_qt
            // 
            this.btn_export_qt.Location = new System.Drawing.Point(1099, 318);
            this.btn_export_qt.Name = "btn_export_qt";
            this.btn_export_qt.Size = new System.Drawing.Size(75, 75);
            this.btn_export_qt.TabIndex = 32;
            this.btn_export_qt.Text = "Xuất";
            this.btn_export_qt.UseVisualStyleBackColor = true;
            this.btn_export_qt.Click += new System.EventHandler(this.btn_export_qt_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(1018, 110);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 75);
            this.btn_refresh.TabIndex = 31;
            this.btn_refresh.Text = "Tạo mới";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(525, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Môn thứ";
            // 
            // txt_sttmon
            // 
            this.txt_sttmon.Location = new System.Drawing.Point(590, 47);
            this.txt_sttmon.Name = "txt_sttmon";
            this.txt_sttmon.Size = new System.Drawing.Size(121, 22);
            this.txt_sttmon.TabIndex = 29;
            // 
            // data_THK1
            // 
            this.data_THK1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_THK1.Location = new System.Drawing.Point(11, 529);
            this.data_THK1.Name = "data_THK1";
            this.data_THK1.RowTemplate.Height = 24;
            this.data_THK1.Size = new System.Drawing.Size(920, 169);
            this.data_THK1.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 506);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Điểm THK1";
            // 
            // data_QT
            // 
            this.data_QT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_QT.Location = new System.Drawing.Point(11, 318);
            this.data_QT.Name = "data_QT";
            this.data_QT.RowTemplate.Height = 24;
            this.data_QT.Size = new System.Drawing.Size(920, 169);
            this.data_QT.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Điểm QT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 787);
            this.Controls.Add(this.tab_sv);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đọc file";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_CC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_SV)).EndInit();
            this.tab_sv.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_THK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_QT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_nhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tenfile_txt;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbData;
        private System.Windows.Forms.Button btn_xuat;
        private System.Windows.Forms.DataGridView data_CC;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DataGridView data_SV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_mamon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_somon;
        private System.Windows.Forms.TabControl tab_sv;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView data_THK1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView data_QT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_sttmon;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_refresh_thk1;
        private System.Windows.Forms.Button btn_ok_thk1;
        private System.Windows.Forms.Button btn_export_thk1;
        private System.Windows.Forms.Button btn_refresh_qt;
        private System.Windows.Forms.Button btn_ok_qt;
        private System.Windows.Forms.Button btn_export_qt;
        private System.Windows.Forms.Button btn_export_sv;
        private System.Windows.Forms.Button btn_SV;
    }
}

