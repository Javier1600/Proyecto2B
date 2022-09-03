using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendamientoCitas.Models.Clases
{
    public class MensajesWeb
    {
        public MensajesWeb(string mensaje)
        {
            Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
        
    }
}