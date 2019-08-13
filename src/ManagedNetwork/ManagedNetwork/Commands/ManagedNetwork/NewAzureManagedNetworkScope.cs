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
using Microsoft.Azure.Commands.ManagedNetwork.Common;
using Microsoft.Azure.Commands.ManagedNetwork.Helpers;
using Microsoft.Azure.Management.ManagedNetwork;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ManagedNetwork.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ManagedNetwork.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedNetworkScope", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSScope))]
    public class NewAzManagedNetworkScope : AzureManagedNetworkCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope management group ids.")]
        public List<string> ManagementGroupIds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope subscription ids.")]
        public List<string> SubscriptionIds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope virtual network ids.")]
        public List<string> VirtualNetworkIds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope subnet ids.")]
        public List<string> SubnetIds { get; set; }

        public override void ExecuteCmdlet()
        {
            PSScope scope = new PSScope();

           if(this.ManagementGroupIds != null)
           {
                scope.ManagementGroups = this.ManagementGroupIds.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.SubscriptionIds != null)
           {
                scope.Subscriptions = this.SubscriptionIds.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.VirtualNetworkIds != null)
           {
                scope.VirtualNetworks = this.VirtualNetworkIds.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.SubscriptionIds != null)
           {
                scope.Subnets = this.SubnetIds.Select(id => new PSResourceId() { Id = id }).ToList();
           }

            WriteObject(scope);
        }
    }
}
