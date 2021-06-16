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
        public void DescriptionTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Description method is called");

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
        public void LanguagesTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Languages method is called");

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
        public void SkillsTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Skills method is called");

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
        public void EducationTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Education method is called");

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
        public void CertificationTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Certification method is called");

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
        public void AvailabilityTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Availability method is called");
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
        public void HoursTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Hours method is called");
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
        public void EarnTargetTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EarnTarget method is called");
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
