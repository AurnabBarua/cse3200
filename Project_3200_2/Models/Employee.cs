namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeePhone { get; set; }
    }
}
