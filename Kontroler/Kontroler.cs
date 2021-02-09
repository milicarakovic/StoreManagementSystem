using BazaAdmina;
using BrokerBazePodataka;
using Domeni;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker = new Broker();
        private static Kontroler _instance;

        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }
                return _instance;
            }
        }

        private Kontroler()
        {
        }

        //Genericke metode
        public List<Proizvodjac> VratiProizvodjace()
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveProizvodjaceSO();
            sistemskaOperacija.Izvrsi(new Proizvodjac());
            return ((VratiSveProizvodjaceSO)sistemskaOperacija).Proizvodjaci;
        }
        
        /*
        public List<Proizvod> VratiProizvode()
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiSveProizvodeSO();
            sistemskaOperacija.Izvrsi(new Proizvod());
            return ((VratiSveProizvodeSO)sistemskaOperacija).Proizvodi;
        }
        */
        public Proizvod SacuvajProizvod(Proizvod p)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new SacuvajProizvodSO();
            sistemskaOperacija.Izvrsi(p);
            return ((SacuvajProizvodSO)sistemskaOperacija).Proizvod;
        }

        public Korisnik SacuvajKorisnika(Korisnik korisnik)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new SacuvajKorisnikaSO();
            sistemskaOperacija.Izvrsi(korisnik);
            return ((SacuvajKorisnikaSO)sistemskaOperacija).Korisnik;
        }

        public bool ObrisiProizvod(Proizvod p)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new ObrisiProizvodSO();
            sistemskaOperacija.Izvrsi(p);
            return ((ObrisiProizvodSO)sistemskaOperacija).Uspelo;
        }

        public bool IzmeniProizvod(Proizvod proizvod)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new IzmeniProizvodSO();
            sistemskaOperacija.Izvrsi(proizvod);
            return ((IzmeniProizvodSO)sistemskaOperacija).Uspelo;
        }


        public Korisnik PrijaviKorisnika(string korIme, string loz)
        {
            Korisnik kor = new Korisnik { KorIme = korIme, Lozinka = loz };

            OpstaSistemskaOperacija sistemskaOperacija = new PrijaviKorisnikaSO();
            sistemskaOperacija.Izvrsi(new Korisnik());
            List < Korisnik > korisnici = ((PrijaviKorisnikaSO)sistemskaOperacija).Korisnici;

            foreach (Korisnik k in korisnici)
            {
                if (k.KorIme.Trim() == korIme && k.Lozinka.Trim() == loz)
                    return k;
            }
            return null;
        }

        public List<Proizvod> VratiProizvode(string deoNaziva)
        {

            OpstaSistemskaOperacija sistemskaOperacija = new VratiProizvodeUzUslovSO();
            ((VratiProizvodeUzUslovSO)sistemskaOperacija).Uslov = deoNaziva;
            sistemskaOperacija.Izvrsi(new Proizvod());
            return ((VratiProizvodeUzUslovSO)sistemskaOperacija).Proizvodi;

        }

        public Porudzbina SacuvajPorudzbinu(Porudzbina porudzbina)
        {
            OpstaSistemskaOperacija sistemskaOperacija = new SacuvajPorudzbinuSO();
            sistemskaOperacija.Izvrsi(porudzbina);
            return ((SacuvajPorudzbinuSO)sistemskaOperacija).Porudzbina;
        }

        public List<Proizvod> VratiProizvodeJoin()
        {
            OpstaSistemskaOperacija sistemskaOperacija = new VratiProizvodeIProizvodjaceSO();
            sistemskaOperacija.Izvrsi(new Proizvod());
            return ((VratiProizvodeIProizvodjaceSO)sistemskaOperacija).Proizvodi;
        }

        //Stare metode


        public Admin PrijaviSe(string korisnickoIme, string lozinka)
        {
            BazaAdmin bazaKor = new BazaAdmin();
            List<Admin> admini = bazaKor.VratiSveAdmine();

            foreach (Admin k in admini)
            {
                if (k.KorIme == korisnickoIme && k.Lozinka == lozinka) return k;
            }
            return null;
        }

    }
}
