﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Mars.Utilities
{
    public class Driver
    {
        public static IWebDriver driver;

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

        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
        }


    }
}

