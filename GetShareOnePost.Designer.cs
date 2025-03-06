namespace GSM
{
    partial class GetShareOnePost
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
            this.txbLinkPost = new System.Windows.Forms.TextBox();
            this.btnShearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dentu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongtinkhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txbLinkPost
            // 
            this.txbLinkPost.Location = new System.Drawing.Point(157, 94);
            this.txbLinkPost.Name = "txbLinkPost";
            this.txbLinkPost.Size = new System.Drawing.Size(569, 20);
            this.txbLinkPost.TabIndex = 0;
            // 
            // btnShearch
            // 
            this.btnShearch.Font = new System.Drawing.Font("Stencil Std", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShearch.ForeColor = System.Drawing.Color.Red;
            this.btnShearch.Location = new System.Drawing.Point(810, 84);
            this.btnShearch.Name = "btnShearch";
            this.btnShearch.Size = new System.Drawing.Size(75, 56);
            this.btnShearch.TabIndex = 1;
            this.btnShearch.Text = "Thống Kê";
            this.btnShearch.UseVisualStyleBackColor = true;
            this.btnShearch.Click += new System.EventHandler(this.btnShearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkShare,
            this.LinkFb,
            this.TenFb,
            this.IdFb,
            this.songtai,
            this.dentu,
            this.thongtinkhac});
            this.dataGridView1.Location = new System.Drawing.Point(48, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1136, 379);
            this.dataGridView1.TabIndex = 2;
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
            // LinkFb
            // 
            this.LinkFb.HeaderText = "Địa chỉ Facebook";
            this.LinkFb.Name = "LinkFb";
            this.LinkFb.Width = 150;
            // 
            // TenFb
            // 
            this.TenFb.HeaderText = "Tên FB";
            this.TenFb.Name = "TenFb";
            this.TenFb.Width = 150;
            // 
            // IdFb
            // 
            this.IdFb.HeaderText = "ID FB";
            this.IdFb.Name = "IdFb";
            this.IdFb.Width = 150;
            // 
            // songtai
            // 
            this.songtai.HeaderText = "Sống tại";
            this.songtai.Name = "songtai";
            this.songtai.Width = 150;
            // 
            // dentu
            // 
            this.dentu.HeaderText = "Đến Từ";
            this.dentu.Name = "dentu";
            this.dentu.Width = 150;
            // 
            // thongtinkhac
            // 
            this.thongtinkhac.HeaderText = "Thông tin khác";
            this.thongtinkhac.Name = "thongtinkhac";
            this.thongtinkhac.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Địa Chỉ Bài Viết";
            // 
            // GetShareOnePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnShearch);
            this.Controls.Add(this.txbLinkPost);
            this.Name = "GetShareOnePost";
            this.Text = "GetShareOnePost";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLinkPost;
        private System.Windows.Forms.Button btnShearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn songtai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dentu;
        private System.Windows.Forms.DataGridViewTextBoxColumn thongtinkhac;
        private System.Windows.Forms.Label label1;
    }
}