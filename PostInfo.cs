using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class PostInfo
    {
        private string diaChi;
        private string noiDung;
        private string thoiGian;
        private string chiaSe;
        private string binhLuan;
        private string userName;
        private string userLink;
        private string pageName;

        public PostInfo(string diachi, string noidung, string thoigian, string chiase, string binhluan, string username, string userlink, string pagename)
        { 
                this.DiaChi = diachi;
                this.NoiDung = noidung;
                this.ThoiGian = thoigian;
                this.ChiaSe = chiase;
                this.BinhLuan = binhluan;
                this.UserName = username;
                this.UserLink = userlink;
                this.PageName = pagename;
         }
        public PostInfo() { }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string ChiaSe { get => chiaSe; set => chiaSe = value; }
        public string BinhLuan { get => binhLuan; set => binhLuan = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserLink { get => userLink; set => userLink = value; }
        public string PageName { get => pageName; set => pageName = value; }
    }
}
