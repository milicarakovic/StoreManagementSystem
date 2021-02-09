using Domeni;
using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Obrada
    {
        private Socket klijentskiSoket;
        private NetworkStream tok;
        private BinaryFormatter formater = new BinaryFormatter();

        public Obrada(Socket klijentskiSoket)
        {
            this.klijentskiSoket = klijentskiSoket;
            tok = new NetworkStream(klijentskiSoket);
        }

        public void ObradaZahteva()
        {
            bool kraj = false;
            while (!kraj)
            {
                Odgovor odgovor = new Odgovor();

                try
                {
                    Zahtev zahtev = (Zahtev)formater.Deserialize(tok);
                    switch (zahtev.Operacija)
                    {
                        case Operacija.Prijava:

                            if (zahtev.Objekat is Admin)
                            {
                                Admin a = (Admin)zahtev.Objekat;
                                Admin pronadjeniAdmin = Kontroler.Kontroler.Instance.PrijaviSe(a.KorIme, a.Lozinka);


                                if (pronadjeniAdmin != null)
                                {
                                    //znaci da je admin
                                    odgovor.Poruka = "Sistem je uspesno pronasao admina.";
                                    odgovor.Objekat = pronadjeniAdmin;
                                    formater.Serialize(tok, odgovor);
                                }
                                else
                                {
                                    odgovor.Poruka = "Sistem nije pronasao admina.";
                                    odgovor.Objekat = null;
                                    formater.Serialize(tok, odgovor);
                                }
                            }
                            else
                            {
                                Korisnik k = (Korisnik)zahtev.Objekat;
                                Korisnik pronadjeniKorisnik = Kontroler.Kontroler.Instance.PrijaviKorisnika(k.KorIme, k.Lozinka);
                                if (pronadjeniKorisnik != null)
                                {
                                    odgovor.Poruka = "Sistem je uspesno pronasao korisnika.";
                                    odgovor.Objekat = pronadjeniKorisnik;
                                    formater.Serialize(tok, odgovor);
                                }
                                else
                                {
                                    odgovor.Poruka = "Sistem nije pronasao korisnika.";
                                    odgovor.Objekat = null;
                                    formater.Serialize(tok, odgovor);
                                }
                            }

                            break;
                        case Operacija.SacuvajNoviProizvod:
                            odgovor.Objekat =  Kontroler.Kontroler.Instance.SacuvajProizvod((Proizvod)zahtev.Objekat);
                            odgovor.Poruka = "Sistem je uspesno pronasao proizvode!";
                            formater.Serialize(tok, odgovor);
                            break;
                        case Operacija.SacuvajNovogKorisnika:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.SacuvajKorisnika((Korisnik)zahtev.Objekat);
                            odgovor.Poruka = "Sistem je uspesno kreirao korisnika!";
                            formater.Serialize(tok, odgovor);
                            break;
                        /*case Operacija.PrikaziSveProizvode:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.VratiProizvode();
                            odgovor.Poruka = "Sistem je uspesno vratio proizvode!";
                            formater.Serialize(tok, odgovor);
                            break;
                         */   
                        case Operacija.PrikaziProizvode:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.VratiProizvode((string) zahtev.Objekat);
                            odgovor.Poruka = "Sistem je uspesno vratio proizvode!";
                            formater.Serialize(tok, odgovor);
                            break;
                        case Operacija.ObrisiProizvod:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.ObrisiProizvod((Proizvod)zahtev.Objekat);
                            odgovor.Poruka = "Sistem je uspesno vratio proizvode!";
                            odgovor.Signal = Signal.Ok;
                            formater.Serialize(tok, odgovor);
                            break;
                        case Operacija.SacuvajPorudzbinu:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.SacuvajPorudzbinu((Porudzbina)zahtev.Objekat);
                            odgovor.Poruka = "Sistem je uspesno kreirao porudzbinu!";
                            formater.Serialize(tok, odgovor);
                            break;
                        case Operacija.PrikaziSveProizvodeJoin:
                            odgovor.Objekat = Kontroler.Kontroler.Instance.VratiProizvodeJoin();
                            odgovor.Poruka = "Sistem je uspesno vratio proizvode!";
                            formater.Serialize(tok, odgovor);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    odgovor.Signal = Signal.Error;
                    odgovor.Poruka = ex.Message;
                    //formater.Serialize(tok, odgovor);
                }
            }
        }


        internal void Zaustavi()
        {
            klijentskiSoket.Shutdown(SocketShutdown.Both);
            klijentskiSoket.Close();
        }
    }
}
