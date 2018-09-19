using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.DAL
{
    public class BillPaymentGateway
    {
        private string connectionDB = WebConfigurationManager.ConnectionStrings["DCBMSConnectionString"].ConnectionString;

        public int SaveTotalBill(BillPayment billPayment)
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            string query = "INSERT INTO PatientBillPayment (TotalAmount, MobileNo) values ('" + billPayment.TotalAmount + "','" + billPayment.ContactNumber + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int LastInsertedBillNo()
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            string query = "select top 1 BillNo from PatientBillPayment order by BillNo desc";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int lastnsertedBillNo = 0;

            while (reader.Read())
            {
                BillPayment billPayment = new BillPayment();
                billPayment.BillNo = int.Parse(reader["BillNo"].ToString());
                lastnsertedBillNo = billPayment.BillNo;
            }
            reader.Close();
            connection.Close();

            return lastnsertedBillNo;
        }


        public List<TestDetails> RequestTestsDetails(int billNo)
        {
            SqlConnection connection = new SqlConnection(connectionDB);
            string query = "exec spPatientRequestTests '" + billNo + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<TestDetails> testsDetailses = new List<TestDetails>();

            while (reader.Read())
            {
                TestDetails tests = new TestDetails();
                tests.TestName = reader["TestName"].ToString();
                tests.Fee = Convert.ToDouble(reader["Fee"].ToString());

                testsDetailses.Add(tests);
            }
            reader.Close();
            connection.Close();

            return testsDetailses;
        }

        public BillPayment GetRequestBillInfoByBillNo(int billNo)
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            string query = "select * from PatientBillPayment where BillNo = '" + billNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            BillPayment billPayment = null;
            while (reader.Read())
            {
                billPayment = new BillPayment();
                billPayment.TestDate = Convert.ToDateTime(reader["BillDate"].ToString());
                billPayment.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                billPayment.PaidAmount = Convert.ToDouble(reader["PaidAmount"].ToString());
                billPayment.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
            }

            reader.Close();
            connection.Close();

            return billPayment;
        }

        public int UpdateRequestBillInformation(BillPayment billPayment)
        {
            SqlConnection connection = new SqlConnection(connectionDB);

            double paidAmount = billPayment.PaidAmount;

            int billNo = billPayment.BillNo;

            string query = "exec spUpdatePatientBillInfo '" + paidAmount + "','" + billNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}