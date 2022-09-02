namespace AgendamientoCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCita")]
    public partial class Cita
    {
        [Key]
        public int idCita { get; set; }

        public int? idDoctor { get; set; }

        public int? idPaciente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public TimeSpan? hora { get; set; }

        public bool? diponibilidad { get; set; }

    }
}
