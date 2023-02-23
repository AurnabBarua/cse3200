namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int DoctorId { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorCatagory { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorPhone { get; set; }

        public int? DoctorRoom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
