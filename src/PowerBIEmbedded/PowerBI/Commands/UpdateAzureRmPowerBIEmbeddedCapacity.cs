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
using Microsoft.Azure.Commands.PowerBI.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBI
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PowerBIEmbeddedCapacity", SupportsShouldProcess = true, DefaultParameterSetName = CmdletParametersSet), OutputType(typeof(PSPowerBIEmbeddedCapacity))]
    public class UpdateAzurePowerBIEmbeddedCapacity : PowerBICmdletBase
    {
        protected const string CmdletParametersSet = "ByNameAndResourceGroup";
        protected const string ObjectParameterSet = "ByInputObject";
        protected const string ResourceIdParameterSet = "ByResourceId";

        private const string ParamSetDefault = "Default";

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Position = 0, 
            Mandatory = true,
            HelpMessage = "Name of the capacity.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the capacity.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the Sku used to create the capacity")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this capacity")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A comma separated capacity names to set as administrators on the capacity")]
        [ValidateNotNull]
        public string[] Administrator { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            Position = 0,
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

            if (!string.IsNullOrEmpty(ResourceId))
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

            if (ShouldProcess(capacityName, Resources.UpdatingPowerBIEmbeddedCapacity))
            {
                PSPowerBIEmbeddedCapacity currentCapacity = null;
                if (!PowerBIClient.TestCapacity(resourceGroupName, capacityName, out currentCapacity))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.CapacityDoesNotExist, capacityName));
                }

                var availableSkus = PowerBIClient.ListSkusForExisting(resourceGroupName, capacityName);
                if (Sku != null && !availableSkus.Value.Any(v => v.Sku.Name == Sku))
                {
                    throw new InvalidOperationException(string.Format(Resources.InvalidSku, Sku, String.Join(",", availableSkus.Value.Select(v => v.Sku.Name))));
                }

                var location = currentCapacity.Location;
                if (Tag == null && currentCapacity.Tag != null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentCapacity.Tag);
                }

                PSPowerBIEmbeddedCapacity updateCapacity = PowerBIClient.CreateOrUpdateCapacity(resourceGroupName, capacityName, location, Sku, Tag, Administrator, currentCapacity);

                if(PassThru.IsPresent)
                {
                    WriteObject(updateCapacity);
                }
            }
        }
    }
}
