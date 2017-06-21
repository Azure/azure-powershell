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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmApplicationGatewaySslPolicy", SupportsShouldProcess = true), 
        OutputType(typeof(PSApplicationGateway))]
    public class SetAzureApplicationGatewaySslPolicyCommand : AzureApplicationGatewaySslPolicyBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess("AzureApplicationGatewaySslPolicy", Microsoft.Azure.Commands.Network.Properties.Resources.CreatingResourceMessage))
            {
                base.ExecuteCmdlet();

                PSApplicationGatewaySslPolicy policy = new PSApplicationGatewaySslPolicy();
                if (this.DisabledSslProtocols != null)
                {
                    policy.DisabledSslProtocols = new List<string>();
                    foreach (var protocol in this.DisabledSslProtocols)
                    {
                        policy.DisabledSslProtocols.Add(protocol);
                    }
                }

                policy.PolicyType = this.PolicyType;
                policy.PolicyName = this.PolicyName;
                policy.MinProtocolVersion = this.MinProtocolVersion;
                if (this.CipherSuites != null)
                {
                    policy.CipherSuites = new List<string>();
                    foreach (var ciphersuite in this.CipherSuites)
                    {
                        policy.CipherSuites.Add(ciphersuite);
                    }
                }

                this.ApplicationGateway.SslPolicy = policy;
                WriteObject(this.ApplicationGateway);
            }
        }
    }
}
