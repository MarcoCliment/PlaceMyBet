using System;
using System.Collections.Generic;
using System.Globalization;
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
            command.CommandText = " select a.*, m.overunder from Apuestas as a, mercados as m where a.idMercado = m.idMercado;";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<Apuestas> ass = new List<Apuestas>();
            Apuestas a = null;
            while (res.Read())
            {
                a = new Apuestas(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetFloat(7), res.GetString(3), res.GetFloat(4), res.GetFloat(5), res.GetString(6));
                ass.Add(a);
            }
            con.Close();
            return ass;
        }
        internal List<ApuestasDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = " select a.*, m.overunder from Apuestas as a, mercados as m where a.idMercado = m.idMercado;";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            List<ApuestasDTO> ass = new List<ApuestasDTO>();
            ApuestasDTO a = null;
            while (res.Read())
            {
                a = new ApuestasDTO(res.GetString(1), res.GetFloat(7), res.GetString(3), res.GetFloat(4), res.GetFloat(5), res.GetString(6));
                ass.Add(a);
            }
            con.Close();
            return ass;
        }
        internal bool HacerApuesta(userApuesta a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            //Obtener la cuota para esa apuesta desde la bdd
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
                
            string sql = "";
             if (a.tipoApuesta.ToLower() == "over") {
                sql = "select cuotaover, dineroOver, dineroUnder from mercados " +
            " where idmercado = " + a.idmercado ;
            } else if (a.tipoApuesta.ToLower() == "under") {
                sql = "select cuotaunder, dineroOver, dineroUnder from mercados " +
            " where idmercado = " + a.idmercado ;
            }
            else
            {
                return false;
            }

        
            command.CommandText = sql;

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            float cuota = -1;
            float over = -1;
            float under = -1;
            if (res.Read())
            {
                cuota = res.GetFloat(0);
                over = res.GetFloat(1);
                under = res.GetFloat(2);
            }
            else
            {
                return false;
            }

            //calcular probabilidad de apuesta
            float total = over + under;
            float prob;
            if(a.tipoApuesta.ToLower() == "over"){
                prob = over / total;
            }else
            {
                prob = under / total;
            }
            res.Close();

            //calcular nueva cuota
            float newCuota = float.Parse((1 / prob) * 0.95 + "");

            //Realizar apuesta

            sql = "insert into apuestas(email, idMercado, tipoapuesta, cuota, " +
            "montoApuesta, fecha)values('"+ a.email +"',"+ a.idmercado +",'"+
            a.tipoApuesta+"',"+ cuota +","+ a.montoApuesta +", now())";
            
            command = con.CreateCommand();
            command.CommandText = sql;

            int nCambios = command.ExecuteNonQuery();

            Console.Write(nCambios + " cambios realizados en bdd");

            //Recalculamos las cuotas según los nuevos datos
            sql = "update mercados set dineroOver = (select sum(montoApuesta) from apuestas where idMercado = " + a.idmercado + " and tipoApuesta = 'Over') where idMercado = " + a.idmercado + "; ";
            command = con.CreateCommand();
            command.CommandText = sql;
            nCambios = command.ExecuteNonQuery();

            sql = "update mercados set dineroUnder = (select sum(montoApuesta) from apuestas where idMercado = " + a.idmercado + " and tipoApuesta = 'Under') where idMercado = " + a.idmercado + "; ";
            command = con.CreateCommand();
            command.CommandText = sql;
            nCambios = command.ExecuteNonQuery();

            sql = "update mercados set cuotaover = 1/(dineroOver/(dineroOver + dineroUnder))*0.95 where idMercado = " + a.idmercado + " ;";
            command = con.CreateCommand();
            command.CommandText = sql;
            nCambios = command.ExecuteNonQuery();

            sql = "update mercados set cuotaunder = 1/(dineroUnder/(dineroOver + dineroUnder))*0.95 where idMercado = " + a.idmercado + " ;";
            command = con.CreateCommand();
            command.CommandText = sql;
            nCambios = command.ExecuteNonQuery();

            con.Close();

            return true;
        }
    }
}