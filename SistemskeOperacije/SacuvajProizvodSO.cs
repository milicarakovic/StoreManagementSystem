using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class SacuvajProizvodSO : OpstaSistemskaOperacija
    {
        public Proizvod Proizvod { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Proizvod p = (Proizvod)objekat;
            broker.Sacuvaj(p);
            Proizvod = p;
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Proizvod))
            {
                throw new ArgumentException();
            }
        }
    }
}
