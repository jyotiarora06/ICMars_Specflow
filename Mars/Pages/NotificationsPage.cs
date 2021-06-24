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
        IWebElement CheckBoxOne => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        IWebElement CheckBoxTwo => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[2]/div/div/div[3]/input"));
        IWebElement CheckBoxSix => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/div/div[3]/input"));
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

        // performing actions on notifications
        public void Notifications()
        {
            SignIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));

            ClickDashboard();
            bool isNotificationPage = ValidateYouAreAtNotificationPage();
            Assert.IsTrue(isNotificationPage); 

            ClickLoadMore();
            bool isMoreNotifications = ValidateMoreNotificationsLoaded();
            Assert.IsTrue(isMoreNotifications);

            ClickShowLess();
            bool isLessNotifications = ValidateLessNotificationsDisplayed();
            Assert.IsTrue(isLessNotifications);

            SelectNotification();
            bool isSelected = ValidateNotificationSelected();
            Assert.IsTrue(isSelected);

            UnselectNotification();
            bool isUnselected = ValidateNotificationUnselected();
            Assert.IsTrue(isUnselected);

            ClickSelectAll();
            bool isAllSelected = ValidateAllNotificationsSelected();
            Assert.IsTrue(isAllSelected);

            ClickUnselectAll();
            bool isAllUnselected = ValidateAllNotificationsUnselected();
            Assert.IsTrue(isAllUnselected);

            SelectNotification();
            ClickMarkSelectionAsRead();
            bool isNotificationMarked = ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Assert.IsTrue(isNotificationMarked);

            SelectNotification();
            ClickDeleteSelection();
            bool isNotificationDeleted = ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Assert.IsTrue(isNotificationDeleted);

        }

        public void ClickDashboard()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div/section[1]/div/a[1]", 10);
            //click dashboard
            Dashboard.Click();
        }

        public void ClickLoadMore()
        {
           //load more notifications
            LoadMore.Click();
        }

        public void ClickShowLess()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div/div[1]/center/a", 20);
            //show less notifications
            ShowLess.Click();
        }

        //selecting a notification
        public void SelectNotification()
        {
            if (!CheckBoxOne.Selected)
            {
                CheckBoxOne.Click();
            }
           
        }

        //unselecting a notification
        public void UnselectNotification()
        {
            if (CheckBoxOne.Selected)
            {
                CheckBoxOne.Click();
            }
        }

        //selecting all notifications
        public void ClickSelectAll()
        {
            SelectAll.Click();
        }

        //unselecting all notifications
        public void ClickUnselectAll()
        {
            UnselectAll.Click();
        }

        //mark selected notification as read
        public void ClickMarkSelectionAsRead()
        {
            MarkSelectionAsRead.Click();
        }

        //deleting selected notification
        public void ClickDeleteSelection()
        {
            DeleteSelection.Click();
        }

        public bool ValidateYouAreAtNotificationPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1", 20);
            return NotificationsText.Displayed;

        }

        public bool ValidateMoreNotificationsLoaded()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/div/div[3]/input", 20);
            return CheckBoxSix.Displayed;

        }

        public bool ValidateLessNotificationsDisplayed()
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/div/div[3]/input"));

            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;

        }

        public bool ValidateNotificationSelected()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 20);
            return CheckBoxOne.Selected;
          
        }

        public bool ValidateNotificationUnselected()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 20);
            return !CheckBoxOne.Selected;

        }

        public bool ValidateAllNotificationsSelected()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 20);
            if (CheckBoxOne.Selected && CheckBoxTwo.Selected)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateAllNotificationsUnselected()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 20);
            if (!CheckBoxOne.Selected && !CheckBoxTwo.Selected)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ValidateMessage(string message)
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div", 100);
            //validate notification is updated
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
