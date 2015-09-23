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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Dns.Models;
using Microsoft.Azure.Commands.Dns.Properties;

using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Deletes an existing zone.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmDnsZone"), OutputType(typeof(bool))]
    public class RemoveAzureDnsZone : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the zone (without a terminating dot).", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group in which the zone exists.", ParameterSetName = "Fields")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The zone object to set.", ParameterSetName = "Object")]
        [ValidateNotNullOrEmpty]
        public DnsZone Zone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the Zone parameter for optimistic concurrency checks.", ParameterSetName = "Object")]
        public SwitchParameter Overwrite { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            bool deleted = false;
            DnsZone zoneToDelete = null;

            if (this.ParameterSetName == "Fields")
            {
                zoneToDelete = new DnsZone 
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Etag = null,
                };
            }
            else if (this.ParameterSetName == "Object")
            {
                if ((string.IsNullOrWhiteSpace(this.Zone.Etag) || this.Zone.Etag == "*") && !this.Overwrite.IsPresent)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(DnsZone).Name));
                }

                zoneToDelete = this.Zone;
            }

            if (zoneToDelete.Name != null && zoneToDelete.Name.EndsWith("."))
            {
                zoneToDelete.Name = zoneToDelete.Name.TrimEnd('.');
                this.WriteWarning(string.Format("Modifying zone name to remove terminating '.'.  Zone name used is \"{0}\".", zoneToDelete.Name));
            }

            bool overwrite = this.Overwrite.IsPresent || this.ParameterSetName != "Object";

            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.Confirm_RemoveZone, zoneToDelete.Name),
                ProjectResources.Progress_RemovingZone,
                this.Name,
                () => { deleted = DnsClient.DeleteDnsZone(zoneToDelete, overwrite); });

            if (deleted)
            {
                WriteVerbose(ProjectResources.Success);
                WriteVerbose(string.Format(ProjectResources.Success_RemoveZone, zoneToDelete.Name, zoneToDelete.ResourceGroupName));
            }

            if (this.PassThru)
            {
                WriteObject(deleted);
            }
        }
    }
}
