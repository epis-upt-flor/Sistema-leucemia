namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diagnostico")]
    public partial class Diagnostico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnostico()
        {
            Control_sangre = new HashSet<Control_sangre>();
            Examen_medico = new HashSet<Examen_medico>();
            Tratamiento = new HashSet<Tratamiento>();
            Tratamiento_sugerido = new HashSet<Tratamiento_sugerido>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idDiagnostico { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Condicion")]
        [StringLength(45)]
        public string condicion { get; set; }

        [Display(Name = "Observacion")]
        [StringLength(45)]
        public string observacion { get; set; }

        [Display(Name = "ID Personal")]
        public int idPersonal { get; set; }

        [Display(Name = "ID Paciente")]
        public int idPaciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control_sangre> Control_sangre { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Personal Personal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examen_medico> Examen_medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento> Tratamiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento_sugerido> Tratamiento_sugerido { get; set; }
    }
}
