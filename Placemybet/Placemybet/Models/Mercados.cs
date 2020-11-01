using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Mercados
    {

        public Mercados(int idEvento, int idMercado, float overUnder, float cuotaOver, float cuotaUnder, float dineroOver, float dineroUnder)
        {
            this.idEvento = idEvento;
            this.idMercado = idMercado;
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
        }

        public int idEvento { get; set; }
        public int idMercado { get; set; }
        public float overUnder { get; set; }
        public float cuotaOver { get; set; }
        public float cuotaUnder { get; set; }
        public float dineroOver { get; set; }
        public float dineroUnder { get; set; }
    }
    public class MercadosDTO
    {
        public MercadosDTO(float overUnder, float cuotaOver, float cuotaUnder)
        {
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
        }


        public float overUnder { get; set; }
        public float cuotaOver { get; set; }
        public float cuotaUnder { get; set; }
    }
}
