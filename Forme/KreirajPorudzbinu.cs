using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domeni;
using System.Globalization;

namespace Forme
{
    public partial class KreirajPorudzbinu : UserControl
    {
        KontrolerKorisnickogInterfejsaKorisnik kki = new KontrolerKorisnickogInterfejsaKorisnik();

        public KreirajPorudzbinu()
        {
            InitializeComponent();
            kki.SrediFormuPorudzbine( lblDatumPorudzbine,  txtRok,  txtUkupanIznos,  dgvProizvodi,  lblRokPrispeca);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            kki.SacuvajPorudzbinu(lblDatumPorudzbine, txtRok, txtUkupanIznos, dgvProizvodi, lblRokPrispeca);
        }

        
        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            kki.DodajStavkePorudzbine(dgvProizvodi, txtUkupanIznos);         
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            kki.ObrisiStavkuPorudzbine(dgvProizvodi);
        }
    }
}
