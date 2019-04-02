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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Dns.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Dns.Models;
using Microsoft.Azure.Management.Internal.Network.Common;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Creates a new zone.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DnsZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = IdsParameterSetName), OutputType(typeof(DnsZone))]
    public class NewAzureDnsZone : DnsBaseCmdlet
    {
        private const string IdsParameterSetName = "Ids";
        private const string ObjectsParameterSetName = "Objects";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the zone (without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group in which to create the zone.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of the zone, Public or Private. This property cannot be changed for a zone.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Public", "Private")]
        public ZoneType? ZoneType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the parent zone to add delegation (without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string ParentZoneName { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = IdsParameterSetName, HelpMessage = "The list of virtual network ids that will register virtual machine hostnames records in this DNS zone, only available for private zones.")]
        [ValidateNotNull]
        public List<string> RegistrationVirtualNetworkId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = IdsParameterSetName, HelpMessage = "The list of virtual network ids able to resolve records in this DNS zone, only available for private zones.")]
        [ValidateNotNull]
        public List<string> ResolutionVirtualNetworkId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ObjectsParameterSetName, HelpMessage = "The list of virtual networks that will register virtual machine hostnames records in this DNS zone, only available for private zones.")]
        [ValidateNotNull]
        public List<IResourceReference> RegistrationVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ObjectsParameterSetName, HelpMessage = "The list of virtual networks able to resolve records in this DNS zone, only available for private zones.")]
        [ValidateNotNull]
        public List<IResourceReference> ResolutionVirtualNetwork { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.Name.EndsWith("."))
            {
                this.Name = this.Name.TrimEnd('.');
                this.WriteWarning(string.Format("Modifying zone name to remove terminating '.'.  Zone name used is \"{0}\".", this.Name));
            }

            base.ConfirmAction(
                ProjectResources.Progress_CreatingNewZone,
                this.Name,
                () =>
                {
                    ZoneType zoneType = this.ZoneType != null ? this.ZoneType.Value : Management.Dns.Models.ZoneType.Public;

                    List<string> registrationVirtualNetworkIds = this.RegistrationVirtualNetworkId;
                    List<string> resolutionVirtualNetworkIds = this.ResolutionVirtualNetworkId;
                    if (this.ParameterSetName == ObjectsParameterSetName)
                    {
                        registrationVirtualNetworkIds = this.RegistrationVirtualNetwork?.Select(virtualNetwork => virtualNetwork.Id).ToList();
                        resolutionVirtualNetworkIds = this.ResolutionVirtualNetwork?.Select(virtualNetwork => virtualNetwork.Id).ToList();
                    }

                    DnsZone result = this.DnsClient.CreateDnsZone(
                        this.Name,
                        this.ResourceGroupName,
                        this.Tag,
                        zoneType,
                        registrationVirtualNetworkIds,
                        resolutionVirtualNetworkIds);
                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteVerbose(zoneType == Management.Dns.Models.ZoneType.Private
                        ? string.Format(ProjectResources.Success_NewPrivateZone, this.Name, this.ResourceGroupName)
                        : string.Format(ProjectResources.Success_NewZone, this.Name, this.ResourceGroupName));
                    this.WriteObject(result);

                    if (!string.IsNullOrEmpty(this.ParentZoneName) && this.Name.EndsWith(this.ParentZoneName))
                    {
                        AddDnsNameserverDelegation(result);
                        this.WriteVerbose(ProjectResources.Success);
                        this.WriteVerbose(string.Format(ProjectResources.Success_NSDelegation, this.Name, this.ParentZoneName));

                    }
                });
        }
        /// <summary>
        /// This method adds name server delegation in the parent zone for the created child zone.
        /// The NS records are added in the parent zone that corresponds to the child zone
        /// </summary>
        /// <param name="zone">the created child zone</param>
        private DnsRecordSet AddDnsNameserverDelegation(DnsZone zone)
        {
            DnsRecordSet recordSet = null;
            if (zone != null && zone.NameServers != null && zone.NameServers.Count > 0)
            {
                List<NsRecord> nameServersList = new List<NsRecord>();
                foreach (string nameserver in zone.NameServers)
                {
                    NsRecord record = new NsRecord();
                    record.Nsdname = nameserver;
                    nameServersList.Add(record);
                }

                DnsRecordBase[] resourceRecords = nameServersList.ToArray();
                string recordName = this.Name.Replace('.' + ParentZoneName, "");
                recordSet = this.DnsClient.CreateDnsRecordSet(
                    this.ParentZoneName,
                    this.ResourceGroupName,
                    recordName,
                    3600,
                    RecordType.NS,
                    null,
                    true,
                    resourceRecords,
                    null);
            }
            return recordSet;
        }
    }
}
