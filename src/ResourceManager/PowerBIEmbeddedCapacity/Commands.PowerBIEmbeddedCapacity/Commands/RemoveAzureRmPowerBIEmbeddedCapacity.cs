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
using System.Security.Permissions;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Properties;
using Microsoft.Azure.Management.PowerBIDedicated.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmPowerBIEmbeddedCapacity", SupportsShouldProcess = true), 
        OutputType(typeof(AzurePowerBIEmbeddedCapacity))]
    [Alias("Remove-AzurePBIECapacity")]
    public class RemovePowerBIEmbeddedCapacity : PowerBIEmbeddedCapacityCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of capacity to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which the capacity exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of capacity not specified"));
            }

            if (ShouldProcess(Name, Resources.RemovingPowerBIEmbeddedCapacity))
            {
                DedicatedCapacity capacity = null;
                if (!PowerBIEmbeddedCapacityClient.TestCapacity(ResourceGroupName, Name, out capacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, Name));
                }

                PowerBIEmbeddedCapacityClient.DeleteCapacity(ResourceGroupName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(AzurePowerBIEmbeddedCapacity.FromPowerBIEmbeddedCapacity(capacity));
                }
            }
        }
    }
}