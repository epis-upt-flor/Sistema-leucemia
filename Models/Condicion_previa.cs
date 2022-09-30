namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Condicion_previa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Condicion_previa()
        {
            Tratamiento_previo = new HashSet<Tratamiento_previo>();
            Sindrome_genetico = new HashSet<Sindrome_genetico>();
        }

        [Key]
        [Display(Name ="ID")]
        public int idCondicion_previa { get; set; }

        [Display(Name ="Ant. familiar")]
        [StringLength(45)]
        public string antecedente_familiar { get; set; }

        [Display(Name ="Radiación")]
        public bool? radiacion { get; set; }

        [Display(Name = "Tabaquismo")]
        public bool? tabaquismo { get; set; }

        [Display(Name ="Sust. química")]
        public bool? sustancia_quimica { get; set; }

        [Display(Name ="ID Paciente")]
        public int idPaciente { get; set; }

        public virtual Paciente Paciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento_previo> Tratamiento_previo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sindrome_genetico> Sindrome_genetico { get; set; }
    }
}
