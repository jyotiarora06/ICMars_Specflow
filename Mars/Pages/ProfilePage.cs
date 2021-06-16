using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;
        private SignInPage signInPageObj;
        private ProfileDescription profileDescription;

        //page factory design pattern

        IWebElement AvailabilityIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));                                                                                          
        IWebElement PartTime => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
        IWebElement FullTime => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]"));
        IWebElement HoursIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        IWebElement LessThan30Hours => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[2]"));
        IWebElement MoreThan30Hours => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[3]"));
        IWebElement AsNeeded => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[4]"));
        IWebElement EarnTargetIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        IWebElement LessThan500 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[2]"));
        IWebElement Between500And1000 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]"));
        IWebElement MoreThan1000 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //Create a Constructor
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            signInPageObj = new SignInPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        public void Availability()
        {
            signInPageObj.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            profileDescription.ValidateProfilePage();
            ClickAvailability();
            SelectAvailability();
            bool isAvailability = ValidateSuccessMessage(ExcelLibHelper.ReadData(1, "AvailabilityMessage"));
            Assert.IsTrue(isAvailability);
        }

        public void Hours()
        {
            signInPageObj.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            profileDescription.ValidateProfilePage();
            ClickHours();
            SelectHours(ExcelLibHelper.ReadData(1, "Hours"));
            bool isHours = ValidateSuccessMessage(ExcelLibHelper.ReadData(1, "HoursMessage"));
            Assert.IsTrue(isHours);
        }

        public void EarnTarget()
        {
            signInPageObj.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            profileDescription.ValidateProfilePage();
            ClickEarnTarget();
            SelectEarnTarget(ExcelLibHelper.ReadData(1, "EarnTarget"));
            bool isEarnTarget = ValidateSuccessMessage(ExcelLibHelper.ReadData(1, "EarnTargetMessage"));
            Assert.IsTrue(isEarnTarget);
        }

        public void ClickAvailability()
        {
            AvailabilityIcon.Click();
        }

        public void SelectAvailability()
        {
            if (ExcelLibHelper.ReadData(1, "Availability") == "Part Time")
            {
                PartTime.Click();
            }
            else
            {
                FullTime.Click();
            }
        }

        public void ClickHours()
        {
            HoursIcon.Click();
        }

        public void SelectHours(string hours)
        {
            switch (hours)
            {
                case "Less than 30hours a week":

                    LessThan30Hours.Click();
                    break;

                case "More than 30hours a week":

                    MoreThan30Hours.Click();
                    break;

                default:

                    AsNeeded.Click();
                    break;
            }

        }

        public void ClickEarnTarget()
        {
            EarnTargetIcon.Click();
        }

        public void SelectEarnTarget(string earnTarget)
        {
            switch (earnTarget)
            {
                case "Less than $500 per month":

                    LessThan500.Click();
                    break;

                case "Between $500 and $1000 per month":

                    Between500And1000.Click();
                    break;

                default:

                    MoreThan1000.Click();
                    break;
            }
        }

        public bool ValidateSuccessMessage(string message)

        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 10);
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

