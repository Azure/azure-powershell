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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Commands.PrivateDns.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets one or more existing record sets.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordSet", DefaultParameterSetName = FieldsParameterSetName), OutputType(typeof(PSPrivateDnsRecordSet))]
    public class GetAzurePrivateDnsRecordSet : PrivateDnsBaseCmdlet
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

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The DnsZone object representing the zone in which to create the record set.", ParameterSetName = ObjectParameterSetName)]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsZone Zone { get; set; }

        [Parameter(ParameterSetName = ResourceParameterSetName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Private DNS Zone ResourceID.")]
        [ResourceIdCompleter("Microsoft.Network/privateDnsZones")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the records in this record set (relative to the name of the zone and without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of DNS records in this record set.")]
        [ValidateNotNullOrEmpty]
        public RecordType? RecordType { get; set; }

        public override void ExecuteCmdlet()
        {
            string zoneName = null;
            string resourceGroupName = null;

            switch (this.ParameterSetName)
            {
                case FieldsParameterSetName:
                    zoneName = this.ZoneName;
                    resourceGroupName = this.ResourceGroupName;
                    break;
                case ResourceParameterSetName:
                    PrivateDnsUtils.GetResourceGroupNameAndZoneNameFromResourceId(this.ParentResourceId, out resourceGroupName, out zoneName);
                    break;
                default:
                    zoneName = this.Zone.Name;
                    resourceGroupName = this.Zone.ResourceGroupName;
                    break;
            }

            if (zoneName != null && zoneName.EndsWith("."))
            {
                zoneName = zoneName.TrimEnd('.');
                this.WriteWarning($"Modifying zone name to remove terminating '.'.  Zone name used is \"{zoneName}\".");
            }

            if (this.Name != null)
            {
                if (this.RecordType == null)
                {
                    throw new PSArgumentException("If you specify the Name parameter you must also specify the RecordType parameter.");
                }

                var result = this.PrivateDnsClient.GetPrivateDnsRecordSet(this.Name, zoneName, resourceGroupName, this.RecordType.Value);
                this.WriteObject(result);
            }
            else
            {
                List<PSPrivateDnsRecordSet> result = null;
                result = this.RecordType == null ? this.PrivateDnsClient.ListRecordSets(zoneName, resourceGroupName) : this.PrivateDnsClient.ListRecordSets(zoneName, resourceGroupName, this.RecordType.Value);

                foreach (var r in result)
                {
                    this.WriteObject(r);
                }
            }

        }
    }
}
