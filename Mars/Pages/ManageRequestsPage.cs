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
        IWebElement ActionButton => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[8]/button"));
        IWebElement Accept => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
        IWebElement Decline => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]"));
        IWebElement SentRequestStatus => driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[5]"));
        IWebElement ReceivedRequestStatus => driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));

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
            ValidateYouAreAtReceivedRequestsPage();
            ClickAccept();
            bool isStatusAccepted = ValidateReceivedRequestStatus(ExcelLibHelper.ReadData(1, "AcceptReceivedRequest"));
            Assert.IsTrue(isStatusAccepted);

        }

        //declining received service request
        public void DeclineReceivedRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickReceivedRequests();
            ValidateYouAreAtReceivedRequestsPage();
            ClickDecline();
            bool isStatusDeclined = ValidateReceivedRequestStatus(ExcelLibHelper.ReadData(1, "DeclineReceivedRequest"));
            Assert.IsTrue(isStatusDeclined);

        }

        //withdrawing sent service request
        public void WithdrawSentRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickSentRequests();
            ValidateYouAreAtSentRequestsPage();
            //Click Withdraw
            ClickActionButton();
            bool isStatusWithdrawn = ValidateSentRequestStatus(ExcelLibHelper.ReadData(1, "WithdrawSentRequest"));
            Assert.IsTrue(isStatusWithdrawn);
        }

        //completing sent service request
        public void CompleteSentRequest()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickManageRequests();
            ClickSentRequests();
            ValidateYouAreAtSentRequestsPage();
            //Click Completed
            ClickActionButton();
            bool isStatusCompleted = ValidateSentRequestStatus(ExcelLibHelper.ReadData(1, "CompleteSentRequest"));
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
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]", 100);
            //click accept
            Accept.Click();
        }

        public void ClickDecline()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]", 100);
            //click decline
            Decline.Click();
        }

        public void ClickActionButton()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[8]/button", 100);
            //Click withdraw or complete actions
            ActionButton.Click();
        }

        public void ValidateYouAreAtSentRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/h2", 500);
            bool isSentRequestsPage = SentRequestsHeading.Displayed;
            Assert.IsTrue(isSentRequestsPage);
        }


        public void ValidateYouAreAtReceivedRequestsPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/h2", 500);
            bool isReceivedRequestsPage = ReceivedRequestsHeading.Displayed;
            Assert.IsTrue(isReceivedRequestsPage);
        }

        public bool ValidateReceivedRequestStatus(string status)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]", 200);
           
            if (ReceivedRequestStatus.Text == status)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateSentRequestStatus(string status)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[5]", 200);

            if (SentRequestStatus.Text == status)
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
