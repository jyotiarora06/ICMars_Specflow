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

        //page factory design pattern
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div/div"));
        IWebElement RemoveIcon => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        IWebElement No => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        IWebElement Yes => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        IWebElement DeletePopup => driver.FindElement(By.XPath(" /html/body/div[2]/div/div[1]"));
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

        //updating service listing details
        public void EditServiceListing()
        {
            shareSkill.CreateServiceListing();
            bool isManageListingsPage = ValidateYouAreAtManageListingsPage();
            Assert.IsTrue(isManageListingsPage);
            ClickUpdateIcon();
            shareSkill.ValidateYouAreAtShareSkillPage();
            EnterEditData();
            shareSkill.ClickSave();
            bool isServiceUpdated = ValidateServiceUpdatedSuccessfully();
            Assert.IsTrue(isServiceUpdated);
        }

        public void EnterEditData()
        {
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
        }

        //deleting service listing
        public void DeleteServiceListing()
        {
            shareSkill.CreateServiceListing();
            bool isManageListingsPage = ValidateYouAreAtManageListingsPage();
            Assert.IsTrue(isManageListingsPage);
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

        public void ValidateDeletePopup()
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 20);
            bool isDeletePopup = DeletePopup.Displayed;
            Assert.IsTrue(isDeletePopup);
        }

        public bool ValidateYouAreAtManageListingsPage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 50);
            return UpdateIcon.Displayed;
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
