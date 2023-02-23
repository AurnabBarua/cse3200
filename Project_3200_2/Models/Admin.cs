namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        [StringLength(50)]
        public string AdminEmail { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }
    }
}
