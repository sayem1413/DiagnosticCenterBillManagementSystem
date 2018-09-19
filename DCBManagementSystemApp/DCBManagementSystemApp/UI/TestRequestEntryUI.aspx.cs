using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBManagementSystemApp.BLL;
using DCBManagementSystemApp.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace DCBManagementSystemApp.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        TestDetailsManager testDetailsManager = new TestDetailsManager();
        PatientTestRequestManager patientTestRequestManager = new PatientTestRequestManager();
        BillPaymentManager billPaymentManager = new BillPaymentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropdwonListBound();
                AddDefaultRecordGridView();
            }
            else
            {
                int dropDownValueChangeForFeeTextBox = int.Parse(selectTestTypeDropDown.SelectedValue);

                if (dropDownValueChangeForFeeTextBox == 0)
                {
                    selectTestTypeDropDown_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }

        }

        private void DropdwonListBound()
        {
            List<TestDetails> testDetailses = testDetailsManager.GetAllTestDetails();
            selectTestTypeDropDown.DataSource = testDetailses;
            selectTestTypeDropDown.DataTextField = "TestName";
            selectTestTypeDropDown.DataValueField = "TestId";
            selectTestTypeDropDown.DataBind();
            selectTestTypeDropDown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }

        protected void selectTestTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = selectTestTypeDropDown.SelectedValue;

            if (id != "0")
            {
                feeTextBox.Text = testDetailsManager.GetTestFee(id).ToString();
            }
        }

        protected void AddDefaultRecordGridView() // Declare ViewState Method
        {
            DataTable dataTable = new DataTable("TestsSetup");
            DataRow dataRow = null;
            dataTable.Columns.Add(new DataColumn("SL"));
            dataTable.Columns.Add(new DataColumn("TestName"));
            dataTable.Columns.Add(new DataColumn("Fee"));
            dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);

            ViewState["TestsSetup"] = dataTable;

            requestTestGridView.DataSource = dataTable;
            requestTestGridView.DataBind();
        }

        protected void requestTestGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
        }

        protected void LoadGridData()
        {
            if (ViewState["TestsSetup"] != null)
            {
                DataTable currentTable = (DataTable) ViewState["TestsSetup"];
                DataRow currentRow = null;
                if (currentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= currentTable.Rows.Count; i++)
                    {
                        currentRow = currentTable.NewRow();
                        currentRow["TestName"] = selectTestTypeDropDown.SelectedItem.Text;
                        currentRow["Fee"] = feeTextBox.Text;
                    }

                    if (currentTable.Rows[0][1].ToString() == string.Empty)
                    {
                        currentTable.Rows[0].Delete();
                        currentTable.AcceptChanges();
                    }

                    for (int i = 0; i < currentTable.Rows.Count; i++)
                    {
                        if (currentTable.Rows[i][1].ToString() == selectTestTypeDropDown.SelectedItem.Text)
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    currentTable.Rows.Add(currentRow);
                    ViewState["TestsSetup"] = currentTable;
                    requestTestGridView.DataSource = currentTable;
                    requestTestGridView.DataBind();

                }
            }

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (CheckRequiredField())
            {
                if (selectTestTypeDropDown.SelectedIndex > 0)
                {
                    LoadGridData();
                    GetTotal();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }

        private void GetTotal()
        {
            double total = 0;
            if (ViewState["TestsSetup"] != null)
            {
                DataTable currentTable = (DataTable) ViewState["TestsSetup"];

                for (int i = 0; i < currentTable.Rows.Count; i++)
                {
                    string fee = currentTable.Rows[i][2].ToString();
                    total += Convert.ToDouble(fee);
                }
                totallTextBox.Text = total.ToString();
            }
        }

        protected void requestEntryButton_Click(object sender, EventArgs e)
        {
            string patientName = patientNameTextBox.Text;
            DateTime dateOfBirth = Convert.ToDateTime(birthDateTextBox.Value);
            string mobileNo = mobileNoTextBox.Text;
            PatientTestRequest patientInfo = new PatientTestRequest(patientName, dateOfBirth, mobileNo);
            if (CheckRequiredField())
            {
                if (patientTestRequestManager.IsPatientExist(patientInfo))
                {
                    SavePatientTestInfo();
                    SaveBillAmount();
                    InvoiceReport();
                }
                else
                {
                    patientTestRequestManager.SavePatient(patientInfo);
                    SavePatientTestInfo();
                    SaveBillAmount();
                    InvoiceReport();
                }
                
            }

        }

        private bool CheckRequiredField()
        {
            string name = patientNameTextBox.Text;
            string date = birthDateTextBox.Value;
            string mobile = mobileNoTextBox.Text;
            if (name != string.Empty && date != string.Empty && mobile != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SavePatientTestInfo()
        {
            TestDetails testDetails = new TestDetails();
            PatientTestRequest patientTestRequest = new PatientTestRequest();

            if (ViewState["TestsSetup"] != null)
            {
                DataTable currentTable = (DataTable) ViewState["TestsSetup"];

                for (int i = 0; i < currentTable.Rows.Count; i++)
                {
                    testDetails.TestName = currentTable.Rows[i][1].ToString();
                    patientTestRequest.ContactNumber = mobileNoTextBox.Text;
                    patientTestRequestManager.SavePatientTest(patientTestRequest, testDetails);
                }
            }
        }

        private void SaveBillAmount()
        {
            BillPayment billPayment = new BillPayment();
            billPayment.TotalAmount = Convert.ToDouble(totallTextBox.Text);
            billPayment.ContactNumber = mobileNoTextBox.Text;
            billPaymentManager.SaveTotalBill(billPayment);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }  

        private void InvoiceReport()
        {
            int lastInsertedBillNo = billPaymentManager.LastInsertedBillNo();
            string name = patientNameTextBox.Text;

            int totallFee = Convert.ToInt32(totallTextBox.Text);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "<table width = '100%' cellspacing='0' cellpadding ='2'><tr><td></td><td align = 'centre'>Void Diagnostic Center Limited <br/> AEPZ, Narayangong, Dhaka <br/> Phone: 0123456789</td><td></td></tr></table>");

            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'");
            stringBuilder.Append("<tr><td align = 'centre'>Bill No- " + lastInsertedBillNo + "</td>");
            stringBuilder.Append("<td>Lab No: </td></tr>");
            stringBuilder.Append("<tr><td align = 'centre'>Patient Name: " + name + "</td>");
            stringBuilder.Append("<td>Ref. By: </td></tr></table>");

            StringWriter stringWriter = new StringWriter(stringBuilder);
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            requestTestGridView.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);


            pdfDocument.Open();
            htmlparser.Parse(stringReader);
            Paragraph newParagraph=new Paragraph("                                                                                                     Totall Amount = "+totallFee+"");
            pdfDocument.Add(newParagraph);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Request_Entry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDocument);
            Response.End();

            requestTestGridView.AllowPaging = true;
            requestTestGridView.DataBind();
        }
    }
}