using Domeni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Forme
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket klijentskiSoket;
        private NetworkStream tok;
        private BinaryFormatter formater = new BinaryFormatter();

        public Komunikacija()
        {

        }

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                    instance = new Komunikacija();
                return instance;
            }
        }

        internal Admin PrijaviSe(string korisnickoIme, string lozinka)
        {
            Admin a = new Admin { KorIme = korisnickoIme, Lozinka = lozinka };
            Zahtev z = new Zahtev { Operacija = Operacija.Prijava, Objekat = a };
            formater.Serialize(tok, z);
            Odgovor odg = (Odgovor)formater.Deserialize(tok);
            if (odg.Signal == Signal.Ok)
            {
                return (Admin)odg.Objekat;
            }
            else
            {
                return null;
            }
        }

        internal Porudzbina SacuvajPorudzbinu(Porudzbina porudzbina)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.SacuvajPorudzbinu, Objekat = porudzbina };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (Porudzbina)odg.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal Korisnik PrijaviKorisnika(string korIme, string loz)
        {
            Korisnik k = new Korisnik { KorIme = korIme, Lozinka = loz};
            Zahtev z = new Zahtev { Operacija = Operacija.Prijava, Objekat = k };
            formater.Serialize(tok, z);
            Odgovor odg = (Odgovor)formater.Deserialize(tok);
            if (odg.Signal == Signal.Ok)
            {
                return (Korisnik)odg.Objekat;
            }
            else
            {
                return null;
            }
        }

        public bool PoveziSe()
        {
            try
            {
                klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                klijentskiSoket.Connect("localhost", 9090);
                tok = new NetworkStream(klijentskiSoket);
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        internal Proizvod SacuvajProizvod(Proizvod p)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.SacuvajNoviProizvod, Objekat = p };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (Proizvod)odg.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal Korisnik SacuvajKorisnika(Korisnik k)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.SacuvajNovogKorisnika, Objekat = k };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (Korisnik)odg.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal List<Proizvod> PrikaziSveProizvode()
        {
            Zahtev z = new Zahtev { Operacija = Operacija.PrikaziSveProizvodeJoin };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (List<Proizvod>)odg.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal List<Proizvod> PrikaziProizvode(string deoNaziva)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.PrikaziProizvode, Objekat = deoNaziva };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (List<Proizvod>)odg.Objekat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal bool ObrisiProizvod(Proizvod p)
        {
            Zahtev z = new Zahtev { Operacija = Operacija.ObrisiProizvod, Objekat = p };
            try
            {
                formater.Serialize(tok, z);
                Odgovor odg = (Odgovor)formater.Deserialize(tok);
                if (odg.Signal == Signal.Ok)
                {
                    return (bool)odg.Objekat;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
