using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBManagementSystemApp.Models
{
    public class BillPayment
    {
        public int BillNo { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public string ContactNumber { get; set; }
        public DateTime TestDate { get; set; }
    }
}