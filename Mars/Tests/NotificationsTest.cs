using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class NotificationsTest : Driver
    {
        private CommonMethods commonMethods;

        public NotificationsTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        public void NotificationActionsTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Notifications method is called");

                //Notifications Page objects
                NotificationsPage notificationsPageObj = new NotificationsPage(driver);
                notificationsPageObj.Notifications();
                test.Log(Status.Pass, "Notification is tested");
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


