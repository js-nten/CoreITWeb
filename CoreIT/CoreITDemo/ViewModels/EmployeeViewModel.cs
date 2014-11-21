using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CoreITDemo.Models;

namespace CoreITDemo.ViewModels
{
    public class EmployeeDTO
    {
        public int EmpId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string ImmigrationStatus { get; set; }
        public decimal? Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? SalaryEffectiveDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }

        public string FullAddress { get; set; }

    }
}