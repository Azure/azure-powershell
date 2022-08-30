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

namespace Microsoft.Azure.Commands.Network.Cortex.VpnServerConfiguration
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

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfigurationPolicyGroup",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName),
        OutputType(typeof(PSVpnServerConfigurationPolicyGroup))]
    public class GetAzureRmVpnServerConfigurationPolicyGroupCommand : VpnServerConfigurationPolicyGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ParentVpnServerConfigurationName", "VpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnServerConfigurations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerConfigurationName { get; set; }

        [Alias("ResourceName", "VpnServerConfigurationPolicyGroupName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnServerConfigurations/vpnServerConfigurationPolicyGroups", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("ParentVpnServerConfiguration", "VpnServerConfiguration")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The parent VpnServerConfiguration for this VpnServerConfigurationPolicyGroup.")]
        [ValidateNotNullOrEmpty]
        public PSVpnServerConfiguration ServerConfigurationObject { get; set; }

        [Alias("ParentVpnServerConfigurationId", "VpnServerConfigurationId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The resource id of the parent VpnServerConfiguration for this VpnServerConfigurationPolicyGroup.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        public string ServerConfigurationResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

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

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                WriteObject(this.GetVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name));
            }
            else
            {
                WriteObject(SubResourceWildcardFilter(Name, this.ListVpnServerConfigurationPolicyGroups(this.ResourceGroupName, this.ServerConfigurationName)), true);
            }
        }
    }
}
