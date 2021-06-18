using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class ShareSkillTest : Driver
    {
        private CommonMethods commonMethods;

        public ShareSkillTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void CreateServiceListingTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CreateServiceListing method is called");

                Setup(browserName);
                //ShareSkill Page objects
                ShareSkillPage shareSkillObj = new ShareSkillPage(driver);
                shareSkillObj.CreateServiceListing();
                test.Log(Status.Pass, "Service is listed");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {
                
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

    }

}
    

