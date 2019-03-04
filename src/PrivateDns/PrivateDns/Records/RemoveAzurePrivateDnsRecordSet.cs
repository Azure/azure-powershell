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

namespace Microsoft.Azure.Commands.PrivateDns.Records
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Deletes an existing record set.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordSet", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName),OutputType(typeof(bool))]
    public class RemoveAzureDnsRecordSet : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ObjectParameterSetName = "Object";
        private const string MixedParameterSetName = "Mixed";
        private const string ResourceParameterSetName = "ResourceId";

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the zone belongs.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The zone in which the record set exists (without a terminating dot).", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The PrivateDnsZone object representing the zone in which to create the record set.", ParameterSetName = MixedParameterSetName)]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones")]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsZone Zone { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsRecordSet RecordSet { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS RecordSet ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSetName, HelpMessage = "The name of the records in the record set (relative to the name of the zone and without a terminating dot).")]
        [Parameter(Mandatory = true, ParameterSetName = MixedParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of Private DNS records in the record set.", ParameterSetName = FieldsParameterSetName)]
        [Parameter(Mandatory = true, HelpMessage = "The type of Private DNS records in the record set.", ParameterSetName = MixedParameterSetName)]
        [ValidateNotNullOrEmpty]
        public RecordType RecordType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Does not use the ETag field of the RecordSet parameter for optimistic concurrency checks.", ParameterSetName = ObjectParameterSetName)]
        public SwitchParameter Overwrite { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var deleted = false;
            PSPrivateDnsRecordSet recordSetToDelete = null;

            switch (this.ParameterSetName)
            {
                case FieldsParameterSetName:
                case MixedParameterSetName:
                {
                    if (this.Name.EndsWith("."))
                    {
                        this.Name = this.Name.TrimEnd('.');
                        this.WriteWarning(string.Format(ProjectResources.Progress_ModifyingRecordSetNameTrimDot, this.Name));
                    }

                    recordSetToDelete = new PSPrivateDnsRecordSet
                    {
                        Name = this.Name,
                        Etag = null,
                        RecordType = this.RecordType,
                        ResourceGroupName = (this.ParameterSetName == FieldsParameterSetName) ? this.ResourceGroupName : this.Zone.ResourceGroupName,
                        ZoneName = (this.ParameterSetName == FieldsParameterSetName) ? this.ZoneName : this.Zone.Name,
                    };
                    break;
                }

                case ObjectParameterSetName when (string.IsNullOrWhiteSpace(this.RecordSet.Etag) || this.RecordSet.Etag == "*") && !this.Overwrite.IsPresent:
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsRecordSet).Name));

                case ObjectParameterSetName:
                    recordSetToDelete = this.RecordSet;
                    break;

                case ResourceParameterSetName:
                {
                    PrivateDnsUtils.GetResourceGroupNameZoneNameRecordNameAndRecordTypeFromResourceId(ResourceId, out var resourceGroupName, out var zoneName, out var recordName, out var recordType);
                    recordSetToDelete = new PSPrivateDnsRecordSet
                    {
                        Name = recordName,
                        Etag = null,
                        RecordType = (RecordType) Enum.Parse(typeof(RecordType), recordType, true),
                        ResourceGroupName = resourceGroupName,
                        ZoneName = zoneName,
                    };
                    break;
                }
            }

            if (recordSetToDelete?.ZoneName != null)
            {
                recordSetToDelete.ZoneName = TrimTrailingDotInZoneName(recordSetToDelete.ZoneName);
            }

            var overwrite = this.Overwrite.IsPresent || this.ParameterSetName != ObjectParameterSetName;

            ConfirmAction(
                ProjectResources.Progress_RemovingRecordSet,
                this.Name,
                () =>
                {
                    deleted = PrivateDnsClient.DeletePrivateDnsRecordSet(recordSetToDelete, overwrite);
                    if (deleted)
                    {
                        WriteVerbose(ProjectResources.Success);
                        WriteVerbose(ProjectResources.Success_RemoveRecordSet);
                    }

                    if (this.PassThru)
                    {
                        WriteObject(deleted);
                    }
                });
        }
    }
}
