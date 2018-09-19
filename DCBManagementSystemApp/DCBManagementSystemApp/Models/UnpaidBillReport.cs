using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBManagementSystemApp.Models
{
    public class UnpaidBillReport
    {
        public int BillNo { get; set; }
        public string PatientMobileNo { get; set; }
        public string PatientName { get; set; }
        public double UnpaidBillAmount { get; set; }
    }
}