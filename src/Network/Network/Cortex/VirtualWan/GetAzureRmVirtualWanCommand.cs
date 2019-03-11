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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWan",
        DefaultParameterSetName = "ListBySubscriptionId"),
        OutputType(typeof(PSVirtualWan))]
    public class GetAzureRmVirtualWanCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var virtualWan = this.GetVirtualWan(this.ResourceGroupName, this.Name);
                WriteObject(virtualWan);
            }
            else
            {
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, this.ListVirtualWans(this.ResourceGroupName)), true);
            }
        }
    }
}
