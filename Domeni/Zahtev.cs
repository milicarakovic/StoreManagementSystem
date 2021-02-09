using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
    }
    public enum Operacija
    {
        Prijava,
        SacuvajNoviProizvod,
        SacuvajNovogKorisnika,
        PrikaziProizvode,
        ObrisiProizvod,
        SacuvajPorudzbinu,
        PrikaziSveProizvodeJoin
    }
}
