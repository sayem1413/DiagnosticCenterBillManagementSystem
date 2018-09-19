using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class BillPaymentManager
    {
        BillPaymentGateway billPaymentGateway = new BillPaymentGateway();

        public int SaveTotalBill(BillPayment billPayment)
        {
            return billPaymentGateway.SaveTotalBill(billPayment);
        }

        public int LastInsertedBillNo()
        {
            return billPaymentGateway.LastInsertedBillNo();
        }


        internal List<TestDetails> RequestTestsDetails(int billNo)
        {
            return billPaymentGateway.RequestTestsDetails(billNo);
        }

        public BillPayment GetRequestBillInfoByBillNo(int billNo)
        {
            return billPaymentGateway.GetRequestBillInfoByBillNo(billNo);
        }

        public int UpdateRequestBillInformation(BillPayment billPayment)
        {
            return billPaymentGateway.UpdateRequestBillInformation(billPayment);
        }
    }
}