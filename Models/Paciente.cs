namespace Sistema_Leucemia_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Condicion_previa = new HashSet<Condicion_previa>();
            Diagnostico = new HashSet<Diagnostico>();
            Sintoma = new HashSet<Sintoma>();
        }

        [Display(Name = "ID")]
        [Key]
        public int idPaciente { get; set; }

        [Display(Name = "DNI")]
        [Required]
        [StringLength(45)]
        public string dni { get; set; }

        [Display(Name = "HC")]
        [Required]
        [StringLength(10)]
        public string hc { get; set; }

        [Display(Name = "Nombres")]
        [Required]
        [StringLength(45)]
        public string nombres { get; set; }

        [Display(Name = "Ap.Paterno")]
        [Required]
        [StringLength(45)]
        public string ap_paterno { get; set; }

        [Display(Name = "Ap.Materno")]
        [Required]
        [StringLength(45)]
        public string ap_materno { get; set; }

        [Display(Name = "Sexo")]
        public bool sexo { get; set; }

        [Display(Name = "Fecha nac.")]
        [Column(TypeName = "date")]
        public DateTime fecha_nac { get; set; }

        [Display(Name = "Procedencia")]
        [Required]
        [StringLength(45)]
        public string procedencia { get; set; }

        [Display(Name = "Distrito")]
        [Required]
        [StringLength(45)]
        public string distrito { get; set; }

        [Display(Name = "Residencia")]
        [Required]
        [StringLength(45)]
        public string residencia { get; set; }

        [Display(Name = "Dirección")]
        [Column(TypeName = "text")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Direc. referencia")]
        [Column(TypeName = "text")]
        public string direc_referencia { get; set; }

        [Display(Name = "Celular")]
        [Required]
        [StringLength(45)]
        public string celular { get; set; }

        [Display(Name = "Email")]
        [StringLength(45)]
        public string email { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Condicion_previa> Condicion_previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnostico> Diagnostico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sintoma> Sintoma { get; set; }
    }
}
