using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Usuarios
    {
        public Usuarios()
        {
        }

        public Usuarios(string email, string nombre, string apellidos, string credenciales, string edad, string banco)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.credenciales = credenciales;
            this.edad = edad;
            this.banco = banco;
        }

        public string email { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string credenciales { get; set; }
        public string edad { get; set; }
        public string banco { get; set; }
    }
}