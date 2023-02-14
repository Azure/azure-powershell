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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.PowerBI.Models;
using Microsoft.Azure.Commands.PowerBI.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.PowerBI
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PowerBIEmbeddedCapacity", SupportsShouldProcess = true), OutputType(typeof(PSPowerBIEmbeddedCapacity))]
    public class NewPowerBIEmbeddedCapacity : PowerBICmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Position = 0, 
            Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Position = 1, 
            Mandatory = true,
            HelpMessage = "Name of the capacity to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Position = 2, 
            Mandatory = true,
            HelpMessage = "Azure region where the capacity should be created.")]
        [LocationCompleter("Microsoft.PowerBIDedicated/capacities")]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Position = 3, 
            Mandatory = true,
            HelpMessage = "Name of the Sku used to create the capacity")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
             Position = 4,
            Mandatory = true,
            HelpMessage = "A comma separated capacity names to set as administrators on the capacity")]
        [ValidateNotNull]
        public string[] Administrator { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true, 
            Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this capacity")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateNewPowerBIEmbeddedCapacity))
            {
                try
                {
                    if (PowerBIClient.GetCapacity(ResourceGroupName, Name) != null)
                    {
                        throw new CloudException(string.Format(Resources.PowerBIEmbeddedCapacityExists, Name));
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                        ex.Message.Contains("ResourceNotFound"))
                    {
                        // capacity does not exists so go ahead and create one
                    }
                    else if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) &&
                             ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                    {
                        // resource group not found, let create throw error don't throw from here
                    }
                    else
                    {
                        // all other exceptions should be thrown
                        throw;
                    }
                }

                var createdCapacity = PowerBIClient.CreateOrUpdateCapacity(ResourceGroupName, Name, Location, Sku, Tag, Administrator, null);
                WriteObject(createdCapacity);
            }
        }
    }
}