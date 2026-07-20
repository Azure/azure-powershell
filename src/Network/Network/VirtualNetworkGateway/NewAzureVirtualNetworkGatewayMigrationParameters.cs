using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayMigrationParameter"), OutputType(typeof(VirtualNetworkGatewayMigrationParameters))]
    public class NewAzureVirtualNetworkGatewayMigrationParameters : NetworkBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The migration type for the virtual network gateway.")]
        [ValidateSet(
        MNM.VirtualNetworkGatewayMigrationType.UpgradeDeploymentToStandardIP,
        IgnoreCase = true)]
        public String MigrationType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Reference to public IP")]
        public String ResourceUrl { get; set; }

        public override void Execute()
        {
            base.Execute();
            var migrationParams = new PSVirtualNetworkGatewayMigrationParameters();
            if (!String.IsNullOrEmpty(this.ResourceUrl))
            {
                migrationParams.ResourceUrl = this.ResourceUrl;
            }
            migrationParams.MigrationType = VirtualNetworkGatewayMigrationParameters.MigrationType;
            WriteObject(migrationParams);
        }
    }
}
