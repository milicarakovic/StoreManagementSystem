using Domeni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class DodajProizvodUPorudzbinu : Form
    {
        KontrolerKorisnickogInterfejsaKorisnik kki = new KontrolerKorisnickogInterfejsaKorisnik();
        public DodajProizvodUPorudzbinu()
        {
            InitializeComponent();
            kki.SrediFormuStavke(cmbProizvod, lblCena, txtKolicina, lblUkupno);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOdbaci_Click(object sender, EventArgs e)
        {
            kki.OdbaciStavku();
            Close();
        }

        private void cmbProizvod_SelectedIndexChanged(object sender, EventArgs e)
        {
            kki.PromenaCMB(cmbProizvod, lblCena, txtKolicina, lblUkupno);
        }
        
        private void txtKolicina_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtKolicina.Text, out int kol))
            {
                double ukupno = kol * double.Parse(lblCena.Text);
                lblUkupno.Text = ukupno.ToString();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            kki.KreirajStavku(cmbProizvod, lblCena, txtKolicina, lblUkupno);
            
            Close();
        }
    }
}
