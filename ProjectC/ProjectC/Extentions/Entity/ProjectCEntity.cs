namespace ProjectC.Extentions.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectCEntity : DbContext
    {
        public ProjectCEntity()
            : base("name=ProjectCEntity")
        {
        }

        public virtual DbSet<phone_validate_code> phone_validate_code { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_auth> user_auth { get; set; }
        public virtual DbSet<user_auth_state> user_auth_state { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
