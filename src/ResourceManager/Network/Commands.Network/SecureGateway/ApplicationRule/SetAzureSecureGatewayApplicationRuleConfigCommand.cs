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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    using System.Linq;

    [Cmdlet(VerbsCommon.Set, "AzureRmSecureGatewayApplicationRuleConfig"), OutputType(typeof(PSSecureGatewayApplicationRuleCollection))]
    public class SetAzureSecureGatewayApplicationRuleConfigCommand : AzureSecureGatewayApplicationRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecureGatewayApplicationRuleCollection")]
        public PSSecureGatewayApplicationRuleCollection SecureGatewayApplicationRuleCollection { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.Protocols == null || this.Protocols.Count == 0)
            {
                throw new ArgumentException("At least one application rule protocol should be specified!");
            }
            if (this.TargetUrls == null || this.TargetUrls.Count == 0)
            {
                throw new ArgumentException("At least one application rule target URL should be specified!");
            }
            if (this.Actions == null || this.Actions.Count == 0)
            {
                throw new ArgumentException("At least one application rule action should be specified!");
            }

            // Verify if the applicationRule exists in the SecureGateway
            var applicationRule = this.SecureGatewayApplicationRuleCollection.Rules.SingleOrDefault(rule => string.Equals(rule.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (applicationRule == null)
            {
                throw new ArgumentException("Application rule with the specified name does not exist");
            }

            applicationRule.Name = this.Name;
            applicationRule.Priority = this.Priority;
            applicationRule.Description = this.Description;
            applicationRule.Direction = this.Direction;
            applicationRule.Protocols = this.Protocols;
            applicationRule.TargetUrls = this.TargetUrls;
            applicationRule.Actions = this.Actions;
            WriteObject(this.SecureGatewayApplicationRuleCollection);
        }
    }
}
