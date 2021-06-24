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

        // searching a skill from all categories
        public void SearchSkillsByAllCategories()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            bool isSearchPage = ValidateSearchPage();
            Assert.IsTrue(isSearchPage);
            EnterSearchSkill();
            ClickEnter();
            bool isSearchResult = ValidateSearchResult();
            Assert.IsTrue(isSearchResult);
        }

        //searching a skill using filter
        public void SearchSkillsByFilters()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            ClickSearchIcon();
            bool isSearchPage = ValidateSearchPage();
            Assert.IsTrue(isSearchPage);
            ClickOnline();
            EnterSearchSkill();
            ClickEnter();
            bool isSearchResult = ValidateSearchResult();
            Assert.IsTrue(isSearchResult);
        }
        public void ClickSearchIcon()
        {
            //click search icon
            SearchIcon.Click();
        }

        public bool ValidateSearchPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]", 20);
            return Online.Displayed;

        }

        public void EnterSearchSkill()
        {
            //enter skill to search
            SearchSkillsBox.SendKeys(ExcelLibHelper.ReadData(1, "SearchSkill"));
        }

        public void ClickEnter()
        {
            //click enter button
            SearchSkillsBox.SendKeys(Keys.Enter);
        }

        public void ClickOnline()
        {
            //click online filter
            Online.Click();
        }

        public void ClickSearchedSkill()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p", 20);

            //Click search result
            SearchedSkill.Click();
        }


        public bool ValidateSearchResult()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p", 20);

            //validate search result
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
