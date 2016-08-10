namespace ProjectC.Extentions.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class phone_validate_code
    {
        [Key]
        [StringLength(100)]
        public string phone { get; set; }

        [Required]
        public string validate_code { get; set; }
    }
}
