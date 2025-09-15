// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayFailoverSingleTestDetail", DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(List<PSExpressRouteFailoverSingleTestDetails>))]
    public class GetAzureVirtualNetworkGatewayFailoverSingleTestDetail : NetworkBaseCmdlet
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
            HelpMessage = "Peering location of the test.",
            ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique Guid value which identifies the test.",
            ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FailoverTestId { get; set; }

        public override void Execute()
        {
            base.Execute();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .GetFailoverSingleTestDetailsWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    virtualNetworkGatewayName: VirtualNetworkGatewayName,
                    peeringLocation: PeeringLocation,
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
            public List<PSExpressRouteFailoverSingleTestDetails> Value { get; set; }
        }

        private List<PSExpressRouteFailoverSingleTestDetails> DeserializeJsonResponse(HttpResponseMessage responseMessage)
        {
            var json = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            WriteVerbose("Response JSON: " + json);

            var wrapper = JsonConvert.DeserializeObject<FailoverTestDetailsWrapper>(json);
            return wrapper?.Value ?? new List<PSExpressRouteFailoverSingleTestDetails>();
        }

         private List<PSExpressRouteFailoverSingleTestDetails> PollAndParse(string locationUrl)
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
                        var response =  JsonConvert.DeserializeObject<FailoverTestDetailsWrapper>(json);
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
