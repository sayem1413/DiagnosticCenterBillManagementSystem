using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class UnpadiBillReportGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;


        public List<UnpaidBillReport> GetUnpaidBillReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "exec spUnpaidBillReport '" + fromDate + "','" + toDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<UnpaidBillReport> unpaidBillReports = new List<UnpaidBillReport>();
            while (reader.Read())
            {
                UnpaidBillReport unpaidBillReport = new UnpaidBillReport();
                unpaidBillReport.BillNo = Convert.ToInt32(reader["BillNo"].ToString());
                unpaidBillReport.PatientMobileNo = reader["MobileNo"].ToString();
                unpaidBillReport.PatientName = reader["PatientName"].ToString();
                unpaidBillReport.UnpaidBillAmount = double.Parse(reader["DueAmount"].ToString());

                unpaidBillReports.Add(unpaidBillReport);
            }
            reader.Close();
            connection.Close();

            return unpaidBillReports;
        }
    }
}