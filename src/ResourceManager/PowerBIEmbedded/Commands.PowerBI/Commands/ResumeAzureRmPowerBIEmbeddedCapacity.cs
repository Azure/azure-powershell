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
using Microsoft.Azure.Commands.PowerBI.Models;
using Microsoft.Azure.Commands.PowerBI.Properties;
using Microsoft.Azure.Commands.PowerBI.Utilities;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBI
{
    [Cmdlet(VerbsLifecycle.Resume, "AzureRmPowerBIEmbeddedCapacity", SupportsShouldProcess = true, DefaultParameterSetName = CmdletParametersSet),
        OutputType(typeof(PSPowerBIEmbeddedCapacity))]
    public class ResumeAzurePowerBIEmbeddedCapacity : PowerBICmdletBase
    {
        protected const string CmdletParametersSet = "ByNameAndResourceGroup";
        protected const string ObjectParameterSet = "ByInputObject";
        protected const string ResourceIdParameterSet = "ByResourceId";

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "Name of a specific capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Mandatory = false,
            HelpMessage = "Name of resource group under which to retrieve the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerBI Embedded Capacity ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "PowerBI Embedded Capacity object.")]
        [ValidateNotNullOrEmpty]
        public PSPowerBIEmbeddedCapacity InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string capacityName = Name;
            string resourceGroupName = ResourceGroupName;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                PowerBIUtils.GetResourceGroupNameAndCapacityName(ResourceId, out resourceGroupName, out capacityName);
            }
            else if (InputObject != null)
            {
                PowerBIUtils.GetResourceGroupNameAndCapacityName(InputObject.Id, out resourceGroupName, out capacityName);
            }

            if (string.IsNullOrEmpty(capacityName))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of capacity not specified"));
            }

            if (ShouldProcess(capacityName, Resources.ResumingPowerBIEmbeddedCapacity))
            {
                PSPowerBIEmbeddedCapacity capacity = null;
                if (!PowerBIClient.TestCapacity(resourceGroupName, capacityName, out capacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, capacityName));
                }

                PowerBIClient.ResumeCapacity(resourceGroupName, capacityName);

                if (PassThru.IsPresent)
                {
                    // Update the capacity current state 
                    if (!PowerBIClient.TestCapacity(resourceGroupName, capacityName, out capacity))
                    {
                        throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, capacityName));
                    }
                    WriteObject(capacity);
                }
            }
        }
    }
}