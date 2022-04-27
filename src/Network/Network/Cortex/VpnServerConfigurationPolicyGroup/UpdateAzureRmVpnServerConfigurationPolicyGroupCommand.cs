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

namespace Microsoft.Azure.Commands.Network.Cortex.VpnGateway
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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfigurationPolicyGroup",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnServerConfigurationPolicyGroup))]
    public class UpdateAzureRmVpnServerConfigurationPolicyGroupCommand : VpnServerConfigurationPolicyGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "The VpnServerConfiguration name this PolicyGroup is linked to.")]
        [Alias("ParentVpnServerConfigurationName", "VpnServerConfigurationName")]
        [ResourceNameCompleter("Microsoft.Network/vpnServerConfigurations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerConfigurationName { get; set; }

        [Alias("ResourceName", "VpnServerConfigurationPolicyGroupName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration object this PolicyGroup is linked to.")]
        [Alias("ParentVpnServerConfiguration", "VpnServerConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSVpnServerConfiguration ServerConfigurationObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of VpnServerConfiguration object this PolicyGroup is linked to.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        [Alias("ParentVpnServerConfigurationId", "VpnServerConfigurationId")]
        [ValidateNotNullOrEmpty]
        public string ServerConfigurationResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Priority of the policy group.",
            ValueFromPipelineByPropertyName = true)]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set this as Default Policy Group on this VpnServerConfiguration.")]
        public bool? DefaultPolicyGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Policy members.")]
        public PSVpnServerConfigurationPolicyGroupMember[] PolicyMember { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingChildResourceLongRunningOperationMessage, this.ResourceGroupName, this.ServerConfigurationName, this.Name));
                    WriteObject(this.UpdatePolicyGroup());
                });
        }

        private PSVpnServerConfigurationPolicyGroup UpdatePolicyGroup()
        {
            PSVpnServerConfiguration parentVpnServerConfiguration = null;
            PSVpnServerConfigurationPolicyGroup policyGroupToUpdate = null;

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnServerConfigurationObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ServerConfigurationObject.ResourceGroupName;
                this.ServerConfigurationName = this.ServerConfigurationObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVpnServerConfigurationResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServerConfigurationResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ServerConfigurationName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ServerConfigurationName))
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationRequiredToCreateOrUpdatePolicyGroup);
            }

            parentVpnServerConfiguration = GetVpnServerConfiguration(this.ResourceGroupName, this.ServerConfigurationName);

            if (parentVpnServerConfiguration == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationRequiredToCreateOrUpdatePolicyGroup);
            }

            policyGroupToUpdate = GetVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name);

            if (policyGroupToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationPolicyGroupNotFound);
            }

            if (this.Priority > 0)
            {
                policyGroupToUpdate.Priority = this.Priority;
            }
            
            if (this.DefaultPolicyGroup.HasValue)
            {
                policyGroupToUpdate.IsDefault = this.DefaultPolicyGroup.Value;
            }

            if (this.PolicyMember != null)
            {
                policyGroupToUpdate.PolicyMembers = new List<PSVpnServerConfigurationPolicyGroupMember>();
                policyGroupToUpdate.PolicyMembers.AddRange(this.PolicyMember);
            }

            this.CreateOrUpdateVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name, policyGroupToUpdate);

            return this.GetVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name);
        }
    }
}
