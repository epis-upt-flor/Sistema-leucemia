namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            Diagnostico = new HashSet<Diagnostico>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idPersonal { get; set; }

        [Display(Name = "DNI")]
        [Required]
        [StringLength(10)]
        public string dni { get; set; }

        [Display(Name = "Nombres")]
        [Required]
        [StringLength(45)]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required]
        [StringLength(45)]
        public string apellidos { get; set; }

        [Display(Name = "Tipo")]
        [Required]
        [StringLength(45)]
        public string tipo { get; set; }

        [Display(Name = "Sexo")]
        public bool sexo { get; set; }

        [Display(Name = "Fecha nac.")]
        [Column(TypeName = "date")]
        public DateTime fecha_nac { get; set; }

        [Display(Name = "Turno")]
        [StringLength(45)]
        public string turno { get; set; }

        [Display(Name = "Celular")]
        [StringLength(45)]
        public string celular { get; set; }

        [Display(Name = "Email")]
        [StringLength(45)]
        public string email { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Display(Name = "Usuario")]
        [Required]
        [StringLength(45)]
        public string usuario { get; set; }

        [Display(Name = "Clave")]
        [Required]
        [StringLength(45)]
        public string clave { get; set; }

        [Display(Name = "Perfil")]
        public byte[] perfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnostico> Diagnostico { get; set; }
    }
}
