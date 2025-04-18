using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Docking2010.Dragging;

namespace GSM.DTO
{
    public class ShearchPost
    {
        private string diaChi;
        private string noiDung;
        private string thoiGian;
        private string chiaSe;
        private string binhLuan;
        private string linkFb;//fb người đăng
        private string tenFb;//tên fb người đăng
        private string linkGoc;//nếu là share lại
        private string thoiGianDangGoc;
        private string linkPage;
        private string namePage; //page được đăng, share;
        private string noidunggoc;
        private string ghiChu;
        private string originalName;
        private string originalLink;
        private int chamdiem;

        public ShearchPost(string diachi, string noidung, string thoigian, string linkfb, string tenfb, string linkgoc, string tggoc, string noidunggoc, string originalname, string originallink, string linkpage, string namepage,string ghichu, string chiase, string binhluan, int chamdiem)
        {
            this.LinkFb = linkfb;
            this.TenFb = tenfb;
            this.LinkGoc = linkgoc;
            this.ThoiGianDangGoc = tggoc;
            this.LinkPage = linkpage;
            this.DiaChi = diachi;
            this.NoiDung = noidung;
            this.ThoiGian = thoigian;
            this.ChiaSe = chiase;
            this.BinhLuan = binhluan;
            this.NamePage = namepage;
            this.GhiChu = ghichu;
            this.Noidunggoc = noidunggoc;
            this.OriginalLink = originallink;
            this.OriginalName = originalname;
            this.Chamdiem = chamdiem;
        }

        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string ThoiGian { get => thoiGian; set => thoiGian = value; }
        
        public string LinkFb { get => linkFb; set => linkFb = value; }
        public string TenFb { get => tenFb; set => tenFb = value; }
        public string LinkGoc { get => linkGoc; set => linkGoc = value; }
        public string ThoiGianDangGoc { get => thoiGianDangGoc; set => thoiGianDangGoc = value; }
        public string NamePage { get => namePage; set => namePage = value; }
        public string LinkPage { get => linkPage; set => linkPage = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string Noidunggoc { get => noidunggoc; set => noidunggoc = value; }
        public string ChiaSe { get => chiaSe; set => chiaSe = value; }
        public string BinhLuan { get => binhLuan; set => binhLuan = value; }
        public string OriginalName { get => originalName; set => originalName = value; }
        public string OriginalLink { get => originalLink; set => originalLink = value; }
        public int Chamdiem { get => chamdiem; set => chamdiem = value; }
    }
}
