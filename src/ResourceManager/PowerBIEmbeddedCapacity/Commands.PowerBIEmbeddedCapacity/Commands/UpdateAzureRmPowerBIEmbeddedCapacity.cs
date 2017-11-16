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
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Models;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Properties;
using Microsoft.Azure.Commands.PowerBIEmbeddedCapacity.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIEmbeddedCapacity
{
    [Cmdlet(VerbsData.Update, "AzureRmPowerBIEmbeddedCapacity", SupportsShouldProcess = true, DefaultParameterSetName = ParamSetDefault), OutputType(typeof(AzurePowerBIEmbeddedCapacity))]
    public class UpdateAzurePowerBIEmbeddedCapacity : PowerBIEmbeddedCapacityCmdletBase
    {
        private const string ParamSetDefault = "Default";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Name of the Sku used to create the capacity")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("A1", "A2", "A3", "A4", "A5", "A6", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this capacity")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A comma separated capacity names to set as administrators on the capacity")]
        [ValidateNotNull]
        public string[] Administrators { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            Position = 1, HelpMessage = "PowerBI Embedded Capacity ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "PowerBI Embedded Capacity object.")]
        [ValidateNotNullOrEmpty]
        public AzurePowerBIEmbeddedCapacity InputObject { get; set; }

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
                PowerBIEmbeddedCapacityUtils.GetResourceGroupNameAndCapacityName(this.ResourceId, out resourceGroupName, out capacityName);
            }
            else if (this.InputObject != null)
            {
                PowerBIEmbeddedCapacityUtils.GetResourceGroupNameAndCapacityName(this.InputObject.Id, out resourceGroupName, out capacityName);
            }

            if (string.IsNullOrEmpty(capacityName))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of capacity not specified"));
            }

            if (ShouldProcess(Name, Resources.UpdatingPowerBIEmbeddedCapacity))
            {
                DedicatedCapacity currentCapacity = null;
                if (!PowerBIEmbeddedCapacityClient.TestCapacity(ResourceGroupName, Name, out currentCapacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, Name));
                }

                var availableSkus = PowerBIEmbeddedCapacityClient.ListSkusForExisting(ResourceGroupName, Name);
                if (Sku != null && !availableSkus.Value.Any(v => v.Sku.Name == Sku))
                {
                    throw new InvalidOperationException(string.Format(Resources.InvalidSku, Sku, String.Join(",", availableSkus.Value.Select(v => v.Sku.Name))));
                }

                var location = currentCapacity.Location;
                if (Tag == null && currentCapacity.Tags != null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentCapacity.Tags);
                }

                DedicatedCapacity updateCapacity = PowerBIEmbeddedCapacityClient.CreateOrUpdateCapacity(ResourceGroupName, Name, location, Sku, Tag, Administrators, currentCapacity);

                if(PassThru.IsPresent)
                {
                    WriteObject(AzurePowerBIEmbeddedCapacity.FromPowerBIEmbeddedCapacity(updateCapacity));
                }
            }
        }
    }
}