using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

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
            Wait.ElementExists(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a", 10);
            //click sign in 
            SignIn.Click();

        }

        public bool ValidateYouAreAtLoginPage()
        {
            return LoginButton.Displayed;
        }

        public void EnterEmailAddressAndPassword(string emailAddress, string password)
        {
            try
            {
                //Enter email address
                Console.WriteLine("Enter Email Address" + emailAddress);
                EmailAddress.SendKeys(emailAddress);

                //Enter password
                Console.WriteLine("Enter Password" + password);
                Password.SendKeys(password);

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
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button", 10);
            return SignOut.Displayed;
        }


        public void Login(string emailAddressValue, string passwordValue)
        {
            Driver.NavigateUrl();
            ClickSignIn();
            ValidateYouAreAtLoginPage();
            EnterEmailAddressAndPassword(emailAddressValue, passwordValue);
            ClickLoginButton();
            ValidateYouAreLoggedInSuccessfully();
        }


    }
}








