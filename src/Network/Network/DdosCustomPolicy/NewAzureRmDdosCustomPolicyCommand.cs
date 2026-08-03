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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicy", SupportsShouldProcess = true), OutputType(typeof(PSDdosCustomPolicy))]
    public partial class NewAzureRmDdosCustomPolicy : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the resource group of the DDoS custom policy to be created.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS custom policy to be created.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the location of the DDoS custom policy to be created.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/ddosCustomPolicies")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies one or more DDoS detection rules for the policy.")]
        public PSDdosCustomPolicyDetectionRule[] DetectionRule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.DetectionRule == null || this.DetectionRule.Length == 0)
            {
                throw new PSArgumentException("At least one detection rule is required when creating a DDoS custom policy.");
            }

            var vDdosCustomPolicy = new PSDdosCustomPolicy
            {
                Location = this.Location,
            };

            var vDdosCustomPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.DdosCustomPolicy>(vDdosCustomPolicy);
            vDdosCustomPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            vDdosCustomPolicyModel.DetectionRules = BuildDetectionRules();
            // Service no longer accepts frontEndIpConfiguration on create payload.
            vDdosCustomPolicyModel.FrontEndIPConfiguration = null;
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).GetAwaiter().GetResult();
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                true,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                    this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, vDdosCustomPolicyModel).GetAwaiter().GetResult();
                    var getDdosCustomPolicy = this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.GetWithHttpMessagesAsync(this.ResourceGroupName, this.Name).GetAwaiter().GetResult().Body;
                var psDdosCustomPolicy = NetworkResourceManagerProfile.Mapper.Map<PSDdosCustomPolicy>(getDdosCustomPolicy);
                psDdosCustomPolicy.ResourceGroupName = this.ResourceGroupName;
                psDdosCustomPolicy.Tag = TagsConversionHelper.CreateTagHashtable(getDdosCustomPolicy.Tags);
                WriteObject(psDdosCustomPolicy, true);
            },
            () => present);
        }

        private List<MNM.DdosDetectionRule> BuildDetectionRules()
        {

            var rules = new List<MNM.DdosDetectionRule>();
            var allowedTrafficTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                MNM.DdosTrafficType.Tcp,
                MNM.DdosTrafficType.Udp,
                MNM.DdosTrafficType.TcpSyn
            };

            var seenRuleNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var rule in this.DetectionRule)
            {
                if (rule == null)
                {
                    throw new ArgumentException("DetectionRule cannot contain null entries.");
                }

                if (string.IsNullOrWhiteSpace(rule.Name))
                {
                    throw new ArgumentException("DetectionRule.Name is required.");
                }

                if (string.IsNullOrWhiteSpace(rule.TrafficType) || !allowedTrafficTypes.Contains(rule.TrafficType))
                {
                    throw new ArgumentException("DetectionRule.TrafficType must be one of Tcp, Udp, or TcpSyn.");
                }

                if (!seenRuleNames.Add(rule.Name))
                {
                    throw new ArgumentException($"Duplicate rule name '{rule.Name}' found in DetectionRule array.");
                }

                rules.Add(new MNM.DdosDetectionRule
                {
                    Name = rule.Name,
                    DetectionMode = MNM.DdosDetectionMode.TrafficThreshold,
                    TrafficDetectionRule = new MNM.TrafficDetectionRule
                    {
                        TrafficType = rule.TrafficType,
                        PacketsPerSecond = rule.PacketsPerSecond,
                    }
                });
            }

            return rules;
        }
    }
}
