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
    public partial class FrmObrisiProizvod : Form
    {
        KontrolerKorisnickogInterfejsa kki = new KontrolerKorisnickogInterfejsa();

        public FrmObrisiProizvod()
        {
            InitializeComponent();
            kki.PrikaziSveProizvode(dgvProizvodi);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kki.ObrisiProizvod(dgvProizvodi, txtNaziv);            
        }

        private void txtNaziv_Click(object sender, EventArgs e)
        {
            txtNaziv.Clear();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            kki.PrikaziProizvode(dgvProizvodi, txtNaziv);
        }
        
        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            kki.PrikaziSveProizvode(dgvProizvodi);
        }

        
    }
}
