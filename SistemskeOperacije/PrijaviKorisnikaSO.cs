using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class PrijaviKorisnikaSO : OpstaSistemskaOperacija
    {
        public List<Korisnik> Korisnici { get; private set; }


        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Korisnici = broker.VratiSve(objekat).Cast<Korisnik>().ToList();
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
