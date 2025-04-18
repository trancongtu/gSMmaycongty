using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSM
{
    public partial class FDetailShearchPost : Form
    {
        public FDetailShearchPost()
        {
            InitializeComponent();

        }
        public void SetData(
       string linkPost, string shareCount, string commentCount, string timePost,
       string posterName, string posterLink, string pageName, string pageLink,
       string originalContent, string content, string originalPostLink, string originalTime, string originalName, string originalLink, string statuspost)
        {
            // Gán dữ liệu vào các control trong form
            rTbLinkPost.Text = linkPost;
            rTbShare.Text = shareCount;
            rTbComment.Text = commentCount;     
            rTbContent.Text = content;
            rTbUserName.Text = posterName;
           rTbUserLink.Text = posterLink;
            rTbTimePost.Text = timePost;
            rTbPageName.Text = pageName;
            rTbPageLink.Text = pageLink;
           rTbOriginalContent.Text = originalContent;           
           rTbOriginalLink.Text = originalPostLink;
           rTbOriginalTime.Text = originalTime;
            rTbOriginalPosterLink.Text = originalLink;
            rTbOriginalName.Text = originalName;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
