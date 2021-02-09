using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Proizvodjac:IDomenskiObjekat
    {
        int IDProizvodjaca, maticniBroj, PIB;
        string nazivProizvodjaca, adresa, kontakt, mejl;

        public int IDProizvodjaca1 { get => IDProizvodjaca; set => IDProizvodjaca = value; }
        public int MaticniBroj { get => maticniBroj; set => maticniBroj = value; }
        public int PIB1 { get => PIB; set => PIB = value; }
        public string NazivProizvodjaca { get => nazivProizvodjaca; set => nazivProizvodjaca = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Kontakt { get => kontakt; set => kontakt = value; }
        public string Mejl { get => mejl; set => mejl = value; }

        public override string ToString()
        {
            return NazivProizvodjaca;
        }


        public string Tabela => "Proizvodjaci";

        public string VrednostiZaInsert => $"{IDProizvodjaca1}, '{NazivProizvodjaca}', '{Adresa}', '{Kontakt}', '{Mejl}', {MaticniBroj}, {PIB1}";

        public string VrednostiZaPretragu => throw new NotImplementedException();

        public string VrednostiZaSK => throw new NotImplementedException();

        public string UslovIdentifikator => "IDProizvodjaca";

        public string NazivKolone => throw new NotImplementedException();
        
        public string VrednostZaUpdate => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string VrednostZaJoin => throw new NotImplementedException();

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> proizvodjaci = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Proizvodjac p = new Proizvodjac
                {
                    IDProizvodjaca1 = (int)reader["IDProizvodjaca"],
                    NazivProizvodjaca = (string)reader["Naziv"],
                    Adresa = (string)reader["Adresa"],
                    Kontakt = (string)reader["Kontakt"],
                    Mejl = (string)reader["Mejl"],
                    MaticniBroj = (int)reader["MaticniBroj"],
                    PIB1 = (int)reader["PIB"]
                };
                proizvodjaci.Add(p);
            }
            return proizvodjaci;
        }

    }
}
