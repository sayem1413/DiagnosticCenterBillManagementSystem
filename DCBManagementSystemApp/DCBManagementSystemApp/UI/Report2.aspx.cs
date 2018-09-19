using System;
using System.Collections.Generic;
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
    public partial class Report2 : System.Web.UI.Page
    {

        TypeWiseReportManager typeWiseReportManager = new TypeWiseReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void typeShowButton_Click(object sender, EventArgs e)
        {
            if (fromDateInput.Value != string.Empty && toDateInput.Value != string.Empty)
            {
                LoadTypeWiseReport();
                GetTotalAmount();
            }
            else
            {
                return;
            }
        }

        private void GetTotalAmount()
        {
            double total = 0;
            for (int i = 0; i < typeReportGridView.Rows.Count; i++)
            {
                string amount = (typeReportGridView.Rows[i].FindControl("totalAmountLabel") as Label).Text;
                total += Convert.ToDouble(amount);
            }

            totalAmountTestTextBox.Text = total.ToString();
        }

        private void LoadTypeWiseReport()
        {
            DateTime fromDate = Convert.ToDateTime(fromDateInput.Value);
            DateTime toDate = Convert.ToDateTime(toDateInput.Value);

            List<TypeWiseReport> testWiseReports = typeWiseReportManager.GetTypeWiseReport(fromDate, toDate);
            typeReportGridView.DataSource = testWiseReports;
            typeReportGridView.DataBind();
        }



        protected void pdfTypeButton_Click(object sender, EventArgs e)
        {
            GetAllInformationInPdf();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        private void GetAllInformationInPdf()
        {
            int totallFee = Convert.ToInt32(totalAmountTestTextBox.Text);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "<table width = '100%' cellspacing='0' cellpadding ='2'><tr><td></td><td align = 'centre'>Void Diagnostic Center Limited <br/> AEPZ, Narayangong, Dhaka <br/> Phone: 0123456789</td><td></td></tr></table>");

            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'> <tr><td></td>");
            stringBuilder.Append("<td><u>Type Wise Test Report Details</u></td>");
            stringBuilder.Append("<td></td></tr></table><br/><br/>");

            StringWriter stringWriter = new StringWriter(stringBuilder);
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            typeReportGridView.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);


            pdfDocument.Open();
            htmlparser.Parse(stringReader);
            Paragraph newParagraph = new Paragraph("                                                                                                     Totall Amount = " + totallFee + "");
            pdfDocument.Add(newParagraph);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Request_Entry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDocument);
            Response.End();

            typeReportGridView.AllowPaging = true;
            typeReportGridView.DataBind();
        }
    }
}