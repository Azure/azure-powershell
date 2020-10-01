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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyDnsSetting", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyDnsSettings))]
    public class NewAzureFirewallDnsSettingCommand : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable DNS Proxy. By default it is disabled."
        )]
        public SwitchParameter EnableProxy { get; set; }

        [CmdletParameterBreakingChange(
            "ProxyNotRequiredForNetworkRule",
            ChangeDescription = "ProxyNotRequiredForNetworkRule is being deprecated without being replaced")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Requires DNS Proxy functionality for FQDNs within Network Rules. By default it is true."
        )]
        public SwitchParameter ProxyNotRequiredForNetworkRule { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The list of DNS Servers")]
        public string[] Server { get; set; }

        public override void Execute()
        {
            base.Execute();

            var dnsSetting = new PSAzureFirewallPolicyDnsSettings
            {
                EnableProxy = this.EnableProxy.IsPresent ? true : (bool?)null,
                Servers = this.Server?.ToList()
            };

            WriteObject(dnsSetting);
        }

    }
}
