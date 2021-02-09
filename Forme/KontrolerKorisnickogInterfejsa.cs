using Domeni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public class KontrolerKorisnickogInterfejsa
    {
        public KontrolerKorisnickogInterfejsa()
        {

        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            if(password.Length <6)
            {
                MessageBox.Show("Lozinka mora imati najmanje 6 karaktera!");
                return false;
            }
            if (password.All(Char.IsLetter))
            {
                MessageBox.Show("Lozinka mora sadrzati cifru!");
                return false;
            }
            if (password.All(Char.IsLower))
            {
                MessageBox.Show("Lozinka mora sadrzati veliko slovo!");
                return false;
            }
            return true;
        }

        //FrmNoviProizvod
        internal void SacuvajProizvod(TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac, Panel panel1, Panel panel2, Label lblProizvodjac)
        {
            if (!ProveraUnosaProizvoda(txtNaziv, txtCena, cmbProizvodjac, panel1, panel2, lblProizvodjac)) return;

            Proizvod p = new Proizvod();
            p.Naziv = txtNaziv.Text;
            p.Cena = double.Parse(txtCena.Text);
            p.Proizvodjac = (Proizvodjac)cmbProizvodjac.SelectedItem;

            Proizvod sacuvanProizvod = Komunikacija.Instance.SacuvajProizvod(p);
            if (sacuvanProizvod != null)
            {
                MessageBox.Show("Proizvod je uspesno sacuvan!");
                SrediFormu(txtNaziv, txtCena, cmbProizvodjac);
            }
            else
            {
                MessageBox.Show("Proizvod nije sacuvan!");
            }
        }

        bool ProveraUnosaProizvoda(TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac, Panel panel1, Panel panel2, Label lblProizvodjac)
        {
            bool ispravno = true;
            if (string.IsNullOrEmpty(txtNaziv.Text) || txtNaziv.Text == "Naziv")
            {
                panel1.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (!double.TryParse(txtCena.Text, out double _))
            {
                panel2.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (cmbProizvodjac.SelectedItem == null)
            {
                lblProizvodjac.ForeColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            return ispravno;
        }

        internal void Prijavi(TextBox txtKorIme, TextBox txtLozinka, CheckBox cbAdmin)
        {
            bool jesteAdmin = cbAdmin.Checked;

            if (Komunikacija.Instance.PoveziSe())
            {
                string korIme = txtKorIme.Text;
                string loz = txtLozinka.Text;
               
                if (jesteAdmin)
                {
                    Admin a = Komunikacija.Instance.PrijaviSe(korIme, loz);
                    if (a != null)
                    {
                        MessageBox.Show("Uspesno ste se prijavili.");
                        Sesija.Instance.Admin = a;
                        FrmGlavnaFormaAdmin forma = new FrmGlavnaFormaAdmin();
                        forma.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Pogresno uneti parametri za administratora.");
                    }
                }
                else
                {
                    Korisnik k = Komunikacija.Instance.PrijaviKorisnika(korIme, loz);
                    if (k != null)
                    {
                        Sesija.Instance.Korisnik = k;
                        FrmGlavnaFormaKorisnik forma = new FrmGlavnaFormaKorisnik();
                        forma.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Pogresno korisnicko ime ili lozinka.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nije moguce povezati se sa serverom.");
            }

        }

        public void SrediFormu(TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac)
        {
            cmbProizvodjac.DataSource = Kontroler.Kontroler.Instance.VratiProizvodjace();
            txtNaziv.Text = "Naziv";
            txtCena.Text = "Cena [RSD]";
        }

        //FrmNoviKorisnik


        private bool ProveraKorisnika(TextBox txtIme, TextBox txtPrezime, TextBox txtKorIme, TextBox txtEmail, TextBox txtTelefon, TextBox txtLozinka, TextBox txtLozinka2, Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel panel5, Panel panel7, Panel panel8)
        {
            bool ispravno = true;

            //podaci o korisniku
            if (string.IsNullOrEmpty(txtIme.Text) || txtIme.Text == "Ime")
            {
                panel1.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (string.IsNullOrEmpty(txtPrezime.Text) || txtPrezime.Text == "Prezime")
            {
                panel2.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (string.IsNullOrEmpty(txtTelefon.Text) || txtTelefon.Text == "Telefon")
            {
                panel3.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || !IsValid(txtEmail.Text))
            {
                panel4.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            //podaci o nalogu
            if (string.IsNullOrEmpty(txtKorIme.Text) || txtKorIme.Text == "Korisnicko ime")
            {
                panel8.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (string.IsNullOrEmpty(txtLozinka.Text) || txtLozinka.Text == "Lozinka" || !IsValidPassword(txtLozinka.Text))
            {
                panel7.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
            }
            if (string.IsNullOrEmpty(txtLozinka2.Text) || txtLozinka.Text != txtLozinka2.Text)
            {
                panel5.BackColor = Color.FromArgb(250, 62, 62);
                ispravno = false;
                MessageBox.Show("Unesene lozinke se ne podudaraju!");
            }
            return ispravno;
        }

        internal void KreirajKorisnika(TextBox txtIme, TextBox txtPrezime, TextBox txtKorIme, TextBox txtEmail, TextBox txtTelefon, TextBox txtLozinka, TextBox txtLozinka2, Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel panel5, Panel panel7, Panel panel8)
        {
            try
            {
                if (!ProveraKorisnika(txtIme, txtPrezime, txtKorIme, txtEmail, txtTelefon, txtLozinka, txtLozinka2, panel1, panel2, panel3, panel4, panel5, panel7, panel8)) return;
                Korisnik korisnik = new Korisnik();
                korisnik.Ime = txtIme.Text;
                korisnik.Prezime = txtPrezime.Text;
                korisnik.Email = txtEmail.Text;
                korisnik.KorIme = txtKorIme.Text;
                korisnik.Lozinka = txtLozinka.Text;
                korisnik.Telefon = txtTelefon.Text;

                Korisnik sacuvaniKorisnik = Komunikacija.Instance.SacuvajKorisnika(korisnik);
                if (sacuvaniKorisnik != null)
                {
                    MessageBox.Show($"Korisnik: {korisnik.KorIme} je uspesno sacuvan.");
                    OcistiFormu(txtIme, txtPrezime, txtKorIme, txtEmail, txtTelefon, txtLozinka, txtLozinka2, panel1, panel2, panel3, panel4, panel5, panel7, panel8);
                }
                else
                {
                    MessageBox.Show("Nije moguce sacuvati korisnika.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Greska! Pogresan unos!");
            }
        }

        public void OcistiFormu(TextBox txtIme, TextBox txtPrezime, TextBox txtKorIme, TextBox txtEmail, TextBox txtTelefon, TextBox txtLozinka, TextBox txtLozinka2, Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel panel5, Panel panel7, Panel panel8)
        {
            txtIme.Text = "Ime";
            txtPrezime.Text = "Prezime";
            txtEmail.Text = "E-mail";
            txtKorIme.Text = "Korisnicko ime";
            txtLozinka.Text = "Lozinka";
            txtLozinka2.Text = "Lozinka";
            txtTelefon.Text = "Telefon";
        }


        //FrmIzmeniProizvod

        BindingList<Proizvod> listaProizvodaBinding = new BindingList<Proizvod>();

        internal void PrikaziSveProizvode(DataGridView dgvProizvodi)
        {
            List<Proizvod> listaProizvoda = Komunikacija.Instance.PrikaziSveProizvode();
            if (listaProizvoda != null)
            {
                listaProizvodaBinding = new BindingList<Proizvod>(listaProizvoda);

                //dgvProizvodi.DataSource = listaProizvodaBinding.Select(x => new { x.IdPRozivoda, x.Naziv, x.Cena, x.Proizvodjac.NazivProizvodjaca }).ToList();
                dgvProizvodi.DataSource = listaProizvoda;
                srediDgv(dgvProizvodi);
            }
            else MessageBox.Show("Nije pronadjen nijedan proizvod.");
        }

        private void srediDgv(DataGridView dgvProizvodi)
        {
            dgvProizvodi.Columns[0].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[1].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[2].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[3].DefaultCellStyle.ForeColor = Color.FromArgb(34, 36, 49);
            dgvProizvodi.Columns[0].HeaderText = "ID Proizvoda";
            dgvProizvodi.Columns[3].HeaderText = "Proizvodjac";

        }

        internal void IzmeniProizvod(TextBox txtNaziv, TextBox txtCena, ComboBox cmbProizvodjac, DataGridView dgvProizvodi)
        {
            string noviNaziv = null;
            double novaCena = -1;
            int indeks = dgvProizvodi.CurrentCell.RowIndex;
            Proizvodjac proizvodjac = (Proizvodjac)cmbProizvodjac.SelectedItem;

            if (!string.IsNullOrEmpty(txtNaziv.Text) && txtNaziv.Text != "Naziv proizvoda")
            {
                noviNaziv = txtNaziv.Text;
            }
            else
            {
                noviNaziv = dgvProizvodi.Rows[indeks].Cells[1].Value.ToString();
            }

            if (!string.IsNullOrEmpty(txtCena.Text) && !txtCena.Text.Contains("RSD"))
            {
                bool cenaBool = Double.TryParse(txtCena.Text, out double nova);
                if (cenaBool) novaCena = nova;
                else
                {
                    MessageBox.Show("Lose uneta cena!");
                    txtCena.Text = "Cena [RSD]";
                }
            }
            else
            {
                novaCena = double.Parse(dgvProizvodi.Rows[indeks].Cells[2].Value.ToString());
            }


            int id = Int32.Parse(dgvProizvodi.Rows[indeks].Cells[0].Value.ToString());
            Proizvod p = new Proizvod { IdPRozivoda = id, Naziv = noviNaziv, Proizvodjac = proizvodjac, Cena = novaCena };

            bool uspesno = Kontroler.Kontroler.Instance.IzmeniProizvod(p);
            if (uspesno)
            {
                MessageBox.Show("Uspesno ste izmenili proizvod.");
                PrikaziSveProizvode(dgvProizvodi);
                sredi(txtCena, txtNaziv);
            }
            else
            {
                MessageBox.Show("Nije moguce izmeniti izabrani proizvod.");
            }

        }
               
        private void sredi(TextBox txtCena, TextBox txtNaziv)
        {
            txtNaziv.Text = "Naziv proizvoda";
            txtCena.Text = "Cena [RSD]";
        }
        
        internal List<Proizvodjac> VratiProizvodjace()
        {
           return Kontroler.Kontroler.Instance.VratiProizvodjace();
        }


        //FrmObrisiProizvod
        internal void ObrisiProizvod(DataGridView dgvProizvodi, TextBox txtNaziv)
        {
            DaLiSteSigurni forma = new DaLiSteSigurni();
            forma.ShowDialog();
            int idProizvodaZaBrisanje = -1;
            if (dgvProizvodi.SelectedRows.Count > 0)
            {
                idProizvodaZaBrisanje = Int32.Parse(dgvProizvodi.SelectedCells[0].Value.ToString());
            }


            if (forma.siguran == true)
            {
                txtNaziv.Clear();
                bool obrisan = false;
                if (idProizvodaZaBrisanje != -1)
                {
                    Proizvod p = new Proizvod { IdPRozivoda = idProizvodaZaBrisanje };
                    obrisan = Komunikacija.Instance.ObrisiProizvod(p);
                    if (obrisan == true)
                    {

                        MessageBox.Show("Uspesno je obrisan proizvod.");
                        txtNaziv.Text = "Naziv proizvoda:";
                        int idProizvoda = (int)dgvProizvodi.SelectedRows[0].Cells[0].Value;
                        listaProizvodaBinding.Remove(new Proizvod { IdPRozivoda = idProizvoda });
                        PrikaziSveProizvode(dgvProizvodi);
                    }
                    else MessageBox.Show("Nije moguce obrisati proizvod.");
                }
                else
                    MessageBox.Show("Morate odabrati proizvod za brisanje.");
            }
            else
                MessageBox.Show("Morate odabrati proizvod za brisanje.");

        }
        

        internal void PrikaziProizvode(DataGridView dgvProizvodi, TextBox txtNaziv)
        {
            string deoNaziva = txtNaziv.Text;
            List<Proizvod> listaProizvoda = Komunikacija.Instance.PrikaziProizvode(deoNaziva);
            if (listaProizvoda.Count != 0)
            {
                //listaProizvodaBinding = new BindingList<Proizvod>(listaProizvoda);
                //dgvProizvodi.DataSource = listaProizvodaBinding.Select(x => new { x.IdPRozivoda, x.Naziv, x.Cena, x.Proizvodjac.NazivProizvodjaca }).ToList();
                dgvProizvodi.DataSource = listaProizvoda;
                srediDgv(dgvProizvodi);
            }
            else
            {
                MessageBox.Show("Nije pronadjen nijedan proizvod sa ovim nazivom.");
                PrikaziSveProizvode(dgvProizvodi);
            }
        }


    }
}
