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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnDeliveryRule"), OutputType(typeof(PSDeliveryRule))]
    public class NewAzCdnDeliveryRule : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Name of the rule")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Order of the rule")]
        public int Order { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "A list of conditions that must be matched for the actions to be executed.")]
        public PSDeliveryRuleCondition[] Condition { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "A list of actions that are executed when all the conditions of a rule are satisfied.")]
        [ValidateNotNullOrEmpty]
        public PSDeliveryRuleAction[] Action { get; set; }

        public override void ExecuteCmdlet()
        {
            var deliveryRule = new PSDeliveryRule
            {
                Name = Name,
                Order = Order,
                Conditions = Condition,
                Actions = Action
            };

            WriteObject(deliveryRule);
        }
    }
}
