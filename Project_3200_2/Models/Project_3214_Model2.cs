namespace Project_3200_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Project_3214_Model2 : DbContext
    {
        public Project_3214_Model2()
            : base("name=Project_3214_Model2")
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ETask> ETasks { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }

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

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Prescriptions)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePassword)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeePhone)
                .IsUnicode(false);

            modelBuilder.Entity<ETask>()
                .Property(e => e.ETaskName)
                .IsUnicode(false);

            modelBuilder.Entity<ETask>()
                .Property(e => e.ETaskStartTime)
                .IsUnicode(false);

            modelBuilder.Entity<ETask>()
                .Property(e => e.ETaskEndTime)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.NurseName)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.NurseEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.NursePassword)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.NurseAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.NursePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .HasMany(e => e.Operations)
                .WithRequired(e => e.Nurse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.OperationDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.DoctorName)
                .IsUnicode(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.Activity)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Operations)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Prescriptions)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.PrescriptionMessage)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskProblem)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskDateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Activity)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentProblem)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentDateTime)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Project_3200_2.Models.Admin> Admins { get; set; }
    }
}
