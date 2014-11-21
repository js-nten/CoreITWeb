using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class Salary
    {           
        public int EmpId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime ExpirationDate { get; set; }
        [Required]
        public decimal PerW2 { get; set; }
        [Required]
        public decimal PerHour { get; set; }
        [Required]
        public decimal EmpHourlyShare { get; set; }
        public string Comments { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}