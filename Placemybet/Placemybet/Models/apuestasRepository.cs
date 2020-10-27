using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Placemybet.Models
{
    public class apuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Apuestas> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuestas";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<Apuestas> ass = new List<Apuestas>();
            Apuestas a = null;
            while (res.Read())
            {
                a = new Apuestas(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetString(3), res.GetFloat(4), res.GetFloat(5), res.GetString(6));
                ass.Add(a);
            }
            con.Close();
            return ass;
        }
    }
}