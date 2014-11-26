using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreITDemo.Models
{
    public class BillingDetails
    {        
        public int BillingId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal TotalHours { get; set; }
        public decimal ActualHours { get; set; }
        public string Comments { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}