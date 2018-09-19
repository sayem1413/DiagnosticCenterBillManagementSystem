using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBManagementSystemApp.Models
{
    public class TestDetails
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public TestDetails(string testName, double fee)
        {
            this.TestName = testName;
            this.Fee = fee;
        }
        public TestDetails(string testName)
        {
            this.TestName = testName;
        }

        public TestDetails(int testId, string testName, double fee, int typeId)
        {
            this.TestId = testId;
            this.TestName = testName;
            this.Fee = fee;
            this.TypeId = typeId;
        }
        public TestDetails(int testId, string testName, double fee, string typeName)
        {
            this.TestId = testId;
            this.TestName = testName;
            this.Fee = fee;
            this.TypeName = typeName;
        }

        public TestDetails(int testId)
        {
            this.TestId = testId;
        }

        public TestDetails()
        {
            
        }
    }
}