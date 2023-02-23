namespace Project_3200_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DoctorModel : DbContext
    {
        public DoctorModel()
            : base("name=DoctorModel")
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorCatagory)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.DoctorPhone)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Project_3200_2.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Project_3200_2.Models.Operation> Operations { get; set; }
    }
}
