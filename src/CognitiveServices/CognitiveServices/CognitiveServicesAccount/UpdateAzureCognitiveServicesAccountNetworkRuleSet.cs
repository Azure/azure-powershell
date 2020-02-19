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
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountNetworkRuleSet", SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSet))]
    public class UpdateAzureCognitiveServicesAccountNetworkRuleSetCommand : CognitiveServicesAccountBaseCmdlet
    {
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
            Mandatory = false,
            HelpMessage = "Cognitive Services Account NetworkRule DefaultAction.")]
        [ValidateNotNullOrEmpty]
        public PSNetWorkRuleDefaultActionEnum DefaultAction
        {
            get
            {
                return defaultAction == null ? PSNetWorkRuleDefaultActionEnum.Allow : defaultAction.Value;
            }
            set
            {
                defaultAction = value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Cognitive Services Account NetworkRule IpRules.")]
        public PSIpRule[] IpRule
        {
            get
            {
                return ipRules;
            }
            set
            {
                isIpRuleSet = true;
                ipRules = value == null ? new List<PSIpRule>().ToArray() : value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Cognitive Services Account NetworkRule VirtualNetworkRules.")]
        public PSVirtualNetworkRule[] VirtualNetworkRule
        {
            get
            {
                return virtualNetworkRules;
            }
            set
            {
                isNetworkRuleSet = true;
                virtualNetworkRules = value == null ? new List<PSVirtualNetworkRule>().ToArray() : value;
            }
        }

        private PSNetWorkRuleDefaultActionEnum? defaultAction = null;
        private PSIpRule[] ipRules = null;
        private PSVirtualNetworkRule[] virtualNetworkRules = null;
        private bool isIpRuleSet = false;
        private bool isNetworkRuleSet = false;


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Update Cognitive Services Account NetworkRule"))
            {
                if (IpRule == null && VirtualNetworkRule == null && defaultAction == null)
                {
                    throw new System.ArgumentNullException("IpRules, VirtualNetworkRules, DefaultAction", "Request must specify an account NetworkRule property to update.");
                }

                var account = this.CognitiveServicesClient.Accounts.GetProperties(
                    this.ResourceGroupName,
                    this.Name);
                NetworkRuleSet accountACL = account.Properties.NetworkAcls;

                if (accountACL == null)
                {
                    accountACL = new NetworkRuleSet();
                }

                PSNetworkRuleSet psNetworkRule = PSNetworkRuleSet.Create(accountACL);

                if (isIpRuleSet)
                {
                    psNetworkRule.IpRules = IpRule;
                }

                if (isNetworkRuleSet)
                {
                    psNetworkRule.VirtualNetworkRules = VirtualNetworkRule;
                }

                if (defaultAction != null)
                {
                    psNetworkRule.DefaultAction = defaultAction.Value;
                }

                var properties = new CognitiveServicesAccountProperties();
                properties.NetworkAcls = psNetworkRule.ToNetworkRuleSet();
                this.CognitiveServicesClient.Accounts.Update(
                    this.ResourceGroupName,
                    this.Name,
                    new CognitiveServicesAccount()
                    {
                        Properties = properties
                    }
                    );

                account = this.CognitiveServicesClient.Accounts.GetProperties(this.ResourceGroupName, this.Name);

                WriteObject(PSNetworkRuleSet.Create(account.Properties.NetworkAcls));
            }
        }
    }
}