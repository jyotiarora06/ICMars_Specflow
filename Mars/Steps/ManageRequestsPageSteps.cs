using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class ManageRequestsPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly ManageRequestsPage manageRequests;
        


        //Create a Constructor
        public ManageRequestsPageSteps()
        {
            signIn = new SignInPage(driver);
            manageRequests = new ManageRequestsPage(driver);

        }

        [Given("I am at Received Requests page")]
        public void GivenIAmAtReceivedRequestsPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            manageRequests.ClickManageRequests();
            manageRequests.ClickReceivedRequests();
            bool isReceivedRequestsPage = manageRequests.ValidateYouAreAtReceivedRequestsPage();
            Console.WriteLine("I am at Received Requests Page");
            Assert.IsTrue(isReceivedRequestsPage);
        }

        [When("I click Accept")]
        public void WhenIClickAccept()
        {
            manageRequests.ClickAccept();
            Console.WriteLine("I click Accept");
        }


        [When("I click Decline")]
        public void WhenIClickDecline()
        {
            manageRequests.ClickDecline();
            Console.WriteLine("I click Decline");
        }

        [Given("I am at Sent Requests page")]
        public void GivenIAmAtSentRequestsPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            manageRequests.ClickManageRequests();
            manageRequests.ClickSentRequests();
            bool isSentRequestsPage = manageRequests.ValidateYouAreAtSentRequestsPage();
            Console.WriteLine("I am at Sent Requests page");
            Assert.IsTrue(isSentRequestsPage);
        }


        [When("I click Withdraw")]
        public void WhenIClickWithdraw()
        {
            manageRequests.ClickWithdraw();
            Console.WriteLine("I click Withdraw");
        }

        [When("I click Completed")]
        public void WhenIClickCompleted()
        {
            manageRequests.ClickCompleted();
            Console.WriteLine("I click Completed");
        }

        [Then("Request should be accepted")]
        public void ThenRequestAccepted()
        {
            bool isStatusAccepted = manageRequests.ValidateAcceptedRequestStatus();
            Console.WriteLine("Request should be accepted");
            Assert.IsTrue(isStatusAccepted);
        }

        [Then("Request should be declined")]
        public void ThenRequestDeclined()
        {
            bool isStatusDeclined = manageRequests.ValidateDeclinedRequestStatus();
            Console.WriteLine("Request should be declined");
            Assert.IsTrue(isStatusDeclined);
        }

        [Then("Request should be withdrawn")]
        public void ThenRequestWithdrawn()
        {

            bool isStatusWithdrawn = manageRequests.ValidateWithdrawnRequestStatus();
            Console.WriteLine("Request should be withdrawn");
            Assert.IsTrue(isStatusWithdrawn);
        }

        [Then("Request should be completed")]
        public void ThenRequestcompleted()
        {
            bool isStatusCompleted = manageRequests.ValidateCompletedRequestStatus();
            Console.WriteLine("Request should be completed");
            Assert.IsTrue(isStatusCompleted);
        }

    }
}
