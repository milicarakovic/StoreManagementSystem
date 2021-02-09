using Domeni;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=baza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        //NOVE METODE


        public int Izmeni(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand($"update {objekat.Tabela} set {objekat.VrednostZaUpdate} where {objekat.UslovIdentifikator}", connection, transaction);
            return command.ExecuteNonQuery();
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat objekat)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"select * from {objekat.Tabela}";
            SqlDataReader reader = comm.ExecuteReader();
            List<IDomenskiObjekat> lista = objekat.VratiListu(reader);
            reader.Close();
            return lista;
        }

        public List<IDomenskiObjekat> VratiUzJoin(IDomenskiObjekat objekat)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"select * from {objekat.VrednostZaJoin} {objekat.Join}";
            SqlDataReader reader = comm.ExecuteReader();
            List<IDomenskiObjekat> lista = objekat.VratiListu(reader);
            reader.Close();
            return lista;
        }


        public bool Sacuvaj(IDomenskiObjekat objekat)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"insert into {objekat.Tabela} values ({objekat.VrednostiZaInsert})";
            int rez = comm.ExecuteNonQuery();

            if (rez != 0) return true;
            return false;
        }
        /*
        public List<IDomenskiObjekat> VratiUzUslov(string uslov, IDomenskiObjekat objekat, IDomenskiObjekat objekat2)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"select * from {objekat.Tabela} a join {objekat2.Tabela} b on a.{objekat.VrednostiZaSK}={objekat2.UslovIdentifikator} " +
                $"where a.{objekat.VrednostiZaPretragu} like '%{uslov}%'";
            SqlDataReader reader = comm.ExecuteReader();
            List<IDomenskiObjekat> lista = objekat.VratiListu(reader);
            reader.Close();
            return lista;
        }
        */
        public List<IDomenskiObjekat> VratiUzUslov(string uslov, IDomenskiObjekat objekat)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"select * from {objekat.VrednostZaJoin} {objekat.Join} where {objekat.VrednostiZaPretragu} like '%{uslov}%'";
            SqlDataReader reader = comm.ExecuteReader();
            List<IDomenskiObjekat> lista = objekat.VratiListu(reader);
            reader.Close();
            return lista;
        }

        public bool Obrisi(IDomenskiObjekat obj)
        {
            try
            {
                SqlCommand command = new SqlCommand("", connection, transaction);
                command.CommandText = $"delete from {obj.Tabela} where {obj.UslovIdentifikator}";
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int VratiID(IDomenskiObjekat objekat)
        {
            SqlCommand comm = new SqlCommand("", connection, transaction);
            comm.CommandText = $"select max({objekat.UslovIdentifikator}) from {objekat.Tabela}";
            object rez = comm.ExecuteScalar();
            if (rez is DBNull)
            {
                return 1;
            }
            int maxid = (int)rez;
            return maxid;
        }

    }
}
