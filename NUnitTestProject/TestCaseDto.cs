using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class TestCaseResultDto
    {
        public TestCaseResultDto() 
        {
            Results = new List<TestCases>();
        }
        public string CustomData { get; set; }
        public List<TestCases> Results { get; set; }
    }

    public class TestCases 
    {
        public string MethodName { get; set; }
        public string MethodType { get; set; }
        public int? ActualScore { get; set; }
        public int EarnedScore { get; set; }
        public string Status { get; set; }
        public bool IsMandatory { get; set; }
    }
}
