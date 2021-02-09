using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme
{
    class Sesija
    {
        private static Sesija instance;

        public static Sesija Instance
        {
            get
            {
                if (instance == null) instance = new Sesija();
                return instance;
            }
        }
        private Sesija() { }
        public Admin Admin { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
