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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyExplicitProxySetting", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyExplicitProxy))]
    public class NewAzureFirewallPolicyExplicitProxySettingCommand : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = false,
            HelpMessage = "When set to true, explicit proxy mode is enabled."
        )]
        public SwitchParameter EnableExplicitProxy { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Port number for explicit proxy http protocol, cannot be greater than 64000."
        )]
        public int HttpPort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Port number for explicit proxy https protocol, cannot be greater than 64000."
        )]
        public int HttpsPort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Port number for firewall to serve PAC file."
        )]
        public int PacFilePort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "SAS URL for PAC file."
        )]
        public string PacFile { get; set; }


        public override void Execute()
        {
            base.Execute();

            var explicitProxy = new PSAzureFirewallPolicyExplicitProxy
            {
                EnableExplicitProxy = this.EnableExplicitProxy.IsPresent ? true : (bool?)null,
                HttpPort = this.HttpPort,
                HttpsPort = this.HttpsPort,
                PacFilePort = this.PacFilePort,
                PacFile = this.PacFile
            };

            WriteObject(explicitProxy);
        }

    }
}
