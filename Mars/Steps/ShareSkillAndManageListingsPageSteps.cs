using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class ShareSkillAndManageListingsPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly ShareSkillPage shareSkill;
        private readonly ManageListingsPage manageListings;


        //Create a Constructor
        public ShareSkillAndManageListingsPageSteps()
        {
            signIn = new SignInPage(driver);
            shareSkill = new ShareSkillPage(driver);
            manageListings = new ManageListingsPage(driver);

        }

        [Given("I am at the Share Skill Page")]
        public void GivenIAmAtTheShareSkillPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            shareSkill.ClickShareSkill();
            bool isShareSkillPage = shareSkill.ValidateYouAreAtShareSkillPage();
            Console.WriteLine("I am at the Share Skill Page");
            Assert.IsTrue(isShareSkillPage);
        }

        [When("I enter data in fields")]
        public void WhenIEnterDataInFields()
        {
            shareSkill.EnterData();
            Console.WriteLine("I enter data in fields");
        }


        [When("I click save on Share Skill Page")]
        public void WhenIClickSave()
        {
            shareSkill.ClickSave();
            Console.WriteLine("I click save on Share Skill Page");
        }

        [Given("I am at the Manage Listings Page")]
        public void GivenIAmAtTheManageListingsPage()
        {
            shareSkill.CreateServiceListing();
            //manageListings.ClickManageListings();
            bool isManageListingsPage = manageListings.ValidateYouAreAtManageListingsPage();
            Console.WriteLine("I am at the Manage Listings Page");
            Assert.IsTrue(isManageListingsPage);
        }


        [When("I click edit action")]
        public void WhenIClickEditAction()
        {
            manageListings.ClickUpdateIcon();
            Console.WriteLine("I click edit action");
        }

        [When("I update the data in fields")]
        public void WhenIUpdateDataInFields()
        {
            manageListings.EnterEditData();
            Console.WriteLine("I update the data in fields");
        }

        [When("I click delete action")]
        public void WhenIClickDeleteAction()
        {
            manageListings.ClickRemoveIcon();
            Console.WriteLine("I click delete action");
        }

        [When("I click Yes on Delete your Service popup")]
        public void WhenIYes()
        {
            manageListings.ClickYes();
            Console.WriteLine("I click Yes on Delete your Service popup");
        }

        [Then("Service should be saved")]
        public void ThenServiceSaved()
        {
            bool isServiceSaved = shareSkill.ValidateServiceSavedSuccessfully();
            Console.WriteLine("Service should be saved");
            Assert.IsTrue(isServiceSaved);
        }

        [Then("Service should be updated")]
        public void ThenServiceUpdated()
        {
            bool isServiceUpdated = manageListings.ValidateServiceUpdatedSuccessfully();
            Console.WriteLine("Service should be updated");
            Assert.IsTrue(isServiceUpdated);
        }

        [Then("Service should be deleted")]
        public void ThenServiceDeleted()
        {
            bool isServiceDeleted = manageListings.ValidateServiceDeletedSuccessfully();
            Console.WriteLine("Service should be deleted");
            Assert.IsTrue(isServiceDeleted);
        }

    }
}
