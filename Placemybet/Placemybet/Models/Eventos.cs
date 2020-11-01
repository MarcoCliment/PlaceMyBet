﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Eventos
    {

        public Eventos(int idEvento, string equipoLocal, string equipoVisitante, string fecha)
        {
            this.idEvento = idEvento;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }

        public int idEvento { get; set; }
        public string equipoLocal { get; set; }
        public string equipoVisitante { get; set; }
        public string fecha { get; set; }

    }
    public class EventosDTO
    {
        public EventosDTO(string equipoLocal, string equipoVisitante, string fecha)
    {
        this.equipoLocal = equipoLocal;
        this.equipoVisitante = equipoVisitante;
        this.fecha = fecha;
    }

    public string equipoLocal { get; set; }
    public string equipoVisitante { get; set; }
    public string fecha { get; set; }
    }
}
