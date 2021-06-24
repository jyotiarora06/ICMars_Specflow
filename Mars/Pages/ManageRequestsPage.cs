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
        IWebElement ManageRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
        IWebElement SentRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]"));
        IWebElement ReceivedRequests => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
        IWebElement SentRequestsHeading => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/h2"));
        IWebElement ReceivedRequestsHeading => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/h2"));
        IWebElement Withdraw => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        IWebElement Completed => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[8]/button"));
        IWebElement Accept => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
        IWebElement Decline => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[8]/button[2]"));
        IWebElement WithdrawnRequestStatus => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement CompletedRequestStatus => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[5]"));
        IWebElement AcceptedRequestStatus => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        IWebElement DeclinedRequestStatus => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[5]"));

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
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 500);
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
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]", 50);
            //click accept
            Accept.Click();
        }

        public void ClickDecline()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[8]/button[2]", 50);
            //click decline
            Decline.Click();
        }

        public void ClickWithdraw()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button", 50);
            //Click withdraw 
            Withdraw.Click();
        }

        public void ClickCompleted()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[8]/button", 50);
            //Click completed 
            Completed.Click();
        }

        public bool ValidateYouAreAtSentRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/h2", 500);
            return SentRequestsHeading.Displayed;
        }


        public bool ValidateYouAreAtReceivedRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/h2", 500);
            return ReceivedRequestsHeading.Displayed;
        }

        public bool ValidateAcceptedRequestStatus()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]", 200);
           
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
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[5]", 200);

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
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]", 200);

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
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[2]/td[5]", 200);

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
