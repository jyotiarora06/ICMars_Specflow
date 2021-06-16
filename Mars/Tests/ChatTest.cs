using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class ChatTest : Driver
    {
        private CommonMethods commonMethods;

        public ChatTest()
        {
            commonMethods = new CommonMethods();
        }

        [Test]
        public void ChatWithSellerTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "ChatWithSeller method is called");

                //Chat Page objects
                ChatPage chatPageObj = new ChatPage(driver);
                chatPageObj.ChatWithSeller();
                test.Log(Status.Pass, "Chat is tested");
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


