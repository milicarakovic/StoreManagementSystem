using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domeni;
namespace Forme
{
    public partial class FrmPrijaviSe : Form
    {
        KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();
        public FrmPrijaviSe()
        {
            InitializeComponent();
        }
               

        private void txtKorIme_Click(object sender, EventArgs e)
        {
            txtKorIme.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtKorIme.ForeColor = Color.FromArgb(78, 184, 206);

            panel2.BackColor = Color.WhiteSmoke;
            txtLozinka.ForeColor = Color.WhiteSmoke;
            
        }
        
        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '*';
        }

        private void txtLozinka_Click(object sender, EventArgs e)
        {
            txtLozinka.Clear();
            txtLozinka.PasswordChar = '*';
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtLozinka.ForeColor = Color.FromArgb(78, 184, 206);

            panel1.BackColor = Color.WhiteSmoke;
            txtKorIme.ForeColor = Color.WhiteSmoke;
        }

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            kki.Prijavi(txtKorIme, txtLozinka, cbAdmin);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPrijaviSe_Load(object sender, EventArgs e)
        {

        }
    }
}
