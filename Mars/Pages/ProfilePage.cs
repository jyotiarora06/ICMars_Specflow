using System;
using Mars.Utilities;
using OpenQA.Selenium;

namespace Mars
{
    class ProfilePage
    {
        private readonly IWebDriver driver;


        //page factory design pattern

        IWebElement DescriptionText => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3"));
        IWebElement DescriptionIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        IWebElement Description => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        IWebElement Save => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        IWebElement SavedDescription => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        IWebElement AddNewLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement AddNewSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement Language => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        IWebElement LanguageLevel => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        IWebElement AddLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        IWebElement AddSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));                                                        
        IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        IWebElement Skill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        IWebElement SkillLevel => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));                                                        
        IWebElement AddedLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement AddedSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        IWebElement Message => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        //IWebElement RemoveLanguage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        //IWebElement RemoveSkill => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));

        //Create a Constructor
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidateProfilePage()
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3", 20);
            return DescriptionText.Displayed;
        }

        public void ClickDescriptionIcon()
        {
            //click description icon
            DescriptionIcon.Click();
        }

        public void EnterDescription(string description)
        {
           //enter description
            Description.Clear();
            Description.SendKeys(description);
        }

        public void ClickSave()
        {
            //click save
            Save.Click();
         
        }

        /*
        public void DeleteLanguage()
        {
            //click delete icon
            RemoveLanguage.Click();

        }

        public void DeleteSkill()
        {
            //click delete icon
            RemoveSkill.Click();

        }
        */
        public void ClickAddNewLanguage()
        {
            //click add new for language
            AddNewLanguage.Click();
        }

        public void ClickAddNewSkill()
        {
            //click add new for skill
            AddNewSkill.Click();
        }

        public void EnterLanguage(string language)
        {
            // enter language
            Language.SendKeys(language);
        }

        public void ChooseLanguageLevel()
        {
           //choose language lavel
            LanguageLevel.Click();
        }

        public void ClickAddLanguage()
        {
            //click add for language
            AddLanguage.Click();
        }

        public void ClickAddSkill()
        {
            //click add for skill
            AddSkill.Click();
        }

        public void ClickSkills()
        {
            //click skills tab
            SkillsTab.Click();
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 10);                                       
        }

        public void EnterSkill(string skill)
        {
            //enter skill
            Skill.SendKeys(skill);
        }

        public void ChooseSkillLevel()
        {
            //choose skill level
            SkillLevel.Click();
            
        }

        public bool ValidateDescriptionSavedMessage(string message)
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 100);

            if (Message.Text == message)
            {
                Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }
        
        public bool ValidateSavedDescription(string description)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 40);

            //validate description is saved
            if (SavedDescription.Text == description)
            {
                Console.WriteLine("Description is saved, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Description is not saved, test failed");
                return false;
            }
        }

        public bool ValidateLanguageSavedMessage(string message)
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 30);

            if (Message.Text == message)
            {
                Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        public bool ValidateAddedLanguage(string language)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //validate language is added
            if (AddedLanguage.Text == language)
            {   
                Console.WriteLine("Language is added, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Language is not added, test failed");
                return false;
            }
        }

        public bool ValidateSkillSavedMessage(string message)
        {
            Wait.ElementExists(driver, "XPath", "/html/body/div[1]/div", 40);

            if (Message.Text == message)
            {
                Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        public bool ValidateAddedSkill(string skill)
        {
            Wait.ElementExists(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //validate skill is added
            if (AddedSkill.Text == skill)
            {
                Console.WriteLine("Skill is added, test passed");
                return true;
            }
            else
            {
                Console.WriteLine("Skill is not added, test failed");
                return false;
            }
        }
    }
}
