using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class VratiSveProizvodjaceSO : OpstaSistemskaOperacija
    {
        public List<Proizvodjac> Proizvodjaci { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Proizvodjaci = broker.VratiSve(objekat).Cast<Proizvodjac>().ToList();
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Proizvodjac))
            {
                throw new ArgumentException();
            }
        }
    }
}
