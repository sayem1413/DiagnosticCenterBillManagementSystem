using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class PatientTestRequestGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;

        public int GetPatientByMobile(string mobileNo)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "select COUNT(PatientName) as [count] from PatientInformation where MobileNo = '" + mobileNo + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = int.Parse(reader["count"].ToString());
            }

            reader.Close();
            connection.Close();

            return count;
        }

        public int SavePatient(PatientTestRequest patientInfo)
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            string query = "INSERT INTO PatientInformation VALUES ('" + patientInfo.PatientName + "','" +
                           patientInfo.PatientBirthDate + "','" + patientInfo.ContactNumber + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public int SavePatientTest(PatientTestRequest patientTest, TestDetails testDetails)
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            string query = "exec spInsertPatientTest '" + testDetails.TestName + "','" +
                           patientTest.ContactNumber + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }
        
    }
}