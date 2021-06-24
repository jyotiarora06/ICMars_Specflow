using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class SignUpPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly RegistrationPage registrationPage;

        //Create a Constructor
        public SignUpPageSteps()
        {
            signIn = new SignInPage(driver);
            registrationPage = new RegistrationPage(driver);
        }

        [Given("I am at the Join page")]
        public void GivenIAmAtTheJoinPage()
        {
            registrationPage.ClickJoin();
            bool isJoinPage = registrationPage.ValidateYouAreAtRegistrationPage();
            Console.WriteLine("I am at the Join page");
            Assert.IsTrue(isJoinPage);
        }

        [When("I enter valid data")]
        public void WhenIEnterValidCredentials()
        {
            registrationPage.EnterData();
            Console.WriteLine("I enter valid data");
        }

        [When("I agree to the terms and conditions")]
        public void WhenIAgreeToTheTermsAndConditions()
        {
            registrationPage.ClickAgreeTermsAndConditions();
            Console.WriteLine("I agree to the terms and conditions");
        }

        [When("I click the Join button")]
        public void WhenIClickTheJoinButton()
        {
            registrationPage.ClickJoinButton();
            Console.WriteLine("I click the Join button");
        }

        [Given("I am at the Sign In page")]
        public void GivenIAmAtTheSignInPage()
        {
            signIn.ClickSignIn();
            bool isLoginPage = signIn.ValidateYouAreAtLoginPage();
            Console.WriteLine("I am at the Sign In page");
            Assert.IsTrue(isLoginPage);
        }

        [When("I enter valid creds")]
        public void WhenIEnterValidCreds()
        {
            signIn.EnterEmailAddressAndPassword(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            Console.WriteLine("I enter valid creds");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            signIn.ClickLoginButton();
            Console.WriteLine("I click the login button");
        }


        [Then("I should be registered successfully")]
        public void ThenIRegisteredSuccessfully()
        {
            bool isRegistered = registrationPage.ValidateSuccessMessage();
            Console.WriteLine("I should be registered successfully");
            Assert.IsTrue(isRegistered);
        }



        [Then("I should be logged in successfully")]
        public void ThenILoggedInSuccessfully()
        {
            bool isLoggedIn = signIn.ValidateYouAreLoggedInSuccessfully();
            Console.WriteLine("I should be logged in successfully");
            Assert.IsTrue(isLoggedIn);
        }

    }
}
