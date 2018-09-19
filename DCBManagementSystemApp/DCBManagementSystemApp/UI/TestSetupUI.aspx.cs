using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBManagementSystemApp.BLL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.UI
{
    public partial class TestSetupUI1 : System.Web.UI.Page
    {
        TestTypeManager testTypeManager=new TestTypeManager();
        TestDetailsManager testDetailsManager=new TestDetailsManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TestType> testTypes = testTypeManager.GetAllTestTypes();
                testTypeDropDown.DataSource = testTypes;
                testTypeDropDown.DataTextField = "TestTypeName";
                testTypeDropDown.DataValueField = "TypeId";
                testTypeDropDown.DataBind();
            }
        }

        protected void testDetailButton_Click(object sender, EventArgs e)
        {
            TestDetails testDetails = new TestDetails(testNameTextBox.Text, Convert.ToInt32(testFeeTestBox.Text));
            int selectedTestType = Convert.ToInt32(testTypeDropDown.SelectedValue.ToString());
            testDetails.TypeId = selectedTestType;
            if (CheckRecuiredField())
            {
                if (testDetailsManager.IsTestNameExists(testDetails))
                {
                    testExixtsLabel.Text = "This Test Name already Exists!!!!";
                    testExixtsLabel.ForeColor = System.Drawing.Color.Red;
                    testNameTextBox.Text = "";
                    testFeeTestBox.Text = "";
                    testNameTextBox.Focus();
                    return;
                }

                int rowAffected = testDetailsManager.SaveTestDetails(testDetails);
                if (rowAffected > 0)
                {
                    testExixtsLabel.Text = "Save successfully Test Name!";
                    testExixtsLabel.ForeColor = System.Drawing.Color.Green;
                    LoadAllTestDetails();
                }
                else
                {
                    testExixtsLabel.Text = "Invalid Insert!!!";
                    testExixtsLabel.ForeColor = System.Drawing.Color.Red;
                    testNameTextBox.Text = "";
                    testFeeTestBox.Text = "";
                    testNameTextBox.Focus();
                }
            }

            
            testNameTextBox.Text = "";
            testFeeTestBox.Text = "";

        }

        private void LoadAllTestDetails()
        {
            List<TestDetails> testDetailses=testDetailsManager.GetAllTestDetails();
            testDetailsGridView.DataSource = testDetailses;
            testDetailsGridView.DataBind();
        }

        private bool CheckRecuiredField()
        {
            if (testNameTextBox.Text != string.Empty && testFeeTestBox.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}