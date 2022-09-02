namespace AgendamientoCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEnfermera")]
    public partial class tblEnfermera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUsuario { get; set; }

        public string nombre { get; set; }

        public virtual tblDoctor tblDoctor { get; set; }
    }
}
