namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnServerConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class NewAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVirtualWanName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        public string ParentResourceName { get; set; }

        [Alias("ParentVirtualWan", "VirtualWan")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        public PSVirtualWan ParentObject { get; set; }

        [Alias("ParentVirtualWanId", "VirtualWanId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The Id of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The Id of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of P2S VPN client tunneling protocols")]
        [ValidateSet(
            MNM.VpnGatewayTunnelingProtocol.IkeV2,
            MNM.VpnGatewayTunnelingProtocol.OpenVPN)]
        [ValidateNotNullOrEmpty]
        public string[] VpnProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public string[] VpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public string[] VpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
             Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        [Parameter(
             Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        [Parameter(
             Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ShouldProcess(this.Name, Properties.Resources.CreatingResourceMessage))
            {
                WriteObject(this.CreateP2SVpnServerConfiguration());
            }
        }

        private PSP2SVpnServerConfiguration CreateP2SVpnServerConfiguration()
        {
            PSP2SVpnServerConfiguration p2SVpnServerConfiguration = new PSP2SVpnServerConfiguration();
            p2SVpnServerConfiguration.Name = this.Name;

            if (this.VpnClientRootCertificateFilesList != null ||
                this.VpnClientRevokedCertificateFilesList != null ||
                this.RadiusServerAddress != null ||
                this.RadiusServerSecret != null ||
                this.RadiusServerRootCertificateFilesList != null ||
                this.RadiusClientRootCertificateFilesList != null ||
                (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0))
            {
                p2SVpnServerConfiguration = this.CreateP2sVpnServerConfigurationObject(
                    p2SVpnServerConfiguration,
                    this.VpnProtocol,
                    this.VpnClientRootCertificateFilesList,
                    this.VpnClientRevokedCertificateFilesList,
                    this.VpnClientIpsecPolicy,
                    this.RadiusServerAddress,
                    this.RadiusServerSecret,
                    this.RadiusServerRootCertificateFilesList,
                    this.RadiusClientRootCertificateFilesList);
            }
            else
            {
                throw new PSArgumentException(Properties.Resources.VpnClientOrRadiusClientSettingsRequiredForP2SVpnServerConfig);
            }

            //// Verify the parent virtual wan exists
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the Parent virtual Wan name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.ParentResourceName))
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualWanRequiredForP2SVpnServerConfig);
            }

            WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));

            var parentVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(this.ResourceGroupName, this.ParentResourceName);

            // Verify if the P2SVpnServerConfiguration already exists in the Parent VirtualWn
            var p2sVpnServerConfig = parentVirtualWan.P2SVpnServerConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (p2sVpnServerConfig != null)
            {
                throw new PSArgumentException(Properties.Resources.P2SVpnServerConfigurationAlreadyExists);
            }

            return this.CreateOrUpdateVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, parentVirtualWan.Name, this.Name, p2SVpnServerConfiguration);
        }
    }
}
