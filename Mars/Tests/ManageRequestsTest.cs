using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class ManageRequestsTest : Driver
    {
        private CommonMethods commonMethods;

        public ManageRequestsTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        public void AcceptReceivedRequestest()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AcceptReceivedRequest method is called");

                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.AcceptReceivedRequest();

                test.Log(Status.Pass, "Request is accepted");
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
        public void DeclineReceivedRequest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeclineReceivedRequest method is called");

                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.DeclineReceivedRequest();

                test.Log(Status.Pass, "Request is declined");
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
        public void WithdrawSentRequest()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "WithdrawSentRequest method is called");

                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.WithdrawSentRequest();

                test.Log(Status.Pass, "Request is withdrawn");
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
        public void CompleteSentRequest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CompleteSentRequest method is called");

                //ManageRequests Page Objects
                ManageRequestsPage manageRequestsObj = new ManageRequestsPage(driver);
                manageRequestsObj.CompleteSentRequest();

                test.Log(Status.Pass, "Request is completed");
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


