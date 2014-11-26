using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class Vendor
    {
        public Vendor()
        {
            this.Address = new HashSet<Address>();
            this.Assignment = new HashSet<Assignment>();
        }

        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; }
    }
}