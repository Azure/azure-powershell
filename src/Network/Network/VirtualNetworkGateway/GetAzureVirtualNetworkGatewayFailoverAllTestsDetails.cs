// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;


namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayFailoverAllTestsDetails", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteFailoverTestDetails>))]
    public class GetAzureVirtualNetworkGatewayFailoverAllTestsDetails : NetworkBaseCmdlet
    {
       private const string GetByNameParameterSet = "GetByNameParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual network gateway.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual network gateway.",
            ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The type of failover test.",
            ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Fetch only the latest tests for each peering location.",
            ParameterSetName = GetByNameParameterSet)]
        public bool FetchLatest { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Start the operation to get failover test details
            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .GetFailoverAllTestDetailsWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    virtualNetworkGatewayName: VirtualNetworkGatewayName,
                    type: Type,
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
                    var fullJson = JsonConvert.SerializeObject(new PSExpressRouteFailoverTestResponse { Value = testDetails }, Formatting.Indented);
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
                var fullJson = JsonConvert.SerializeObject(new PSExpressRouteFailoverTestResponse { Value = testDetails }, Formatting.Indented);
                WriteObject(fullJson);
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response status: {response.Response.StatusCode}");
            }
        }

        // Wrapper class for the response containing a list of test details
        public class PSExpressRouteFailoverTestResponse
        {
            [JsonProperty("value")]
            public List<PSExpressRouteFailoverTestDetails> Value { get; set; }
        }

        // Deserialize the JSON response into the wrapper class
        private List<PSExpressRouteFailoverTestDetails> DeserializeJsonResponse(HttpResponseMessage responseMessage)
        {
            var json = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var response = JsonConvert.DeserializeObject<PSExpressRouteFailoverTestResponse>(json);
            return response.Value;
        }

        // Poll until the operation completes and the status changes to 200 OK
        private List<PSExpressRouteFailoverTestDetails> PollAndParse(string locationUrl)
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
                        var response = JsonConvert.DeserializeObject<PSExpressRouteFailoverTestResponse>(json);
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