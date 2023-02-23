namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ETask")]
    public partial class ETask
    {
        public int ETaskId { get; set; }

        [StringLength(50)]
        public string ETaskName { get; set; }

        [StringLength(50)]
        public string ETaskStartTime { get; set; }

        [StringLength(50)]
        public string ETaskEndTime { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
