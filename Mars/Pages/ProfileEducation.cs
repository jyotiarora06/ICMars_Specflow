using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars
{
    class ProfileEducation
    {
        private readonly IWebDriver driver;
        private SignInPage signIn;
        private ProfileDescription profileDescription;

        //page factory design pattern

        IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        IWebElement College => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        IWebElement Country => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[11]"));
        IWebElement Title => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[8]"));
        IWebElement Degree => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        IWebElement Year => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[8]"));
        IWebElement Add => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        IWebElement AddedDegree => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        IWebElement EducationTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));


        //Create a Constructor
        public ProfileEducation(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        public void Education()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            profileDescription.ValidateProfilePage();
            ClickEducationTab();
            ClickAddNew();
            EnterCollege();
            SelectCountry();
            SelectTitle();
            EnterDegree();
            SelectYear();
            ClickAdd();
            bool isMessage = ValidateEducationSavedMessage();
            Assert.IsTrue(isMessage);
            bool isEducation = ValidateAddedEducation();
            Assert.IsTrue(isEducation);
        }

        public void ClickEducationTab()
        {
            //click Education Tab
            EducationTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new 
            AddNew.Click();
        }

        public void EnterCollege()
        {
            // enter College
            College.SendKeys(ExcelLibHelper.ReadData(1, "College"));
        }

        public void EnterDegree()
        {
            // enter Degree
            Degree.SendKeys(ExcelLibHelper.ReadData(1, "Degree"));
        }

        public void SelectCountry()
        {
            //select country
            Country.Click();
        }

        public void SelectTitle()
        {
            //select title
            Title.Click();
        }

        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add 
            Add.Click();
        }

        public bool ValidateEducationSavedMessage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 30);

            if (Message.Text == ExcelLibHelper.ReadData(1, "EducationMessage"))
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

        public bool ValidateAddedEducation()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]", 30);

            //validate Education is added
            if (AddedDegree.Text == ExcelLibHelper.ReadData(1, "Degree"))
            {
                //Console.WriteLine("Certificate is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Certificate is not added, test failed");
                return false;
            }
        }

    }
}
