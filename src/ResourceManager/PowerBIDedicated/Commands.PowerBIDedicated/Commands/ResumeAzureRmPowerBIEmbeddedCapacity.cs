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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.PowerBIDedicated.Models;
using Microsoft.Azure.Commands.PowerBIDedicated.Properties;
using Microsoft.Azure.Commands.PowerBIDedicated.Utilities;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIDedicated
{
    [Cmdlet(VerbsLifecycle.Resume, "AzureRmPowerBIEmbeddedCapacity", 
        SupportsShouldProcess = true),
        OutputType(typeof(AzurePowerBIDedicated))]
    public class ResumeAzurePowerBIEmbeddedCapacity : PowerBIDedicatedCmdletBase
    {
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true,
            Mandatory = false, HelpMessage = "Name of resource group under which to retrieve the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true,
            Mandatory = true, HelpMessage = "Name of a specific capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            Position = 1, HelpMessage = "PowerBI Embedded Capacity ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "PowerBI Embedded Capacity object.")]
        [ValidateNotNullOrEmpty]
        public AzurePowerBIDedicated InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string capacityName = string.Empty;

            if (!string.IsNullOrEmpty(Name))
            {
                capacityName = Name;
            }
            else if (!string.IsNullOrEmpty(this.ResourceId))
            {
                PowerBIDedicatedUtils.GetResourceGroupNameAndCapacityName(this.ResourceId, out resourceGroupName, out capacityName);
            }
            else if (this.InputObject != null)
            {
                PowerBIDedicatedUtils.GetResourceGroupNameAndCapacityName(this.InputObject.Id, out resourceGroupName, out capacityName);
            }

            if (string.IsNullOrEmpty(capacityName))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of capacity not specified"));
            }

            if (ShouldProcess(Name, Resources.ResumingPowerBIEmbeddedCapacity))
            {
                DedicatedCapacity capacity = null;
                if (!PowerBIDedicatedClient.TestCapacity(ResourceGroupName, Name, out capacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, Name));
                }

                PowerBIDedicatedClient.ResumeCapacity(ResourceGroupName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(AzurePowerBIDedicated.FromPowerBIDedicated(capacity));
                }
            }
        }
    }
}