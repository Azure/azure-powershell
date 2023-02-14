using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.Cortex;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnGatewayPacketCapture",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnGatewayName, SupportsShouldProcess = true), OutputType(typeof(PSVpnGatewayPacketCaptureResult))]
    public class StopAzVpnGatewayPacketCaptureCommand : VpnGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnGatewayName", "GatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The vpn gateway name where packet capture to be started.")]
        [ResourceNameCompleter("Microsoft.Network/VpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn gateway object where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public PSVpnGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VpnGateway where packet capture to be started.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SAS URL packet capture on vpn gateway.")]
        public string SasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            PSVpnGateway existingVpnGateway = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayObject))
            {
                existingVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnGatewayResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingVpnGateway = this.GetVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnGatewayNotFound);
            }

            VpnGatewayPacketCaptureStopParameters parameters = new VpnGatewayPacketCaptureStopParameters();
            if (this.SasUrl != null)
            {
                parameters.SasUrl = SasUrl;
            }

            base.Execute();
            if (ShouldProcess(this.Name, String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name)))
            {
                WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                PSVpnGatewayPacketCaptureResult output = new PSVpnGatewayPacketCaptureResult()
                {
                    Name = existingVpnGateway.Name,
                    ResourceGroupName = existingVpnGateway.ResourceGroupName,
                    Tag = existingVpnGateway.Tag,
                    ResourceGuid = existingVpnGateway.ResourceGuid,
                    Location = existingVpnGateway.Location,
                };
                output.StartTime = DateTime.UtcNow;
                var result = this.VpnGatewayClient.StopPacketCapture(this.ResourceGroupName, this.Name, parameters);
                output.EndTime = DateTime.UtcNow;
                WriteObject(output);
            }
        }
    }
}
