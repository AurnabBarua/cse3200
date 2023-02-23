namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int TaskId { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskProblem { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskDateTime { get; set; }

        public int PatientId { get; set; }

        [StringLength(50)]
        public string Activity { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
