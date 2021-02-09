using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class StavkaPorudzbine:IDomenskiObjekat
    {
        int redniBroj, kolicina;
        double cena, iznosStavke;
        Proizvod proizvod;

        public int RedniBroj { get => redniBroj; set => redniBroj = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public double Cena { get => cena; set => cena = value; }
        public double IznosStavke { get => iznosStavke; set => iznosStavke = value; }
        public Proizvod Proizvod { get => proizvod; set => proizvod = value; }
        public int SifraPorudzbine { get; set; }
        public string Tabela => "StavkaPorudzbine";

        public string VrednostiZaInsert => $"{Kolicina}, {Cena}, {IznosStavke}, {SifraPorudzbine}, {Proizvod.IdPRozivoda}";

        public string VrednostiZaPretragu => throw new NotImplementedException();

        public string VrednostiZaSK => throw new NotImplementedException();

        public string UslovIdentifikator => throw new NotImplementedException();

        public string NazivKolone => throw new NotImplementedException();

        public string VrednostZaUpdate => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string VrednostZaJoin => throw new NotImplementedException();

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
