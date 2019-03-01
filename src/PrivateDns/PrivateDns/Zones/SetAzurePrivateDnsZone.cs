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

namespace Microsoft.Azure.Commands.PrivateDns.Zones
{
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Updates an existing zone.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZone", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName), OutputType(typeof(PSPrivateDnsZone))]
    public class SetAzurePrivateDnsZone : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ObjectParameterSetName = "Object";
        private const string ResourceParameterSetName = "ResourceId";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which the zone exists.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the zone (without a terminating dot).", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The zone object to set.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsZone PrivateZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the RecordSet parameter for optimistic concurrency checks.", ParameterSetName = ObjectParameterSetName)]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            PSPrivateDnsZone result = null;
            PSPrivateDnsZone zoneToUpdate = null;

            if (this.ParameterSetName == FieldsParameterSetName || this.ParameterSetName == ResourceParameterSetName)
            {
                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    PrivateDnsUtils.GetResourceGroupNameAndZoneNameFromResourceId(this.ResourceId, out var resourceGroupName, out var zoneName);
                    this.ResourceGroupName = resourceGroupName;
                    this.Name = zoneName;
                }

                if (this.Name.EndsWith("."))
                {
                    this.Name = this.Name.TrimEnd('.');
                    this.WriteWarning($"Modifying Private DNS zone name to remove terminating '.'.  Zone name used is \"{this.Name}\".");
                }

                zoneToUpdate = this.PrivateDnsClient.GetPrivateDnsZone(this.Name, this.ResourceGroupName);
                zoneToUpdate.Etag = "*";
            }
            else if (this.ParameterSetName == ObjectParameterSetName)
            {
                if ((string.IsNullOrWhiteSpace(this.PrivateZone.Etag) || this.PrivateZone.Etag == "*") && !this.Overwrite.IsPresent)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsZone).Name));
                }

                zoneToUpdate = this.PrivateZone;
            }

            if (zoneToUpdate == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_ZoneNotFound), this.Name);
            }

            zoneToUpdate.Tags = this.Tag;

            if (zoneToUpdate.Name != null && zoneToUpdate.Name.EndsWith("."))
            {
                zoneToUpdate.Name = zoneToUpdate.Name.TrimEnd('.');
                this.WriteWarning($"Modifying Private DNS zone name to remove terminating '.'.  Zone name used is \"{zoneToUpdate.Name}\".");
            }
            ConfirmAction(
                ProjectResources.Progress_Modifying,
                zoneToUpdate?.Name,
                () =>
                {
                    bool overwrite = this.Overwrite.IsPresent || this.ParameterSetName != ObjectParameterSetName;
                    result = this.PrivateDnsClient.UpdatePrivateDnsZone(zoneToUpdate, overwrite);

                    WriteVerbose(ProjectResources.Success);
                    WriteObject(result);
                });
        }
    }
}
