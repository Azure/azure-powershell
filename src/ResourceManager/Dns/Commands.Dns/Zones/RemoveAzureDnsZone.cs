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
    [Cmdlet(VerbsCommon.Remove, "AzureDnsZone"), OutputType(typeof(bool))]
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
        public SwitchParameter IgnoreEtag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
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
                zoneToDelete = this.Zone;

                if ((string.IsNullOrWhiteSpace(this.Zone.Etag) || this.Zone.Etag == "*") && !this.IgnoreEtag.IsPresent)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(DnsZone).Name));
                }
            }

            bool ignoreEtag = this.IgnoreEtag.IsPresent || this.ParameterSetName != "Object";

            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.Confirm_RemoveZone, zoneToDelete.Name),
                ProjectResources.Progress_RemovingZone,
                this.Name,
                () => { deleted = DnsClient.DeleteDnsZone(zoneToDelete, ignoreEtag); });

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
