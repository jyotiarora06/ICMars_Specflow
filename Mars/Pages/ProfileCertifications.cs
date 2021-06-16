using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars
{
    class ProfileCertifications
    {
        private readonly IWebDriver driver;
        private SignInPage signIn;
        private ProfileDescription profileDescription;

        //page factory design pattern

        IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));                                                                                    
        IWebElement Certificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        IWebElement CertifiedFrom => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
        IWebElement Year => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[13]"));
        IWebElement Add => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        IWebElement AddedCertificate => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        IWebElement CertificationsTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));


        //Create a Constructor
        public ProfileCertifications(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
            profileDescription = new ProfileDescription(driver);
        }

        public void Certification()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            profileDescription.ValidateProfilePage();
            ClickCertificationsTab();
            ClickAddNew();
            EnterCertificate();
            EnterCertifiedFrom();
            SelectYear();
            ClickAdd();
            bool isMessage = ValidateCertificateSavedMessage();
            Assert.IsTrue(isMessage);
            bool isCertificate = ValidateAddedCertificate();
            Assert.IsTrue(isCertificate);
        }

        public void ClickCertificationsTab()
        {
            //click Certifications Tab
            CertificationsTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new for Certifications
            AddNew.Click();
        }

        public void EnterCertificate()
        {
            // enter Certificate
            Certificate.SendKeys(ExcelLibHelper.ReadData(1, "Certificate"));
        }

        public void EnterCertifiedFrom()
        {
            // enter Certified From
            CertifiedFrom.SendKeys(ExcelLibHelper.ReadData(1, "CertifiedFrom"));
        }


        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add for Certifications
            Add.Click();
        }

        public bool ValidateCertificateSavedMessage()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 1000);

            if (Message.Text == ExcelLibHelper.ReadData(1, "CertificateMessage"))
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

        public bool ValidateAddedCertificate()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]", 30);

            //validate Certificate is added
            if (AddedCertificate.Text == ExcelLibHelper.ReadData(1, "Certificate"))
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
