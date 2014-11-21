using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreITDemo.ViewModels
{
    public class VendorViewModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool? IsActive { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
    }
}