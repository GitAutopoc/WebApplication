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
    public class Test2
    {
        public TestResults testResults;
        private WeatherForecastController _weatherForecastController;
        private ILogger<WeatherForecastController> _logger;
        public List<object> jsonResult = new List<object>();
        private NewProject project;
        public string customValue;
        public string UniqueGuid = "18f69543-da90-412c-8a01-4825f31340bb";

        [SetUp]
        public void Setup()
        {
            project = new NewProject();
            testResults = new TestResults();
            _weatherForecastController = new WeatherForecastController(_logger);
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
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
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
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 0,
                    ActualScore = 5,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            finally
            {
                SendTestCaseResults(testResults);
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
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 15,
                    ActualScore = 15,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            catch (Exception ex)
            {
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 0,
                    ActualScore = 15,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            finally
            {
                SendTestCaseResults(testResults);
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
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
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
                testResults.TestCaseResults.Add("18f69543-da90-412c-8a01-4825f31340bb", new TestCaseResultDto
                {
                    MethodName = "test1",
                    MethodType = "functional",
                    EarnedScore = 25,
                    ActualScore = 0,
                    Status = "Passed",
                    IsMandatory = true
                });
            }
            finally
            {
                SendTestCaseResults(testResults);
            }
        }

        public async Task SendTestCaseResults(TestResults results)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                var testResultsJson = JsonConvert.SerializeObject(results);
                await _httpClient.PostAsync("http://localhost:7070/api/TestCaseResultsEnqueue", new StringContent(testResultsJson, Encoding.UTF8, "application/json"));
            }
        }
    }
}