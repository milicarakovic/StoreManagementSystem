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
    public partial class FrmIzmeniProizvod : Form
    {
        KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();
        
        public FrmIzmeniProizvod()
        {
            InitializeComponent();
            cmbProizvodjac.DataSource = kki.VratiProizvodjace();
            PrikaziSve();
        }

        private void PrikaziSve()
        {
            kki.PrikaziSveProizvode(dgvProizvodi);
        }

        private void txtNaziv_Click(object sender, EventArgs e)
        {
            txtNaziv.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtNaziv.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtCena_Click(object sender, EventArgs e)
        {
            txtCena.Clear();
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtCena.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void btnIzmeniProizvod_Click(object sender, EventArgs e)
        {
            kki.IzmeniProizvod(txtNaziv, txtCena, cmbProizvodjac, dgvProizvodi);
        }

        private void dgvProizvodi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
