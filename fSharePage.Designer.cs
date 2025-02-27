namespace GSM
{
    partial class fSharePage
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
            this.txbLinkPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTimePost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCountPost = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSharePage = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Live = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResult = new System.Windows.Forms.Button();
            this.txbLinkShare = new System.Windows.Forms.TextBox();
            this.txbLinkFb = new System.Windows.Forms.TextBox();
            this.txbNameFb = new System.Windows.Forms.TextBox();
            this.txbLive = new System.Windows.Forms.TextBox();
            this.txbFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharePage)).BeginInit();
            this.SuspendLayout();
            // 
            // txbLinkPage
            // 
            this.txbLinkPage.Location = new System.Drawing.Point(252, 39);
            this.txbLinkPage.Name = "txbLinkPage";
            this.txbLinkPage.Size = new System.Drawing.Size(666, 20);
            this.txbLinkPage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(57, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Địa Chỉ Page";
            // 
            // cbTimePost
            // 
            this.cbTimePost.FormattingEnabled = true;
            this.cbTimePost.Items.AddRange(new object[] {
            "Một Ngày",
            "Hai Ngày",
            "Ba Ngày",
            "Bốn Ngày",
            "Năm Ngày",
            "Sáu Ngày",
            "Một Tuần"});
            this.cbTimePost.Location = new System.Drawing.Point(606, 84);
            this.cbTimePost.Name = "cbTimePost";
            this.cbTimePost.Size = new System.Drawing.Size(239, 21);
            this.cbTimePost.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(472, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thời Gian Lấy";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbCountPost);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbTimePost);
            this.panel1.Location = new System.Drawing.Point(44, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 121);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(51, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số Bài Lấy";
            // 
            // cbCountPost
            // 
            this.cbCountPost.FormattingEnabled = true;
            this.cbCountPost.Items.AddRange(new object[] {
            "Một Ngày",
            "Hai Ngày",
            "Ba Ngày",
            "Bốn Ngày",
            "Năm Ngày",
            "Sáu Ngày",
            "Một Tuần"});
            this.cbCountPost.Location = new System.Drawing.Point(185, 81);
            this.cbCountPost.Name = "cbCountPost";
            this.cbCountPost.Size = new System.Drawing.Size(239, 21);
            this.cbCountPost.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(207, 48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(127, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Lấy theo số lượng Bài";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(619, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(148, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Lấy Theo Thời Gian Đăng";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(397, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tiêu Chí Lọc";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dgvSharePage
            // 
            this.dgvSharePage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSharePage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkShare,
            this.linkFb,
            this.NameFb,
            this.Live,
            this.From});
            this.dgvSharePage.Location = new System.Drawing.Point(35, 281);
            this.dgvSharePage.Name = "dgvSharePage";
            this.dgvSharePage.Size = new System.Drawing.Size(897, 252);
            this.dgvSharePage.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // LinkShare
            // 
            this.LinkShare.HeaderText = "Địa Chỉ Share";
            this.LinkShare.Name = "LinkShare";
            this.LinkShare.Width = 150;
            // 
            // linkFb
            // 
            this.linkFb.HeaderText = "Địa Chỉ Fb";
            this.linkFb.Name = "linkFb";
            this.linkFb.Width = 150;
            // 
            // NameFb
            // 
            this.NameFb.HeaderText = "Tên FB";
            this.NameFb.Name = "NameFb";
            this.NameFb.Width = 150;
            // 
            // Live
            // 
            this.Live.HeaderText = "Sống Tại";
            this.Live.Name = "Live";
            this.Live.Width = 150;
            // 
            // From
            // 
            this.From.HeaderText = "Đến Từ";
            this.From.Name = "From";
            this.From.Width = 150;
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.ForeColor = System.Drawing.Color.Magenta;
            this.btnResult.Location = new System.Drawing.Point(955, 129);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(75, 70);
            this.btnResult.TabIndex = 6;
            this.btnResult.Text = "Thống Kê";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // txbLinkShare
            // 
            this.txbLinkShare.Location = new System.Drawing.Point(252, 552);
            this.txbLinkShare.Name = "txbLinkShare";
            this.txbLinkShare.Size = new System.Drawing.Size(666, 20);
            this.txbLinkShare.TabIndex = 7;
            // 
            // txbLinkFb
            // 
            this.txbLinkFb.Location = new System.Drawing.Point(252, 578);
            this.txbLinkFb.Name = "txbLinkFb";
            this.txbLinkFb.Size = new System.Drawing.Size(666, 20);
            this.txbLinkFb.TabIndex = 8;
            // 
            // txbNameFb
            // 
            this.txbNameFb.Location = new System.Drawing.Point(252, 604);
            this.txbNameFb.Name = "txbNameFb";
            this.txbNameFb.Size = new System.Drawing.Size(666, 20);
            this.txbNameFb.TabIndex = 9;
            // 
            // txbLive
            // 
            this.txbLive.Location = new System.Drawing.Point(252, 630);
            this.txbLive.Name = "txbLive";
            this.txbLive.Size = new System.Drawing.Size(666, 20);
            this.txbLive.TabIndex = 10;
            // 
            // txbFrom
            // 
            this.txbFrom.Location = new System.Drawing.Point(252, 656);
            this.txbFrom.Name = "txbFrom";
            this.txbFrom.Size = new System.Drawing.Size(666, 20);
            this.txbFrom.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(71, 553);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Địa Chỉ Share";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(71, 579);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Địa Chỉ FB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(71, 605);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tên FB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(71, 631);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sống Tại";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(71, 659);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Đến Từ";
            // 
            // fSharePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 687);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbFrom);
            this.Controls.Add(this.txbLive);
            this.Controls.Add(this.txbNameFb);
            this.Controls.Add(this.txbLinkFb);
            this.Controls.Add(this.txbLinkShare);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.dgvSharePage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbLinkPage);
            this.Name = "fSharePage";
            this.Text = "fSharePage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharePage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLinkPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTimePost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCountPost;
        private System.Windows.Forms.DataGridView dgvSharePage;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Live;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.TextBox txbLinkShare;
        private System.Windows.Forms.TextBox txbLinkFb;
        private System.Windows.Forms.TextBox txbNameFb;
        private System.Windows.Forms.TextBox txbLive;
        private System.Windows.Forms.TextBox txbFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}