using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;
using DCBManagementSystemApp.Models;

namespace DCBManagementSystemApp.BLL
{
    public class TestDetailsManager
    {
        TestDetailsGateway testDetailsGateway=new TestDetailsGateway();

        public bool IsTestNameExists(TestDetails testDetails)
        {
            TestDetails existingTestName = testDetailsGateway.GetTestNameByInputName(testDetails.TestName);
            if (existingTestName != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SaveTestDetails(TestDetails testDetails)
        {
            return testDetailsGateway.SaveTestDetails(testDetails);
        }

        public List<TestDetails> GetAllTestDetails()
        {
            return testDetailsGateway.GetAllTestDetailses();
        }

        public double GetTestFee(string testId)
        {
            return testDetailsGateway.GetTestFee(testId);
        }

    }
}