// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap", SupportsShouldProcess = true, DefaultParameterSetName = "RemoveByNameParameterSet"), OutputType(typeof(bool))]
    public partial class RemoveAzureRmVirtualNetworkTap : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "RemoveByNameParameterSet",
            HelpMessage = "The resource group name of the virtual network tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "RemoveByNameParameterSet",
            HelpMessage = "The name of the tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkTaps", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "DeleteByResourceIdParameterSet")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DeleteByInputObjectParameterSet")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkTap InputObject
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to delete resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Delete(ResourceGroupName, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
