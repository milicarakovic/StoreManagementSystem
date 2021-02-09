using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaAdmina
{
    public class BazaAdmin
    {
        private List<Admin> admini;

        public BazaAdmin()
        {
            admini = new List<Admin>();
            Admin k1 = new Admin()
            {
                KorIme = "milica",
                Lozinka = "milica",
                Email = "milica@gmail.com",
                Ime = "Milica",
                Prezime = "Rakovic",
                Telefon = "+381644225555"
            };

            admini.Add(k1);
        }
        public List<Admin> VratiSveAdmine()
        {
            return admini;
        }
    }
}
