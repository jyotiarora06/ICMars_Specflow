using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{

    [Parallelizable]
    [TestFixture]
    class ShareSkillTest : Driver
    {
        private CommonMethods commonMethods;

        public ShareSkillTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        public void CreateServiceTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CreateService method is called");
                //ShareSkill Page objects
                ShareSkillPage shareSkillObj = new ShareSkillPage(driver);
                shareSkillObj.CreateService();
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


        [Test]
        public void EditServiceTest()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EditService method is called");

                // ManageListings Page objects
                ManageListingsPage manageListingsObj = new ManageListingsPage(driver);
                manageListingsObj.EditService();

                test.Log(Status.Pass, "Service is updated");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {
                
                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }

        [Test]
        public void RemoveServiceTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeleteService method is called");

                // ManageListings Page objects
                ManageListingsPage manageListingsObj = new ManageListingsPage(driver);
                manageListingsObj.DeleteService();

                test.Log(Status.Pass, "Service is deleted");
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
    

