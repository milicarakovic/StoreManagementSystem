using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Porudzbina:IDomenskiObjekat
    {
        int sifraPorudzbine;
        DateTime datumPorudzbine, rokPrispeca;
        double ukupanIznos;
        Korisnik Korisnik;
        public List<StavkaPorudzbine> StavkePorudzbine { get; set; }

        public int SifraPorudzbine { get => sifraPorudzbine; set => sifraPorudzbine = value; }
        public DateTime DatumPorudzbine { get => datumPorudzbine; set => datumPorudzbine = value; }
        public DateTime RokPrispeca { get => rokPrispeca; set => rokPrispeca = value; }
        public double UkupanIznos { get => ukupanIznos; set => ukupanIznos = value; }
        public Korisnik Korisnik1 { get => Korisnik; set => Korisnik = value; }

        public string Tabela => "Porudzbina";

        public string VrednostiZaInsert => $"'{DatumPorudzbine}', '{RokPrispeca}', {UkupanIznos}, {Korisnik1.IDKorisnika}";

        public string VrednostiZaPretragu => throw new NotImplementedException();

        public string VrednostiZaSK => throw new NotImplementedException();

        public string UslovIdentifikator => "SifraPorudzbine";

        public string NazivKolone => throw new NotImplementedException();

        public string VrednostZaUpdate => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string VrednostZaJoin => throw new NotImplementedException();

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> porudzbine = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Porudzbina p = new Porudzbina
                {
                    SifraPorudzbine = (int)reader["SifraPorudzbine"],
                    DatumPorudzbine = (DateTime)reader["DatumPorudzbine"],
                    RokPrispeca = (DateTime)reader["RokPrispeca"],
                    UkupanIznos = (double)reader["UkupanIznos"],
                    Korisnik1 = new Korisnik { IDKorisnika = (int)reader["KorisnikID"] }
                };
                porudzbine.Add(p);
            }
            return porudzbine;
        }
    }
}
