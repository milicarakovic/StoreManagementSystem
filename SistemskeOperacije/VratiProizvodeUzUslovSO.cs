using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class VratiProizvodeUzUslovSO : OpstaSistemskaOperacija
    {
        public List<Proizvod> Proizvodi { get; private set; }
        public string Uslov { get; set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Proizvodi = broker.VratiUzUslov(Uslov, objekat).Cast<Proizvod>().ToList();
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
