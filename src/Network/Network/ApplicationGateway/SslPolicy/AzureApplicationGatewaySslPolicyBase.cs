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
    public class AzureApplicationGatewaySslPolicyBase : NetworkBaseCmdlet
    {
        [Parameter(
               HelpMessage = "List of SSL protocols to be disabled")]
        [ValidateSet("TLSv1_0", "TLSv1_1", "TLSv1_2", "TLSv1_3", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string[] DisabledSslProtocols { get; set; }

        [Parameter(
               HelpMessage = "Type of Ssl Policy")]
        [ValidateSet("Predefined", "Custom", "CustomV2", IgnoreCase = true)]
        public string PolicyType { get; set; }

        [Parameter(
               HelpMessage = "Name of Ssl predefined policy")]
        public string PolicyName { get; set; }

        [Parameter(
               HelpMessage = "Ssl cipher suites to be enabled in the specified order to application gateway")]
        public string[] CipherSuite { get; set; }

        [Parameter(
               HelpMessage = "Minimum version of Ssl protocol to be supported on application gateway")]
        [ValidateSet("TLSv1_0", "TLSv1_1", "TLSv1_2", "TLSv1_3", IgnoreCase = true)]
        public string MinProtocolVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        public PSApplicationGatewaySslPolicy NewObject()
        {
            var policy = new PSApplicationGatewaySslPolicy();
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
            if (this.CipherSuite != null)
            {
                policy.CipherSuites = new List<string>();
                foreach (var ciphersuite in this.CipherSuite)
                {
                    policy.CipherSuites.Add(ciphersuite);
                }
            }

            return policy;
        }
    }
}
