using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class TypeWiseReportGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;


        public List<TypeWiseReport> GetTypeWiseReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "exec spTypeWiseReport '" + fromDate + "','" + toDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TypeWiseReport> typeWiseReports = new List<TypeWiseReport>();
            while (reader.Read())
            {
                TypeWiseReport typeReport = new TypeWiseReport();
                typeReport.TestTypeName = reader["TypeName"].ToString();
                typeReport.TotalNoTest = int.Parse(reader["TotalCount"].ToString());
                typeReport.TotalAmount = double.Parse(reader["TotalAmount"].ToString());

                typeWiseReports.Add(typeReport);
            }
            reader.Close();
            connection.Close();

            return typeWiseReports;
        }
    }
}