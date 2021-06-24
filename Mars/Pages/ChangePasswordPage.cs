using System;
using System.Threading;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class ChangePasswordPage
    {
        private readonly IWebDriver driver;
        private SignInPage signIn;

        //page factory design pattern
        IWebElement Username => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/span"));
        IWebElement ChangePasswordItem => driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/span/div/a[2]"));
        IWebElement CurrentPassword => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[1]/input"));
        IWebElement NewPassword => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[2]/input"));
        IWebElement ConfirmPassword => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[3]/input"));
        IWebElement Save => driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[4]/button"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //Create a Constructor
        public ChangePasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
        }

        //changing password
        public void ChangePassword()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "Email"), ExcelLibHelper.ReadData(1, "Pwd"));
            ClickChangePassword();
            bool isChangePasswordPage = ValidateYouAreAtChangePasswordPage();
            Assert.IsTrue(isChangePasswordPage);
            EnterData();
            ClickSave();
            bool isPasswordChanged = ValidateSuccessMessage();
            Assert.IsTrue(isPasswordChanged);

        }

       
        public void ClickChangePassword()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3", 5000);

            //click Hi username
            Username.Click();

            //Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]", 5000);
            Thread.Sleep(200);
            //click Change Password menu item
            ChangePasswordItem.Click();

        }

        public bool ValidateYouAreAtChangePasswordPage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[4]/button", 200);
            return Save.Displayed;

        }

        public void EnterData()
        {
            try
            {
                Wait.ElementExists(driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[1]/input", 50);
                //Enter current password
                CurrentPassword.SendKeys(ExcelLibHelper.ReadData(1, "CurrentPassword"));

                //Enter new password
                NewPassword.SendKeys(ExcelLibHelper.ReadData(1, "NewPassword"));

                //Enter confirm password
                ConfirmPassword.SendKeys(ExcelLibHelper.ReadData(1, "NewConfirmPassword"));

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at SignIn page", msg.Message);
            }

        }

        public void ClickSave()
        {
            //Click save button
            Wait.ElementExists(driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[4]/button", 500);

            Save.Click();

        }

        public bool ValidateSuccessMessage()
        {
            Thread.Sleep(200);
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div",10 );
            
            //validate password changed message is displayed
            if (Message.Text == ExcelLibHelper.ReadData(1, "PasswordChangeMessage"))
            {
                //Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        
    }
}
