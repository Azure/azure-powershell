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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewaySslPolicy", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewaySslPolicyCommand : AzureApplicationGatewaySslPolicyBase
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
                if (ApplicationGateway.AutoscaleConfiguration == null)
                {
                    throw new ArgumentException("SslPolicy does not exist");
                }

                if (this.DisabledSslProtocols != null)
                {
                    ApplicationGateway.SslPolicy.DisabledSslProtocols = new List<string>();
                    foreach (var protocol in this.DisabledSslProtocols)
                    {
                        ApplicationGateway.SslPolicy.DisabledSslProtocols.Add(protocol);
                    }
                }

                if (!string.IsNullOrEmpty(this.PolicyType))
                {
                    ApplicationGateway.SslPolicy.PolicyType = this.PolicyType;
                }

                if (!string.IsNullOrEmpty(this.PolicyName))
                {
                    ApplicationGateway.SslPolicy.PolicyName = this.PolicyName;
                }

                if (!string.IsNullOrEmpty(this.MinProtocolVersion))
                {
                    ApplicationGateway.SslPolicy.MinProtocolVersion = this.MinProtocolVersion;
                }

                if (this.CipherSuite != null)
                {
                    ApplicationGateway.SslPolicy.CipherSuites = new List<string>();
                    foreach (var ciphersuite in this.CipherSuite)
                    {
                        ApplicationGateway.SslPolicy.CipherSuites.Add(ciphersuite);
                    }
                }

                WriteObject(this.ApplicationGateway);
            }
        }
    }
}
