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
    using System;

    [Cmdlet(VerbsCommon.New, "AzureRmSecureGatewayApplicationRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayApplicationRule))]
    public class NewAzureSecureGatewayApplicationRuleConfigCommand : AzureSecureGatewayApplicationRuleConfigBase
    {
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

            var applicationRule = new PSSecureGatewayApplicationRule
            {
                Name = this.Name,
                Priority = this.Priority,
                Description = this.Description,
                Direction = this.Direction,
                Protocols = this.Protocols,
                TargetUrls = this.TargetUrls,
                Actions = this.Actions
            };
            WriteObject(applicationRule);
        }
    }
}
