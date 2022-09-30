namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Control_sangre
    {
        [Key]
        [Display(Name = "ID")]
        public int idControl_sangre { get; set; }

        [Display(Name = "Leucocitos")]
        public int? leucocitos { get; set; }

        [Display(Name = "EMR")]
        [Column(TypeName = "numeric")]
        public decimal? EMR { get; set; }

        [Display(Name = "Hemoglobina")]
        [Column(TypeName = "numeric")]
        public decimal? hemoglobina { get; set; }

        [Display(Name = "Plaquetas")]
        [Column(TypeName = "numeric")]
        public decimal? plaquetas { get; set; }

        [Display(Name = "Linfoblasto")]
        [Column(TypeName = "numeric")]
        public decimal? linfoblasto { get; set; }

        [Display(Name = "Neutrofilos")]
        [Column(TypeName = "numeric")]
        public decimal? neutrofilos { get; set; }

        [Display(Name = "ID Diagnostico")]
        public int idDiagnostico { get; set; }

        public virtual Diagnostico Diagnostico { get; set; }
    }
}
