namespace AgendamientoCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDoctor")]
    public partial class tblDoctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDoctor()
        {
            tblCita = new HashSet<tblCita>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUsuario { get; set; }

        public int idEspecialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCita> tblCita { get; set; }

        public virtual Consultorio tblConsultorio { get; set; }

        public virtual Especialidad tblEspecialidad { get; set; }

        public virtual Usuario tblUsuario { get; set; }

        public virtual tblEnfermera tblEnfermera { get; set; }
    }
}
