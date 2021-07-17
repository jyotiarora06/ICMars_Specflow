using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class ProfilePageSteps : Driver
    {
        private readonly ProfileDescription profileDescription;
        private readonly ProfileLanguage profileLanguage;
        private readonly ProfileSkill profileSkill;
        private readonly ProfileCertifications profileCertifications;
        private readonly ProfileEducation profileEducation;
        private readonly ProfilePage profilePage;
        private readonly SignInPage signIn;
        private readonly ChangePasswordPage changePasswordPage;

        //Create a Constructor
        public ProfilePageSteps()
        {
            profileDescription = new ProfileDescription(driver);
            profileLanguage = new ProfileLanguage(driver);
            profileSkill = new ProfileSkill(driver);
            profileCertifications = new ProfileCertifications(driver);
            profileEducation = new ProfileEducation(driver);
            profilePage = new ProfilePage(driver);
            signIn = new SignInPage(driver);
            changePasswordPage = new ChangePasswordPage(driver);
        }

        [Given("I am at the Profile Page")]
        public void GivenIAmAtTheProfilePage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            bool isProfilePage = profileDescription.ValidateProfilePage();
            Console.WriteLine("I am at the Profile Page");
            Assert.IsTrue(isProfilePage);
        }

        [When("I click description icon")]
        public void WhenIClickDescriptionIcon()
        {
            profileDescription.ClickDescriptionIcon();
            Console.WriteLine("I click description icon");
        }

        [When("I enter description")]
        public void WhenIEnterDescription()
        {
            profileDescription.EnterDescription();
            Console.WriteLine("I enter description");
        }

        [When("I click save")]
        public void WhenIClickSave()
        {
            profileDescription.ClickSave();
            Console.WriteLine("I click save");
        }

        [When("I click Add New in languages")]
        public void WhenIClickAddNewLanguage()
        {
            profileLanguage.ClickAddNew();
            Console.WriteLine("I click Add New in languages");
        }

        [When("I enter language")]
        public void WhenIEnterLanguage()
        {
            profileLanguage.EnterLanguage();
            Console.WriteLine("I enter language");
        }

        [When("I choose language level")]
        public void WhenIChooseLanguageLeve()
        {
            profileLanguage.ChooseLanguageLevel();
            Console.WriteLine("I choose language level");
        }

        [When("I click Add in languages")]
        public void WhenIClikAddLanguage()
        {
            profileLanguage.ClickAdd();
            Console.WriteLine("I click add in languages");
        }

        [When("I click skills tab")]
        public void WhenIClickSkillsTab()
        {
            profileSkill.ClickSkillsTab();
            Console.WriteLine("I click skills tab");
        }

        [When("I click Add New in skills")]
        public void WhenIClickAddNewSkill()
        {
            profileSkill.ClickAddNew();
            Console.WriteLine("I click Add New in skills");
        }

        [When("I enter skill")]
        public void WhenIEnterSkill()
        {

            profileSkill.EnterSkill();
            Console.WriteLine("I enter skill");
        }

        [When("I choose skill level")]
        public void WhenIChooseSkillLevel()
        {
            profileSkill.ChooseSkillLevel();
            Console.WriteLine("I choose skill level");
        }

        [When("I click Add in skills")]
        public void WhenIClikAddSkill()
        {
            profileSkill.ClickAdd();
            Console.WriteLine("I click add in skills");
        }

        [When("I click certifications tab")]
        public void WhenIClickCertificationsTab()
        {
            profileCertifications.ClickCertificationsTab();
            Console.WriteLine("I click certifications tab");
        }

        [When("I click Add New in certifications")]
        public void WhenIClickAddNewCertification()
        {
            profileCertifications.ClickAddNew();
            Console.WriteLine("I click Add New in certifications");
        }

        [When("I enter certificate")]
        public void WhenIEnterCertificate()
        {

            profileCertifications.EnterCertificate();
            Console.WriteLine("I enter certificate");
        }

        [When("I enter certified from")]
        public void WhenIEnterCertifiedFrom()
        {

            profileCertifications.EnterCertifiedFrom();
            Console.WriteLine("I enter certified from");
        }

        [When("I select year")]
        public void WhenISelectYear()
        {

            profileCertifications.SelectYear();
            Console.WriteLine("I select year");
        }

        [When("I click Add in certifications")]
        public void WhenIClickAddCertification()
        {

            profileCertifications.ClickAdd();
            Console.WriteLine("I click Add in certifications");
        }

        [When("I click education tab")]
        public void WhenIClickEducationTab()
        {
            profileEducation.ClickEducationTab();
            Console.WriteLine("I click education tab");
        }

        [When("I click Add New in education")]
        public void WhenIClickAddNewEducation()
        {
            profileEducation.ClickAddNew();
            Console.WriteLine("I click Add New in education");
        }

        [When("I enter college")]
        public void WhenIEnterCollege()
        {

            profileEducation.EnterCollege();
            Console.WriteLine("I enter college");
        }

        [When("I select country")]
        public void WhenISelectCountry()
        {

            profileEducation.SelectCountry();
            Console.WriteLine("I select country");
        }

        [When("I select title")]
        public void WhenISelectTitle()
        {

            profileEducation.SelectTitle();
            Console.WriteLine("I select title");
        }

        [When("I enter degree")]
        public void WhenIEnterDegree()
        {

            profileEducation.EnterDegree();
            Console.WriteLine("I enter degree");
        }


        [When("I select year of graduation")]
        public void WhenISelectYearOfGraduation()
        {

            profileEducation.SelectYear();
            Console.WriteLine("I select year of graduation");
        }

        [When("I click Add in education")]
        public void WhenIClickAddEducation()
        {

            profileEducation.ClickAdd();
            Console.WriteLine("I click Add in education");
        }

        [When("I click availability icon")]
        public void WhenIClickAvailabilityIcon()
        {
            profilePage.ClickAvailability();
            Console.WriteLine("I click availability icon");
        }

        [When("I select availability")]
        public void WhenISelectAvailability()
        {

            profilePage.SelectAvailability();
            Console.WriteLine("I select availability");
        }

        [When("I click hours icon")]
        public void WhenIClickHoursIcon()
        {
            profilePage.ClickHours();
            Console.WriteLine("I click hours icon");
        }

        [When("I select hours")]
        public void WhenISelectHours()
        {

            profilePage.SelectHours(ExcelLibHelper.ReadData(1, "Hours"));
            Console.WriteLine("I select hours");
        }

        [When("I click earn target icon")]
        public void WhenIClickEarnTargetIcon()
        {
            profilePage.ClickEarnTarget();
            Console.WriteLine("I click earn target icon");
        }

        [When("I select earn target")]
        public void WhenISelectEarnTarget()
        {

            profilePage.SelectEarnTarget(ExcelLibHelper.ReadData(1, "EarnTarget"));
            Console.WriteLine("I select hours");
        }

        [Given("I am at the change password Page")]
        public void GivenIAmAtChangePasswordPage()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "Email"), ExcelLibHelper.ReadData(1, "Pwd"));
            changePasswordPage.ClickChangePassword();
            bool isChangePasswordPage = changePasswordPage.ValidateYouAreAtChangePasswordPage();
            Console.WriteLine("I am at the change password Page");
            Assert.IsTrue(isChangePasswordPage);
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            changePasswordPage.EnterData();
            Console.WriteLine("I enter valid credentials");
        }

        [When("I click Save button")]
        public void WhenIClickSaveButton()
        {
            changePasswordPage.ClickSave();
            Console.WriteLine("I click Save button");
        }

        [Then("Description saved message should be displayed")]
        public void ThenDescriptionSavedMessageDisplayed()
        {
            bool IsDescriptionSavedMessage = profileDescription.ValidateDescriptionSavedMessage();
            Console.WriteLine("Description saved message should be displayed");
            Assert.IsTrue(IsDescriptionSavedMessage);
        }

        [Then("Saved description should be displayed on the profile page")]
        public void ThenSavedDescriptionDisplayedOnTheProfilePage()
        {
            bool IsSavedDescription = profileDescription.ValidateSavedDescription();
            Console.WriteLine("Saved description should be displayed on the profile page");
            Assert.IsTrue(IsSavedDescription);
        }

        [Then("Language saved message should be displayed")]
        public void ThenLanguageSavedMessageDisplayed()
        {
            bool IsLanguageSavedMessage = profileLanguage.ValidateLanguageSavedMessage();
            Console.WriteLine("Language saved message should be displayed");
            Assert.IsTrue(IsLanguageSavedMessage);
        }

        [Then("Added language should be displayed on the profile page")]
        public void ThenAddedLanguageDisplayedOnTheProfilePage()
        {
            bool IsAddedLanguage = profileLanguage.ValidateAddedLanguage();
            Console.WriteLine("Added language should be displayed on the profile page");
            Assert.IsTrue(IsAddedLanguage);
        }

        [Then("Skill saved message should be displayed")]
        public void ThenSkillSavedMessageDisplayed()
        {
            bool IsSkillSavedMessage = profileSkill.ValidateSkillSavedMessage();
            Console.WriteLine("Skill saved message should be displayed");
            Assert.IsTrue(IsSkillSavedMessage);
        }

        [Then("Added skill should be displayed on the profile page")]
        public void ThenAddedSkillDisplayedOnTheProfilePage()
        {
            bool IsAddedSkill = profileSkill.ValidateAddedSkill();
            Console.WriteLine("Added skill should be displayed on the profile page");
            Assert.IsTrue(IsAddedSkill);
        }

        [Then("Certification saved message should be displayed")]
        public void ThenCertificationSavedMessageDisplayed()
        {
            bool IsCertificationSavedMessage = profileCertifications.ValidateCertificateSavedMessage();
            Console.WriteLine("Certification saved message should be displayed");
            Assert.IsTrue(IsCertificationSavedMessage);
        }


        [Then("Added certification should be displayed on the profile page")]
        public void ThenAddedCertificationDisplayedOnTheProfilePage()
        {
            bool IsAddedCertification = profileCertifications.ValidateAddedCertificate();
            Console.WriteLine("Added certification should be displayed on the profile page");
            Assert.IsTrue(IsAddedCertification);
        }

        [Then("Education saved message should be displayed")]
        public void ThenEducationSavedMessageDisplayed()
        {
            bool IsEducationSavedMessage = profileEducation.ValidateEducationSavedMessage();
            Console.WriteLine("Education saved message should be displayed");
            Assert.IsTrue(IsEducationSavedMessage);
        }


        [Then("Added education should be displayed on the profile page")]
        public void ThenAddedEducationDisplayedOnTheProfilePage()
        {
            bool IsAddedEducation = profileEducation.ValidateAddedEducation();
            Console.WriteLine("Added education should be displayed on the profile page");
            Assert.IsTrue(IsAddedEducation);
        }

        [Then("Availability updated message should be displayed")]
        public void ThenAvailabilityUpdatedMessageDisplayed()
        {
            bool IsAvailabilityUpdatedMessage = profilePage.ValidateSuccessMessage();
            Console.WriteLine("Availability updated message should be displayed");
            Assert.IsTrue(IsAvailabilityUpdatedMessage);
        }

        [Then("Hours updated message should be displayed")]
        public void ThenHoursUpdatedMessageDisplayed()
        {
            bool IsHoursUpdatedMessage = profilePage.ValidateSuccessMessage();
            Console.WriteLine("Hours updated message should be displayed");
            Assert.IsTrue(IsHoursUpdatedMessage);
        }

        [Then("Earn Target updated message should be displayed")]
        public void ThenEarnTargetUpdatedMessageDisplayed()
        {
            bool IsEarnTargetUpdatedMessage = profilePage.ValidateSuccessMessage();
            Console.WriteLine("Earn Target updated message should be displayed");
            Assert.IsTrue(IsEarnTargetUpdatedMessage);
        }

        [Then("Password changed message should be displayed")]
        public void ThenPasswordChangedMessageDisplayed()
        {
            bool isPasswordChanged = changePasswordPage.ValidateSuccessMessage();
            Console.WriteLine("Password changed message should be displayed");
            Assert.IsTrue(isPasswordChanged);
        }
    }
}