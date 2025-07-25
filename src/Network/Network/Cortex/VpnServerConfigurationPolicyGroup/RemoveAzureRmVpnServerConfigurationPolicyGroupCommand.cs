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

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfigurationPolicyGroup",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveVpnServerConfigurationPolicyGroupCommand : VpnServerConfigurationPolicyGroupBaseCmdlet
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
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of VpnServerConfiguration object this PolicyGroup is linked to.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        [Alias("ParentVpnServerConfigurationId", "VpnServerConfigurationId")]
        [ValidateNotNullOrEmpty]
        public string ServerConfigurationResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration object this PolicyGroup is linked to.")]
        [Alias("ParentVpnServerConfiguration", "VpnServerConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSVpnServerConfiguration ServerConfigurationObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
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

            // Get the VpnServerConfigurationPolicyGroup object - this will throw not found if the object is not found
            PSVpnServerConfigurationPolicyGroup configurationPolicyGroupToRemove = this.GetVpnServerConfigurationPolicyGroup(this.ResourceGroupName, this.ServerConfigurationName, this.Name);

            if (configurationPolicyGroupToRemove == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationPolicyGroupNotFound);
            }
            else
            {
                base.Execute();

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.RemovingResource, this.Name),
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        this.ConfigurationPolicyGroupClient.Delete(this.ResourceGroupName, this.ServerConfigurationName, this.Name);

                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
        }
    }
}
