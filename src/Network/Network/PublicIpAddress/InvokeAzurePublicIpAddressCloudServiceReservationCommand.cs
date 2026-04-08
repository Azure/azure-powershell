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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpAddressCloudServiceReservation",
        DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(PSPublicIpAddress))]
    public class InvokeAzurePublicIpAddressCloudServiceReservationCommand : PublicIpAddressBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ByName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address name.")]
        [ResourceNameCompleter("Microsoft.Network/publicIPAddresses", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSetNames.ByName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The public IP address object.")]
        [ValidateNotNullOrEmpty]
        public PSPublicIpAddress InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address resource ID.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/publicIPAddresses")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When true, reverts from static to dynamic allocation (undo reservation).")]
        public SwitchParameter IsRollback { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByInputObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            if (!this.IsPublicIpAddressPresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            string target = string.Format("{0}/{1}", this.ResourceGroupName, this.Name);
            if (!ShouldProcess(target, "Reserve or roll back cloud service public IP address allocation"))
            {
                return;
            }

            var request = new MNM.ReserveCloudServicePublicIpAddressRequest(this.IsRollback.IsPresent ? "true" : "false");
            request.Validate();

            var result = this.PublicIpAddressClient.ReserveCloudServicePublicIpAddress(
                this.ResourceGroupName,
                this.Name,
                request);

            var psPublicIp = this.ToPsPublicIpAddress(result);
            psPublicIp.ResourceGroupName = this.ResourceGroupName;
            WriteObject(psPublicIp);
        }
    }
}
