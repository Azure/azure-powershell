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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using PSKeyVaultModels = Microsoft.Azure.Commands.KeyVault.Models;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultNetworkRuleSetObject")]
    [OutputType(typeof(PSKeyVaultNetworkRuleSet))]
    public class NewAzureKeyVaultNetworkRuleSetObject : KeyVaultManagementCmdletBase
    {
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies default action of network rule.")]
        [ValidateNotNull]
        public PSKeyVaultNetworkRuleDefaultActionEnum DefaultAction { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies bypass of network rule.")]
        [ValidateNotNull]
        public PSKeyVaultNetworkRuleBypassEnum Bypass { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies allowed network IP address range of network rule.")]
        [ValidateCount(0, 127)]
        [ValidateNotNull]
        public string[] IpAddressRange { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies allowed virtual network resource identifier of network rule.")]
        [ValidateCount(0, 127)]
        [ValidateNotNull]
        public string[] VirtualNetworkResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            var defaultRuleSet = new PSKeyVaultNetworkRuleSet();

            WriteObject(new PSKeyVaultNetworkRuleSet(
                this.IsParameterBound(c => c.DefaultAction) ? DefaultAction : defaultRuleSet.DefaultAction,
                this.IsParameterBound(c => c.Bypass) ? Bypass : defaultRuleSet.Bypass,
                this.IsParameterBound(c => c.IpAddressRange) ? IpAddressRange : defaultRuleSet.IpAddressRanges,
                this.IsParameterBound(c => c.VirtualNetworkResourceId) ? VirtualNetworkResourceId : defaultRuleSet.VirtualNetworkResourceIds
            ));
        }
    }
}