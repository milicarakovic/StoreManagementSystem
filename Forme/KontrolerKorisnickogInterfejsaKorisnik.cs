using Domeni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public class KontrolerKorisnickogInterfejsaKorisnik
    {
        public KontrolerKorisnickogInterfejsaKorisnik()
        {

        }

        //KreirajPorudzbinu

        BindingList<StavkaPorudzbine> listaStavkiBinding = new BindingList<StavkaPorudzbine>();
        double ukIznos = 0;

        internal void SacuvajPorudzbinu(Label lblDatumPorudzbine, TextBox txtRok, TextBox txtUkupanIznos, DataGridView dgvProizvodi, Label lblRokPrispeca)
        {
            Porudzbina porudzbina = ValidacijaPorudzbine(lblDatumPorudzbine, txtRok, txtUkupanIznos, dgvProizvodi, lblRokPrispeca);
            if (porudzbina != null)
            {
                if (Komunikacija.Instance.SacuvajPorudzbinu(porudzbina) != null)
                {
                    MessageBox.Show("Porudzbina je sacuvana!");
                    listaStavkiBinding.Clear();
                    SrediFormuPorudzbine(lblDatumPorudzbine, txtRok, txtUkupanIznos, dgvProizvodi ,lblRokPrispeca);
                }
                else
                {
                    MessageBox.Show("Porudzbina nije sacuvana!");
                }
            }
        }

        internal void ObrisiStavkuPorudzbine(DataGridView dgvProizvodi)
        {
            if (dgvProizvodi.SelectedRows.Count > 0)
            {
                Console.WriteLine(">>>" + dgvProizvodi.SelectedRows[0].DataBoundItem);

                int idProizvoda = (int)dgvProizvodi.SelectedRows[0].Cells[0].Value;
                foreach (StavkaPorudzbine sp in listaStavkiBinding)
                {
                    if (sp.RedniBroj == idProizvoda)
                    {
                        listaStavkiBinding.Remove(sp);
                        break;
                    }
                }

                var broj = 1;
                listaStavkiBinding.ToList().ForEach(st => st.RedniBroj = broj++);
                srediDgvStavke(dgvProizvodi);
                dgvProizvodi.DataSource = listaStavkiBinding.Select(x => new { x.RedniBroj, x.Proizvod.Naziv, x.Cena, x.Kolicina, x.IznosStavke }).ToList(); ;
            }
        }

        internal void DodajStavkePorudzbine(DataGridView dgvProizvodi, TextBox txtUkupanIznos)
        {
            DodajProizvodUPorudzbinu forma1 = new DodajProizvodUPorudzbinu();
            forma1.ShowDialog();
            //StavkaPorudzbine stavka = Stavka;
            if (uspesno)
            {
                if (stavka != null)
                {
                    int brojac = 0;
                    foreach (StavkaPorudzbine sp in listaStavkiBinding)
                    {
                        if (sp.Proizvod.Naziv == stavka.Proizvod.Naziv)
                        {
                            sp.Kolicina += stavka.Kolicina;
                            sp.IznosStavke += stavka.IznosStavke;
                            brojac++;
                        }
                    }
                    if (brojac == 0)
                    {
                        stavka.RedniBroj = listaStavkiBinding.Count() + 1;
                        listaStavkiBinding.Add(stavka);
                    }
                    dgvProizvodi.DataSource = listaStavkiBinding.Select(x => new { x.RedniBroj, x.Proizvod.Naziv, x.Cena, x.Kolicina, x.IznosStavke }).ToList();
                    srediDgvStavke(dgvProizvodi);
                    ukIznos += stavka.IznosStavke;
                    txtUkupanIznos.Text = ukIznos.ToString();

                }
            }
        }

        private Porudzbina ValidacijaPorudzbine(Label lblDatumPorudzbine, TextBox txtRok, TextBox txtUkupanIznos, DataGridView dgvProizvodi, Label lblRokPrispeca)
        {
            Porudzbina porudzbina = new Porudzbina();
            bool dobro = true;

            porudzbina.DatumPorudzbine = DateTime.Now;

            if (int.TryParse(txtRok.Text, out int brDana))
            {
                porudzbina.RokPrispeca = porudzbina.DatumPorudzbine.AddDays(brDana);
            }
            else
            {
                dobro = false;
                MessageBox.Show("Unesite ponovo broj dana.");
                lblRokPrispeca.ForeColor = Color.FromArgb(250, 62, 62);
            }

            if (double.TryParse(txtUkupanIznos.Text, out double ukupno))
                porudzbina.UkupanIznos = ukupno;
            else
            {
                dobro = false;
                MessageBox.Show("Greska prilikom upisa ukupnog iznosa.");
                txtUkupanIznos.ForeColor = Color.FromArgb(250, 62, 62);
            }

            Korisnik k = FrmGlavnaFormaKorisnik.k;
            porudzbina.Korisnik1 = k;
            try
            {
                porudzbina.StavkePorudzbine = listaStavkiBinding.ToList();
            }
            catch (Exception)
            {

                dobro = false;
                MessageBox.Show("Greska sa listom stavki.");
            }

            if (!dobro) return null;
            return porudzbina;
        }

        internal void SrediFormuPorudzbine(Label lblDatumPorudzbine, TextBox txtRok, TextBox txtUkupanIznos, DataGridView dgvProizvodi, Label lblRokPrispeca)
        {
            lblDatumPorudzbine.Text = DateTime.Now.ToShortDateString();
            lblRokPrispeca.ForeColor = Color.FromArgb(192, 255, 255);
            txtRok.Clear();
            txtUkupanIznos.Clear();
            dgvProizvodi.DataSource = listaStavkiBinding.Select(x => new { x.RedniBroj, x.Proizvod.Naziv, x.Cena, x.Kolicina, x.IznosStavke }).ToList();
            srediDgvStavke(dgvProizvodi);
        }

        private void srediDgvStavke(DataGridView dgvProizvodi)
        {
            dgvProizvodi.Columns[0].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[1].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[2].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[3].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[4].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);

        }

        private void srediDgvKorisnika(DataGridView dgvProizvodi)
        {
            dgvProizvodi.Columns[0].Visible = false;
            dgvProizvodi.Columns[1].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[2].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[3].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[0].HeaderText = "ID Proizvoda";
            dgvProizvodi.Columns[3].HeaderText = "Proizvodjac";
        }

        //Dodaj stavku
        public static StavkaPorudzbine stavka;
        public static bool uspesno = true;

        internal void SrediFormuStavke(ComboBox cmbProizvod, Label lblCena, TextBox txtKolicina, Label lblUkupno)
        {

            cmbProizvod.DataSource = Kontroler.Kontroler.Instance.VratiProizvodeJoin();
            Proizvod p = (Proizvod)cmbProizvod.SelectedItem;
            lblCena.Text = p.Cena.ToString();

            double ukupno = 0;
            if (string.IsNullOrEmpty(txtKolicina.Text))
            {
                ukupno = p.Cena;
            }
            else
            {
                if (int.TryParse(txtKolicina.Text, out int kol))
                {
                    ukupno = p.Cena * kol;
                }

            }
            lblUkupno.Text = ukupno.ToString();
            
        }

        private bool Provera(TextBox txtKolicina)
        {
            if (string.IsNullOrEmpty(txtKolicina.Text))
            {
                return false;
            }
            return true;
        }

        internal void KreirajStavku(ComboBox cmbProizvod, Label lblCena, TextBox txtKolicina, Label lblUkupno)
        {
            stavka = new StavkaPorudzbine();
            
            if (Provera(txtKolicina))
            {
                if (Int32.TryParse(txtKolicina.Text, out int kol))
                {
                    stavka.Kolicina = kol;
                    stavka.Cena = Double.Parse(lblCena.Text.ToString());
                    stavka.IznosStavke = Double.Parse(lblUkupno.Text.ToString());
                    if (cmbProizvod.SelectedItem is Proizvod)
                    {
                        stavka.Proizvod = (Proizvod)cmbProizvod.SelectedItem;                        
                    }
                    else
                    {
                        MessageBox.Show("Morate odabrati postojeci proizvod!");
                        uspesno = false;
                    }            
                }
                else
                {
                    MessageBox.Show("Unesite ponovo zeljenu kolicinu.");
                    uspesno = false;
                }
            }
            else
            {
                MessageBox.Show("Morate uneti sva polja!");
                uspesno = false;
            }

            if (uspesno) listaStavkiBinding.Add(stavka);
        }

        internal void OdbaciStavku()
        {
            stavka = null;
        }
        
        internal void PromenaCMB(ComboBox cmbProizvod, Label lblCena, TextBox txtKolicina, Label lblUkupno)
        {
            Proizvod p = (Proizvod)cmbProizvod.SelectedItem;
            lblCena.Text = p.Cena.ToString();

            double ukupno = 0;
            if (string.IsNullOrEmpty(txtKolicina.Text))
            {
                ukupno = p.Cena;
            }
            else
            {
                if (int.TryParse(txtKolicina.Text, out int kol))
                {
                    ukupno = p.Cena * kol;
                }
            }
            lblUkupno.Text = ukupno.ToString();
        }
       
        
        //Pretraga proizvoda
        BindingList<Proizvod> listaProizvodaBinding = new BindingList<Proizvod>();

        internal void PrikaziSveProizvode(DataGridView dgvProizvodi)
        {
            List<Proizvod> listaProizvoda = Komunikacija.Instance.PrikaziSveProizvode();
            if (listaProizvoda != null)
            {
                //listaProizvodaBinding = new BindingList<Proizvod>(listaProizvoda);

                //dgvProizvodi.DataSource = listaProizvodaBinding.Select(x => new { x.IdPRozivoda, x.Naziv, x.Cena, x.Proizvodjac.NazivProizvodjaca }).ToList();
                dgvProizvodi.DataSource = listaProizvoda;
                srediDgvKorisnika(dgvProizvodi);
            }
            else MessageBox.Show("Nije pronadjen nijedan proizvod.");
        }

        internal void PrikaziProizvode(TextBox txtNaziv, DataGridView dgvProizvodi)
        {
            string deoNaziva = txtNaziv.Text;
            List<Proizvod> listaProizvoda = Komunikacija.Instance.PrikaziProizvode(deoNaziva);
            if (listaProizvoda.Count != 0)
            {
                dgvProizvodi.DataSource = listaProizvoda;
                srediDgvKorisnika(dgvProizvodi);
            }
            else
            {
                MessageBox.Show("Nije pronadjen nijedan proizvod sa ovim nazivom.");
                PrikaziSveProizvode(dgvProizvodi);
            }
        }


        //Prikaz korisnika
        internal void SrediKorisnika(Label lblIme, Label lblPrezime, Label lblEmail, Label lblKorIme, Label lblTel)
        {
            lblIme.Text = Sesija.Instance.Korisnik.Ime;
            lblPrezime.Text = Sesija.Instance.Korisnik.Prezime;
            lblTel.Text = Sesija.Instance.Korisnik.Telefon;
            lblEmail.Text = Sesija.Instance.Korisnik.Email;
            lblKorIme.Text = Sesija.Instance.Korisnik.KorIme;

        }
    }
}
