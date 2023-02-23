namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nurse")]
    public partial class Nurse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nurse()
        {
            Operations = new HashSet<Operation>();
        }

        public int NurseId { get; set; }

        [Required]
        [StringLength(50)]
        public string NurseName { get; set; }

        [Required]
        [StringLength(50)]
        public string NurseEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string NursePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string NurseAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string NursePhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
