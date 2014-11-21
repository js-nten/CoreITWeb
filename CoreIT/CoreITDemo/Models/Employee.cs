using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class Employee
    {
        public Employee()
        {
            this.SalaryRecords = new HashSet<Salary>();
            this.Address = new HashSet<Address>();
        }
        [Key]
        public int EmpId { get; set; }
        public string Firstname { get; set; }   
        public string Lastname { get; set; }
        public ImmigrationStatus ImmigrationStatus { get; set; }
        public DateTime HireDate { get; set; }

        public virtual ICollection<Salary> SalaryRecords { get; set; }
        public virtual ICollection<Address> Address { get; set; }
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