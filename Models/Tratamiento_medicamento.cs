namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tratamiento_medicamento
    {
        [Display(Name = "ID Tratamiento")]
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTratamiento { get; set; }

        [Display(Name = "ID Medicamento")]
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMedicamento { get; set; }

        [Display(Name = "Cantidad")]
        [Column(TypeName = "numeric")]
        public decimal? cantidad { get; set; }

        [Display(Name = "Medida")]
        [Required]
        [StringLength(10)]
        public string medida { get; set; }
        public string medida2 { get; set; }

        [Display(Name = "Recurrencia")]
        [StringLength(45)]
        public string recurrencia { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Column(TypeName = "date")]
        public DateTime? fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Column(TypeName = "date")]
        public DateTime? fecha_fin { get; set; }

        public virtual Medicamento Medicamento { get; set; }

        public virtual Tratamiento Tratamiento { get; set; }
    }
}
