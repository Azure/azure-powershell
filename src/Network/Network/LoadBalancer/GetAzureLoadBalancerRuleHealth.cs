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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerRuleHealth", DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSLoadBalancerHealthPerRule))]
    public partial class GetAzureLoadBalancerRuleHealth : NetworkBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";

        [Parameter(
        Mandatory = true,
        HelpMessage = "The resource group name of the load balancer.",
        ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
        HelpMessage = "The name of the load balancer.",
        ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(Mandatory = true,
        HelpMessage = "The name of the load balancing rule.",
        ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            var getHealth = this.NetworkClient.NetworkManagementClient.LoadBalancerLoadBalancingRules.Health(this.ResourceGroupName, this.LoadBalancerName, this.Name);
            var psHealth = NetworkResourceManagerProfile.Mapper.Map<PSLoadBalancerHealthPerRule>(getHealth);
            WriteObject(psHealth, true);
        }
    }
}
