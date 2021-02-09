using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Admin
    {
        public int IDAdmina { get; set; }
        public string Ime { get; set; }
        public String Prezime { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        public String KorIme { get; set; }
        public String Lozinka { get; set; }
    }
}
