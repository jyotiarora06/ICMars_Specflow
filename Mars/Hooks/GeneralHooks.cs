using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace Mars.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private static ScenarioContext scenarioContextObject;
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter hTMLReporter;
        private static ExtentTest feature;
        private static ExtentTest scenario;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            hTMLReporter = new ExtentHtmlReporter(@"/Users/jyotimadan/");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(hTMLReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                scenarioContextObject = scenarioContext;

                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
        }
        
        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock currentScenarioBlock = scenarioContextObject.CurrentScenarioBlock;

            switch (currentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);


                    }
                    else
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                case ScenarioBlock.When:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<When>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<When>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                case ScenarioBlock.Then:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<Then>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;

                default:

                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<And>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<And>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }
    }
}