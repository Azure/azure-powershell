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

using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models;
using Microsoft.Azure.Management.PowerBIDedicated;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity
{
    [Cmdlet(VerbsCommon.Get, "AzureRmPowerBIEmbeddedCapacity"),
     OutputType(typeof(List<AzurePowerBIEmbeddedCapacity>))]
    [Alias("Get-AzurePBIECapacity")]
    public class GetAzurePowerBIEmbeddedCapacity : PowerBIEmbeddedCapacityCmdletBase
    {
        [Parameter(Position = 0,
            ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which the user want to retrieve the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "Name of a specific capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get for single capacity
                var capacity = PowerBIEmbeddedCapacityClient.GetCapacity(ResourceGroupName, Name);
                WriteObject(AzurePowerBIEmbeddedCapacity.FromPowerBIEmbeddedCapacity(capacity));
            }
            else
            {
                // List all capacities in given resource group if avaliable otherwise all capacities in the subscription
                var list = PowerBIEmbeddedCapacityClient.ListCapacities(ResourceGroupName);
                WriteObject(AzurePowerBIEmbeddedCapacity.FromPowerBIEmbeddedCapacityCollection(list), true);
            }
        }
    }
}