using System;
using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static Mars.Utilities.CommonMethods;

namespace Mars.Steps
{
    [Binding]
    public class ChatPageSteps : Driver
    {
        private readonly SignInPage signIn;
        private readonly ServiceDetailPage serviceDetailPage;
        private readonly ChatPage chatPage;
        private readonly SearchPage searchPage;

        //Create a Constructor
        public ChatPageSteps()
        {
            signIn = new SignInPage(driver);
            serviceDetailPage = new ServiceDetailPage(driver);
            chatPage = new ChatPage(driver);
            searchPage = new SearchPage(driver);
        }

        [Given("I am at the Service Detail Page")]
        public void GivenIAmAtTheServiceDetailPage()
        {
            searchPage.SearchSkillsByAllCategories();
            searchPage.ClickSearchedSkill();
            bool isServiceDetailPage = serviceDetailPage.ValidateYouAreAtServiceDetailPage();
            Console.WriteLine("I am at the Service Detail Page");
            Assert.IsTrue(isServiceDetailPage);
        }

        [When("I click Chat button")]
        public void WhenIClickChatButton()
        {
            serviceDetailPage.ClickChatButton();
            Console.WriteLine("I click Chat button");
        }


        [When("I enter message in the chat box")]
        public void WhenIEnterMessageInChatBox()
        {
            chatPage.EnterChatMessage();
            Console.WriteLine("I enter message in the chat box");
        }

        [When("I click send")]
        public void WhenIClickSend()
        {
            chatPage.ClickSend();
            Console.WriteLine("I click send");
        }


        [Given("I am in the Chat room")]
        public void GivenIAmInTheChatRoom()
        {
            signIn.Login(ExcelLibHelper.ReadData(1, "EmailAddress"), ExcelLibHelper.ReadData(1, "Password"));
            chatPage.ClickChat();
            bool isChatRoom = chatPage.ValidateYouAreInChatRoom();
            Console.WriteLine("I am in the Chat room");
            Assert.IsTrue(isChatRoom);
        }

        [When("I enter seller name in search box")]
        public void WhenIEnterSellerNameInSearchBox()
        {
            chatPage.EnterSellerName();
            Console.WriteLine("I enter seller name in search box");
        }


        [Then("Message should be sent")]
        public void ThenMessageShouldBeSent()
        {
            bool isMessageSent = chatPage.ValidateMessageSent();
            Console.WriteLine("Message should be sent");
            Assert.IsTrue(isMessageSent);
        }



        [Then("Chat History with the seller should be visible")]
        public void ThenChatHistoryShouldBeVisible()
        {
            bool isChatHistory = chatPage.ValidateMessageSent();
            Console.WriteLine("Chat History with the seller should be visible");
            Assert.IsTrue(isChatHistory);
        }

    }
}

