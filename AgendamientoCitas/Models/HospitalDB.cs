using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AgendamientoCitas.Models
{
    public partial class HospitalDB : DbContext
    {
        public HospitalDB()
            : base("name=HospitalDB")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Consultorio> Consultorio { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Enfermera> Enfermera { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .Property(e => e.hora)
                .HasPrecision(1);

            modelBuilder.Entity<Consultorio>()
                .Property(e => e.numeroConsultorio)
                .IsUnicode(false);


            modelBuilder.Entity<Enfermera>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.nombreEspecialidad)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.nombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.sexo)
                .IsUnicode(false);

        }
    }
}
