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
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmSecureGatewayApplicationRule", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayApplicationRule))]
    public class NewAzureSecureGatewayApplicationRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Application Rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The priority of the rule")]
        [ValidateNotNullOrEmpty]
        public uint Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public List<PSSecureGatewayApplicationRuleProtocol> Protocols { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The target URLs of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> TargetUrls { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The actions of the rule")]
        [ValidateNotNullOrEmpty]
        public List<PSSecureGatewayApplicationRuleAction> Actions { get; set; }

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
                Direction = MNM.SecureGatewayRuleDirection.Outbound,
                Protocols = this.Protocols,
                TargetUrls = this.TargetUrls,
                Actions = this.Actions
            };
            WriteObject(applicationRule);
        }
    }
}
