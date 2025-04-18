namespace GSM
{
    partial class FShearchPost
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShreach = new System.Windows.Forms.Button();
            this.btnOpenKeywords = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbcontent = new System.Windows.Forms.TextBox();
            this.lblinkbv = new System.Windows.Forms.Label();
            this.txblinkbv = new System.Windows.Forms.TextBox();
            this.CbLocNoidung = new System.Windows.Forms.CheckBox();
            this.btnKeywordfilter = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkpost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgdang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chamdiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.linkpost,
            this.noidung,
            this.tgdang,
            this.comment,
            this.share,
            this.ghichu,
            this.chamdiem});
            this.dataGridView1.Location = new System.Drawing.Point(22, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1194, 404);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnShreach
            // 
            this.btnShreach.Location = new System.Drawing.Point(1088, 22);
            this.btnShreach.Name = "btnShreach";
            this.btnShreach.Size = new System.Drawing.Size(73, 57);
            this.btnShreach.TabIndex = 1;
            this.btnShreach.Text = "Tìm Kiếm";
            this.btnShreach.UseVisualStyleBackColor = true;
            this.btnShreach.Click += new System.EventHandler(this.btnShreach_Click);
            // 
            // btnOpenKeywords
            // 
            this.btnOpenKeywords.Location = new System.Drawing.Point(814, 22);
            this.btnOpenKeywords.Name = "btnOpenKeywords";
            this.btnOpenKeywords.Size = new System.Drawing.Size(73, 57);
            this.btnOpenKeywords.TabIndex = 2;
            this.btnOpenKeywords.Text = "Mở Keyword";
            this.btnOpenKeywords.UseVisualStyleBackColor = true;
            this.btnOpenKeywords.Click += new System.EventHandler(this.btnOpenKeywords_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(37, 43);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Chờ hành động";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Full Nội Dung";
            // 
            // txbcontent
            // 
            this.txbcontent.Location = new System.Drawing.Point(86, 562);
            this.txbcontent.Multiline = true;
            this.txbcontent.Name = "txbcontent";
            this.txbcontent.Size = new System.Drawing.Size(1119, 73);
            this.txbcontent.TabIndex = 5;
            // 
            // lblinkbv
            // 
            this.lblinkbv.AutoSize = true;
            this.lblinkbv.Location = new System.Drawing.Point(12, 529);
            this.lblinkbv.Name = "lblinkbv";
            this.lblinkbv.Size = new System.Drawing.Size(41, 13);
            this.lblinkbv.TabIndex = 6;
            this.lblinkbv.Text = "Địa Chỉ";
            // 
            // txblinkbv
            // 
            this.txblinkbv.Location = new System.Drawing.Point(57, 523);
            this.txblinkbv.Multiline = true;
            this.txblinkbv.Name = "txblinkbv";
            this.txblinkbv.Size = new System.Drawing.Size(1148, 19);
            this.txblinkbv.TabIndex = 7;
            // 
            // CbLocNoidung
            // 
            this.CbLocNoidung.AutoSize = true;
            this.CbLocNoidung.Location = new System.Drawing.Point(386, 44);
            this.CbLocNoidung.Name = "CbLocNoidung";
            this.CbLocNoidung.Size = new System.Drawing.Size(115, 17);
            this.CbLocNoidung.TabIndex = 8;
            this.CbLocNoidung.Text = "Lọc nội dung trước";
            this.CbLocNoidung.UseVisualStyleBackColor = true;
            this.CbLocNoidung.CheckedChanged += new System.EventHandler(this.CbLocNoidung_CheckedChanged);
            // 
            // btnKeywordfilter
            // 
            this.btnKeywordfilter.Location = new System.Drawing.Point(532, 23);
            this.btnKeywordfilter.Name = "btnKeywordfilter";
            this.btnKeywordfilter.Size = new System.Drawing.Size(73, 57);
            this.btnKeywordfilter.TabIndex = 9;
            this.btnKeywordfilter.Text = "Mở Nội dung lọc";
            this.btnKeywordfilter.UseVisualStyleBackColor = true;
            this.btnKeywordfilter.Click += new System.EventHandler(this.btnKeywordfilter_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // linkpost
            // 
            this.linkpost.HeaderText = "Địa Chỉ Bài Viết";
            this.linkpost.Name = "linkpost";
            this.linkpost.Width = 200;
            // 
            // noidung
            // 
            this.noidung.HeaderText = "Nội Dung";
            this.noidung.Name = "noidung";
            this.noidung.Width = 300;
            // 
            // tgdang
            // 
            this.tgdang.HeaderText = "thời gian đăng";
            this.tgdang.Name = "tgdang";
            // 
            // comment
            // 
            this.comment.HeaderText = "Bình Luận";
            this.comment.Name = "comment";
            this.comment.Width = 50;
            // 
            // share
            // 
            this.share.HeaderText = "Chia sẻ";
            this.share.Name = "share";
            this.share.Width = 50;
            // 
            // ghichu
            // 
            this.ghichu.HeaderText = "Ghi Chú";
            this.ghichu.Name = "ghichu";
            this.ghichu.Width = 150;
            // 
            // chamdiem
            // 
            this.chamdiem.HeaderText = "Chấm điểm";
            this.chamdiem.Name = "chamdiem";
            // 
            // FShearchPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 647);
            this.Controls.Add(this.btnKeywordfilter);
            this.Controls.Add(this.CbLocNoidung);
            this.Controls.Add(this.txblinkbv);
            this.Controls.Add(this.lblinkbv);
            this.Controls.Add(this.txbcontent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpenKeywords);
            this.Controls.Add(this.btnShreach);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FShearchPost";
            this.Text = "FShearchPost";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShreach;
        private System.Windows.Forms.Button btnOpenKeywords;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbcontent;
        private System.Windows.Forms.Label lblinkbv;
        private System.Windows.Forms.TextBox txblinkbv;
        private System.Windows.Forms.CheckBox CbLocNoidung;
        private System.Windows.Forms.Button btnKeywordfilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkpost;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidung;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgdang;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn share;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
        private System.Windows.Forms.DataGridViewTextBoxColumn chamdiem;
    }
}