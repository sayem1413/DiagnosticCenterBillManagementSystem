using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBManagementSystemApp.DAL;

namespace DCBManagementSystemApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway testTypeGateway=new TestTypeGateway();
        public bool IsTestTypeExists(TestType testType)
        {
            TestType existingTestType = testTypeGateway.GetTestTypeNameByInputName(testType.TestTypeName);
            if (existingTestType!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SaveTestType(TestType testType)
        {
            return testTypeGateway.SaveTestType(testType);
        }

        public List<TestType> GetAllTestTypes()
        {
            return testTypeGateway.GetAllTypeName();
        }
    }
}