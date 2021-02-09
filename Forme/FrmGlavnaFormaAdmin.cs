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
    public partial class FrmGlavnaFormaAdmin : Form
    {
        public FrmGlavnaFormaAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void kreirajNovogKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNoviKorisnik frmNoviKorisnik = new FrmNoviKorisnik();
            frmNoviKorisnik.ShowDialog();
        }

        private void kreirajProzivodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNoviProizvod forma = new FrmNoviProizvod();
            forma.ShowDialog();
        }

        private void obrisiProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObrisiProizvod forma = new FrmObrisiProizvod();
            forma.ShowDialog();
        }

        private void izmeniProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzmeniProizvod forma = new FrmIzmeniProizvod();
            forma.ShowDialog();
        }
    }
}
