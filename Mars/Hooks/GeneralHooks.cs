using System;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Mars.Pages;
using Mars.Utilities;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Hooks
{
    [Binding]
    public class GeneralHooks : Driver
    {
        private static ScenarioContext scenarioContextObject;
        private static ExtentReports extent;
        private static ExtentHtmlReporter hTMLReporter;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private SignInPage SignIn;
        private CommonMethods commonMethods;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            hTMLReporter = new ExtentHtmlReporter(ConstantHelpers.ReportsPath);
            hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(hTMLReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {

            if (null != featureContext)
            { 
                featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                scenarioContextObject = scenarioContext;

                scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }

            //launch the browser
            Initialize();

            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

          

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.DataFilePath, ConstantHelpers.DataSheetName);
        
            //call the SignIn class

            SignIn = new SignInPage(driver);
            SignIn.Login(CommonMethods.ExcelLibHelper.ReadData(1, "EmailAddress"), CommonMethods.ExcelLibHelper.ReadData(1, "Password"));
        }
        

        [AfterStep]
        public void AfterStep()
        {
            //Screenshot in Base64 format
            ScenarioBlock currentScenarioBlock = scenarioContextObject.CurrentScenarioBlock;
            commonMethods = new CommonMethods();
            var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(scenarioContextObject.ScenarioInfo.Title.Trim());
            switch (currentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (scenarioContextObject.TestError != null)
                    {
                        scenario.CreateNode<Given>(scenarioContextObject.TestError.Message).Fail("/n" +
                            scenarioContextObject.TestError.StackTrace, mediaEntity);


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
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

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
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

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
                            scenarioContextObject.TestError.StackTrace, mediaEntity);

                    }
                    else
                    {
                        scenario.CreateNode<And>(scenarioContextObject.StepContext.StepInfo.Text).Pass("");

                    }
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {

            // close the browser
            FinalSteps();

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }


        
        
    }
}