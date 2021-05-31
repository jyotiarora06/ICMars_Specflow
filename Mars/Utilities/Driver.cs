using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Mars.Utilities
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver;
      

        [OneTimeSetUp]
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();
           
            //Maximise the window
            driver.Manage().Window.Maximize();
        
        }
    
        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [OneTimeTearDown]
        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }


    }
}

