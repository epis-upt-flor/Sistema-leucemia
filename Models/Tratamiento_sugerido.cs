namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tratamiento_sugerido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tratamiento_sugerido()
        {
            Tsugerido_Medicamento = new HashSet<Tsugerido_Medicamento>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idTratamiento_sugerido { get; set; }

        [Display(Name = "Duración")]
        [StringLength(45)]
        public string duracion { get; set; }

        [Display(Name = "Protocolo")]
        [StringLength(45)]
        public string protocolo { get; set; }

        [Display(Name = "ID Diagnóstico")]
        public int? idDiagnostico { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tsugerido_Medicamento> Tsugerido_Medicamento { get; set; }
    }
}
