using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class ManageListingsTest : Driver
    {
        private CommonMethods commonMethods;
      
        public ManageListingsTest()
        {
            commonMethods = new CommonMethods();
            
        }

        [Test]
        public void EditServiceListingTest()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EditServiceListing method is called");

                // ManageListings Page Objects
                ManageListingsPage manageListingsObj = new ManageListingsPage(driver);
                manageListingsObj.EditServiceListing();

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
        public void RemoveServiceListingTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeleteServiceListing method is called");

                // ManageListings Page Objects
                ManageListingsPage manageListingsObj = new ManageListingsPage(driver);
                manageListingsObj.DeleteServiceListing();

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


