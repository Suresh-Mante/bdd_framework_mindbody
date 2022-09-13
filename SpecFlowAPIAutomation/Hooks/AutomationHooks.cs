using RestSharp;

namespace Specflow_Automation.Hooks
{
    [Binding]
    public class AutomationHooks
    {
        public static RestClient client;
        public static RestRequest request;
        public static RestResponse response;

    }
}
