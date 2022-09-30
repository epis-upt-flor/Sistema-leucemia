namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tratamiento_previo
    {
        [Display(Name = "ID")]
        [Key]
        public int idTratamiento_previo { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Grado")]
        [StringLength(45)]
        public string grado { get; set; }

        [Display(Name = "Grado elevado")]
        [StringLength(45)]
        public string grado_elev { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Column(TypeName = "date")]
        public DateTime? fecha_inicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Column(TypeName = "date")]
        public DateTime? fecha_fin { get; set; }

        [Display(Name = "ID Condición previa")]
        public int idCondicion_previa { get; set; }

        public virtual Condicion_previa Condicion_previa { get; set; }
    }
}
