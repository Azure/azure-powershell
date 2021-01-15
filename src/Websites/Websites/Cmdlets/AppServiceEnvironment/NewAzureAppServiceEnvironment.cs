using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create a new Azure App Service Environment
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironment", SupportsShouldProcess = true)]
    public class NewAzureAppServiceEnvironmentCmdlet : WebAppBaseClientCmdLet
    {
        private const string ASEv2SubnetIdParameterSet = "ASEv2SubnetIdParameterSet";
        private const string ASEv2SubnetNameParameterSet = "ASEv2SubnetNameParameterSet";
        private const string ASEv3SubnetIdParameterSet = "ASEv3SubnetIdParameterSet";
        private const string ASEv3SubnetNameParameterSet = "ASEv3SubnetNameParameterSet";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the web app eg: West Europe.")]
        [LocationCompleter("Microsoft.Web/sites", "Microsoft.Web/serverFarms", "Microsoft.Web/hostingEnvironments")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The version of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("ASEv2", "ASEv3")]
        public string Kind { get; set; } = "ASEv2";

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = "The vNet name.")]
        [Parameter(ParameterSetName = ASEv3SubnetNameParameterSet, Mandatory = true, HelpMessage = "The vNet name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = true, HelpMessage = "The subnet id.")]
        [Parameter(ParameterSetName = ASEv3SubnetIdParameterSet, Mandatory = true, HelpMessage = "The inbound subnet id.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = "The subnet name.")]
        [Parameter(ParameterSetName = ASEv3SubnetNameParameterSet, Mandatory = true, HelpMessage = "The inbound subnet name.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = "Load balancer mode of the app service environment.")]
        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = true, HelpMessage = "Load balancer mode of the app service environment.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Internal", "External")]
        public string LoadBalancerMode { get; set; }

        [Parameter(ParameterSetName = ASEv3SubnetIdParameterSet, Mandatory = true, HelpMessage = "The subnet id.")]
        [ValidateNotNullOrEmpty]
        public string InboundSubnetId { get; set; }

        [Parameter(ParameterSetName = ASEv3SubnetNameParameterSet, Mandatory = true, HelpMessage = "The subnet name.")]
        [ValidateNotNullOrEmpty]
        public string InboundSubnetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the app service environment object.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, $"Creating App Service Environment '{Name}'"))
            {
                AppServiceEnvironmentResource appServiceEnvironment = new AppServiceEnvironmentResource();
                appServiceEnvironment.AppServiceEnvironmentResourceName = Name;
                appServiceEnvironment.AppServiceEnvironmentResourceLocation = Location;
                appServiceEnvironment.Location = Location;
                appServiceEnvironment.Kind = Kind;
                appServiceEnvironment.WorkerPools = new List<WorkerPool>() { };

                AppServiceEnvironmentResource ase = null;
                switch (ParameterSetName)
                {
                    case ASEv2SubnetNameParameterSet:
                    case ASEv2SubnetIdParameterSet:
                        var subnet = ParameterSetName == ASEv2SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given Subnet
                        var subnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(subnet, VirtualNetworkName);
                        //If unble to fetch Subnet rg from above step, use the input RG to get validation error from api call.
                        subnetResourceGroupName = !String.IsNullOrEmpty(subnetResourceGroupName) ? subnetResourceGroupName : ResourceGroupName;
                        var subnetResourceId = NetworkClient.ValidateSubnet(subnet, VirtualNetworkName, subnetResourceGroupName, DefaultContext.Subscription.Id);

                        appServiceEnvironment.VirtualNetwork = new VirtualNetworkProfile(id: subnetResourceId);
                        appServiceEnvironment.InternalLoadBalancingMode = LoadBalancerMode == "Internal" ? "Web,Publishing" : "None";

                        // Create ASEv2
                        ase = WebsitesClient.CreateAppServiceEnvironment(ResourceGroupName, Name, appServiceEnvironment);
                        break;

                    case ASEv3SubnetNameParameterSet:
                    case ASEv3SubnetIdParameterSet:
                        var outboundSubnet = ParameterSetName == ASEv3SubnetNameParameterSet ? SubnetName : SubnetId;
                        var inboundSubnet = ParameterSetName == ASEv3SubnetNameParameterSet ? InboundSubnetName : InboundSubnetId;
                        //Fetch RG of given Subnet
                        var inboundSubnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(inboundSubnet, VirtualNetworkName);
                        var outboundSubnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(outboundSubnet, VirtualNetworkName);
                        //If unble to fetch Subnet rg from above step, use the input RG to get validation error from api call.
                        inboundSubnetResourceGroupName = !String.IsNullOrEmpty(inboundSubnetResourceGroupName) ? inboundSubnetResourceGroupName : ResourceGroupName;
                        var inboundSubnetResourceId = NetworkClient.ValidateSubnet(inboundSubnet, VirtualNetworkName, inboundSubnetResourceGroupName, DefaultContext.Subscription.Id);
                        outboundSubnetResourceGroupName = !String.IsNullOrEmpty(outboundSubnetResourceGroupName) ? outboundSubnetResourceGroupName : ResourceGroupName;
                        var outboundSubnetResourceId = NetworkClient.ValidateSubnet(outboundSubnet, VirtualNetworkName, outboundSubnetResourceGroupName, DefaultContext.Subscription.Id);

                        appServiceEnvironment.VirtualNetwork = new VirtualNetworkProfile(id: outboundSubnetResourceId);
                        NetworkClient.EnsureASEv3SubnetConfig(outboundSubnetResourceId, inboundSubnetResourceId);

                        // Create ASEv3
                        ase = WebsitesClient.CreateAppServiceEnvironment(ResourceGroupName, Name, appServiceEnvironment);

                        // Create private endpoint
                        var aseResourceId = ase.Id;
                        var aseGroupId = "hostingEnvironments";                      
                        NetworkClient.CreatePrivateEndpoint(ResourceGroupName, Name, aseResourceId, aseGroupId, inboundSubnetResourceId, Location);
                        break;
                }

                if (PassThru)
                {
                    // Refresh object to get the final state
                    var ps_ase = new PSAppServiceEnvironment(WebsitesClient.GetAppServiceEnvironment(ResourceGroupName, Name));
                    WriteObject(ps_ase);
                }
            }
        }
    }
}
