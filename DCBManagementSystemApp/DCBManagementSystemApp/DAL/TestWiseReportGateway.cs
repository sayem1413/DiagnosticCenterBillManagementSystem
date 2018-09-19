using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class TestWiseReportGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;


        public List<TestWiseReport> GetTestWiseReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "exec spTestWiseReport '" + fromDate + "','" + toDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestWiseReport> testWiseReport = new List<TestWiseReport>();
            while (reader.Read())
            {
                TestWiseReport testReport = new TestWiseReport();
                testReport.TestName = reader["TestName"].ToString();
                testReport.TotalNoTest = int.Parse(reader["TotalTest"].ToString());
                testReport.TotalAmount = double.Parse(reader["TotalAmount"].ToString());

                testWiseReport.Add(testReport);
            }
            reader.Close();
            connection.Close();

            return testWiseReport;
        }
    }
}