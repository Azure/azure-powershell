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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.PowerBI.Models;
using Microsoft.Azure.Commands.PowerBI.Utilities;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBI
{
    [Cmdlet(VerbsCommon.Get, "AzureRmPowerBIEmbeddedCapacity"),
        OutputType(typeof(List<PSDedicatedCapacity>))]
    public class GetAzurePowerBIEmbeddedCapacity : PowerBICmdletBase
    {
        protected const string ResourceGroupParameterSet = "ByResourceGroup";
        protected const string CapacityParameterSet = "ByCapacity";
        protected const string ResourceIdParameterSet = "ByResourceId";

        [Parameter(
            ParameterSetName = ResourceGroupParameterSet,
            Mandatory = false,
            HelpMessage = "Name of resource group under which the user want to retrieve the capacity.")]
        [Parameter(
            ParameterSetName = CapacityParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "Name of resource group under which the user want to retrieve the capacity.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = CapacityParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "Name of a specific capacity.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerBI Embedded Capacity ResourceID.")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string capacityName = string.Empty;

            if (!string.IsNullOrEmpty(Name))
            {
                // Get for single capacity
                var capacity = PowerBIClient.GetCapacity(ResourceGroupName, Name);
                WriteObject(capacity);
            }
            else
            {
                if (!string.IsNullOrEmpty(ResourceId))
                {
                    PowerBIUtils.GetResourceGroupNameAndCapacityName(ResourceId, out resourceGroupName, out capacityName);
                    ResourceGroupName = resourceGroupName;
                    Name = capacityName;
                }
                // List all capacities in given resource group if avaliable otherwise all capacities in the subscription
                var list = PowerBIClient.ListCapacities(ResourceGroupName);
                list.ForEach(capacity => WriteObject(capacity));
            }
        }
    }
}