using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class SearchPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly SearchPage searchPage;

        //Create a Constructor
        public SearchPageSteps()
        {
            signIn = new SignInPage(driver);
            searchPage = new SearchPage(driver);
        }

        [Given("I am at the Search Page")]
        public void GivenIAmAtTheSearchPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            searchPage.ClickSearchIcon();
            bool isSearchPage = searchPage.ValidateSearchPage();
            Console.WriteLine("I am at the Search Page");
            Assert.IsTrue(isSearchPage);
        }

        [When("I enter search data in Search skills")]
        public void WhenIEnterSearchDataInSearchSkills()
        {
            searchPage.EnterSearchSkill();
            Console.WriteLine("I enter search data in Search skills");
        }


        [When("I select filter")]
        public void WhenISelectFilter()
        {
            searchPage.ClickOnline();
            Console.WriteLine("I select filter");
        }

        [When("I click enter")]
        public void WhenIClickEnter()
        {
            searchPage.ClickEnter();
            Console.WriteLine("I click enter");
        }

        [Then("Search data should be displayed")]
        public void ThenSearchDataShouldBeDisplayed()
        {
            bool isSearchResult = searchPage.ValidateSearchResult();
            Console.WriteLine("Search data should be displayed");
            Assert.IsTrue(isSearchResult);
        }
    }
}
