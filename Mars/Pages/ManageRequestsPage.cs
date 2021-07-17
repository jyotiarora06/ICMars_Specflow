using System;
using System.Threading;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class ManageRequestsPage
    {
        private IWebDriver driver;
        private SignInPage signIn;

        //page factory design pattern
        
        IWebElement ReceivedRequests => driver.FindElement(By.XPath("//a[contains(text(),'Received Requests')]"));
        IWebElement SentRequests => driver.FindElement(By.XPath("//a[contains(text(),'Sent Requests')]"));
        IWebElement SentRequestsHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Sent Requests')]"));
        IWebElement ReceivedRequestsHeading => driver.FindElement(By.XPath("//h2[contains(text(),'Received Requests')]"));
        IWebElement Withdraw => driver.FindElement(By.XPath("//tr[1]//button[contains(text(),'Withdraw')]"));
        IWebElement Completed => driver.FindElement(By.XPath("//tr[2]//button[contains(text(),'Completed')]"));
        IWebElement Accept => driver.FindElement(By.XPath("//tr[2]//button[contains(text(),'Accept')]"));
        IWebElement Decline => driver.FindElement(By.XPath("//tr[1]//button[contains(text(),'Decline')]"));
        IWebElement ManageRequests => driver.FindElement(By.XPath("//div[contains(text(),'Manage Requests')]"));
        IWebElement WithdrawnRequestStatus => driver.FindElement(By.XPath("//tr[1]//td[contains(text(),'Withdrawn')]"));
        IWebElement CompletedRequestStatus => driver.FindElement(By.XPath("//tr[2]//td[contains(text(),'Completed')]"));
        IWebElement AcceptedRequestStatus => driver.FindElement(By.XPath("//tr[2]//td[contains(text(),'Accepted')]"));
        IWebElement DeclinedRequestStatus => driver.FindElement(By.XPath("//tr[1]//td[contains(text(),'Declined')]"));

        //Create a Constructor
        public ManageRequestsPage(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
        }

        //accepting received service request
        public void AcceptReceivedRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickReceivedRequests();
            bool isReceivedRequestsPage = ValidateYouAreAtReceivedRequestsPage();
            Assert.IsTrue(isReceivedRequestsPage); 
            ClickAccept();
            bool isStatusAccepted = ValidateAcceptedRequestStatus();
            Assert.IsTrue(isStatusAccepted);

        }

        //declining received service request
        public void DeclineReceivedRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickReceivedRequests();
            bool isReceivedRequestsPage = ValidateYouAreAtReceivedRequestsPage();
            Assert.IsTrue(isReceivedRequestsPage);
            ClickDecline();
            bool isStatusDeclined = ValidateDeclinedRequestStatus();
            Assert.IsTrue(isStatusDeclined);

        }

        //withdrawing sent service request
        public void WithdrawSentRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickSentRequests();
            bool isSentRequestsPage = ValidateYouAreAtSentRequestsPage();
            Assert.IsTrue(isSentRequestsPage); 
            //Click Withdraw
            ClickWithdraw();
            bool isStatusWithdrawn = ValidateWithdrawnRequestStatus();
            Assert.IsTrue(isStatusWithdrawn);
        }

        //completing sent service request
        public void CompleteSentRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickSentRequests();
            bool isSentRequestsPage = ValidateYouAreAtSentRequestsPage();
            Assert.IsTrue(isSentRequestsPage);
            //Click Completed
            ClickCompleted();
            bool isStatusCompleted = ValidateCompletedRequestStatus();
            Assert.IsTrue(isStatusCompleted);
        }

        public void ClickManageRequests()
        {
            //click manage requests
            Wait.ElementExists(driver, "XPath", "//div[contains(text(),'Manage Requests')]", 50);
            ManageRequests.Click();
            Thread.Sleep(500);
           
        }

        public void ClickReceivedRequests()
        {
            //click received requests
            ReceivedRequests.Click();
        }

        public void ClickSentRequests()
        {
            //click sent requests
            SentRequests.Click();
        }

        public void ClickAccept()
        {
            Wait.ElementExists(driver, "XPath", "//tr[2]//button[contains(text(),'Accept')]", 50);
            //click accept
            Accept.Click();
        }

        public void ClickDecline()
        {
            Wait.ElementExists(driver, "XPath", "//tr[1]//button[contains(text(),'Decline')]", 50);
            //click decline
            Decline.Click();
        }

        public void ClickWithdraw()
        {
            Wait.ElementExists(driver, "XPath", "//tr[1]//button[contains(text(),'Withdraw')]", 50);
            //Click withdraw 
            Withdraw.Click();
        }

        public void ClickCompleted()
        {
            Wait.ElementExists(driver, "XPath", "//tr[2]//button[contains(text(),'Completed')]", 50);
            //Click completed 
            Completed.Click();
        }

        public bool ValidateYouAreAtSentRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//h2[contains(text(),'Sent Requests')]", 50);
            return SentRequestsHeading.Displayed;
        }


        public bool ValidateYouAreAtReceivedRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//h2[contains(text(),'Received Requests')]", 50);
            return ReceivedRequestsHeading.Displayed;
        }

        public bool ValidateAcceptedRequestStatus()
        {
            Wait.ElementExists(driver, "XPath", "//tr[2]//td[contains(text(),'Accepted')]", 50);

            if (AcceptedRequestStatus.Text == ExcelLibHelper.ReadData(1, "AcceptReceivedRequest"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateDeclinedRequestStatus()
        {
            Wait.ElementExists(driver, "XPath", "//tr[1]//td[contains(text(),'Declined')]", 50);

            if (DeclinedRequestStatus.Text == ExcelLibHelper.ReadData(1, "DeclineReceivedRequest"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateWithdrawnRequestStatus()
        {
            Wait.ElementExists(driver, "XPath", "//tr[1]//td[contains(text(),'Withdrawn')]", 50);

            if (WithdrawnRequestStatus.Text == ExcelLibHelper.ReadData(1, "WithdrawSentRequest"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateCompletedRequestStatus()
        {
            Wait.ElementExists(driver, "XPath", "//tr[2]//td[contains(text(),'Completed')]", 50);

            if (CompletedRequestStatus.Text == ExcelLibHelper.ReadData(1, "CompleteSentRequest"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
