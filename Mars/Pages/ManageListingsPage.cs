using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class ManageListingsPage
    {
        private IWebDriver driver;
        private readonly ShareSkillPage shareSkill;
        private bool isProfilePage;

        //page factory design pattern
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div/div"));
        IWebElement RemoveIcon => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        IWebElement No => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        IWebElement Yes => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        IWebElement DeletePopup => driver.FindElement(By.XPath(" /html/body/div[2]/div/div[1]"));
        IWebElement ManageListings => driver.FindElement(By.XPath("/html/body/div/div/section[1]/div/a[3]"));
        IWebElement UpdateIcon => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        IWebElement UpdatedTitle => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        IWebElement UpdatedDescription => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        IWebElement UpdatedCategory => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));

        //reading data from file
        private string deleteMessage = ExcelLibHelper.ReadData(1, "DeleteMessage");
        private string editTitle = ExcelLibHelper.ReadData(1, "EditTitle");
        private string editDescription = ExcelLibHelper.ReadData(1, "EditDescription");
        private string editCategory = ExcelLibHelper.ReadData(1, "EditCategory");
        private string editTags = ExcelLibHelper.ReadData(1, "EditTags");
        private string editServiceType = ExcelLibHelper.ReadData(1, "EditServiceType");
        private string editLocationType = ExcelLibHelper.ReadData(1, "EditLocationType");
        private string editSkillTrade = ExcelLibHelper.ReadData(1, "EditSkillTrade");
        private string editAcive = ExcelLibHelper.ReadData(1, "EditActive");
        private string editSkillExchangeTag = ExcelLibHelper.ReadData(1, "EditSkillExchangeTag");
        private string editCreditServiceCharge = ExcelLibHelper.ReadData(1, "EditCreditServiceCharge");
        private int editDaysToStartDate = Convert.ToInt32(ExcelLibHelper.ReadData(1, "EditDaysInCurrentDateToStart"));
        private int editDaysToEndDate = Convert.ToInt32(ExcelLibHelper.ReadData(1, "EditDaysInCurrentDateToEnd"));

        //Create a Constructor
        public ManageListingsPage(IWebDriver driver)
        {
            this.driver = driver;
            shareSkill = new ShareSkillPage(driver);   
        }


        private bool ExistsElement()
        {
            try
            {
                driver.FindElement(By.XPath("/html/body/div/div/section[1]/div/a[3]"));
             
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        //updating service listing details
        public void EditService()
        {

            isProfilePage = ExistsElement();
            if (isProfilePage == true)
            {
                ClickManageListings();
            }
         
            ClickUpdateIcon();
            shareSkill.ValidateYouAreAtShareSkillPage();
            shareSkill.EnterTitle(editTitle);
            shareSkill.EnterDescription(editDescription);
            shareSkill.SelectCategory(editCategory);
            shareSkill.SelectSubCategory();
            shareSkill.EnterTags(editTags);
            shareSkill.SelectServiceType(editServiceType);
            shareSkill.SelectLocationType(editLocationType);
            shareSkill.EnterStartDate(editDaysToStartDate);
            shareSkill.EnterEndDate(editDaysToStartDate, editDaysToEndDate);
            shareSkill.SelectSkillTrade(editSkillTrade, editSkillExchangeTag, editCreditServiceCharge);
            shareSkill.SelectActive(editAcive);
            shareSkill.ClickSave();
            bool isServiceUpdated = ValidateServiceUpdatedSuccessfully();
            Assert.IsTrue(isServiceUpdated);
        }

        //deleting service listing
        public void DeleteService()
        {
            isProfilePage = ExistsElement();
            if (isProfilePage == true)
            {
                ClickManageListings();
            }
           
            ClickRemoveIcon();
            ValidateDeletePopup();
            ClickYes();
            bool isServiceDeleted = ValidateServiceDeletedSuccessfully();
            Assert.IsTrue(isServiceDeleted);
        }

        public void ClickRemoveIcon()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 50);
            RemoveIcon.Click();
        }

        public void ClickManageListings()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div/section[1]/div/a[3]", 100);
            ManageListings.Click();
        }
       

        public void ValidateDeletePopup()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 20);
            bool isDeletePopup = DeletePopup.Displayed;
            Assert.IsTrue(isDeletePopup);
        }

        public void ClickYes()
        {
            Yes.Click();
        }

        public void ClickNo()
        {
            No.Click();
        }

        public bool ValidateServiceDeletedSuccessfully()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div/div", 4000);
            //remove before characters
            string Msg = Message.Text;
            int charPos = Msg.IndexOf(" ");
            Msg = Msg.Remove(0, charPos+1);
            if (Msg == deleteMessage)
            {
                //Assert.Pass("user is able to delete Service successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to delete Service, test failed");
                return false;
            }

        }

        public void ClickUpdateIcon()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 50);
            UpdateIcon.Click();
        }

        public bool ValidateServiceUpdatedSuccessfully()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]", 500);
            if (UpdatedTitle.Text == editTitle && UpdatedDescription.Text == editDescription && UpdatedCategory.Text == editCategory)
            {
                //Assert.Pass("user is able to update Service successfully, test passed");
                return true;
            }
            else
            {
                //Assert.Fail("user is not able to update Service, test failed");
                return false;
            }

        }


    }
}
