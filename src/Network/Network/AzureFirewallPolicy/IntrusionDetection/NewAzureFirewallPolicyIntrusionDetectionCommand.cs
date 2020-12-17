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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyIntrusionDetection",
        SupportsShouldProcess = true),
        OutputType(typeof(PSAzureFirewallPolicyIntrusionDetection))]
    public class NewAzureFirewallPolicyIntrusionDetectionCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "Intrusion Detection general state."
         )]
        [ValidateSet(
            MNM.FirewallPolicyIntrusionDetectionStateType.Off,
            MNM.FirewallPolicyIntrusionDetectionStateType.Alert,
            MNM.FirewallPolicyIntrusionDetectionStateType.Deny,
            IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string Mode { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of specific signatures states."
         )]
        public PSAzureFirewallPolicyIntrusionDetectionSignatureOverride[] SignatureOverride { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of rules for traffic to bypass."
         )]
        public PSAzureFirewallPolicyIntrusionDetectionBypassTrafficSetting[] BypassTraffic { get; set; }

        public override void Execute()
        {
            base.Execute();

            var intrusionDetection = new PSAzureFirewallPolicyIntrusionDetection
            {
                Mode = this.Mode
            };

            if (this.SignatureOverride?.Count() > 0 || this.BypassTraffic?.Count() > 0)
            {
                intrusionDetection.Configuration = new PSAzureFirewallPolicyIntrusionDetectionConfiguration
                {
                    SignatureOverrides = this.SignatureOverride?.ToList(),
                    BypassTrafficSettings = this.BypassTraffic?.ToList()
                };
            }

            WriteObject(intrusionDetection);
        }
    }
}
