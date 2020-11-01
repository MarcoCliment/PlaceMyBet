using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class userApuesta
    {
        public userApuesta(string email, int idmercado, string tipoApuesta, float montoApuesta)
        {
            this.email = email;
            this.idmercado = idmercado;
            this.tipoApuesta = tipoApuesta;
            this.montoApuesta = montoApuesta;
        }

        public string email { get; set; }
        public int idmercado { get; set; }
        public string tipoApuesta { get; set; }
        public float montoApuesta { get; set; }
    }
}