namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examen_medico
    {
        [Display(Name = "ID")]
        [Key]
        public int idExamen_medico { get; set; }

        [Display(Name = "Estado")]
        [StringLength(45)]
        public string estado { get; set; }

        [Display(Name = "F.Encargo")]
        [Column(TypeName = "date")]
        public DateTime? fecha_encargo { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Área")]
        [StringLength(45)]
        public string area { get; set; }

        [Display(Name = "Encargado")]
        [StringLength(45)]
        public string encargado { get; set; }

        [Display(Name = "F.Resultado")]
        [Column(TypeName = "date")]
        public DateTime? fecha_resultado { get; set; }

        [Display(Name = "Resultado")]
        [StringLength(45)]
        public string resultado { get; set; }

        [Display(Name = "ID Diagnostico")]
        public int idDiagnostico { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }
    }
}
