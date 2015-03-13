using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.WindowsAzure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation
{
    public class RequestSettings : IDisposable
    {
        private readonly AutomationManagementClient client;

        public RequestSettings(IAutomationManagementClient automationClient)
        {
            client = ((AutomationManagementClient)automationClient);
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, Guid.NewGuid().ToString());
        }
        
        public void Dispose()
        {
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
        }
    }
}
