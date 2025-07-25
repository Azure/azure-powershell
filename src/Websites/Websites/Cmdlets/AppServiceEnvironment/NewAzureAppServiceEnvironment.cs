using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create a new Azure App Service Environment
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironment", SupportsShouldProcess = true, DefaultParameterSetName = ASEv2SubnetNameParameterSet), OutputType(typeof(PSAppServiceEnvironment))]
    public class NewAzureAppServiceEnvironmentCmdlet : WebAppBaseClientCmdLet
    {
        private const string ASEv2SubnetIdParameterSet = "ASEv2SubnetIdParameterSet";
        private const string ASEv2SubnetNameParameterSet = "ASEv2SubnetNameParameterSet";
        private const string ASEv3SubnetIdParameterSet = "ASEv3SubnetIdParameterSet";
        private const string ASEv3SubnetNameParameterSet = "ASEv3SubnetNameParameterSet";

        private const string SkipNetworkSecurityGroupHelpMessage = "Do not create the recommended network security group as part of the app service environment.";
        private const string SkipRouteTableHelpMessage = "Do not create the recommended route table as part of the app service environment.";
        private const string LoadBalancerModeHelpMessage = "Load balancer mode of the app service environment.";
        private const string SubnetNameHelpMessage = "The subnet name. Used in combination with -VirtualNetworkName and must be in same resource group as ASE. If not, use -SubnetId";
        private const string VirtualNetworkNameHelpMessage = "The vNet name. Used in combination with -SubnetName and must be in same resource group as ASE. If not, use -SubnetId";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The Location of the app service environment eg: West Europe.")]
        [LocationCompleter("Microsoft.Web/sites", "Microsoft.Web/serverFarms", "Microsoft.Web/hostingEnvironments")]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The version of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("ASEv2", "ASEv3")]
        public string Kind { get; set; } = "ASEv2";

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = VirtualNetworkNameHelpMessage)]
        [Parameter(ParameterSetName = ASEv3SubnetNameParameterSet, Mandatory = true, HelpMessage = VirtualNetworkNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = true, HelpMessage = "The subnet id.")]
        [Parameter(ParameterSetName = ASEv3SubnetIdParameterSet, Mandatory = true, HelpMessage = "The subnet id.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = SubnetNameHelpMessage)]
        [Parameter(ParameterSetName = ASEv3SubnetNameParameterSet, Mandatory = true, HelpMessage = SubnetNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = true, HelpMessage = LoadBalancerModeHelpMessage)]
        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = true, HelpMessage = LoadBalancerModeHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Internal", "External")]
        public string LoadBalancerMode { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = false, HelpMessage = SkipRouteTableHelpMessage)]
        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = false, HelpMessage = SkipRouteTableHelpMessage)]
        public SwitchParameter SkipRouteTable { get; set; }

        [Parameter(ParameterSetName = ASEv2SubnetNameParameterSet, Mandatory = false, HelpMessage = SkipNetworkSecurityGroupHelpMessage)]
        [Parameter(ParameterSetName = ASEv2SubnetIdParameterSet, Mandatory = false, HelpMessage = SkipNetworkSecurityGroupHelpMessage)]
        public SwitchParameter SkipNetworkSecurityGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the app service environment object.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, $"Creating App Service Environment '{Name}'"))
            {
                AppServiceEnvironmentResource appServiceEnvironment = new AppServiceEnvironmentResource();
                appServiceEnvironment.Location = Location;
                appServiceEnvironment.Kind = Kind;

                AppServiceEnvironmentResource ase = null;
                switch (ParameterSetName)
                {
                    case ASEv2SubnetNameParameterSet:
                    case ASEv2SubnetIdParameterSet:
                        var subnet = ParameterSetName == ASEv2SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given Subnet
                        var subnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(subnet, VirtualNetworkName);
                        //If unable to fetch Subnet rg from above step, use the input RG to get validation error from api call.
                        subnetResourceGroupName = !String.IsNullOrEmpty(subnetResourceGroupName) ? subnetResourceGroupName : ResourceGroupName;
                        var subnetResourceId = NetworkClient.ValidateSubnet(subnet, VirtualNetworkName, subnetResourceGroupName, DefaultContext.Subscription.Id);

                        if (!SkipRouteTable)
                            NetworkClient.EnsureASEv2RouteTable(ResourceGroupName, Name, Location, subnetResourceId);

                        if (!SkipNetworkSecurityGroup)
                            NetworkClient.EnsureASEv2NetworkSecurityGroup(ResourceGroupName, Name, Location, subnetResourceId);

                        appServiceEnvironment.VirtualNetwork = new VirtualNetworkProfile(id: subnetResourceId);
                        appServiceEnvironment.InternalLoadBalancingMode = LoadBalancerMode == "External" ? "None" : "Web,Publishing";
                        
                        // Create ASEv2
                        ase = WebsitesClient.CreateAppServiceEnvironment(ResourceGroupName, Name, appServiceEnvironment);
                        break;

                    case ASEv3SubnetNameParameterSet:
                    case ASEv3SubnetIdParameterSet:
                        var outboundSubnet = ParameterSetName == ASEv3SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given Subnet
                        var outboundSubnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(outboundSubnet, VirtualNetworkName);
                        //If unable to fetch Subnet rg from above step, use the input RG to get validation error from api call.
                        outboundSubnetResourceGroupName = !String.IsNullOrEmpty(outboundSubnetResourceGroupName) ? outboundSubnetResourceGroupName : ResourceGroupName;
                        var outboundSubnetResourceId = NetworkClient.ValidateSubnet(outboundSubnet, VirtualNetworkName, outboundSubnetResourceGroupName, DefaultContext.Subscription.Id);

                        appServiceEnvironment.VirtualNetwork = new VirtualNetworkProfile(id: outboundSubnetResourceId);

                        // Create ASEv3
                        NetworkClient.VerifyEmptySubnet(outboundSubnetResourceId);
                        NetworkClient.EnsureSubnetDelegation(outboundSubnetResourceId, "Microsoft.Web/hostingEnvironments");
                        ase = WebsitesClient.CreateAppServiceEnvironment(ResourceGroupName, Name, appServiceEnvironment);
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
