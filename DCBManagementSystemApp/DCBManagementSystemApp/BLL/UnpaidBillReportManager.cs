using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class UnpaidBillReportManager
    {
        UnpadiBillReportGateway unpadiBillReportGateway = new UnpadiBillReportGateway();

        public List<UnpaidBillReport> GetUnpaidBillReport(DateTime fromDate, DateTime toDate)
        {
            return unpadiBillReportGateway.GetUnpaidBillReport(fromDate, toDate);
        }
    }
}