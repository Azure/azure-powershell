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

using Microsoft.Azure.Commands.Dns.Models;
using Microsoft.Azure.Management.Dns.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Gets one or more existing record sets.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmDnsRecordSet"), OutputType(typeof(DnsRecordSet))]
    public class GetAzureDnsRecordSet : DnsBaseCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = "Fields", ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the records inthis record set (relative to the name of the zone and without a terminating dot).")]
        [Parameter(Mandatory = false, ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The zone in which to create the record set (without a terminating dot).", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ZoneName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group to which the zone belongs.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The DnsZone object representing the zone in which to create the record set.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public DnsZone Zone { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of DNS records in this record set.")]
        [ValidateNotNullOrEmpty]
        public RecordType? RecordType { get; set; }

        public override void ExecuteCmdlet()
        {
            string zoneName = null;
            string resourceGroupName = null;

            if (this.ParameterSetName == "Fields")
            {
                zoneName = this.ZoneName;
                resourceGroupName = this.ResourceGroupName;
            }
            else
            {
                zoneName = this.Zone.Name;
                resourceGroupName = this.Zone.ResourceGroupName;
            }

            if (zoneName != null && zoneName.EndsWith("."))
            {
                zoneName = zoneName.TrimEnd('.');
                this.WriteWarning(string.Format("Modifying zone name to remove terminating '.'.  Zone name used is \"{0}\".", zoneName));
            }

            if (this.Name != null)
            {
                if (this.RecordType == null)
                {
                    throw new PSArgumentException("If you specify the Name parameter you must also specify the RecordType parameter.");
                }

                DnsRecordSet result = this.DnsClient.GetDnsRecordSet(this.Name, zoneName, resourceGroupName, this.RecordType.Value);
                this.WriteObject(result);
            }
            else
            {
                List<DnsRecordSet> result = null;
                if (this.RecordType == null)
                {
                    result = this.DnsClient.ListRecordSets(zoneName, resourceGroupName);
                }
                else
                {
                    result = this.DnsClient.ListRecordSets(zoneName, resourceGroupName, this.RecordType.Value);
                }

                foreach (var r in result)
                {
                    this.WriteObject(r);
                }
            }

        }
    }
}
