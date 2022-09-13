using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specflow_Automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace Specflow_Automation.StepDefinitions
{
    [Binding]
    //[CollectionDefinition("SpecFlowNonParallelizableFeatures", DisableParallelization = false)]
    public class LoginStepDefinitions
    {
        private readonly AutomationHooks _automationHooks;
        public LoginStepDefinitions(AutomationHooks automationHooks)
        {
            _automationHooks = automationHooks;
        }

        [Given(@"I have a browser and orangehrm page")]
        public void GivenIHaveABrowserAndOrangehrmPage()
        {
            _automationHooks.driver = new ChromeDriver();
            _automationHooks.driver.Manage().Window.Maximize();

            _automationHooks.driver.Url = "https://opensource-demo.orangehrmlive.com/";

            _automationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            _automationHooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            _automationHooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            _automationHooks.driver.FindElement(By.CssSelector("button[type=submit]")).Click();
        }

        [Then(@"I should be successfully logged in")]
        public void ThenIShouldBeSuccessfullyLoggedIn()
        {
            Console.WriteLine("Logged in successfully");
        }

        [Then(@"I shoud be navigated to '([^']*)' dashboard screen")]
        public void ThenIShoudBeNavigatedToDashboardScreen(string pIM)
        {
            Console.WriteLine("navigated to dashboard screen");
        }

        [Then(@"I should not be able to log in")]
        public void ThenIShouldNotBeAbleToLogIn()
        {
            Console.WriteLine("Not able to log in");
        }

        [Then(@"I should get an error message as '([^']*)'")]
        public void ThenIShouldGetAnErrorMessageAs(string p0)
        {
            Console.WriteLine("Show an error message");
        }
    }
}
