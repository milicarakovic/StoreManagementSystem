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
    public partial class FrmNoviProizvod : Form
    {
        private KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();

        public FrmNoviProizvod()
        {
            InitializeComponent();
            kki.SrediFormu(txtNaziv, txtCena, cmbProizvodjac);
        }
        
        //back
        private void label1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //minimizuj
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
         

        private void btnOdbaciProizvod_Click(object sender, EventArgs e)
        {
            kki.SrediFormu(txtNaziv, txtCena, cmbProizvodjac);
        }

        private void btnSacuvajProizvod_Click(object sender, EventArgs e)
        {
            kki.SacuvajProizvod(txtNaziv, txtCena, cmbProizvodjac, panel1, panel2, lblProizvodjac);            
        }

        private void txtNaziv_Click(object sender, EventArgs e)
        {
            txtNaziv.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtNaziv.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtCena_Click(object sender, EventArgs e)
        {
            txtCena.Clear();
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtCena.ForeColor = Color.FromArgb(78, 184, 206);
        }
    }
}
