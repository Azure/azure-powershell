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

using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.CognitiveServices;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = NetWorkRuleStringParameterSet)]
    [OutputType(typeof(PSVirtualNetworkRule), ParameterSetName = new string[] { NetWorkRuleStringParameterSet, NetworkRuleObjectParameterSet })]
    [OutputType(typeof(PSIpRule), ParameterSetName = new string[] { IpRuleStringParameterSet, IpRuleObjectParameterSet })]
    public class AddAzureCognitiveServicesAccountNetworkRuleCommand : CognitiveServicesAccountBaseCmdlet
    {
        /// <summary>
        /// NetWorkRule in String parameter set name
        /// </summary>
        private const string NetWorkRuleStringParameterSet = "NetWorkRuleString";

        /// <summary>
        /// IpRule in String paremeter set name
        /// </summary>
        private const string IpRuleStringParameterSet = "IpRuleString";

        /// <summary>
        /// NetWorkRule Objects pipeline parameter set
        /// </summary>
        private const string NetworkRuleObjectParameterSet = "NetworkRuleObject";

        /// <summary>
        /// IpRule Objects pipeline parameter set
        /// </summary>
        private const string IpRuleObjectParameterSet = "IpRuleObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Cognitive Services Account NetworkRule IpRules.",
            ValueFromPipeline = true, ParameterSetName = IpRuleObjectParameterSet)]
        public PSIpRule[] IpRule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Cognitive Services Account NetworkRule VirtualNetworkRules.",
            ValueFromPipeline = true, ParameterSetName = NetworkRuleObjectParameterSet)]
        public PSVirtualNetworkRule[] VirtualNetworkRule { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Cognitive Services Account NetworkRule IpRules IpAddressOrRange in string.",
            ParameterSetName = IpRuleStringParameterSet)]
        public string[] IpAddressOrRange { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Cognitive Services Account NetworkRule VirtualNetworkRules VirtualNetworkResourceId in string.",
            ParameterSetName = NetWorkRuleStringParameterSet)]
        [Alias("SubnetId", "VirtualNetworkId")]
        public string[] VirtualNetworkResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Add Cognitive Services Account NetworkRules"))
            {
                var account = this.CognitiveServicesClient.Accounts.GetProperties(
                this.ResourceGroupName,
                this.Name);
                NetworkRuleSet accountACL = account.Properties.NetworkAcls;

                if (accountACL == null)
                {
                    accountACL = new NetworkRuleSet();
                }

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                        if (accountACL.VirtualNetworkRules == null)
                        {
                            accountACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        }

                        foreach (string s in VirtualNetworkResourceId)
                        {
                            VirtualNetworkRule rule = new VirtualNetworkRule(s, null, true);
                            accountACL.VirtualNetworkRules.Add(rule);
                        }
                        break;
                    case IpRuleStringParameterSet:
                        if (accountACL.IpRules == null)
                        {
                            accountACL.IpRules = new List<IpRule>();
                        }

                        foreach (string s in IpAddressOrRange)
                        {
                            IpRule rule = new IpRule(s);
                            accountACL.IpRules.Add(rule);
                        }
                        break;
                    case NetworkRuleObjectParameterSet:
                        if (accountACL.VirtualNetworkRules == null)
                        {
                            accountACL.VirtualNetworkRules = new List<VirtualNetworkRule>();
                        }

                        foreach (PSVirtualNetworkRule rule in VirtualNetworkRule)
                        {
                            accountACL.VirtualNetworkRules.Add(rule.ToVirtualNetworkRule());
                        }
                        break;
                    case IpRuleObjectParameterSet:
                        if (accountACL.IpRules == null)
                        {
                            accountACL.IpRules = new List<IpRule>();
                        }

                        foreach (PSIpRule rule in IpRule)
                        {
                            accountACL.IpRules.Add(rule.ToIpRule());
                        }
                        break;
                }

                var properties = new CognitiveServicesAccountProperties();
                properties.NetworkAcls = accountACL;
                this.CognitiveServicesClient.Accounts.Update(
                    this.ResourceGroupName,
                    this.Name,
                    new CognitiveServicesAccount()
                    {
                        Properties = properties
                    }
                    );

                account = this.CognitiveServicesClient.Accounts.GetProperties(this.ResourceGroupName, this.Name);

                switch (ParameterSetName)
                {
                    case NetWorkRuleStringParameterSet:
                    case NetworkRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.Create(account.Properties.NetworkAcls).VirtualNetworkRules);
                        break;
                    case IpRuleStringParameterSet:
                    case IpRuleObjectParameterSet:
                        WriteObject(PSNetworkRuleSet.Create(account.Properties.NetworkAcls).IpRules);
                        break;
                }
            }
        }
    }
}
