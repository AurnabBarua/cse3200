namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Operations = new HashSet<Operation>();
            Prescriptions = new HashSet<Prescription>();
            Tasks = new HashSet<Task>();
            Treatments = new HashSet<Treatment>();
        }

        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientName { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
