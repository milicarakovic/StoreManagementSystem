using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public interface IDomenskiObjekat
    {
        string Tabela { get; }
        string VrednostiZaInsert { get; }
        string VrednostiZaPretragu { get; }
        string VrednostZaUpdate { get; }

        string VrednostiZaSK { get; }
        string UslovIdentifikator { get; } 
        string Join { get; }
        string VrednostZaJoin { get; }

        List<IDomenskiObjekat> VratiListu(SqlDataReader reader);
    }
}
