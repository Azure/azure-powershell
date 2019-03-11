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
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Creates a new record set.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordSet", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSetName),OutputType(typeof(PSPrivateDnsRecordSet))]
    public class NewAzurePrivateDnsRecordSet : PrivateDnsBaseCmdlet
    {
        private const string FieldsParameterSetName = "Fields";
        private const string ObjectParameterSetName = "Object";
        private const string ResourceParameterSetName = "ResourceId";

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the zone belongs.", ParameterSetName = FieldsParameterSetName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The zone in which to create the record set (without a terminating dot).", ParameterSetName = FieldsParameterSetName)]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The PrivateDnsZone object representing the zone in which to create the record set.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsZone Zone { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the records in this record set (relative to the name of the zone and without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of Private DNS records in this record set.")]
        [ValidateNotNullOrEmpty]
        public RecordType RecordType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The TTL value of all the records in this record set.")]
        [ValidateNotNullOrEmpty]
        public uint Ttl { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Metadata { get; set; }

        [Alias("PrivateDnsRecords")]
        [Parameter(Mandatory = false, HelpMessage = "The private dns records that are part of this record set.")]
        [ValidateNotNull]
        public PSPrivateDnsRecordBase[] PrivateDnsRecord { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not fail if the record set already exists.")]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            string zoneName = null;
            string resourceGroupName = null;
            PSPrivateDnsRecordSet result = null;

            if (RecordType == RecordType.SOA)
            {
                throw new System.ArgumentException(ProjectResources.Error_AddRecordSOA);
            }

            switch (this.ParameterSetName)
            {
                case FieldsParameterSetName:
                    zoneName = this.ZoneName;
                    resourceGroupName = this.ResourceGroupName;
                    break;
                case ObjectParameterSetName:
                    zoneName = this.Zone.Name;
                    resourceGroupName = this.Zone.ResourceGroupName;
                    break;
                case ResourceParameterSetName:
                    PrivateDnsUtils.GetResourceGroupNameAndZoneNameFromResourceId(this.ParentResourceId, out resourceGroupName, out zoneName);
                    break;
            }

            if(zoneName != null && this.Name.EndsWith(zoneName))
            {
                this.WriteWarning(string.Format(ProjectResources.Error_RecordSetNameEndsWithZoneName, this.Name, zoneName));
            }

            zoneName = TrimTrailingDotInZoneName(zoneName);

            ConfirmAction(
                ProjectResources.Progress_CreatingRecordSet,
                this.Name,
                () =>
                {
                    result = this.PrivateDnsClient.CreatePrivateDnsRecordSet(
                        zoneName,
                        resourceGroupName,
                        this.Name, 
                        this.Ttl,
                        this.RecordType,
                        this.Metadata,
                        this.Overwrite,
                        this.PrivateDnsRecord);

                    if (result != null)
                    {
                        WriteVerbose(ProjectResources.Success);
                        WriteVerbose(string.Format(ProjectResources.Success_NewRecordSet, this.Name, zoneName, this.RecordType));
                        WriteVerbose(string.Format(ProjectResources.Success_RecordSetFqdn, this.Name, zoneName, this.RecordType));
                    }

                    WriteObject(result);
                });
        }
    }
}
