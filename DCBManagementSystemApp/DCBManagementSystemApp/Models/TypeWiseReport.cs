using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBManagementSystemApp.Models
{
    public class TypeWiseReport
    {
        public string TestTypeName { get; set; }
        public int TotalNoTest { get; set; }
        public double TotalAmount { get; set; }
    }
}