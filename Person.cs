using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class Person
    {
        private int id;
        private string linkFb;
        private string tenFb;
        private string noiSong;
        private string denTu;
        private string hocVan;
        private string idFb;

        public Person(int id, string linkfb, string tenfb, string dentu, string noisong, string hocvan, string idfb)
        {
            this.Id = id;
            this.LinkFb = linkfb;
            this.TenFb = tenfb;
            this.DenTu = dentu;
            this.NoiSong = noisong;
            this.HocVan = hocvan;
            this.IdFb = idfb;
        }
        public Person(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.TenFb = (string)row["TenFb"];
            this.LinkFb = (string)row["LinkFb"];
            this.NoiSong = (string)row["NoiSong"];
            this.DenTu = (string)row["DenTu"];
            this.HocVan = (string)row["HocVan"];
            this.IdFb = (string)row["IdFb"];
        }
        public Person() { }
        public string LinkFb { get => linkFb; set => linkFb = value; }             
        public string IdFb { get => idFb; set => idFb = value; }
        public int Id { get => id; set => id = value; }
        public string TenFb { get => tenFb; set => tenFb = value; }
        public string NoiSong { get => noiSong; set => noiSong = value; }
        public string DenTu { get => denTu; set => denTu = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
    }
}
