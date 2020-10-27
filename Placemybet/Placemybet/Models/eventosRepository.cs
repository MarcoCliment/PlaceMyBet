using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Placemybet.Models
{
    public class eventosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Eventos> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<Eventos> ev = new List<Eventos>();
            Eventos e = null;
            while (res.Read())
            {
                e = new Eventos(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3));
                ev.Add(e);
            }
            con.Close();
            return ev;
        }
    }
}