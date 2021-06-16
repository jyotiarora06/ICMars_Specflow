using System;
using Mars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Mars.Utilities.CommonMethods;

namespace Mars.Pages
{
    public class ChatPage
    {
        private readonly IWebDriver driver;
        private readonly SearchPage searchPageObj;
        private readonly ServiceDetailPage serviceDetailPageObj;

        //page factory design pattern
        IWebElement ChatTextBox => driver.FindElement(By.XPath("//*[@id='chatTextBox']"));
        IWebElement Send => driver.FindElement(By.XPath("//*[@id='btnSend']"));
        IWebElement SentMessage => driver.FindElement(By.XPath("//*[text()='Hello I want to exchange my skill']"));

        //Create a Constructor
        public ChatPage(IWebDriver driver)
        {
            this.driver = driver;
            searchPageObj = new SearchPage(driver);
            serviceDetailPageObj = new ServiceDetailPage(driver);
        }

        public void ChatWithSeller()
        {
            searchPageObj.SearchSkillsByAllCategories();
            searchPageObj.ClickSearchedSkill();
            serviceDetailPageObj.ValidateYouAreAtServiceDetailPage();
            serviceDetailPageObj.ClickChat();
            ValidateYouAreInChatRoom();
            EnterChatMessage();
            ClickSend();
            bool isMessageSent = ValidateMessageSent();
            Assert.IsTrue(isMessageSent);
        }

        public void EnterChatMessage()
        {

            ChatTextBox.SendKeys(ExcelLibHelper.ReadData(1, "ChatMessage"));

        }
        public void ClickSend()
        {
            Send.Click();
        }

        public void ValidateYouAreInChatRoom()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='chatTextBox']", 10);
            bool isChatRoom = ChatTextBox.Displayed;
            Assert.IsTrue(isChatRoom);
        }

        public bool ValidateMessageSent()
        {
            Wait.ElementExists(driver, "XPath", "//*[text()='Hello I want to exchange my skill']", 200);

            if (SentMessage.Text == ExcelLibHelper.ReadData(1, "ChatMessage"))
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
