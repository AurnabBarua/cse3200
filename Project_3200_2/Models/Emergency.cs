namespace Project_3200_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emergency")]
    public partial class Emergency
    {
        public int EmergencyId { get; set; }

        [StringLength(50)]
        public string EmergencyProblem { get; set; }

        [StringLength(50)]
        public string EmergencyLink { get; set; }
    }
}
