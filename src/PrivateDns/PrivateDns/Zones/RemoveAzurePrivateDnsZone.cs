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
    using System.Management.Automation;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Deletes an existing zone.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZone", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName),OutputType(typeof(bool))]
    public class RemoveAzurePrivateDnsZone : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ResourceParameterSetName = "ResourceId";
        private const string ObjectParameterSetName = "Object";

        [Parameter(Mandatory = true, HelpMessage = "The resource group in which the zone exists.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The full name of the zone (without a terminating dot).", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The private zone object to delete.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsZone PrivateZone { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the Zone parameter for optimistic concurrency checks.", ParameterSetName = ObjectParameterSetName)]
        public SwitchParameter Overwrite { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Used for passing the deleted private zone further down the pipeline.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            const bool deleted = true;
            var overwrite = this.Overwrite.IsPresent || this.ParameterSetName != ObjectParameterSetName;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                PrivateDnsUtils.GetResourceGroupNameAndZoneNameFromResourceId(this.ResourceId, out var resourceGroupName, out var zoneName);
                this.ResourceGroupName = resourceGroupName;
                this.Name = zoneName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                this.Name = TrimTrailingDotInZoneName(this.Name);
            }

            var zoneToDelete = (this.ParameterSetName != ObjectParameterSetName)
                ? this.PrivateDnsClient.GetDnsZoneHandleNonExistentZone(this.Name, this.ResourceGroupName)
                : this.PrivateZone;

            if (zoneToDelete == null)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_ZoneNotFound, this.Name));
            }

            if ((string.IsNullOrWhiteSpace(zoneToDelete.Etag) || zoneToDelete.Etag == "*") && !overwrite)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsZone).Name));
            }

            if (zoneToDelete.Name != null)
            {
                zoneToDelete.Name = TrimTrailingDotInZoneName(zoneToDelete.Name);
            }

            ConfirmAction(
                ProjectResources.Progress_RemovingZone,
                zoneToDelete.Name,
                () =>
                {
                    PrivateDnsClient.DeletePrivateDnsZone(zoneToDelete, overwrite);

                    WriteVerbose(ProjectResources.Success);
                    WriteVerbose(string.Format(ProjectResources.Success_RemoveZone, zoneToDelete.Name, zoneToDelete.ResourceGroupName));

                    if (this.PassThru)
                    {
                        WriteObject(deleted);
                    }
                });
        }
    }
}
