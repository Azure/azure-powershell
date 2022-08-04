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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyExplicitProxy", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyExplicitProxy))]
    public class NewAzureFirewallPolicyExplicitProxyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Explicit Proxy. By default it is disabled.")]
        public SwitchParameter EnableExplicitProxy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Port number for explicit proxy http protocol.")]
        public int? HttpPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Port number for explicit proxy https protocol.")]
        public int? HttpsPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable PAC File. By default it is disabled.")]
        public SwitchParameter EnablePacFile { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Port number for firewall to serve PAC file.")]
        public int? PacFilePort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "SAS URL for PAC file.")]
        public string PacFile { get; set; }

        public override void Execute()
        {
            base.Execute();

            var explicitProxySetting = new PSAzureFirewallPolicyExplicitProxy
            {
                EnableExplicitProxy = this.EnableExplicitProxy.IsPresent ? true : (bool?)null,
                HttpPort = this.HttpPort,
                HttpsPort = this.HttpsPort,
                EnablePacFile = this.EnablePacFile.IsPresent ? true : (bool?)null,
                PacFilePort = this.PacFilePort,
                PacFile = this.PacFile
            };
            WriteObject(explicitProxySetting);
        }
    }
}
