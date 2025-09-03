using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayRoutesInformation", DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSGatewayRouteSetsInformation))]
    public class GetAzureVirtualNetworkGatewayRoutesInformationCommand : NetworkBaseCmdlet
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
            Mandatory = false,
            HelpMessage = "Attempt to recalculate the Route Sets Information for the gateway.")]
        public bool AttemptRefresh { get; set; } = false;

        public override void Execute()
        {
            base.Execute();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .GetRoutesInformationWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    virtualNetworkGatewayName: VirtualNetworkGatewayName,
                    attemptRefresh: AttemptRefresh)
                .GetAwaiter().GetResult();

            GatewayRouteSetsInformation routeInfo = null;

            if (response.Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                routeInfo = DeserializeJsonResponse(response.Response);
            }
            else if (response.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var locationUrl = response.Response.Headers.Location?.ToString();
                if (!string.IsNullOrEmpty(locationUrl))
                {
                    WriteVerbose("Operation accepted. Polling the Location URL until completion...");
                    routeInfo = PollAndParse(locationUrl);
                }
                else
                {
                    throw new InvalidOperationException("Location header is missing in 202 Accepted response.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response status: {response.Response.StatusCode}");
            }

            if (routeInfo != null)
            {
                var formattedJson = JsonConvert.SerializeObject(routeInfo, Formatting.Indented);
                WriteObject(formattedJson);
            }
        }

        private GatewayRouteSetsInformation DeserializeJsonResponse(HttpResponseMessage responseMessage)
        {
            var json = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            json = json.Replace(" PM UTC", " PM");
            return JsonConvert.DeserializeObject<GatewayRouteSetsInformation>(json);
        }

        private GatewayRouteSetsInformation PollAndParse(string locationUrl)
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
                        return JsonConvert.DeserializeObject<GatewayRouteSetsInformation>(json);
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
