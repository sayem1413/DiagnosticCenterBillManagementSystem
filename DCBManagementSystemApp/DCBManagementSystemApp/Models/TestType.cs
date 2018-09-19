using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace DCBManagementSystemApp
{
    public class TestType
    {
        public int TypeId { get; set; }
        public string TestTypeName { get; set; }

        public TestType(string testTypeName)
        {
            this.TestTypeName = testTypeName;
        }

        public TestType(int typeId, string testTypeName)
        {
            this.TypeId = typeId;
            this.TestTypeName = testTypeName;
        }
    }
}