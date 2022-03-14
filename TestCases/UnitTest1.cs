using ClassLibraryProject;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestCases;



namespace TestProject
{
    public class Tests
    {
        public NewProject newProject;
        public TestResults testResults;
        public Dictionary<string, TestCaseResultDto> testCaseResults;
        public string customValue;
        public string UniqueGuid = "18f69543-da90-412c-8a01-4825f31340bb";
        [SetUp]
        public void Setup()
        {
            newProject = new NewProject();
            testResults = new TestResults();
            testCaseResults = new Dictionary<string, TestCaseResultDto>();
            customValue = System.IO.File.ReadAllText("../../../../custom.ih");
            testResults.CustomData = customValue;
        }



        [Test]
        public void Test1()
        {
            try
            {
                string a = "Hello ", b = "there";
                var result = newProject.ConcatString(a,b);
                Assert.Equals(result, "Hello there");
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 0,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
        }

        [Test]
        public void Test2()
        {
            try
            {
                string a = "Good ", b = "morning";
                var result = newProject.ConcatString(a, b);
                Assert.Equals(result, "Hello there");
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test2",
                    MethodType = "functional",
                    EarnedScore = 0,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test2",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
        }

        [Test]
        public void Test3()
        {
            try
            {
                int a = 10, b = 20;
                var result = newProject.Multiply(a, b);
                Assert.Equals(result, 200);
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test3",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test3",
                    MethodType = "functional",
                    EarnedScore = 0,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
        }

        [Test]
        public void Test4()
        {
            try
            {
                int a = 10, b = 20;
                var result = newProject.Multiply(a, b);
                Assert.Equals(result, 20);
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test4",
                    MethodType = "functional",
                    EarnedScore = 0,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test4",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 25,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
        }


        [TearDown]
        public async Task SendTestCaseResults()
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                testResults.TestCaseResults = JsonConvert.SerializeObject(testCaseResults);
                var testResultsJson = JsonConvert.SerializeObject(testResults);
                await _httpClient.PostAsync("https://yaksha-stage-sbfn.azurewebsites.net/api/TestCaseResultsEnqueue?code=AjU0mofZlYs9oYbZnJpVwJWRY1dRKkDyS3QDY8aJAvrcjJvgBAXVDg==", new StringContent(testResultsJson, Encoding.UTF8, "application/json"));
            }
        }
    }
}