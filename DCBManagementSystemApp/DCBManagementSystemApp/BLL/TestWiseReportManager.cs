using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class TestWiseReportManager
    {
        TestWiseReportGateway testWiseReportGateway = new TestWiseReportGateway();

        public List<TestWiseReport> GetTestWiseReport(DateTime fromDate, DateTime toDate)
        {
            return testWiseReportGateway.GetTestWiseReport(fromDate, toDate);
        }
    }
}