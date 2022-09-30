namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tratamiento")]
    public partial class Tratamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tratamiento()
        {
            Tratamiento_medicamento = new HashSet<Tratamiento_medicamento>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idTratamiento { get; set; }

        [Display(Name = "Etapa")]
        [StringLength(45)]
        public string etapa { get; set; }

        [Display(Name = "Protocolo")]
        [StringLength(45)]
        public string protocolo { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Column(TypeName = "date")]
        public DateTime? fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Column(TypeName = "date")]
        public DateTime? fecha_fin { get; set; }

        [Display(Name = "Observación")]
        [Column(TypeName = "text")]
        public string observacion { get; set; }

        [Display(Name = "ID Diagnóstico")]
        public int idDiagnostico { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento_medicamento> Tratamiento_medicamento { get; set; }
    }
}
