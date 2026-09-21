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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicy", SupportsShouldProcess = true), OutputType(typeof(PSDdosCustomPolicy))]
    public partial class SetAzureRmDdosCustomPolicyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The DDoS custom policy object to update.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSDdosCustomPolicy DdosCustomPolicy { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.IsNullOrEmpty(this.DdosCustomPolicy.ResourceGroupName))
            {
                throw new ArgumentException("ResourceGroupName is required.");
            }

            if (string.IsNullOrEmpty(this.DdosCustomPolicy.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            var vDdosCustomPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.DdosCustomPolicy>(this.DdosCustomPolicy);
            vDdosCustomPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.DdosCustomPolicy.Tag, validate: true);

            vDdosCustomPolicyModel.DetectionRules = BuildDetectionRules(this.DdosCustomPolicy.DetectionRules);
            // Service no longer accepts frontEndIpConfiguration on update payload.
            vDdosCustomPolicyModel.FrontEndIPConfiguration = null;

            ConfirmAction(
                true,
                string.Format(Properties.Resources.OverwritingResource, this.DdosCustomPolicy.Name),
                Properties.Resources.SettingResourceMessage,
                this.DdosCustomPolicy.Name,
                () =>
                {
                    this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.CreateOrUpdate(
                        this.DdosCustomPolicy.ResourceGroupName,
                        this.DdosCustomPolicy.Name,
                        vDdosCustomPolicyModel);

                    var getDdosCustomPolicy = this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.Get(
                        this.DdosCustomPolicy.ResourceGroupName,
                        this.DdosCustomPolicy.Name);

                    var psDdosCustomPolicy = NetworkResourceManagerProfile.Mapper.Map<PSDdosCustomPolicy>(getDdosCustomPolicy);
                    psDdosCustomPolicy.ResourceGroupName = this.DdosCustomPolicy.ResourceGroupName;
                    psDdosCustomPolicy.Tag = TagsConversionHelper.CreateTagHashtable(getDdosCustomPolicy.Tags);

                    WriteObject(psDdosCustomPolicy, true);
                });
        }

        private static List<MNM.DdosDetectionRule> BuildDetectionRules(IList<PSDdosCustomPolicyDetectionRule> detectionRules)
        {
            if (detectionRules == null)
            {
                return null;
            }

            var rules = new List<MNM.DdosDetectionRule>();
            var allowedTrafficTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                MNM.DdosTrafficType.Tcp,
                MNM.DdosTrafficType.Udp,
                MNM.DdosTrafficType.TcpSyn,
            };
            var seenRuleNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var rule in detectionRules)
            {
                if (rule == null)
                {
                    throw new ArgumentException("DetectionRules cannot contain null entries.");
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
                    throw new ArgumentException(string.Format("Duplicate rule name '{0}' found in DetectionRules.", rule.Name));
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
