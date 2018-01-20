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

    [Cmdlet(VerbsCommon.New, "AzureRmSecureGatewayApplicationRuleCollection", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayApplicationRuleCollection))]
    public class NewAzureSecureGatewayApplicationRuleCollectionCommand : AzureSecureGatewayApplicationRuleCollectionBase
    {
        public override void Execute()
        {
            base.Execute();

            if (this.Rules == null || this.Rules.Count == 0)
            {
                throw new ArgumentException("At least one application rule should be specified!");
            }

            var applicationRc = new PSSecureGatewayApplicationRuleCollection
            {
                Name = this.Name,
                Rules = this.Rules
            };
            WriteObject(applicationRc);
        }
    }
}
