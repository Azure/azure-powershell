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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
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
        private const string NamesParameterSetName = "Names";

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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the parent zone to add delegation (without a terminating dot).", ParameterSetName = NamesParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ParentZoneName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of the parent zone to add delegation (without a terminating dot).", ParameterSetName = IdsParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ParentZoneId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The DnsZone object representing the parent zone to add delegation.", ParameterSetName = ObjectsParameterSetName)]
        [ValidateNotNullOrEmpty]
        public DnsZone ParentZone { get; set; }

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

                    try
                    {
                        DnsZone parent = this.ParseParentZoneFromArguments();
                        if (parent != null && this.Name.EndsWith(parent.Name))
                        {
                            AddDnsNameserverDelegation(result, parent);
                            this.WriteVerbose(ProjectResources.Success);
                            this.WriteVerbose(string.Format(ProjectResources.Success_NSDelegation, this.Name, parent.Name));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        this.WriteWarning(string.Format(ProjectResources.Error_NSDelegation, this.Name));
                        this.WriteWarning(ex.Message);
                    }
                });
        }
        /// <summary>
        /// This method adds name server delegation in the parent zone for the created child zone.
        /// The NS records are added in the parent zone that corresponds to the child zone
        /// </summary>
        /// <param name="zone">the created child zone</param>
        /// <param name="parent">the parent zone</param>
        private DnsRecordSet AddDnsNameserverDelegation(DnsZone zone, DnsZone parent)
        {
            DnsRecordSet recordSet = null;
            if (zone != null && parent != null && zone.NameServers != null && zone.NameServers.Count > 0)
            {
                List<NsRecord> nameServersList = new List<NsRecord>();
                foreach (string nameserver in zone.NameServers)
                {
                    NsRecord record = new NsRecord();
                    record.Nsdname = nameserver;
                    nameServersList.Add(record);
                }

                DnsRecordBase[] resourceRecords = nameServersList.ToArray();
                string recordName = this.Name.Replace('.' + parent.Name, "");
                recordSet = this.DnsClient.CreateDnsRecordSet(
                    parent.Name,
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

        /// <summary>
        /// This method parses the parent zone from the command arguments, depending
        /// on the format of the parent zone details passed.
        /// Supports resource id, parent zone name and the zone object.
        /// </summary>
        private DnsZone ParseParentZoneFromArguments()
        {
            DnsZone parent = null;
            string parentZoneName = this.ParentZoneName;
            string parentResourceGroupName = this.ResourceGroupName;

            if (this.ParameterSetName == ObjectsParameterSetName && this.ParentZone != null)
            {
                parentZoneName = this.ParentZone.Name;
                parentResourceGroupName = this.ParentZone.ResourceGroupName;
            }
            else if (this.ParameterSetName == IdsParameterSetName && !string.IsNullOrEmpty(this.ParentZoneId))
            {
                ResourceIdentifier resource = new ResourceIdentifier(ParentZoneId);
                string subscriptionIdInContext = this.DefaultContext.Subscription.Id;
                parentZoneName = resource.ResourceName;
                parentResourceGroupName = resource.ResourceGroupName;
                if (subscriptionIdInContext != resource.Subscription)
                {
                    throw new PSArgumentException(string.Format(ProjectResources.Error_NSDelegationSubscriptionMisMatch, this.Name, parentZoneName));
                }
            }
            if(parentZoneName != null)
            {
                parent = new DnsZone();
                parent.Name = parentZoneName;
                parent.ResourceGroupName = parentResourceGroupName;
            }
            return parent;
        }
    }
}
