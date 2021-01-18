using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServiceEnvironment
{
    /// <summary>
    /// this commandlet will let you create inbound services for a new Azure App Service Environment
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServiceEnvironmentInboundServices", SupportsShouldProcess = true)]
    public class NewAzureAppServiceEnvironmentInboundServicesCmdlet : WebAppBaseClientCmdLet
    {
        private const string SubnetIdParameterSet = "SubnetIdParameterSet";
        private const string SubnetNameParameterSet = "SubnetNameParameterSet";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the app service environment.")]
        [ResourceNameCompleter("Microsoft.Web/hostingEnvironments", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "The vNet name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SubnetIdParameterSet, Mandatory = true, HelpMessage = "The subnet id.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(ParameterSetName = SubnetNameParameterSet, Mandatory = true, HelpMessage = "The subnet name.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not create Azure Private DNS Zone and records.")]
        public SwitchParameter SkipDns { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, $"Creating App Service Environment '{Name}'"))
            {
                AppServiceEnvironmentResource ase = null;
                switch (ParameterSetName)
                {
                    case SubnetNameParameterSet:
                    case SubnetIdParameterSet:
                        var subnet = ParameterSetName == SubnetNameParameterSet ? SubnetName : SubnetId;
                        //Fetch RG of given Subnet
                        var subnetResourceGroupName = NetworkClient.GetSubnetResourceGroupName(subnet, VirtualNetworkName);
                        //If unable to fetch Subnet rg from above step, use the input RG to get validation error from api call.
                        subnetResourceGroupName = !String.IsNullOrEmpty(subnetResourceGroupName) ? subnetResourceGroupName : ResourceGroupName;
                        var subnetResourceId = NetworkClient.ValidateSubnet(subnet, VirtualNetworkName, subnetResourceGroupName, DefaultContext.Subscription.Id);                        
                        ase = WebsitesClient.GetAppServiceEnvironment(ResourceGroupName, Name);
                        if (ase != null)
                        {
                            string inboundIPAddress = "";
                            if (ase.Kind.ToLower() == "asev2")
                            {
                                // Internal ASEv2
                                if (ase.InternalLoadBalancingMode != "None")
                                {
                                    var vipInfo = WebsitesClient.GetAppServiceEnvironmentAddresses(ResourceGroupName, Name);
                                    inboundIPAddress = vipInfo.InternalIpAddress;
                                }
                                else
                                {
                                    throw new Exception("Private DNS Zone is not compatible with External App Service Environment");
                                }
                            }
                            else if (ase.Kind.ToLower() == "asev3")
                            {
                                // Create private endpoint
                                var aseResourceId = ase.Id;
                                var aseGroupId = "hostingEnvironments";
                                NetworkClient.EnsureSubnetPrivateEndpointPolicy(subnetResourceId, false);
                                var pe = NetworkClient.CreatePrivateEndpoint(ResourceGroupName, Name, aseResourceId, aseGroupId, subnetResourceId, ase.Location);
                                var nicId = pe.NetworkInterfaces[0].Id;                                
                                inboundIPAddress = NetworkClient.GetNetworkInterfacePrivateIPAddress(nicId);
                            }

                            if (!SkipDns)
                            {
                                // Create Private DNS Zone and records
                                var virtualNetworkResourceId = NetworkClient.GetVirtualNetworkResourceId(subnetResourceId);
                                PrivateDnsClient.CreateAppServiceEnvironmentPrivateDnsZone(ResourceGroupName, Name, virtualNetworkResourceId, inboundIPAddress);
                            }
                        }
                        break;
                }
            }
        }
    }
}
