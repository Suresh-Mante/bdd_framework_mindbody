using NUnit.Framework;
using RestSharp;
using Specflow_Automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowAPIAutomation.StepDefinitions
{
    [Binding]
    public class PetShopStepDefinitions
    {

        public PetShopStepDefinitions()
        {
            AutomationHooks.request = new RestRequest();
        }

        [Given(@"I have base url '([^']*)' and resource '([^']*)'")]
        public void GivenIHaveBaseUrlAndResource(string baseUrl, string resourceUrl)
        {
            AutomationHooks.client = new RestClient(baseUrl + resourceUrl);
        }


        [When(@"I do the Get Request")]
        public void WhenIDoTheGetRequest()
        {
            AutomationHooks.request.Method = Method.Get;
            AutomationHooks.response = AutomationHooks.client.Execute(AutomationHooks.request);
        }

        [Then(@"I should get the response as (.*)")]
        public void ThenIShouldGetTheResponseAs(int expectedResponseCode)
        {
            Assert.AreEqual(expectedResponseCode, (int)AutomationHooks.response.StatusCode);
        }

        [Then(@"I should get the details of pet in json format")]
        public void ThenIShouldGetTheDetailsOfPetInJsonFormat()
        {
            var data = AutomationHooks.response.Content;
        }

        [Then(@"I should get the message as '([^']*)'")]
        public void ThenIShouldGetTheMessageAs(string expectedMessage)
        {
            if((int)AutomationHooks.response.StatusCode != 200)
            {
                Assert.True(AutomationHooks.response.Content.Contains(expectedMessage));
            }
        }

        [Given(@"I need to add api_key '([^']*)' in the header")]
        public void GivenINeedToAddApi_KeyInTheHeader(string apiKey)
        {
            AutomationHooks.request.AddHeader("api_key", apiKey);
        }

        [When(@"I do the delete request")]
        public void WhenIDoTheDeleteRequest()
        {
            AutomationHooks.request.Method = Method.Delete;
            AutomationHooks.response = AutomationHooks.client.Execute(AutomationHooks.request);
        }
    }
}
