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
using System.Management.Automation;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmPowerBIEmbeddedCapacity"), OutputType(typeof(bool))]
    [Alias("Test-AzurePBIECapacity")]
    public class TestAzurePowerBIEmbeddedCapacity : PowerBIEmbeddedCapacityCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of a specific capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which want to test the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            DedicatedCapacity capacity = null;
            WriteObject(PowerBIEmbeddedCapacityClient.TestCapacity(ResourceGroupName, Name, out capacity));
        }
    }
}