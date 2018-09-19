using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBManagementSystemApp.BLL;

namespace DCBManagementSystemApp.UI
{
    public partial class TestTypeUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager=new TestTypeManager();
            



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveTypeButton_Click(object sender, EventArgs e)
        {
            TestType testTypeName=new TestType(typeNameTextBox.Text);
            if (CheckRecuiredField())
            {
                if (testTypeManager.IsTestTypeExists(testTypeName))
                {
                    typeExistLabel.Text = "This Test Type already Exists!!!!";
                    typeExistLabel.ForeColor = System.Drawing.Color.Red;
                    typeNameTextBox.Text = "";
                    typeNameTextBox.Focus();
                    return;
                }

                int rowAffected = testTypeManager.SaveTestType(testTypeName);
                if (rowAffected > 0)
                {
                    typeExistLabel.Text = "Save successful!!!";
                    typeExistLabel.ForeColor = System.Drawing.Color.Green;
                    LoadAllTestTypes();
                }
                else
                {
                    typeExistLabel.Text = "Invalid insert!!";
                    typeExistLabel.ForeColor = System.Drawing.Color.Red;
                    typeNameTextBox.Focus();
                    typeNameTextBox.Text = "";
                }
            }
            else
            {
                typeExistLabel.Text = "Please enter a valid Test Type!! ";
                typeExistLabel.ForeColor = System.Drawing.Color.Red;
                typeNameTextBox.Focus();
                return;
            }

            
            typeNameTextBox.Text = "";
        }

        private void LoadAllTestTypes()
        {
            List<TestType> testTypes = testTypeManager.GetAllTestTypes();
            testTypeGridView.DataSource = testTypes;
            testTypeGridView.DataBind();
        }

        private bool CheckRecuiredField()
        {
            if (typeNameTextBox.Text != string.Empty)
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