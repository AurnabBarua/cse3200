namespace Project_3200_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TreatmentModel : DbContext
    {
        public TreatmentModel()
            : base("name=TreatmentModel")
        {
        }

        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .Property(e => e.OperationDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskProblem)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentProblem)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentDateTime)
                .IsUnicode(false);
        }
    }
}
