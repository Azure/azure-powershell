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
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models;
using Microsoft.Azure.Management.PowerBIDedicated;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Properties;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity
{
    [Cmdlet(VerbsLifecycle.Suspend, "AzureRmPowerBIEmbeddedCapacity",
        SupportsShouldProcess = true),
        OutputType(typeof(AzurePowerBIEmbeddedCapacity))]
    [Alias("Suspend-AzurePBIECapacity")]
    public class SuspendAzurePowerBIEmbeddedCapacity : PowerBIEmbeddedCapacityCmdletBase
    {
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "Name of resource group under which to retrieve the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "Name of a specific capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of capacity not specified"));
            }

            if (ShouldProcess(Name, Resources.SuspendingPowerBIEmbeddedCapacity))
            {
                DedicatedCapacity capacity = null;
                if (!PowerBIEmbeddedCapacityClient.TestCapacity(ResourceGroupName, Name, out capacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, Name));
                }

                PowerBIEmbeddedCapacityClient.SuspendCapacity(ResourceGroupName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(AzurePowerBIEmbeddedCapacity.FromPowerBIEmbeddedCapacity(capacity));
                }
            }
        }
    }
}