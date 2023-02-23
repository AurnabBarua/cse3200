namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operation")]
    public partial class Operation
    {
        public int OperationId { get; set; }

        public int NurseId { get; set; }

        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string OperationDateTime { get; set; }

        [StringLength(50)]
        public string DoctorName { get; set; }

        [StringLength(50)]
        public string Activity { get; set; }

        public virtual Nurse Nurse { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
