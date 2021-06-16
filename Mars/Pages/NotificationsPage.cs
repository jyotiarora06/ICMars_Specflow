using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class NotificationsPage
    {
        private IWebDriver driver;
        private SignInPage SignIn;


        //page factory design pattern
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div/div"));
        IWebElement Dashboard => driver.FindElement(By.XPath("/html/body/div/div/section[1]/div/a[1]"));
        IWebElement NotificationsText => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1"));
        IWebElement LoadMore => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a"));
        IWebElement ShowLess => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div/div[1]/center/a"));
        IWebElement NotificationCheckBox => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        IWebElement SelectAll => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[1]"));
        IWebElement UnselectAll => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]"));
        IWebElement DeleteSelection => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]"));
        IWebElement MarkSelectionAsRead => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]"));
        
        //Create a Constructor
        public NotificationsPage(IWebDriver driver)
        {
            this.driver = driver;
            SignIn = new SignInPage(driver);
        }

        public void Notifications()
        {
            SignIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickDashboard();
            ValidateYouAreAtNotificationPage();
            ClickLoadMore();
            ClickShowLess();
            SelectNotification();
            UnselectNotification();
            ClickSelectAll();
            ClickUnselectAll();
            ClickMarkSelectionAsRead();
            bool isNotificationMarked = ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Assert.IsTrue(isNotificationMarked);
            ClickDeleteSelection();
            bool isNotificationDeleted = ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Assert.IsTrue(isNotificationDeleted);

        }

        public void ClickDashboard()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div/section[1]/div/a[1]", 10);
            Dashboard.Click();
        }

        public void ClickLoadMore()
        {
           
            LoadMore.Click();
        }

        public void ClickShowLess()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div/div[1]/center/a", 20);
            ShowLess.Click();
        }

        public void SelectNotification()
        {
            if (!NotificationCheckBox.Selected)
            {
                NotificationCheckBox.Click();
            }
           
        }

        public void UnselectNotification()
        {
            if (NotificationCheckBox.Selected)
            {
                NotificationCheckBox.Click();
            }
        }

        public void ClickSelectAll()
        {
            SelectAll.Click();
        }

        public void ClickUnselectAll()
        {
            UnselectAll.Click();
        }

        public void ClickMarkSelectionAsRead()
        {
            SelectNotification();
            MarkSelectionAsRead.Click();
        }

        public void ClickDeleteSelection()
        {
            SelectNotification();
            DeleteSelection.Click();
        }

        public void ValidateYouAreAtNotificationPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1", 20);
            bool isNotificationPage = NotificationsText.Displayed;
            Assert.IsTrue(isNotificationPage);
        }

        public bool ValidateMessage(string message)
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div", 100);

            if (Message.Text == message)
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
