using System;
using AventStack.ExtentReports;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;


namespace Mars.Tests
{
    [TestFixture]
    class SearchTest : Driver
    {
        private readonly CommonMethods commonMethods;
       

        public SearchTest()
        {
            commonMethods = new CommonMethods();
            
        }

        [Test]
        public void SearchSkillsByAllCategoriesTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByAllCategories method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage(driver);
                searchPageObj.SearchSkillsByAllCategories();

                test.Log(Status.Pass, "Search skills by all categories is tested");
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
        public void SearchSkillsByFiltersTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByFilters method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage(driver);
                searchPageObj.SearchSkillsByFilters();

                test.Log(Status.Pass, "Search skills by filters is tested");
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


