using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreITDemo.Models
{
    public class Assignment
    {
        public Assignment()
        {
            this.BillingDetails = new HashSet<BillingDetails>();
        }
        public int AssignmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmpId { get; set; }
        public int VendorId { get; set; }
        public string Workplace { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal EmpShare { get; set; }        
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
    }
}