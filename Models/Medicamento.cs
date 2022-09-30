namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicamento")]
    public partial class Medicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicamento()
        {
            Tratamiento_medicamento = new HashSet<Tratamiento_medicamento>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idMedicamento { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Abreviacion")]
        [StringLength(5)]
        public string abreviacion { get; set; }

        [Display(Name = "Descripccion")]
        [StringLength(45)]
        public string descripccion { get; set; }

        [Display(Name = "Componente")]
        [StringLength(45)]
        public string componente { get; set; }

        [Display(Name = "Cantidad")]
        [Column(TypeName = "numeric")]
        public decimal cantidad { get; set; }

        [Display(Name = "Medida")]
        [Required]
        [StringLength(10)]
        public string medida { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tratamiento_medicamento> Tratamiento_medicamento { get; set; }
    }
}
