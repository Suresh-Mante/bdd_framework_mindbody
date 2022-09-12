using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Specflow_Automation.Hooks;
using TechTalk.SpecFlow;

namespace Specflow_Automation.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private string firstName = string.Empty;
        private string middleName = string.Empty;
        private string lastName = string.Empty;

        [When(@"I click on PIM menu")]
        public void WhenIClickOnPIMMenu()
        {
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add employee")]
        public void WhenIClickOnAddEmployee()
        {
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AutomationHooks.driver.FindElement(By.XPath("//button[text()=' Add ']")).Click();
        }

        [When(@"I fill the add employee section")]
        public void WhenIFillTheAddEmployeeSection(Table table)
        {
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            table.Rows.ElementAt(0).TryGetValue("firstname", out firstName);
            table.Rows.ElementAt(0).TryGetValue("middlename", out middleName);
            table.Rows.ElementAt(0).TryGetValue("lastname", out lastName);
            table.Rows.ElementAt(0).TryGetValue("employee_id", out string employee_id);
            table.Rows.ElementAt(0).TryGetValue("toggle_login_detail", out string toggle_login_detail);
            table.Rows.ElementAt(0).TryGetValue("username", out string username);
            table.Rows.ElementAt(0).TryGetValue("password", out string password);
            table.Rows.ElementAt(0).TryGetValue("confirm_password", out string confirm_password);
            table.Rows.ElementAt(0).TryGetValue("status", out string status);

            AutomationHooks.driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys(firstName);
            AutomationHooks.driver.FindElement(By.XPath("//input[@name='middleName']")).SendKeys(middleName);
            AutomationHooks.driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys(lastName);

            if (toggle_login_detail == "on")
            {
                AutomationHooks.driver.FindElement(By.XPath("//span[contains(@class, 'oxd-switch-input')]")).Click();

                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Username')]/following::input"))
                    .SendKeys(username);
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Password')]/following::input"))
                    .SendKeys(password);
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Confirm Password')]/following::input"))
                    .SendKeys(confirm_password);

                if (status.ToLower().Equals("disabled"))
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text()='Disabled']")).Click();
                }
                else
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text()='Enabled']")).Click();
                }
            }
        }

        [When(@"I click on save")]
        public void WhenIClickOnSave()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[text()=' Save ']")).Click();
        }

        [Then(@"I should be navigated to personal details section with added employee records\.")]
        public void ThenIShouldBeNavigatedToPersonalDetailsSectionWithAddedEmployeeRecords_()
        {
            string actualFirstName = AutomationHooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");
            Assert.Equal(firstName, actualFirstName);

            string actualMiddleName = AutomationHooks.driver.FindElement(By.Name("middleName")).GetAttribute("value");
            Assert.Equal(middleName, actualMiddleName);

            string actualLastName = AutomationHooks.driver.FindElement(By.Name("lastName")).GetAttribute("value");
            Assert.Equal(lastName, actualLastName);
        }
    }
}
