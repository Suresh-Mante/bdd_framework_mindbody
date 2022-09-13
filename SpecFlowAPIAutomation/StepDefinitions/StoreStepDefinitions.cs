using Specflow_Automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowAPIAutomation.StepDefinitions
{
    [Binding]
    public class StoreStepDefinitions
    {
        [Then(@"I should get the details of purchase order in json format")]
        public void ThenIShouldGetTheDetailsOfPurchaseOrderInJsonFormat()
        {
            var data = AutomationHooks.response.Content;
        }
    }
}
