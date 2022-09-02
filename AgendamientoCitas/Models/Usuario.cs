namespace AgendamientoCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUsuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
         
        }

        [Key]
        public int idUsuario { get; set; }

        public string cedula { get; set; }

        public string password { get; set; }

        public string nombre { get; set; }

        [StringLength(1)]
        public string sexo { get; set; }

        public int? idRol { get; set; }

    }
}
