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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using System.Net;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpAllocation"), OutputType(typeof(PSIpAllocation))]
    public class SetAzureIpAllocationCommand : IpAllocationBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IpAllocation Id",
            ParameterSetName = SetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IpAllocationId")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = "The IpAllocation")]
        [Alias("IpAllocation")]
        public PSIpAllocation InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The allocation tags of the IP allocation")]
        public Hashtable IpAllocationTag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

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

            if (!this.IsIpAllocationPresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }
            try
            {
                if (this.InputObject == null)
                {
                    var ipAllocation = GetIpAllocation(this.ResourceGroupName, this.Name);
                    this.InputObject = NetworkResourceManagerProfile.Mapper.Map<PSIpAllocation>(ipAllocation);
                    this.InputObject.ResourceGroupName = this.ResourceGroupName;
                    this.InputObject.Name = this.Name;
                }
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                }

                throw;
            }

            // Map to the sdk object
            var allocationModel = NetworkResourceManagerProfile.Mapper.Map<MNM.IpAllocation>(this.InputObject);
            allocationModel.AllocationTags = TagsConversionHelper.CreateTagDictionary(IpAllocationTag, validate: true);
            allocationModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            // Execute the Update VirtualNetwork call
            this.IpAllocationClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.Name, allocationModel);

            var getVirtualNetwork = this.GetIpAllocation(this.InputObject.ResourceGroupName, this.InputObject.Name);
            WriteObject(getVirtualNetwork);
        }
    }
}
