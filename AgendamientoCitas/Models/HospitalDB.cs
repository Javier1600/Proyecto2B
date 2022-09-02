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

        public virtual DbSet<tblCita> tblCita { get; set; }
        public virtual DbSet<Consultorio> Consultorio { get; set; }
        public virtual DbSet<tblDoctor> tblDoctor { get; set; }
        public virtual DbSet<tblEnfermera> tblEnfermera { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCita>()
                .Property(e => e.hora)
                .HasPrecision(1);

            modelBuilder.Entity<Consultorio>()
                .Property(e => e.numeroConsultorio)
                .IsUnicode(false);

            modelBuilder.Entity<tblDoctor>()
                .HasMany(e => e.tblCita)
                .WithOptional(e => e.tblDoctor)
                .HasForeignKey(e => e.idDoctor);

            modelBuilder.Entity<tblDoctor>()
                .HasOptional(e => e.tblEnfermera)
                .WithRequired(e => e.tblDoctor);

            modelBuilder.Entity<tblEnfermera>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .Property(e => e.nombreEspecialidad)
                .IsUnicode(false);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.tblDoctor)
                .WithRequired(e => e.tblEspecialidad)
                .WillCascadeOnDelete(false);

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
