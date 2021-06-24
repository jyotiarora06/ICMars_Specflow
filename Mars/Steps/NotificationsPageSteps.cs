using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class NotificationsPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly NotificationsPage notificationsPage;
      

        //Create a Constructor
        public NotificationsPageSteps()
        {
            signIn = new SignInPage(driver);
            notificationsPage = new NotificationsPage(driver);
            
        }

        [Given("I am at the Notifications Page")]
        public void GivenIAmAtTheNotificationsPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            notificationsPage.ClickDashboard();
            bool isNotificationPage = notificationsPage.ValidateYouAreAtNotificationPage();
            Console.WriteLine("I am at the Notifications Page");
            Assert.IsTrue(isNotificationPage);
        }

        [When("I click Load More")]
        public void WhenIClickLoadMore()
        {
            notificationsPage.ClickLoadMore();
            Console.WriteLine("I click Load More");
        }


        [When("I click Show Less")]
        public void WhenIClickShowLess()
        {
            notificationsPage.ClickShowLess();
            Console.WriteLine("I click Show Less");
        }

        [When("I select a notification")]
        public void WhenISelectNotification()
        {
            notificationsPage.SelectNotification();
            Console.WriteLine("I select a notification");
        }

        [When("I unselect a notification")]
        public void WhenIUnselectNotification()
        {
            notificationsPage.UnselectNotification();
            Console.WriteLine("I unselect a notification");
        }


        [When("I click Select all")]
        public void WhenISelectAll()
        {
            notificationsPage.ClickSelectAll();
            Console.WriteLine("I click Select all");
        }

        [When("I click Unselect all")]
        public void WhenIUnselectAll()
        {
            notificationsPage.ClickUnselectAll();
            Console.WriteLine("I click Unselect all");
        }

        [When("I click Mark selection as read")]
        public void WhenIMarkSelectionAsRead()
        {
            notificationsPage.ClickMarkSelectionAsRead();
            Console.WriteLine("I click Mark selection as read");
        }

        [When("I click Delete selection")]
        public void WhenIDeleteSelection()
        {
            notificationsPage.ClickDeleteSelection();
            Console.WriteLine("I click Delete selection");
        }

        [Then("More notifications should be loaded")]
        public void ThenMoreNotificationsLoaded()
        {
            bool isMoreNotifications = notificationsPage.ValidateMoreNotificationsLoaded();
            Console.WriteLine("More notifications should be loaded");
            Assert.IsTrue(isMoreNotifications);
        }

        [Then("Less notifications should be displayed")]
        public void ThenLessNotificationsDisplayed()
        {
            bool isLessNotifications = notificationsPage.ValidateLessNotificationsDisplayed();
            Console.WriteLine("Less notifications should be displayed");
            Assert.IsTrue(isLessNotifications);
        }

        [Then("Notification should be selected")]
        public void ThenNotificationSelected()
        {
            bool isSelected = notificationsPage.ValidateNotificationSelected();
            Console.WriteLine("Notification should be selected");
            Assert.IsTrue(isSelected);
        }

        [Then("Notification should be unselected")]
        public void ThenNotificationUnselected()
        {
            bool isUnselected = notificationsPage.ValidateNotificationUnselected();
            Console.WriteLine("Notification should be unselected");
            Assert.IsTrue(isUnselected);
        }

        [Then("All notifications should be selected")]
        public void ThenAllNotificationSelected()
        {
            bool isAllSelected = notificationsPage.ValidateAllNotificationsSelected();
            Console.WriteLine("All notifications should be selected");
            Assert.IsTrue(isAllSelected);
        }

        [Then("All notifications should be unselected")]
        public void ThenAllNotificationUnselected()
        {
            bool isAllUnselected = notificationsPage.ValidateAllNotificationsUnselected();
            Console.WriteLine("All notifications should be unselected");
            Assert.IsTrue(isAllUnselected);
        }

        [Then("Notification should be marked as read")]
        public void ThenNotificationMarkedAsRead()
        {
            bool isNotificationMarked = notificationsPage.ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Console.WriteLine("Notification should be marked as read");
            Assert.IsTrue(isNotificationMarked);
        }

        [Then("Notification should be deleted")]
        public void ThenAllNotificationDeleted()
        {
            bool isNotificationDeleted = notificationsPage.ValidateMessage(ExcelLibHelper.ReadData(1, "NotificationMessage"));
            Console.WriteLine("Notification should be deleted");
            Assert.IsTrue(isNotificationDeleted);
        }
    }
}
