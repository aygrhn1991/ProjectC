namespace ProjectC.Extentions.Entity
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_auth
    {
        public int Id { get; set; }

        public int user_id { get; set; }

        public IdentityType identity_type { get; set; }

        [Required]
        public string identifier { get; set; }

        [Required]
        public string credential { get; set; }
    }
}
