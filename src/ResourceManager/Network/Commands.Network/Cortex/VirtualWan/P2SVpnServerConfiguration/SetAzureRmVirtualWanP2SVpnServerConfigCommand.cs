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
    [Cmdlet(VerbsCommon.Set,
    "AzureRmVirtualWanP2SVpnServerConfiguration",
    SupportsShouldProcess = true),
    OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class SetAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVirtualWanName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The parent resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ParentResourceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId,
            HelpMessage = "The resource id of the P2SVpnServerConfiguration object to delete.")]
        [ValidateNotNullOrEmpty]
        public string P2SVpnServerConfigurationId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject,
            HelpMessage = "The P2SVpnServerConfiguration object to update.")]
        public PSP2SVpnServerConfiguration P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The PSP2SVpnServerConfiguration in-memory object.")]
        public PSP2SVpnServerConfiguration P2SVpnServerConfigurationToSet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (P2SVpnServerConfigurationToSet == null)
            {
                throw new PSArgumentException("Specified P2SVpnServerConfiguration to set is null.");
            }

            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnServerConfigurationName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnServerConfigurationObject, StringComparison.OrdinalIgnoreCase))
                {
                    this.P2SVpnServerConfigurationId = this.P2SVpnServerConfiguration.Id;
                }

                //// At this point, the resource id should not be null. If it is, customer did not specify a valid resource to modify.
                if (string.IsNullOrWhiteSpace(this.P2SVpnServerConfigurationId))
                {
                    throw new PSArgumentException("No P2SVpnServerConfiguration specified. Nothing will be modified.");
                }

                var parsedResourceId = new ResourceIdentifier(this.P2SVpnServerConfigurationId);
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
                throw new PSArgumentException("The P2SVpnServerConfiguration and/or Parent VirtualWan to modify could not be found.");
            }

            var p2sVpnServerConfigurationToModify = parentVirtualWan.P2SVpnServerConfigurations.FirstOrDefault(p2sVpnServerConfiguration => p2sVpnServerConfiguration.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));

            // Modify P2SVpnServerConfiguration settings
            p2sVpnServerConfigurationToModify.Name = this.Name;
            p2sVpnServerConfigurationToModify.VpnProtocols = P2SVpnServerConfigurationToSet.VpnProtocols;

            // Set VpnClient settings
            p2sVpnServerConfigurationToModify.P2SVpnServerConfigVpnClientRootCertificates = P2SVpnServerConfigurationToSet.P2SVpnServerConfigVpnClientRootCertificates;
            p2sVpnServerConfigurationToModify.P2SVpnServerConfigVpnClientRevokedCertificates = P2SVpnServerConfigurationToSet.P2SVpnServerConfigVpnClientRevokedCertificates;
            p2sVpnServerConfigurationToModify.VpnClientIpsecPolicies = P2SVpnServerConfigurationToSet.VpnClientIpsecPolicies;

            // Set RadiusClient settings
            p2sVpnServerConfigurationToModify.RadiusServerAddress = P2SVpnServerConfigurationToSet.RadiusServerAddress;
            p2sVpnServerConfigurationToModify.RadiusServerSecret = P2SVpnServerConfigurationToSet.RadiusServerSecret;
            p2sVpnServerConfigurationToModify.P2SVpnServerConfigRadiusServerRootCertificates = P2SVpnServerConfigurationToSet.P2SVpnServerConfigRadiusServerRootCertificates;
            p2sVpnServerConfigurationToModify.P2SVpnServerConfigRadiusClientRootCertificates = P2SVpnServerConfigurationToSet.P2SVpnServerConfigRadiusClientRootCertificates;

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.SettingResourceMessage, this.Name),
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        var createdOrUpdatedP2SVpnServerConfiguration = this.CreateOrUpdateVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, parentVirtualWan.Name, this.Name, p2sVpnServerConfigurationToModify);

                        WriteObject(createdOrUpdatedP2SVpnServerConfiguration);
                    });
        }
    }
}
