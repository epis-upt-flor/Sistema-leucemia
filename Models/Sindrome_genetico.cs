namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sindrome_genetico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sindrome_genetico()
        {
            Condicion_previa = new HashSet<Condicion_previa>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idSindrome_genetico { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(45)]
        public string nombre { get; set; }

        [Display(Name = "Grado")]
        [StringLength(45)]
        public string grado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Condicion_previa> Condicion_previa { get; set; }
    }
}
