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
            Mandatory = true,
            HelpMessage = "Specifies the traffic type for the DDoS detection rule. Allowed values are Tcp, Udp, and TcpSyn.")]
        [ValidateSet(MNM.DdosTrafficType.Tcp, MNM.DdosTrafficType.Udp, MNM.DdosTrafficType.TcpSyn, IgnoreCase = true)]
        public string TrafficType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the packets per second threshold for the DDoS detection rule.")]
        [ValidateRange(1, int.MaxValue)]
        public int? PacketsPerSecond { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vDdosCustomPolicy = new PSDdosCustomPolicy
            {
                Location = this.Location,
            };

            var vDdosCustomPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.DdosCustomPolicy>(vDdosCustomPolicy);
            vDdosCustomPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            vDdosCustomPolicyModel.DetectionRules = new List<MNM.DdosDetectionRule>
            {
                new MNM.DdosDetectionRule
                {
                    Name = string.Format("detectionRule{0}", this.TrafficType),
                    DetectionMode = MNM.DdosDetectionMode.TrafficThreshold,
                    TrafficDetectionRule = new MNM.TrafficDetectionRule
                    {
                        TrafficType = this.TrafficType,
                        PacketsPerSecond = this.PacketsPerSecond,
                    }
                }
            };
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.Get(this.ResourceGroupName, this.Name);
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
                this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.CreateOrUpdate(this.ResourceGroupName, this.Name, vDdosCustomPolicyModel);
                var getDdosCustomPolicy = this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.Get(this.ResourceGroupName, this.Name);
                var psDdosCustomPolicy = NetworkResourceManagerProfile.Mapper.Map<PSDdosCustomPolicy>(getDdosCustomPolicy);
                psDdosCustomPolicy.ResourceGroupName = this.ResourceGroupName;
                psDdosCustomPolicy.Tag = TagsConversionHelper.CreateTagHashtable(getDdosCustomPolicy.Tags);
                WriteObject(psDdosCustomPolicy, true);
            },
            () => present);
        }
    }
}
