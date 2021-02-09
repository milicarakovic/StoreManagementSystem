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
    public partial class FrmGlavnaFormaKorisnik : Form
    {
        BindingList<Proizvod> odabraniProizvodi = new BindingList<Proizvod>();

        public FrmGlavnaFormaKorisnik()
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

        public static Korisnik k = Sesija.Instance.Korisnik;

        private void FrmGlavnaFormaKorisnik_Load(object sender, EventArgs e)
        {
            prikazProfila1.Visible = true;
            pretragaFrm.Visible = false;
            kreirajPorudzbinu1.Visible = false;
            
        }        

        private void btnPretragaProizvoda_Click(object sender, EventArgs e)
        {
            prikazProfila1.Visible = false;
            pretragaFrm.Visible = true;
            kreirajPorudzbinu1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prikazProfila1.Visible = false;
            pretragaFrm.Visible = false;
            kreirajPorudzbinu1.Visible = true;
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            prikazProfila1.Visible = true;
            pretragaFrm.Visible = false;
            kreirajPorudzbinu1.Visible = false;
        }
    }
}
