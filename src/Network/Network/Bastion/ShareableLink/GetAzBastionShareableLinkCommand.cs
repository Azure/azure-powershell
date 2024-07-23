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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName + Constants.ShareableLink,
        DefaultParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
        SupportsShouldProcess = true),
        OutputType(typeof(List<PSBastionShareableLink>))]
    public class GetAzBastionShareableLinkCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The resource group name where Bastion resource exists")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByResourceGroupName + BastionParameterSetNames.ByName,
            HelpMessage = "The Bastion resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Bastion", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = BastionParameterSetNames.ByResourceId,
           HelpMessage = "The Bastion Resource ID")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByBastionObject,
            HelpMessage = "Bastion Object")]
        [ValidateNotNullOrEmpty]
        public PSBastion InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "ID of the VMs to get Bastion shareable links")]
        public List<string> TargetVmId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(BastionParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(BastionParameterSetNames.ByBastionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.Name = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
            }

            if (!this.TryGetBastion(this.ResourceGroupName, this.Name, out PSBastion bastion))
            {
                throw new ItemNotFoundException(string.Format(Properties.Resources.ResourceNotFound, this.Name));
            }

            if (!bastion.EnableShareableLink.Value)
            {
                throw new PropertyNotFoundException(Properties.Resources.BastionShareableLinkNotEnabled);
            }

            var psBslRequest = new PSBastionShareableLinkRequest(this.TargetVmId);
            var getBslResultIter = this.NetworkClient.NetworkManagementClient.GetBastionShareableLink(this.ResourceGroupName, this.Name, psBslRequest.ToSdkObject());

            List<PSBastionShareableLink> psBslResult = new List<PSBastionShareableLink>();
            foreach (var bsl in getBslResultIter)
            {
                psBslResult.Add(new PSBastionShareableLink(bsl));
            }

            WriteVerbose($"Found {psBslResult.Count} Bastion shareable links");
            WriteObject(psBslResult);
        }
    }
}
