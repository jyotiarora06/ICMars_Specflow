using System;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Mars.Steps
{
    [Binding]
    public class ProfilePageSteps : Driver
    {
        private readonly ProfilePage profilePage;

       

        //Create a Constructor
        public ProfilePageSteps()
        {
            profilePage = new ProfilePage(driver);
        }

        [Given("I am at the Profile Page")]
        public void GivenIAmAtTheProfilePage()
        {
            bool isProfilePage = profilePage.ValidateProfilePage();
            Console.WriteLine("I am at the Profile Page");
            Assert.IsTrue(isProfilePage);
        }

        [When("I click description icon")]
        public void WhenIClickDescriptionIcon()
        {
            profilePage.ClickDescriptionIcon();
            Console.WriteLine("I click description icon");
        }

        [When("I enter description '(.*)'")]
        public void WhenIEnterDescription(String description)
        {
            profilePage.EnterDescription(description);
            Console.WriteLine("I enter description");
        }

        [When("I click save")]
        public void WhenIClickSave()
        {
            profilePage.ClickSave();
            Console.WriteLine("I click save");
        }


        [When("I click Add New in languages")]
        public void WhenIClickAddNewLanguage()
        {
            profilePage.ClickAddNewLanguage();
            Console.WriteLine("I click Add New in languages");
        }

        [When("I click Add New in skills")]
        public void WhenIClickAddNewSkill()
        {
            profilePage.ClickAddNewSkill();
            Console.WriteLine("I click Add New in skills");
        }

        [When("I enter language '(.*)'")]
        public void WhenIEnterLanguage(String language )
        {
            profilePage.EnterLanguage(language);
            Console.WriteLine("I enter language");
        }

        [When("I choose language level")]
        public void WhenIChooseLanguageLeve()
        {
            profilePage.ChooseLanguageLevel();
            Console.WriteLine("I choose language level");
        }

        [When("I click Add in languages")]
        public void WhenIClikAddLanguage()
        {
            profilePage.ClickAddLanguage();
            Console.WriteLine("I click add in languages");
        }

        [When("I click Add in skills")]
        public void WhenIClikAddSkill()
        {
            profilePage.ClickAddSkill();
            Console.WriteLine("I click add in skills");
        }

        [When("I click skills tab")]
        public void WhenIClickSkillsTab()
        {
            profilePage.ClickSkills();
            Console.WriteLine("I click skills tab");
        }

        [When("I enter skill '(.*)'")]
        public void WhenIEnterSkill(String skill)
        {
            
            profilePage.EnterSkill(skill);
            Console.WriteLine("I enter skill");
        }

        [When("I choose skill level")]
        public void WhenIChooseSkillLevel()
        {
            profilePage.ChooseSkillLevel();
            Console.WriteLine("I choose skill level");
        }
        
        [Then("Description message '(.*)' should be displayed")]
        public void ThenDescriptionSavedMessageDisplayed(string message)
        {
            bool IsDescriptionSavedMessage = profilePage.ValidateDescriptionSavedMessage(message);
            Console.WriteLine("Description saved message should be displayed");
            Assert.IsTrue(IsDescriptionSavedMessage);
        }
        
        [Then("Description '(.*)' should be displayed on the profile page")]
        public void ThenSavedDescriptionDisplayedOnTheProfilePage(string description)
        {
            bool IsSavedDescription = profilePage.ValidateSavedDescription(description);
            Console.WriteLine("Saved description should be displayed on the profile page");
            Assert.IsTrue(IsSavedDescription);
        }
        
        [Then("Language message '(.*)' should be displayed")]
        public void ThenLanguageSavedMessageDisplayed(String message)
        {
            bool IsLanguageSavedMessage = profilePage.ValidateLanguageSavedMessage(message);
            Console.WriteLine("Language saved message should be displayed");
            Assert.IsTrue(IsLanguageSavedMessage);
        }


        [Then("Language '(.*)' should be displayed on the profile page")]
        public void ThenAddedLanguageDisplayedOnTheProfilePage(String language)
        {
            bool IsAddedLanguage = profilePage.ValidateAddedLanguage(language);
            Console.WriteLine("Added language should be displayed on the profile page");
            Assert.IsTrue(IsAddedLanguage);
        }
        
        [Then("Skill message '(.*)' should be displayed")]
        public void ThenSkillSavedMessageDisplayed(string message)
        {
            bool IsSkillSavedMessage = profilePage.ValidateSkillSavedMessage(message);
            Console.WriteLine("Skill saved message should be displayed");
            Assert.IsTrue(IsSkillSavedMessage);
        }

        [Then("Skill '(.*)' should be displayed on the profile page")]
        public void ThenAddedSkillDisplayedOnTheProfilePage(string skill)
        {
            bool IsAddedSkill = profilePage.ValidateAddedSkill(skill);
            Console.WriteLine("Skill should be added and displayed on the profile page");
            Assert.IsTrue(IsAddedSkill);
        }
        
        
        
    }
}
