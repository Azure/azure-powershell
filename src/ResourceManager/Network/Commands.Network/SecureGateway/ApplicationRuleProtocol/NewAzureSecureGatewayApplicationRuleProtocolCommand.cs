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
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmSecureGatewayApplicationRuleProtocol", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayApplicationRuleProtocol))]
    public class NewAzureSecureGatewayApplicationRuleProtocolCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The type of the protocol")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.SecureGatewayApplicationRuleProtocolType.Http,
            MNM.SecureGatewayApplicationRuleProtocolType.Https,
            IgnoreCase = true)]
        public string ProtocolType { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            var ruleProtocol = new PSSecureGatewayApplicationRuleProtocol
            {
                ProtocolType = this.ProtocolType,
                Port = this.ProtocolType == MNM.SecureGatewayApplicationRuleProtocolType.Http ? 80U : 443U
            };
            WriteObject(ruleProtocol);
        }
    }
}
