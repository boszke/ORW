using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using NUnit.Framework;

using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    class Selen
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.kurnik.pl";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSeleniumTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("piłka")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("gość")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='appcont']/div[1]/div/div/div[1]/div[1]/button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='appcont']/div[2]/div[2]/div[3]/div[2]/div[1]/div[2]/button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='appcont']/div[2]/div[2]/div[3]/div[2]/div[1]/div[2]/div/button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='appcont']/div[2]/div[2]/div[3]/div[1]/div[1]/button[2]")).Click();
            Thread.Sleep(1000);
            driver.Close();
            Thread.Sleep(5000);
        }




        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
    
}
