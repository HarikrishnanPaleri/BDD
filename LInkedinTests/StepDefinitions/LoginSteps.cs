using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LInkedinTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        
       
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://linkedin.com/";
        }

        [AfterFeature]
        public static void CleanUP()
        {
            driver.Quit();
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement? emailInput = fluentWait.Until(dri => dri?.FindElement(By.Id("session_key")));
            emailInput?.SendKeys(un);
        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            passwordInput = fluentWait.Until(dri => dri?.FindElement(By.Id("session_password")));
            passwordInput?.SendKeys(pwd);
            Console.WriteLine(passwordInput.GetAttribute("value"));
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type ='submit']")));
            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//button[@type ='submit']")));
        }

        [Then(@"User will be redirected to homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }
        [Then(@"Error message for Password Lenth should be thrown")]
        public void ThenErrorMessageForPasswordLenthShouldBeThrown()
        {
            IWebElement alertPara = driver.FindElement(By.XPath("//p[@for='session_password']"));
            string? alerttext = alertPara?.Text;
            Assert.That(alerttext.Equals("The password you provided must have at least 6 characters"));
        }
        [When(@"User will click on show link in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"The Password Characters Should Be Shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
           Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on Hide link in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            showButton.Click();
        }

        [Then(@"The Password Characters Should not Be Shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }
}
