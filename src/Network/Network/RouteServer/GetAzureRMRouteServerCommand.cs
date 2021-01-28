using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServer", DefaultParameterSetName = RouteServerParameterSetNames.ByRouteServerSubscriptionId), OutputType(typeof(PSRouteServer))]
    public partial class GetAzureRmRouteServer : RouteServerBaseCmdlet
    {
        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            Mandatory = true,
            HelpMessage = "The resource group name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            Mandatory = false,
            HelpMessage = "The name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string RouteServerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, RouteServerParameterSetNames.ByRouteServerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                RouteServerName = resourceInfo.ResourceName;
            }

            string ipConfigName = "ipconfig1";
            if (ShouldGetByName(ResourceGroupName, RouteServerName))
            {
                var virtualHub = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(ResourceGroupName, RouteServerName);
                var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                virtualHubModel.ResourceGroupName = this.ResourceGroupName;
                virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                AddBgpConnectionsToPSVirtualHub(virtualHubModel, ResourceGroupName, RouteServerName);
                AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, RouteServerName, ipConfigName);

                var routeServerModel = new PSRouteServer(virtualHubModel);
                routeServerModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                WriteObject(routeServerModel, true);
            }
            else
            {
                IPage<VirtualHub> virtualHubPage;
                if (ShouldListByResourceGroup(ResourceGroupName, RouteServerName))
                {
                    virtualHubPage = this.NetworkClient.NetworkManagementClient.VirtualHubs.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    virtualHubPage = this.NetworkClient.NetworkManagementClient.VirtualHubs.List();
                }

                var virtualHubList = ListNextLink<VirtualHub>.GetAllResourcesByPollingNextLink(virtualHubPage,
                    this.NetworkClient.NetworkManagementClient.VirtualHubs.ListNext);
                List<PSRouteServer> routeServerList = new List<PSRouteServer>();
                foreach (var virtualHub in virtualHubList)
                {
                    RouteServerName = virtualHub.Name;
                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualHub>(virtualHub);
                    virtualHubModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(virtualHub.Id);
                    virtualHubModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    AddBgpConnectionsToPSVirtualHub(virtualHubModel, ResourceGroupName, RouteServerName);
                    AddIpConfigurtaionToPSVirtualHub(virtualHubModel, this.ResourceGroupName, RouteServerName, ipConfigName);

                    var routeServerModel = new PSRouteServer(virtualHubModel);
                    routeServerModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHub.Tags);
                    routeServerList.Add(routeServerModel);
                }
                WriteObject(routeServerList, true);
            }
        }
    }
}