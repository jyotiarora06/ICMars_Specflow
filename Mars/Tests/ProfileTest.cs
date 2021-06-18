using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;

namespace Mars.Tests
{
    [TestFixture]
    public class ProfileTest:Driver
    {
        private CommonMethods commonMethods;
      
        public ProfileTest()
        {
            commonMethods = new CommonMethods();
            
        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void DescriptionTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Description method is called");

                Setup(browserName);
                //Profile Description objects
                ProfileDescription profileDescriptionObj = new ProfileDescription(driver);
                profileDescriptionObj.Description();
                test.Log(Status.Pass, "Description is saved successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void LanguagesTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Languages method is called");

                Setup(browserName);
                //Profile Language objects
                ProfileLanguage profileLanguageObj = new ProfileLanguage(driver);
                profileLanguageObj.Languages();
                test.Log(Status.Pass, "Language is added successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void SkillsTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Skills method is called");

                Setup(browserName);
                //Profile Skill objects
                ProfileSkill profileSkillObj = new ProfileSkill(driver);
                profileSkillObj.Skills();
                test.Log(Status.Pass, "Skill is added successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void EducationTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Education method is called");

                Setup(browserName);
                //Profile Education objects
                ProfileEducation profileEducationObj = new ProfileEducation(driver);
                profileEducationObj.Education();
                test.Log(Status.Pass, "Education is added successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void CertificationTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Certification method is called");

                Setup(browserName);
                //Profile Certifications objects
                ProfileCertifications profileCertificationsObj = new ProfileCertifications(driver);
                profileCertificationsObj.Certification();
                test.Log(Status.Pass, "Certification is added successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void AvailabilityTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Availability method is called");

                Setup(browserName);
                //Profile Page objects
                ProfilePage profilePageObj = new ProfilePage(driver);
                profilePageObj.Availability();

                test.Log(Status.Pass, "Availability is updated successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void HoursTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Hours method is called");

                Setup(browserName);
                //Profile Page objects
                ProfilePage profilePageObj = new ProfilePage(driver);
                profilePageObj.Hours();

                test.Log(Status.Pass, "Hours is updated successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }

        [Test]
        [TestCaseSource(typeof(Driver), "BrowserToRunWith")]
        public void EarnTargetTest(string browserName)
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EarnTarget method is called");

                Setup(browserName);
                //Profile Page objects
                ProfilePage profilePageObj = new ProfilePage(driver);
                profilePageObj.EarnTarget();

                test.Log(Status.Pass, "EarnTarget is updated successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = commonMethods.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }
    }
}
