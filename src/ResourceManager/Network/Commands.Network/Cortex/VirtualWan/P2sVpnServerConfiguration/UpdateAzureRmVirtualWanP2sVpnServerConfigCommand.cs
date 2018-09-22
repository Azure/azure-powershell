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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnServerConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName + P2SVpnServerConfigurationParameterSets.Default,
        SupportsShouldProcess = true),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class UpdateAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVirtualWanName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration needs to be associated with.")]
        [ValidateNotNullOrEmpty]
        public virtual string ParentResourceName { get; set; }

        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The resource name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Alias("P2SVpnServerConfigurationId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The resource id of the P2SVpnServerConfiguration object to delete.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The resource id of the P2SVpnServerConfiguration object to delete.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("P2SVpnServerConfiguration")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The P2SVpnServerConfiguration object to update.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The P2SVpnServerConfiguration object to update.")]
        public PSP2SVpnServerConfiguration InputObject { get; set; }

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
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public string[] VpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public string[] VpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
             Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        [Parameter(
             Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject + P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!ParameterSetName.Contains(CortexParameterSetNames.ByP2SVpnServerConfigurationName))
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByP2SVpnServerConfigurationObject))
                {
                    this.ResourceId = this.InputObject.Id;
                }

                //// At this point, the resource id should not be null. If it is, customer did not specify a valid resource to modify.
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException(Properties.Resources.P2SVpnServerConfigurationNotSpecified);
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the Parent VirtualWan object - this will throw not found if the object is not found
            PSVirtualWan parentVirtualWan = this.GetVirtualWan(this.ResourceGroupName, this.ParentResourceName);

            if (parentVirtualWan == null ||
                parentVirtualWan.P2SVpnServerConfigurations == null ||
                !parentVirtualWan.P2SVpnServerConfigurations.Any(p2sVpnServerConfiguration => p2sVpnServerConfiguration.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.ParentWanOrP2SVpnServerConfigurationNotFound);
            }

            //// Get existing P2SVpnServerConfiguration to modify
            var p2sVpnServerConfigurationToModify = parentVirtualWan.P2SVpnServerConfigurations.FirstOrDefault(p2sVpnServerConfiguration => p2sVpnServerConfiguration.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));

            //// Set RadiusServerAddress, RadiusServerSecret parameter values if passed else set values from existing P2SVpnServerConfiguration resource.
            this.RadiusServerAddress = (this.RadiusServerAddress != null) ? this.RadiusServerAddress : p2sVpnServerConfigurationToModify.RadiusServerAddress;
            this.RadiusServerSecret = (this.RadiusServerSecret != null) ? this.RadiusServerSecret :
                (p2sVpnServerConfigurationToModify.RadiusServerSecret != null) ? SecureStringExtensions.ConvertToSecureString(p2sVpnServerConfigurationToModify.RadiusServerSecret) : null;

            //// Modify P2SVpnServerConfiguration settings
            p2sVpnServerConfigurationToModify = CreateP2sVpnServerConfigurationObject(
            p2sVpnServerConfigurationToModify,
                this.VpnProtocol,
                this.VpnClientRootCertificateFilesList,
                this.VpnClientRevokedCertificateFilesList,
                this.VpnClientIpsecPolicy,
                this.RadiusServerAddress,
                this.RadiusServerSecret,
                this.RadiusServerRootCertificateFilesList,
                this.RadiusClientRootCertificateFilesList);

            if (ShouldProcess(this.Name, Properties.Resources.SettingResourceMessage))
            {
                WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name + "under parent Virtual Wan:" + parentVirtualWan.Name));
                WriteObject(this.CreateOrUpdateVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, parentVirtualWan.Name, this.Name, p2sVpnServerConfigurationToModify));
            }
        }
    }
}
