using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Korisnik:IDomenskiObjekat
    {
        public int IDKorisnika { get; set; }
        public string Ime { get; set; }
        public String Prezime { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        public String KorIme { get; set; }
        public String Lozinka { get; set; }

        public string Tabela => "Korisnici";

        public string VrednostiZaInsert => $"'{Ime}', '{Prezime}', '{Telefon}', '{Email}', '{KorIme}', '{Lozinka}'";

        public string VrednostiZaPretragu => $"IDKorisnika = {IDKorisnika}";

        public string VrednostiZaSK => throw new NotImplementedException();

        public string UslovIdentifikator => $"{IDKorisnika}";

        public string NazivKolone => throw new NotImplementedException();

        public string VrednostZaUpdate => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string VrednostZaJoin => throw new NotImplementedException();

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> kroisnici = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Korisnik k = new Korisnik
                {
                    IDKorisnika = (int)reader["IDKorisnika"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Telefon = (string)reader["Telefon"],
                    Email = (string)reader["Email"],
                    KorIme = (string)reader["KorisnickoIme"],
                    Lozinka = (string)reader["Lozinka"],
                };
                kroisnici.Add(k);
            }
            return kroisnici;
        }
    }
}
