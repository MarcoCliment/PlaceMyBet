using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Apuestas
    {
        public Apuestas()
        {
        }

        public Apuestas(int idApuestas, string email, int idMercado, string tipoApuesta, float cuota, float montoApuesta, string fecha)
        {
            this.idApuestas = idApuestas;
            this.email = email;
            this.idMercado = idMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.montoApuesta = montoApuesta;
            this.fecha = fecha;
        }

        public int idApuestas { get; set; }
        public string email { get; set; }
        public int idMercado { get; set; }
        public string tipoApuesta { get; set; }
        public float cuota { get; set; }
        public float montoApuesta { get; set; }
        public string fecha { get; set; }
    }
}