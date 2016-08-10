namespace ProjectC.Extentions.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_auth_state
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        public bool phone_auth { get; set; }

        public bool email_auth { get; set; }

        public bool is_lockout { get; set; }

        public int access_failed_count { get; set; }

        [Required]
        public string security_stamp { get; set; }
    }
}
