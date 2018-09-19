using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class TestDetailsGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;

        public int SaveTestDetails(TestDetails testDetails)
        {
            SqlConnection connection=new SqlConnection(connectionDB);
            string query = "INSERT INTO TestDetails(TestName,Fee,TypeID) Values('"+testDetails.TestName+"','"+testDetails.Fee+"','"+testDetails.TypeId+"')";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TestDetails> GetAllTestDetailses()
        {
            SqlConnection connection=new SqlConnection(connectionDB);
            string query = "SELECT TestDetails.TestId, TestDetails.TestName, TestDetails.Fee, TestType.TypeName FROM TestType, TestDetails WHERE TestDetails.TypeID=TestType.TypeID ORDER BY TestDetails.TestName ASC";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestDetails> testDetailses=new List<TestDetails>();
            while (reader.Read())
            {
                int testId = Convert.ToInt32(reader["TestId"].ToString());
                string testName = reader["TestName"].ToString();
                double fee = double.Parse(reader["Fee"].ToString());
                string typeName = reader["TypeName"].ToString();
                TestDetails testDetails = new TestDetails(testId, testName, fee, typeName);
                testDetailses.Add(testDetails);
            }
            reader.Close();
            connection.Close();
            return testDetailses;
        }
        public TestDetails GetTestNameByInputName(string testName)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT * FROM TestDetails WHERE TestName='" + testName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestDetails testDetails = null;
            while (reader.Read())
            {
                string testNameExists = reader["TestName"].ToString();
                testDetails = new TestDetails(testNameExists);
            }
            reader.Close();
            connection.Close();
            return testDetails;
        }

        public double GetTestFee(string testId)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "SELECT * FROM TestDetails WHERE TestId='" + testId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            double fee = 0;
            while (reader.Read())
            {
                fee = double.Parse(reader["Fee"].ToString());
            }
            reader.Close();
            connection.Close();
            return fee;
        }
    }
}