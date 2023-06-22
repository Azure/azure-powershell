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


using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicySnat"), OutputType(typeof(PSAzureFirewallPolicySNAT))]
    public class NewAzureFirewallPolicySNATCommand : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Private IP Range")]
        public string[] PrivateRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable/disable auto learn private ranges. By default it is disabled.")]
        public SwitchParameter AutoLearnPrivateRange { get; set; }

        public override void Execute()
        {
            base.Execute();

            if(this.AutoLearnPrivateRange.IsPresent && this.PrivateRange == null)
            {
                this.PrivateRange = new string[] {};
            }

            var firewallPolicySNAT = new PSAzureFirewallPolicySNAT
            {
                AutoLearnPrivateRanges = this.AutoLearnPrivateRange.IsPresent ? "Enabled" : "Disabled",
                PrivateRanges = this.PrivateRange
            };
            WriteObject(firewallPolicySNAT);
        }

    }
}
