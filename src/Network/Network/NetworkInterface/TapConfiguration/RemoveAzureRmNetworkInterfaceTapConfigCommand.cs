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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceTapConfig", SupportsShouldProcess = true, DefaultParameterSetName = "RemoveByNameParameterSet"), OutputType(typeof(PSNetworkInterface))]
    public partial class RemoveAzureRmNetworkInterfaceTapConfigCommand : NetworkInterfaceTapConfigBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "RemoveByNameParameterSet",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "RemoveByNameParameterSet",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "RemoveByNameParameterSet",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network peering name.")]
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
        public PSNetworkInterfaceTapConfiguration InputObject
        {
            get; set;
        }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
                this.NetworkInterfaceName = this.InputObject.NetworkInterfaceName;
            }

            if (ParameterSetName.Equals("DeleteByResourceIdParameterSet", StringComparison.OrdinalIgnoreCase))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.NetworkInterfaceName = resourceIdentifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
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
                    this.NetworkInterfaceTapClient.Delete(this.ResourceGroupName, this.NetworkInterfaceName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
