using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CoreITDemo.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        //Employee Id or Vendor Id or WorkPlace Id
        public int EntityId { get; set; }
        public AddressEntity EntityType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
        public bool IsCurrent { get; set; }

        public virtual Employee Employee { get; set; }   
    }

    public enum AddressEntity
    {
        Employee,
        Vendor,
        Workplace
    }
}