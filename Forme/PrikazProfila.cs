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
    public partial class PrikazProfila : UserControl
    {
        KontrolerKorisnickogInterfejsaKorisnik kki = new KontrolerKorisnickogInterfejsaKorisnik();

        public PrikazProfila()
        {
            InitializeComponent();
            kki.SrediKorisnika(lblIme, lblPrezime, lblEmail, lblKorIme, lblTel);
        }
        public PrikazProfila(Korisnik k)
        {
            InitializeComponent();
            kki.SrediKorisnika(lblIme, lblPrezime, lblEmail, lblKorIme, lblTel);
        }



    }
}
