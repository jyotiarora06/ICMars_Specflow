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
        IWebElement Chat => driver.FindElement(By.XPath("//a[contains(text(),'Chat')]"));
        IWebElement SearchBox => driver.FindElement(By.XPath("//input[@class='prompt']"));
        IWebElement ChatTextBox => driver.FindElement(By.XPath("//input[@id ='chatTextBox']"));
        IWebElement Send => driver.FindElement(By.XPath("//button[@id='btnSend']"));
        IWebElement SentMessage => driver.FindElement(By.XPath("//span[text()='Testing skill exchange']"));

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
            Wait.ElementExists(driver, "XPath", "//input[@id ='chatTextBox']", 10);
            return ChatTextBox.Displayed;
            
        }

        public bool ValidateMessageSent()
        {
            Wait.ElementExists(driver, "XPath", "//span[text()='Testing skill exchange']", 50);
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
