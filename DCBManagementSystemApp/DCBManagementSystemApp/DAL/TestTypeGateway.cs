using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DCBManagementSystemApp.DAL
{
    public class TestTypeGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;
        public int SaveTestType(TestType testTypeName)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "INSERT INTO TestType(TypeName)VALUES('" + testTypeName.TestTypeName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public TestType GetTestTypeNameByInputName(string testTypeName)
        {
            SqlConnection connection=new SqlConnection(connectionDB);
            string query = "SELECT * FROM TestType WHERE TypeName='" + testTypeName + "'";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestType testType = null;
            while (reader.Read())
            {
                string typeName = reader["TypeName"].ToString();
                testType = new TestType(typeName);
            }
            reader.Close();
            connection.Close();
            return testType;
        }

        public List<TestType> GetAllTypeName()
        {
            SqlConnection connection=new SqlConnection(connectionDB);
            string query = "SELECT * FROM TestType ORDER BY TypeID ASC";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestType> testTypes=new List<TestType>();
            while (reader.Read())
            {
                int testId = Convert.ToInt32(reader["TypeID"].ToString());
                string testName = reader["TypeName"].ToString();
                TestType testType=new TestType(testId, testName);
                testTypes.Add(testType);
            }
            reader.Close();
            connection.Close();
            return testTypes;
        }
    }
}