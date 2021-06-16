using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class RegistrationPage
    {
        private readonly IWebDriver driver;
        

        //page factory design pattern
        IWebElement Join => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));
        IWebElement FirstName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/input"));
        IWebElement LastName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/input"));
        IWebElement EmailAddress => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/input"));
        IWebElement Password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/input"));
        IWebElement ConfirmPassword => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/input"));
        IWebElement AgreeTerms => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/div/input"));
        IWebElement JoinButton => driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));



        //Create a Constructor
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
          
        }


        public void ClickJoin()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/button", 10);
            //click join
            Join.Click();

        }

        public void ValidateYouAreAtRegistrationPage()
        {
            bool isJoinPage = JoinButton.Displayed;
            Assert.IsTrue(isJoinPage);
        }

        public void EnterData()
        {
            try
            {
                //Enter first name 
                FirstName.SendKeys(ExcelLibHelper.ReadData(1, "FirstName"));

                //Enter last name
                LastName.SendKeys(ExcelLibHelper.ReadData(1, "LastName"));

                //Enter email address
                EmailAddress.SendKeys(ExcelLibHelper.ReadData(1, "EmailAddress"));

                //Enter password
                Password.SendKeys(ExcelLibHelper.ReadData(1, "Password"));

                //Enter confirm password
                ConfirmPassword.SendKeys(ExcelLibHelper.ReadData(1, "ConfirmPassword"));

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at Join page", msg.Message);
            }

        }
        public void ClickAgreeTermsAndConditions()
        {
            //Click on AgreeTermsAndConditions
            AgreeTerms.Click();

        }

        public void ClickJoinButton()
        {
            //Click Join button
            JoinButton.Click();

        }
        public bool ValidateSuccessMessage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 10000);

            if (Message.Text == ExcelLibHelper.ReadData(1, "RegistrationMessage"))
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

        public void Registration()
        {
            
            ClickJoin();
            ValidateYouAreAtRegistrationPage();
            EnterData();
            ClickAgreeTermsAndConditions();
            ClickJoinButton();
            bool isRegistered = ValidateSuccessMessage();
            Assert.IsTrue(isRegistered);
        }
    }
}
