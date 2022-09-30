using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sistema_Leucemia_v2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DatosLeucemia")
        {
        }

        public virtual DbSet<Condicion_previa> Condicion_previa { get; set; }
        public virtual DbSet<Control_sangre> Control_sangre { get; set; }
        public virtual DbSet<Diagnostico> Diagnostico { get; set; }
        public virtual DbSet<Examen_medico> Examen_medico { get; set; }
        public virtual DbSet<Medicamento> Medicamento { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Sindrome_genetico> Sindrome_genetico { get; set; }
        public virtual DbSet<Sintoma> Sintoma { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }
        public virtual DbSet<Tratamiento_medicamento> Tratamiento_medicamento { get; set; }
        public virtual DbSet<Tratamiento_previo> Tratamiento_previo { get; set; }
        public virtual DbSet<Tratamiento_sugerido> Tratamiento_sugerido { get; set; }
        public virtual DbSet<Tsugerido_Medicamento> Tsugerido_Medicamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condicion_previa>()
                .Property(e => e.antecedente_familiar)
                .IsUnicode(false);

            modelBuilder.Entity<Condicion_previa>()
                .HasMany(e => e.Tratamiento_previo)
                .WithRequired(e => e.Condicion_previa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Condicion_previa>()
                .HasMany(e => e.Sindrome_genetico)
                .WithMany(e => e.Condicion_previa)
                .Map(m => m.ToTable("Condicion_previa_Sindrome_genetico").MapLeftKey("idCondicion_previa").MapRightKey("idSindrome_genetico"));

            modelBuilder.Entity<Control_sangre>()
                .Property(e => e.EMR)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Control_sangre>()
                .Property(e => e.hemoglobina)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Control_sangre>()
                .Property(e => e.plaquetas)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Control_sangre>()
                .Property(e => e.linfoblasto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Control_sangre>()
                .Property(e => e.neutrofilos)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.condicion)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostico>()
                .HasMany(e => e.Control_sangre)
                .WithRequired(e => e.Diagnostico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnostico>()
                .HasMany(e => e.Examen_medico)
                .WithRequired(e => e.Diagnostico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnostico>()
                .HasMany(e => e.Tratamiento)
                .WithRequired(e => e.Diagnostico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Examen_medico>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Examen_medico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Examen_medico>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<Examen_medico>()
                .Property(e => e.encargado)
                .IsUnicode(false);

            modelBuilder.Entity<Examen_medico>()
                .Property(e => e.resultado)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.abreviacion)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.descripccion)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.componente)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.cantidad)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Medicamento>()
                .Property(e => e.medida)
                .IsUnicode(false);

            modelBuilder.Entity<Medicamento>()
                .HasMany(e => e.Tratamiento_medicamento)
                .WithRequired(e => e.Medicamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.hc)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.ap_paterno)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.ap_materno)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.procedencia)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.distrito)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.residencia)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.direc_referencia)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Condicion_previa)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Diagnostico)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Sintoma)
                .WithMany(e => e.Paciente)
                .Map(m => m.ToTable("Paciente_Sintoma").MapLeftKey("idPaciente").MapRightKey("idSintoma"));

            modelBuilder.Entity<Personal>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.turno)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .HasMany(e => e.Diagnostico)
                .WithRequired(e => e.Personal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sindrome_genetico>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sindrome_genetico>()
                .Property(e => e.grado)
                .IsUnicode(false);

            modelBuilder.Entity<Sintoma>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sintoma>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Sintoma>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento>()
                .Property(e => e.etapa)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento>()
                .Property(e => e.protocolo)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento>()
                .HasMany(e => e.Tratamiento_medicamento)
                .WithRequired(e => e.Tratamiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tratamiento_medicamento>()
                .Property(e => e.cantidad)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Tratamiento_medicamento>()
                .Property(e => e.medida)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_medicamento>()
                .Property(e => e.recurrencia)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_previo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_previo>()
                .Property(e => e.grado)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_previo>()
                .Property(e => e.grado_elev)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_sugerido>()
                .Property(e => e.duracion)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_sugerido>()
                .Property(e => e.protocolo)
                .IsUnicode(false);

            modelBuilder.Entity<Tratamiento_sugerido>()
                .HasMany(e => e.Tsugerido_Medicamento)
                .WithRequired(e => e.Tratamiento_sugerido)
                .HasForeignKey(e => e.idTsugerido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tsugerido_Medicamento>()
                .Property(e => e.codigo_med)
                .IsUnicode(false);

            modelBuilder.Entity<Tsugerido_Medicamento>()
                .Property(e => e.cantidad)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Tsugerido_Medicamento>()
                .Property(e => e.medida)
                .IsUnicode(false);

            modelBuilder.Entity<Tsugerido_Medicamento>()
                .Property(e => e.recurrencia)
                .IsUnicode(false);
        }
    }
}
