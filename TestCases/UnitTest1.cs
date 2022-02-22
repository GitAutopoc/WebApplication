using ClassLibraryProject;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace TestCases
{
    public class Tests
    {
        public TestCaseResultDto testResults;
        private WeatherForecastController _weatherForecastController;
        private ILogger<WeatherForecastController> _logger;
        public List<object> jsonResult = new List<object>();
        private NewProject project;
        public string customValue;

        [SetUp]
        public void Setup()
        {
            testResults = new TestCaseResultDto();
            _weatherForecastController = new WeatherForecastController(_logger);
            project = new NewProject();
            customValue = System.IO.File.ReadAllText(@"C:\ProofofConcept\WebApplication\custom.ih");
            testResults.CustomData = customValue;
        }

        [Test]
        public void test1()
        {
            try
            {
                int a = 10, b = 20;
                var result = _weatherForecastController.CalculateTotal(a, b);
                Assert.AreEqual(result, 30);
                testResults.Results.Add(new TestCases
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 5,
                    ActualScore = 5,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex) 
            {
                testResults.Results.Add(new TestCases
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    ActualScore = 5,
                    EarnedScore = 0,
                    Status = "Failed",
                    IsMandatory = true
                });
            }
        }

        [Test]
        public void test2()
        {
            try
            {
                int a = -2, b = -2;
                var result = _weatherForecastController.CalculateTotal(a, b);
                Assert.AreEqual(result, 50);
                testResults.Results.Add(new TestCases
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    ActualScore = 0,
                    EarnedScore = 5,
                    Status = "Failed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testResults.Results.Add(new TestCases
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    ActualScore = 5,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
        }

        [Test]
        public void testFunction3() 
        {
            try
            {
                string a = "Hello ", b = "there";
                var result = project.ConcatString(a, b);
                Assert.Equals(result, "Hello there");
                testResults.Results.Add(new TestCases
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
                testResults.Results.Add(new TestCases
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    ActualScore = 25,
                    EarnedScore = 0,
                    Status = "Failed",
                    IsMandatory = true
                });
            }
        }

        [OneTimeTearDown]
        public async Task SendTestCaseResults() 
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                var testResultsJson = JsonConvert.SerializeObject(testResults);
                await _httpClient.PostAsync("http://localhost:7071/api/TestCaseResultsEnqueue", testResultsJson);
            }
        }
    }
}