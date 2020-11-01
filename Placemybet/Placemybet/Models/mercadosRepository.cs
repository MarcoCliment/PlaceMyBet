using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Placemybet.Models
{
    public class mercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Mercados> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<Mercados> me = new List<Mercados>();
            Mercados m = null;
            while (res.Read())
            {
                m = new Mercados(res.GetInt32(0), res.GetInt32(1), res.GetFloat(2), res.GetFloat(3), res.GetFloat(4), res.GetFloat(5), res.GetFloat(6));
                me.Add(m);
            }
            con.Close();
            return me;
        }
        internal List<MercadosDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercados";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<MercadosDTO> me = new List<MercadosDTO>();
            MercadosDTO m = null;
            while (res.Read())
            {
                m = new MercadosDTO(res.GetFloat(2), res.GetFloat(3), res.GetFloat(4));
                me.Add(m);
            }
            con.Close();
            return me;
        }
    }
}