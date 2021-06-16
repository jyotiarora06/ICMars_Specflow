using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;
        private SignInPage signIn;


        //page factory design pattern
        IWebElement SearchIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"));
        IWebElement SearchSkillsBox => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input"));
        IWebElement SearchedSkill => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p"));
        IWebElement Online => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]"));

        //Create a Constructor
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            signIn = new SignInPage(driver);
        }

        public void SearchSkillsByAllCategories()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            EnterSearchSkill();
            ClickEnter();
            bool isSearchResult = ValidateSearchResult();
            Assert.IsTrue(isSearchResult);
        }

        public void SearchSkillsByFilters()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            ClickOnline();
            EnterSearchSkill();
            ClickEnter();
            bool isSearchResult = ValidateSearchResult();
            Assert.IsTrue(isSearchResult);
        }
        public void ClickSearchIcon()
        {
            SearchIcon.Click();
        }

        public void EnterSearchSkill()
        {
            SearchSkillsBox.SendKeys(ExcelLibHelper.ReadData(1, "SearchSkill"));
        }

        public void ClickEnter()
        {
            SearchSkillsBox.SendKeys(Keys.Enter);
        }

        public void ClickOnline()
        {
            Online.Click();
        }

        public void ClickSearchedSkill()
        {
            SearchedSkill.Click();
        }


        public bool ValidateSearchResult()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p", 20);

            if (SearchedSkill.Text == ExcelLibHelper.ReadData(1, "SearchSkill"))
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
