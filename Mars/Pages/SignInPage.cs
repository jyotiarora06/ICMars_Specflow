using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class SignInPage
    {
        private readonly IWebDriver driver;

        //page factory design pattern
        IWebElement SignIn => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        IWebElement Password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        IWebElement LoginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]"));
        IWebElement SignOut => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button"));

        //Create a Constructor
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void ClickSignIn()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a", 500);
            //click sign in 
            SignIn.Click();

        }

        public void ValidateYouAreAtLoginPage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]", 100);
            bool isLoginPage= LoginButton.Displayed;
            Assert.IsTrue(isLoginPage);
        }

        public void EnterEmailAddressAndPassword(string emailAddressValue, string PasswordValue)
        {
            try
            {
                Wait.ElementExists(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[1]/input", 200);

                //Enter email address
                EmailAddress.SendKeys(emailAddressValue);

                //Enter password
                Password.SendKeys(PasswordValue);

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at SignIn page", msg.Message);
            }

        }

        public void ClickLoginButton()
        {
            //Click login button

            LoginButton.Click();

        }

        public bool ValidateYouAreLoggedInSuccessfully()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button", 1000);
            return SignOut.Displayed;
        }


        public void Login(string emailAddress,string password)
        {
            ClickSignIn();
            ValidateYouAreAtLoginPage();
            EnterEmailAddressAndPassword(emailAddress,password);
            ClickLoginButton();
            bool isLoggedIn = ValidateYouAreLoggedInSuccessfully();
            Assert.IsTrue(isLoggedIn);
        }

    }
}








