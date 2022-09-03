using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    public class Cita
    {
        public int idCita { get; set; }

        public int? idDoctor { get; set; }

        public int? idPaciente { get; set; }

        public DateTime? fecha { get; set; }

        public TimeSpan? hora { get; set; }

        public bool? diponibilidad { get; set; }

        public override string ToString()
        {
            return $"Hora: {hora.ToString()}, Hospital HCAM- Quito";
        }
    }
}
