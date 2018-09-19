using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway typeWiseReportGateway = new TypeWiseReportGateway();


        public List<TypeWiseReport> GetTypeWiseReport(DateTime fromDate, DateTime toDate)
        {
            return typeWiseReportGateway.GetTypeWiseReport(fromDate, toDate);
        }
    }
}