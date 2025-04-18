using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.DTO
{
    public class PersonShare
    {
        private string diachiShare;
        private string linkFb;
        private string idFb;
        public PersonShare(string diachiShare, string linkFb, string idfb)
        {
            this.DiachiShare = diachiShare;
            this.LinkFb = linkFb;
            this.IdFb = idfb;
        }
        public string DiachiShare { get => diachiShare; set => diachiShare = value; }
        public string LinkFb { get => linkFb; set => linkFb = value; }
        public string IdFb { get => idFb; set => idFb = value; }
    }
}
