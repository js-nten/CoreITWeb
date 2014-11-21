using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreITDemo.Models
{
    public class Payment
    {
        public int EmpId { get; set; }
        public DateTime PaidOn { get; set; }
        public decimal? PaidAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Comments { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Employee Employee { get; set; }
    }

    public enum PaymentType
    {
        MonthlyPay,
        Arrears,
        MiscExpenses
    }
}