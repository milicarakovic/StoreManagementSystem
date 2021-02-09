using Domeni;
using Kontroler;
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
    public partial class FrmNoviKorisnik : Form
    {
        public FrmNoviKorisnik()
        {
            InitializeComponent();
        }
        KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();

        private void txtIme_Click(object sender, EventArgs e)
        {
            txtIme.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtIme.ForeColor = Color.FromArgb(78, 184, 206);
            
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrezime_Click(object sender, EventArgs e)
        {
            txtPrezime.Clear();
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtPrezime.ForeColor = Color.FromArgb(78, 184, 206);

        }

        private void txtTelefon_Click(object sender, EventArgs e)
        {
            txtTelefon.Clear();
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            txtTelefon.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            panel4.BackColor = Color.FromArgb(78, 184, 206);
            txtEmail.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtKorIme_Click(object sender, EventArgs e)
        {
            txtKorIme.Clear();
            panel8.BackColor = Color.FromArgb(78, 184, 206);
            txtKorIme.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtLozinka_Click(object sender, EventArgs e)
        {
            txtLozinka.Clear();
            panel7.BackColor = Color.FromArgb(78, 184, 206);
            txtLozinka.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtLozinka2_Click(object sender, EventArgs e)
        {
            txtLozinka2.Clear();
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            txtLozinka2.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '*';
        }

        private void txtLozinka2_TextChanged(object sender, EventArgs e)
        {
            txtLozinka2.PasswordChar = '*';
        }

        private void btnKreirajKorisnika_Click(object sender, EventArgs e)
        {
            kki.KreirajKorisnika(txtIme, txtPrezime, txtKorIme, txtEmail, txtTelefon, txtLozinka, txtLozinka2, panel1, panel2, panel3,panel4, panel5, panel7, panel8);
        }
          

        private void btnOdbaciKorisnika_Click(object sender, EventArgs e)
        {
            kki.OcistiFormu(txtIme, txtPrezime, txtKorIme, txtEmail, txtTelefon, txtLozinka, txtLozinka2, panel1, panel2, panel3, panel4, panel5, panel7, panel8);
         
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
