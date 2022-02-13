using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Internal.Common;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Get-AzRouteServerPeerLearnedRoute")]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouterPeerLearnedRoute", DefaultParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName), OutputType(typeof(PSPeerRoute))]
    public class GetVirtualRouterPeerLearnedRouteCommand : NetworkBaseCmdlet
    {
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router peer resource group's name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router name")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualRouterName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual router peer name")]
        [ValidateNotNullOrEmpty]
        public virtual string PeerName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual router peer input object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualRouterPeer InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        IAzureContext context;
        private IAzureRestClient _client;
        private IAzureRestClient ServiceClient
        {
            get
            {
                if (_client == null)
                {
                    var clientFactory = AzureSession.Instance.ClientFactory;
                    _client = clientFactory.CreateArmClient<AzureRestClient>(context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        public override void Execute()
        {
            WriteWarningWithTimestamp("Upcoming breaking changes in the cmdlet 'Get-AzVirtualRouterLearnedRoutes': "
                + "The output type 'Microsoft.Azure.Commands.Network.Models.PSVirtualRouterLearnedRoutes' is changing. "
                + "Note: Go to https://aka.ms/azps-changewarnings for steps to suppress this breaking change warning, and other information on breaking changes in Azure PowerShell.");

            base.Execute();

            context = DefaultContext;

            if (string.Equals(this.ParameterSetName, VirtualRouterPeerParameterSetNames.ByVirtualRouterPeerInputObject, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                PeerName = resourceInfo.ResourceName;
                VirtualRouterName = resourceInfo.ParentResource;
            }

            var locationHeader = this.NetworkClient.NetworkManagementClient.VirtualHubBgpConnections.ListLearnedRoutesWithHttpMessagesAsync(this.ResourceGroupName, this.VirtualRouterName, this.PeerName).Result.Response.Headers.Location;

            string resourceId = locationHeader.LocalPath;
            string apiVersion = locationHeader.Query.Substring(13);
            var reponse = ServiceClient.Operations.GetResourceWithFullResponse(resourceId, apiVersion).Body;
            dynamic routeServiceRole = JObject.Parse(reponse);

            List<PeerRoute> peerRouteList = routeServiceRole.RouteServiceRole_IN_0.ToObject<List<PeerRoute>>();
            peerRouteList.AddRange(routeServiceRole.RouteServiceRole_IN_1.ToObject<List<PeerRoute>>());

            List<PSPeerRoute> learnedRoutes = new List<PSPeerRoute>();
            foreach (var route in peerRouteList)
            {
                learnedRoutes.Add(NetworkResourceManagerProfile.Mapper.Map<PSPeerRoute>(route));
            }

            WriteObject(learnedRoutes, true);
        }
    }
}