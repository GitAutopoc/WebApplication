using System;
using System.Collections.Generic;
using System.Text;

namespace TestCases
{
    public class TestCaseResultDto
    {
        public TestCaseResultDto() 
        {
            EvaluationResultJson = new List<TestCases>();
        }
        public string CustomData { get; set; }
        public List<TestCases> EvaluationResultJson { get; set; }
    }

    public class TestCases 
    {
        public string MethodName { get; set; }
        public string MethodType { get; set; }
        public int? ActualScore { get; set; }
        public int EarnedScore { get; set; }
        public string Status { get; set; }
        public bool IsMandatory { get; set; }
        public string ErroMessage{ get; set; }
    }
}
