namespace Project_3200_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=NewModel1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Emergency> Emergencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Emergency>()
                .Property(e => e.EmergencyProblem)
                .IsUnicode(false);

            modelBuilder.Entity<Emergency>()
                .Property(e => e.EmergencyLink)
                .IsUnicode(false);
        }
    }
}
