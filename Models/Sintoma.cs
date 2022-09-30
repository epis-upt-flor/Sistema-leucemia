namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sintoma")]
    public partial class Sintoma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sintoma()
        {
            Paciente = new HashSet<Paciente>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idSintoma { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(45)]
        public string tipo { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(45)]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
