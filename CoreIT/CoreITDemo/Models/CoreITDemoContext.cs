using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class CoreITDemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CoreITDemo.Models.CoreITDemoContext>());

        public CoreITDemoContext() : base("name=CoreITDemoContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<BillingDetails> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.EmpId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Salary>().HasKey(s => new { s.EmpId, s.EffectiveFrom, s.ExpirationDate });
            modelBuilder.Entity<Salary>().HasRequired(s => s.Employee).WithMany(e => e.SalaryRecords).HasForeignKey(p => p.EmpId).WillCascadeOnDelete();

            modelBuilder.Entity<Payment>().HasKey(p => new { p.EmpId, p.PaymentType });
            modelBuilder.Entity<Payment>().HasRequired(p => p.Employee).WithMany(e => e.Payments).HasForeignKey(p => p.EmpId).WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>().HasKey(a => a.AssignmentId);
            modelBuilder.Entity<Assignment>().HasRequired(a => a.Employee).WithMany(e => e.Assignments).HasForeignKey(a => a.EmpId).WillCascadeOnDelete();
            modelBuilder.Entity<Assignment>().HasRequired(a => a.Vendor).WithMany(e => e.Assignment).HasForeignKey(a => a.VendorId).WillCascadeOnDelete();

            modelBuilder.Entity<BillingDetails>().HasKey(b => b.BillingId);
            modelBuilder.Entity<BillingDetails>().HasRequired(b => b.Assignment).WithMany(a => a.BillingDetails).HasForeignKey(b => b.AssignmentId).WillCascadeOnDelete();
        }

        
    }
}
