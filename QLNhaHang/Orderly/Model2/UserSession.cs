namespace Orderly.Model2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSession")]
    public partial class UserSession
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public DateTime? SessionTime { get; set; }

        public virtual Login Login { get; set; }
    }
}
