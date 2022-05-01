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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfigurationPolicyGroup",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnServerConfigurationPolicyGroup))]
    public class NewAzureRmVpnServerConfigurationPolicyGroupCommand : VpnServerConfigurationPolicyGroupBaseCmdlet
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
            Mandatory = true,
            HelpMessage = "The Priority of the policy group.",
            ValueFromPipelineByPropertyName = true)]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to set this as Default Policy Group on this VpnServerConfiguration.")]
        public SwitchParameter DefaultPolicyGroup { get; set; }

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

            WriteObject(this.VpnServerConfigurationPolicy());
        }

        private PSVpnServerConfigurationPolicyGroup VpnServerConfigurationPolicy()
        {
            base.Execute();
            PSVpnServerConfiguration parentVpnServerConfiguration = null;

            //// Resolve the VpnServerConfiguration
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationObject))
            {
                this.ResourceGroupName = this.ServerConfigurationObject.ResourceGroupName;
                this.ServerConfigurationName = this.ServerConfigurationObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ServerConfigurationResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ServerConfigurationName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ServerConfigurationName))
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationRequiredToCreateOrUpdatePolicyGroup);
            }

            //// At this point, we should have the resource name and the resource group for the parent VpnServerConfiguration resolved.
            //// This will throw not found exception if the VpnServerConfiguration does not exist
            parentVpnServerConfiguration = this.GetVpnServerConfiguration(this.ResourceGroupName, this.ServerConfigurationName);
            if (parentVpnServerConfiguration == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVpnServerConfigurationNotFound);
            }


            if (this.IsVpnServerConfigurationPolicyGroupPresent(this.ResourceGroupName, this.ServerConfigurationName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.ServerConfigurationName));
            }

            // Create VpnServerConfigurationPolicyGroup
            PSVpnServerConfigurationPolicyGroup policyGroup = new PSVpnServerConfigurationPolicyGroup
            {
                Name = this.Name,
                Priority = this.Priority,
                PolicyMembers = new List<PSVpnServerConfigurationPolicyGroupMember>()
            };

            if (this.DefaultPolicyGroup.IsPresent)
            {
                policyGroup.IsDefault = true;
            }
            else
            {
                policyGroup.IsDefault = false;
            }

            if (this.PolicyMember != null && this.PolicyMember.Any())
            {
                policyGroup.PolicyMembers.AddRange(this.PolicyMember);
            }


            PSVpnServerConfigurationPolicyGroup policyGroupToReturn = null;
            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingChildResourceLongRunningOperationMessage, this.ResourceGroupName, this.ServerConfigurationName, this.Name));
                    this.CreateOrUpdateVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name, policyGroup);

                    policyGroupToReturn = this.GetVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name);
                });

            return policyGroupToReturn;
        }
    }
}
