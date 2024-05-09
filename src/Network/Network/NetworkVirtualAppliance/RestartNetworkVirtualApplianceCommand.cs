﻿// ----------------------------------------------------------------------------------
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


using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Post", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualAppliance", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSNetworkVirtualApplianceRestartOperationStatusResponse))]
    public class RestartNetworkVirtualApplianceCommand : NetworkVirtualApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualApplianceName", "NvaName", "NetworkVirtualApplianceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Network Virtual Appliance name.")]
        [ResourceNameCompleter("Microsoft.Network/networkVirtualAppliances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Network Virtual Appliance instance ids to be restarted")]
        public string[] InstanceId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "The resource Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.Name = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances");
            }

            if (!this.IsNetworkVirtualAppliancePresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }

            PSNetworkVirtualApplianceRestartOperationStatusResponse output = new PSNetworkVirtualApplianceRestartOperationStatusResponse()
            {
                Name = this.Name,
                InstancesRestarted = this.InstanceId
            };

            NetworkVirtualApplianceInstanceIds instanceIds = new NetworkVirtualApplianceInstanceIds()
            {
                InstanceIds = this.InstanceId
            };

            var result = this.NetworkVirtualAppliancesClient.RestartWithHttpMessagesAsync(resourceGroupName: this.ResourceGroupName, networkVirtualApplianceName: this.Name, networkVirtualApplianceInstanceIds: instanceIds).GetAwaiter().GetResult();

            if(result != null && result.Request != null && result.Request.RequestUri != null)
            {
                output.OperationId = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
            }

            WriteObject(output);
        }
    }
}
