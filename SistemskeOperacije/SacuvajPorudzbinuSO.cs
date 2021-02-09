using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOperacije
{
    public class SacuvajPorudzbinuSO : OpstaSistemskaOperacija
    {
        public Porudzbina Porudzbina { get; private set; }

        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            Porudzbina porudzbina = (Porudzbina)objekat;
            broker.Sacuvaj(porudzbina);
            Porudzbina = porudzbina;
            foreach (StavkaPorudzbine sp in porudzbina.StavkePorudzbine)
            {
                sp.SifraPorudzbine = broker.VratiID(porudzbina);
                broker.Sacuvaj(sp);
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            if (!(objekat is Porudzbina))
            {
                throw new ArgumentException();
            }
        }
    }
}
