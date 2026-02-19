using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;


namespace Microsoft.Azure.Commands.Network.ExpressRouteCircuit
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitLinkFailoverAllTestsDetails", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteLinkFailoverAllTestsDetails>))]
    public class ExpressRouteCircuitLinkFailoverAllTestsDetails : NetworkBaseCmdlet
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
            HelpMessage = "The type of failover test: LinkFailover.",
            ParameterSetName = ByName)]
        [ValidateSet("SingleSiteFailover", "MultiSiteFailover", "All", "LinkFailover", IgnoreCase = true)]
        public string FailoverTestType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Fetch only the latest tests",
            ParameterSetName = ByName)]
        public bool FetchLatest { get; set; }

        public override void Execute()
        {
            base.Execute();

            // ************* To Do: correct API call to get all test details for the specified ExpressRoute circuit and failover test type
            //var response = NetworkClient.NetworkManagementClient.ExpressRouteCircuits
            //    .GetFailoverAllTestDetailsWithHttpMessagesAsync(
            //        resourceGroupName: ResourceGroupName,
            //        expressRouteCircuitName: ExpressRouteCircuitName,
            //        testType: FailoverTestType,
            //        fetchLatest: FetchLatest)
            //    .GetAwaiter().GetResult();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .GetFailoverAllTestDetailsWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    virtualNetworkGatewayName: ExpressRouteCircuitName,
                    type: FailoverTestType,
                    fetchLatest: FetchLatest)
                .GetAwaiter().GetResult();

            // If the response status is 202 (Accepted), poll for the result
            if (response.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var locationUrl = response.Response.Headers.Location?.ToString();
                if (!string.IsNullOrEmpty(locationUrl))
                {
                    WriteVerbose("Operation accepted. Polling the Location URL until completion...");
                    var testDetails = PollAndParse(locationUrl);
                    var fullJson = JsonConvert.SerializeObject(new PSExpressRouteCircuitLinkFailoverTestResponse { Value = testDetails }, Formatting.Indented); 
                    WriteObject(fullJson);

                }
                else
                {
                    throw new InvalidOperationException("Location header is missing in 202 Accepted response.");
                }
            }
            else if (response.Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // If the response status is 200 (OK), directly deserialize the response
                var testDetails = DeserializeJsonResponse(response.Response);
                var fullJson = JsonConvert.SerializeObject(new PSExpressRouteCircuitLinkFailoverTestResponse { Value = testDetails }, Formatting.Indented);
                WriteObject(fullJson);
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response status: {response.Response.StatusCode}");
            }
        }

        // Wrapper class for the response containing a list of test details
        private class PSExpressRouteCircuitLinkFailoverTestResponse
        {
            [JsonProperty("value")]
            public List<PSExpressRouteLinkFailoverAllTestsDetails> Value { get; set; }
        }

        // Deserialize the JSON response into the wrapper class
        private List<PSExpressRouteLinkFailoverAllTestsDetails> DeserializeJsonResponse(HttpResponseMessage responseMessage)
        {
            var json = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var response = JsonConvert.DeserializeObject<PSExpressRouteCircuitLinkFailoverTestResponse>(json);
            return response.Value;
        }

        // Poll until the operation completes and the status changes to 200 OK
        private List<PSExpressRouteLinkFailoverAllTestsDetails> PollAndParse(string locationUrl)
        {
            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(5000); // Wait 5 seconds between polls

                    var pollResponse = httpClient.GetAsync(locationUrl).GetAwaiter().GetResult();

                    if (pollResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        continue; // keep polling
                    }
                    else if (pollResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = pollResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        var response = JsonConvert.DeserializeObject<PSExpressRouteCircuitLinkFailoverTestResponse>(json);
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