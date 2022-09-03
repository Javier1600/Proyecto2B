using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }


        public int idUsuario { get; set; }

        public string cedula { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }

        public string sexo { get; set; }

        public int? idRol { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
