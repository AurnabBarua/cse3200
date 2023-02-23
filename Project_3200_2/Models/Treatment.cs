namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        public int TreatmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string TreatmentProblem { get; set; }

        [Required]
        [StringLength(50)]
        public string TreatmentDateTime { get; set; }

        public int? PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
