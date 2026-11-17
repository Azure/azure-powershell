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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayAdvancedRoutingConditionSet"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayAdvancedRoutingConditionSetCommand : AzureApplicationGatewayAdvancedRoutingConditionSetBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ApplicationGateway.AdvancedRoutingConditionSets == null)
            {
                this.ApplicationGateway.AdvancedRoutingConditionSets = new List<PSApplicationGatewayAdvancedRoutingConditionSet>();
            }

            var conditionSet = this.ApplicationGateway.AdvancedRoutingConditionSets.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (conditionSet != null)
            {
                throw new ArgumentException("AdvancedRoutingConditionSet with the specified name already exists");
            }

            conditionSet = base.NewObject();
            this.ApplicationGateway.AdvancedRoutingConditionSets.Add(conditionSet);
            WriteObject(this.ApplicationGateway);
        }
    }
}
