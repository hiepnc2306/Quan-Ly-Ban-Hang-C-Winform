namespace quanlybanhang
{
    partial class FormThongKeSoLuongHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbYear = new System.Windows.Forms.RadioButton();
            this.rdbMonth = new System.Windows.Forms.RadioButton();
            this.rdbDay = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTon = new System.Windows.Forms.RadioButton();
            this.rdbXuat = new System.Windows.Forms.RadioButton();
            this.rdbNhap = new System.Windows.Forms.RadioButton();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ SỐ LƯỢNG HÀNG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(109, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 378);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(25, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(713, 177);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ThoiGian";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "MaHD";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TenHang";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Soluong";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DonGia";
            this.Column5.Name = "Column5";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(344, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 155);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ngày thống kê";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(188, 95);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(188, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Đến Ngày/Tháng/Năm";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn Ngày/Tháng/Năm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbYear);
            this.groupBox2.Controls.Add(this.rdbMonth);
            this.groupBox2.Controls.Add(this.rdbDay);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(182, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " ";
            // 
            // rdbYear
            // 
            this.rdbYear.AutoSize = true;
            this.rdbYear.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYear.Location = new System.Drawing.Point(21, 120);
            this.rdbYear.Name = "rdbYear";
            this.rdbYear.Size = new System.Drawing.Size(78, 19);
            this.rdbYear.TabIndex = 2;
            this.rdbYear.TabStop = true;
            this.rdbYear.Text = "Theo năm";
            this.rdbYear.UseVisualStyleBackColor = true;
            // 
            // rdbMonth
            // 
            this.rdbMonth.AutoSize = true;
            this.rdbMonth.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMonth.Location = new System.Drawing.Point(21, 82);
            this.rdbMonth.Name = "rdbMonth";
            this.rdbMonth.Size = new System.Drawing.Size(87, 19);
            this.rdbMonth.TabIndex = 1;
            this.rdbMonth.TabStop = true;
            this.rdbMonth.Text = "Theo tháng";
            this.rdbMonth.UseVisualStyleBackColor = true;
            // 
            // rdbDay
            // 
            this.rdbDay.AutoSize = true;
            this.rdbDay.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDay.Location = new System.Drawing.Point(21, 40);
            this.rdbDay.Name = "rdbDay";
            this.rdbDay.Size = new System.Drawing.Size(83, 19);
            this.rdbDay.TabIndex = 0;
            this.rdbDay.TabStop = true;
            this.rdbDay.Text = "Theo ngày";
            this.rdbDay.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTon);
            this.groupBox1.Controls.Add(this.rdbXuat);
            this.groupBox1.Controls.Add(this.rdbNhap);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại hàng";
            // 
            // rdbTon
            // 
            this.rdbTon.AutoSize = true;
            this.rdbTon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTon.Location = new System.Drawing.Point(21, 120);
            this.rdbTon.Name = "rdbTon";
            this.rdbTon.Size = new System.Drawing.Size(75, 19);
            this.rdbTon.TabIndex = 2;
            this.rdbTon.TabStop = true;
            this.rdbTon.Text = "Hàng tồn";
            this.rdbTon.UseVisualStyleBackColor = true;
            // 
            // rdbXuat
            // 
            this.rdbXuat.AutoSize = true;
            this.rdbXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbXuat.Location = new System.Drawing.Point(21, 82);
            this.rdbXuat.Name = "rdbXuat";
            this.rdbXuat.Size = new System.Drawing.Size(79, 19);
            this.rdbXuat.TabIndex = 1;
            this.rdbXuat.TabStop = true;
            this.rdbXuat.Text = "Hàng xuất";
            this.rdbXuat.UseVisualStyleBackColor = true;
            // 
            // rdbNhap
            // 
            this.rdbNhap.AutoSize = true;
            this.rdbNhap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNhap.Location = new System.Drawing.Point(21, 40);
            this.rdbNhap.Name = "rdbNhap";
            this.rdbNhap.Size = new System.Drawing.Size(84, 19);
            this.rdbNhap.TabIndex = 0;
            this.rdbNhap.TabStop = true;
            this.rdbNhap.Text = "Hàng nhập";
            this.rdbNhap.UseVisualStyleBackColor = true;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Location = new System.Drawing.Point(114, 450);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(122, 42);
            this.btnThucHien.TabIndex = 3;
            this.btnThucHien.Text = "THỰC HIỆN";
            this.btnThucHien.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(252, 450);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(122, 42);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "TIẾP TỤC";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(389, 450);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 42);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "IN";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(534, 450);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 42);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "THOÁT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txb
            // 
            this.txb.Location = new System.Drawing.Point(722, 462);
            this.txb.Name = "txb";
            this.txb.Size = new System.Drawing.Size(140, 20);
            this.txb.TabIndex = 7;
            // 
            // FormThongKeSoLuongHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(989, 525);
            this.Controls.Add(this.txb);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongKeSoLuongHang";
            this.Text = "Form11";
            this.Load += new System.EventHandler(this.FormThongKeSoLuongHang_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTon;
        private System.Windows.Forms.RadioButton rdbXuat;
        private System.Windows.Forms.RadioButton rdbNhap;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbYear;
        private System.Windows.Forms.RadioButton rdbMonth;
        private System.Windows.Forms.RadioButton rdbDay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}