using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBManagementSystemApp.BLL;
using DCBManagementSystemApp.Models;
using Org.BouncyCastle.Asn1.Esf;

namespace DCBManagementSystemApp.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {

        BillPaymentManager billPaymentManager=new BillPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (billNoTextBox.Text != string.Empty)
            {
                LastRequestTestsDetails();
                RequestBillInformation();
            }
            else
            {
                return;
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            if (billNoTextBox.Text != string.Empty && amountTextBox.Text != string.Empty)
            {
                BillPayment billPayment = new BillPayment();

                billPayment.BillNo = int.Parse(billNoTextBox.Text);
                billPayment.PaidAmount = double.Parse(amountTextBox.Text);

                billPaymentManager.UpdateRequestBillInformation(billPayment);
                RequestBillInformation();
            }
            else
            {
                return;
            }
        }

        private void LastRequestTestsDetails()
        {
            int billNo = Convert.ToInt32(billNoTextBox.Text);
            List<TestDetails> requestTestDetailses = billPaymentManager.RequestTestsDetails(billNo);

            orderTestGridview.DataSource = requestTestDetailses;
            orderTestGridview.DataBind();
        }

        private void RequestBillInformation()
        {
            int billNo = Convert.ToInt32(billNoTextBox.Text);
 
            BillPayment billPayment=new BillPayment();

            billPayment = billPaymentManager.GetRequestBillInfoByBillNo(billNo);

            billDateLabel.Text = billPayment.TestDate.ToString();
            totallFeeLabel.Text = billPayment.TotalAmount.ToString();
            paidAmountLabel.Text = billPayment.PaidAmount.ToString();
            deuAmountLabel.Text = billPayment.DueAmount.ToString();
            
        }
    }
}