using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    [Serializable]
    public class Proizvod : IDomenskiObjekat
    {
        int idPRozivoda;
        string naziv;
        double cena;
        public int IdPRozivoda { get => idPRozivoda; set => idPRozivoda = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public double Cena { get => cena; set => cena = value; }
        public Proizvodjac Proizvodjac { get; set; }

        [Browsable(false)]
        public string Tabela => "Proizvodi";
        [Browsable(false)]
        public string VrednostZaJoin => "Proizvodi pr";
        [Browsable(false)]
        public string VrednostiZaInsert => $"'{Naziv}', {Cena}, {Proizvodjac.IDProizvodjaca1}";
        [Browsable(false)]
        public string VrednostiZaPretragu => "pr.Naziv";
        [Browsable(false)]
        public string VrednostiZaSK => "Proizvodjac";
        [Browsable(false)]
        public string UslovIdentifikator => $"IDProizvoda = {IdPRozivoda}";
        [Browsable(false)]
        public string NazivKolone => "Naziv";
        [Browsable(false)]
        public string VrednostZaUpdate => $"Naziv = '{Naziv}', Cena = {Cena}, Proizvodjac = {Proizvodjac.IDProizvodjaca1}";
        [Browsable(false)]
        public string Join => $"join Proizvodjaci p on (p.IDProizvodjaca = pr.Proizvodjac)";


        public override string ToString()
        {
            return Naziv;
        }
        [Browsable(false)]
        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> proizvodi = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Proizvod p = new Proizvod
                {
                    IdPRozivoda = Convert.ToInt32(reader[0]),
                    Naziv = reader[1].ToString(),
                    Cena = Convert.ToDouble(reader[2]),
                    Proizvodjac = new Proizvodjac
                    {
                        IDProizvodjaca1 = (int)reader[3],
                        NazivProizvodjaca = reader[5].ToString()
                    }

                };
                proizvodi.Add(p);
            }
            //reader.Close();
            return proizvodi;
        }

    }
}
