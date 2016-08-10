namespace ProjectC.Extentions.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int Id { get; set; }

        [Required]
        public string user_name { get; set; }
    }
}
