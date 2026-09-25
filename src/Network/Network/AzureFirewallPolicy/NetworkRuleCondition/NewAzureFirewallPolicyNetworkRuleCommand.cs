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

using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Network.AzureFirewallPolicy;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyNetworkRule"), OutputType(typeof(PSAzureFirewallNetworkRule))]
    public class NewAzureFirewallPolicyNetworkRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Network Rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceAddress,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceIpGroup,
            HelpMessage = "The source ipgroups of the rule. Either SourceIpGroup or SourceAddress must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceIpGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination addresses of the rule")]
        public string[] DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination ipgroups of the rule")]
        public string[] DestinationIpGroup { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination ports of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination fqdns of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateSet(
            MNM.AzureFirewallNetworkRuleProtocol.Any,
            MNM.AzureFirewallNetworkRuleProtocol.TCP,
            MNM.AzureFirewallNetworkRuleProtocol.UDP,
            MNM.AzureFirewallNetworkRuleProtocol.Icmp,
            IgnoreCase = false)]
        public string[] Protocol { get; set; }
        
        [Parameter(
            Mandatory = false,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceGeoLocation,
            HelpMessage = "The source geographic location filters (ISO 3166-1 alpha-2 country codes, e.g. \"US\", \"CA\") of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] SourceGeoLocation { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination geographic location filters (ISO 3166-1 alpha-2 country codes, e.g. \"US\", \"CA\") of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationGeoLocation { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (DestinationFqdn != null)
            {
                foreach (string fqdn in DestinationFqdn)
                {
                    ValidateIsFqdn(fqdn);
                }
            }

            // Source types (SourceAddress, SourceIpGroup, SourceGeoLocation) are mutually exclusive.
            // Only one source type may be specified per rule (matches NFVRP validation).
            var sourceTypes = new[]
            {
                SourceAddress != null,
                SourceIpGroup != null,
                SourceGeoLocation != null
            };

            if (sourceTypes.Count(x => x) > 1)
            {
                throw new ArgumentException("SourceAddresses, SourceIpGroups and SourceGeoLocations are exclusive to each other. Only one source type may be specified per rule.");
            }

            // At least one source type must be present
            if (!sourceTypes.Any(x => x))
            {
                throw new ArgumentException("Either SourceAddress, SourceIpGroup or SourceGeoLocation is required");
            }

            // Destination types (DestinationAddress, DestinationIpGroup, DestinationFqdn, DestinationGeoLocation)
            // are mutually exclusive. Only one destination type may be specified per rule (matches NFVRP validation).
            var destinationTypes = new[]
            {
                DestinationAddress != null,
                DestinationIpGroup != null,
                DestinationFqdn != null,
                DestinationGeoLocation != null
            };

            if (destinationTypes.Count(x => x) > 1)
            {
                throw new ArgumentException("DestinationAddresses, DestinationIpGroups, DestinationFqdns and DestinationGeoLocations are exclusive to each other. Only one destination type may be specified per rule.");
            }

            // One of DestinationAddress, DestinationIpGroup, DestinationFqdns or DestinationGeoLocation must be present
            if (!destinationTypes.Any(x => x))
            {
                throw new ArgumentException("Either DestinationAddress, DestinationIpGroup, DestinationFqdns or DestinationGeoLocation is required");
            }

            var networkRule = new PSAzureFirewallPolicyNetworkRule
            {
                Name = this.Name,
                protocols = this.Protocol?.ToList(),
                SourceAddresses = this.SourceAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationIpGroups = this.DestinationIpGroup?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList(),
                DestinationFqdns = this.DestinationFqdn?.ToList(),
                SourceGeoLocations = this.SourceGeoLocation?.ToList(),
                DestinationGeoLocations = this.DestinationGeoLocation?.ToList(),
                RuleType = "NetworkRule",
                Description = this.Description
            };

            WriteObject(networkRule);
        }

        private void ValidateIsFqdn(string fqdn)
        {
            var fqdnRegEx = new Regex("^\\*$|^[a-zA-Z0-9]+(([a-zA-Z0-9_\\-]*[a-zA-Z0-9]+)*\\.)*(?:[a-zA-Z0-9]{2,})$");

            if (!fqdnRegEx.IsMatch(fqdn))
            {
                throw new ArgumentException($"Invalid value {fqdn}.");
            }
        }
    }
}
