namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tsugerido_Medicamento
    {
        [Display(Name = "ID")]
        [Key]
        public int idTsugerido_Medicamento { get; set; }

        [Display(Name = "Medicamento")]
        [StringLength(45)]
        public string codigo_med { get; set; }

        [Display(Name = "Cantidad")]
        [Column(TypeName = "numeric")]
        public decimal? cantidad { get; set; }

        [Display(Name = "Medida")]
        [StringLength(10)]
        public string medida { get; set; }

        [Display(Name = "Recurrencia")]
        [StringLength(45)]
        public string recurrencia { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Column(TypeName = "date")]
        public DateTime? fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Column(TypeName = "date")]
        public DateTime? fecha_fin { get; set; }

        [Display(Name = "ID Tsugerido")]
        public int idTsugerido { get; set; }

        public virtual Tratamiento_sugerido Tratamiento_sugerido { get; set; }
    }
}
