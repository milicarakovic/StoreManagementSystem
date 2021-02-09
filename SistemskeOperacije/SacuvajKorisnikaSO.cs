using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class SacuvajKorisnikaSO : OpstaSistemskaOperacija
    {
        public Korisnik Korisnik { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Korisnik k = (Korisnik)objekat;
            broker.Sacuvaj(k);
            Korisnik = k;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Korisnik))
            {
                throw new ArgumentException();
            }
        }
    }
}
