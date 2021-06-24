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
        IWebElement Chat => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]"));
        IWebElement SearchBox => driver.FindElement(By.XPath("//*[@id='chatRoomContainer']/div/div[1]/div/div[1]/input"));
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

        //sending message to seller
        public void ChatWithSeller()
        {
            searchPageObj.SearchSkillsByAllCategories();
            searchPageObj.ClickSearchedSkill();
            bool isServiceDetailPage = serviceDetailPageObj.ValidateYouAreAtServiceDetailPage();
            Assert.IsTrue(isServiceDetailPage);
            serviceDetailPageObj.ClickChatButton();
            ValidateYouAreInChatRoom();
            EnterChatMessage();
            ClickSend();
            bool isMessageSent = ValidateMessageSent();
            Assert.IsTrue(isMessageSent);
        }

        public void ClickChat()
        {
            //click chat item
            Chat.Click();
        }

        public void EnterChatMessage()
        {
            //enter message in chat text box
            ChatTextBox.SendKeys(ExcelLibHelper.ReadData(1, "ChatMessage"));

        }
        public void ClickSend()
        {
            //click send
            Send.Click();
        }

        public void EnterSellerName()
        {
            //enter message in chat text box
            SearchBox.SendKeys(ExcelLibHelper.ReadData(1, "SellerName"));

        }

        public bool ValidateYouAreInChatRoom()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='chatTextBox']", 10);
            return ChatTextBox.Displayed;
            
        }

        public bool ValidateMessageSent()
        {
            Wait.ElementExists(driver, "XPath", "//*[text()='Hello I want to exchange my skill']", 200);
            //validate message is sent to seller
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
