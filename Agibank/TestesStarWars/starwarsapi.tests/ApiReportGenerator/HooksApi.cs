
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace starwarsapi.tests.ApiReportGenerator
{
    [Binding]
    public class HooksApi
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        [BeforeTestRun]
        public static void inicializeReport()
        {
            try
            {
                GerarRelatorio();
            }
            catch
            {
                throw;
            }
        }
        private static void GerarRelatorio()
        {
            string filePath = Path.GetFullPath("report");
            var htmlReport = new ExtentHtmlReporter(filePath);
            htmlReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void insertStepsReport()
        {
            var step = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (step == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("PASSOU");
                }
                else if (step == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("PASSOU"); ;
                }
                else if (step == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("PASSOU"); ;
                }
                else if (step == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("PASSOU");
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (step == "Given" && status == TestStatus.Failed)
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail("FALHOU" + errorMessage);
                }
                else if (step == "When" && status == TestStatus.Failed)
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail("FALHOU" + errorMessage);
                }
                else if (step == "And" && status == TestStatus.Failed)
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail("FALHOU" + errorMessage);
                }
                else if (step == "Then" && status == TestStatus.Failed)
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail("FALHOU" + errorMessage);
                }
            }
        }

        [BeforeScenario]
        public void StartTest(FeatureInfo feature)
        {
            //createTest
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void TearDown()
        {
            try
            {
                {
                    extent.Flush();
                }
            }
            catch (Exception) { }
        }
    }
}

