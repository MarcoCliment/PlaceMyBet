using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Placemybet.Models
{
    public class usuariosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Usuarios> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<Usuarios> us = new List<Usuarios>();
            Usuarios u = null;
            while (res.Read())
            {
                u = new Usuarios(res.GetString(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetString(5));
                us.Add(u);
            }
            con.Close();
            return us;
        }
    }
}