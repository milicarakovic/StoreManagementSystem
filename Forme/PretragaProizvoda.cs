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

namespace Forme
{
    public partial class PretragaProizvoda : UserControl
    {
        
        KontrolerKorisnickogInterfejsaKorisnik kki = new KontrolerKorisnickogInterfejsaKorisnik();

        public PretragaProizvoda()
        {
            InitializeComponent();
            kki.PrikaziSveProizvode(dgvProizvodi);
        }


        private void txtIme_Click(object sender, EventArgs e)
        {
            txtNaziv.Clear();            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            kki.PrikaziProizvode(txtNaziv, dgvProizvodi);
        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            kki.PrikaziSveProizvode(dgvProizvodi);
        }
        
    }
}
