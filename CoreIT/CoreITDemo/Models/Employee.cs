using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class Employee
    {
        public Employee()
        {
            this.SalaryRecords = new HashSet<Salary>();
            this.Address = new HashSet<Address>();
            this.Payments = new HashSet<Payment>();
            this.Assignments = new HashSet<Assignment>();
        }
        [Key]
        public int EmpId { get; set; }
        public string Firstname { get; set; }   
        public string Lastname { get; set; }
        public ImmigrationStatus ImmigrationStatus { get; set; }
        public DateTime HireDate { get; set; }

        public virtual ICollection<Salary> SalaryRecords { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }

    public enum ImmigrationStatus
    {
        PetetionApproved,
        PetetionInitiated,
        PetetionInProcess,
        PetetionDenied,
        RFE,
        RFEInProcess,
        RFEDenied        
    }
}