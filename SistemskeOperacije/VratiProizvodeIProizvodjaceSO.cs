using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class VratiProizvodeIProizvodjaceSO : OpstaSistemskaOperacija
    {
        public List<Proizvod> Proizvodi { get; private set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Proizvodi = broker.VratiUzJoin(objekat).Cast<Proizvod>().ToList();
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
