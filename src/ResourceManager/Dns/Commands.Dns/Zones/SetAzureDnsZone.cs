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
using System.Collections;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Updates an existing zone.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDnsZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(DnsZone))]
    public class SetAzureDnsZone : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the zone (without a terminating dot).", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group in which the zone exists.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource tags.", ParameterSetName = "Fields")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The zone object to set.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public DnsZone Zone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the RecordSet parameter for optimistic concurrency checks.", ParameterSetName = "Object")]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            DnsZone result = null;
            DnsZone zoneToUpdate = null;

            if (this.ParameterSetName == "Fields")
            {
                zoneToUpdate = new DnsZone
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Etag = "*",
                    Tags = this.Tag,
                };
            }
            else if (this.ParameterSetName == "Object")
            {
                if ((string.IsNullOrWhiteSpace(this.Zone.Etag) || this.Zone.Etag == "*") && !this.Overwrite.IsPresent)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(DnsZone).Name));
                }

                zoneToUpdate = this.Zone;
            }

            if (zoneToUpdate.Name != null && zoneToUpdate.Name.EndsWith("."))
            {
                zoneToUpdate.Name = zoneToUpdate.Name.TrimEnd('.');
                this.WriteWarning(string.Format("Modifying zone name to remove terminating '.'.  Zone name used is \"{0}\".", zoneToUpdate.Name));
            }
            ConfirmAction(
                ProjectResources.Progress_Modifying,
                zoneToUpdate.Name,
                () =>
                {
                    bool overwrite = this.Overwrite.IsPresent || this.ParameterSetName != "Object";
                    result = this.DnsClient.UpdateDnsZone(zoneToUpdate, overwrite);

                    WriteVerbose(ProjectResources.Success);
                    WriteObject(result);
                });
        }
    }
}
