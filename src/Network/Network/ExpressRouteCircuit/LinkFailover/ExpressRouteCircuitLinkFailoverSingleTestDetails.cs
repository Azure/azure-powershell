using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.ExpressRouteCircuit
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitLinkFailoverSingleTestDetails", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteLinkFailoverSingleTestDetails>))]
    public class ExpressRouteCircuitLinkFailoverSingleTestDetails : NetworkBaseCmdlet
    {
        private const string ByName = "ByName";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the ExpressRoute circuit.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ExpressRoute circuit.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteCircuitName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Link type: Primary or Secondary.",
            ParameterSetName = ByName)]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string LinkType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Circuit Test Category: BgpDisconnect or ASPathPrepend.",
            ParameterSetName = ByName)]
        [ValidateSet("BgpDisconnect", "ASPathPrepend", IgnoreCase = true)]
        public string CircuitMaintenanceCategory { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique Guid value which identifies the test.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string FailoverTestId { get; set; }

        public override void Execute()
        {
            base.Execute();

            var response = NetworkClient.NetworkManagementClient.ExpressRouteCircuits
                .GetCircuitLinkFailoverSingleTestDetailsWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    circuitName: ExpressRouteCircuitName,
                    linkType: LinkType,
                    circuitTestCategory: CircuitMaintenanceCategory,
                    failoverTestId: FailoverTestId)
                .GetAwaiter().GetResult();

            if (response.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                WriteVerbose("Operation accepted. Polling for results...");
                var locationUrl = response.Response.Headers.Location?.ToString();
                if (!string.IsNullOrEmpty(locationUrl))
                {
                    var testDetails = PollAndParse(locationUrl);
                    var fullJson = JsonConvert.SerializeObject(new FailoverTestDetailsWrapper { Value = testDetails }, Formatting.Indented);
                    WriteObject(fullJson);
                }
                else
                {
                    throw new InvalidOperationException("Location header missing in 202 Accepted response.");
                }
            }
            else if (response.Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var testDetails = DeserializeJsonResponse(response.Response);
                var fullJson = JsonConvert.SerializeObject(new FailoverTestDetailsWrapper { Value = testDetails }, Formatting.Indented);
                WriteObject(fullJson);

            }
            else
            {
                throw new InvalidOperationException($"Unexpected response status: {response.Response.StatusCode}");
            }
        }

        private class FailoverTestDetailsWrapper
        {
            [JsonProperty("value")]
            public List<PSExpressRouteLinkFailoverSingleTestDetails> Value { get; set; }
        }

        private List<PSExpressRouteLinkFailoverSingleTestDetails> DeserializeJsonResponse(HttpResponseMessage responseMessage)
        {
            var json = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            WriteVerbose("Response JSON: " + json);

            var wrapper = JsonConvert.DeserializeObject<FailoverTestDetailsWrapper>(json);
            return wrapper?.Value ?? new List<PSExpressRouteLinkFailoverSingleTestDetails>();
        }

        private List<PSExpressRouteLinkFailoverSingleTestDetails> PollAndParse(string locationUrl)
        {
            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(5000); // wait before polling
                    var pollResponse = httpClient.GetAsync(locationUrl).GetAwaiter().GetResult();

                    WriteVerbose($"Polling response status code: {pollResponse.StatusCode}");

                    if (pollResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        continue; // still processing
                    }
                    else if (pollResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = pollResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        var response = JsonConvert.DeserializeObject<FailoverTestDetailsWrapper>(json);
                        return response.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Polling failed. Status code: {pollResponse.StatusCode}");
                    }
                }
            }
        }
    }
}