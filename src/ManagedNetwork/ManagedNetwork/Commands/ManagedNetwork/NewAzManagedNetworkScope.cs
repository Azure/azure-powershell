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
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ManagedNetwork.Models;

namespace Microsoft.Azure.Commands.ManagedNetwork
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedNetworkScope", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSScope))]
    public class NewAzManagedNetworkScope : AzureManagedNetworkCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope management group ids.")]
        public List<string> ManagementGroupIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope subscription ids.")]
        public List<string> SubscriptionIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope virtual network ids.")]
        public List<string> VirtualNetworkIdList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure ManagedNetwork Scope subnet ids.")]
        public List<string> SubnetIdList { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSScope scope = new PSScope();

           if(this.ManagementGroupIdList != null)
           {
                scope.ManagementGroups = this.ManagementGroupIdList.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.SubscriptionIdList != null)
           {
                scope.Subscriptions = this.SubscriptionIdList.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.VirtualNetworkIdList != null)
           {
                scope.VirtualNetworks = this.VirtualNetworkIdList.Select(id => new PSResourceId() { Id = id }).ToList();
           }

           if (this.SubnetIdList != null)
           {
                scope.Subnets = this.SubnetIdList.Select(id => new PSResourceId() { Id = id }).ToList();
           }

            WriteObject(scope);
        }
    }
}
