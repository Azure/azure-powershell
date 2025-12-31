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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkAppliance", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSVirtualNetworkAppliance))]
    public class GetVirtualNetworkApplianceCommand : VirtualNetworkApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkAppliances", "ResourceGroupName")]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id.",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.Name = GetResourceName(this.ResourceId, "Microsoft.Network/virtualNetworkAppliances");
            }

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                var vna = this.GetVirtualNetworkAppliance(this.ResourceGroupName, this.Name);
                WriteObject(vna);
            }
            else
            {
                IPage<VirtualNetworkAppliance> vnaPage;
                if (ShouldListByResourceGroup(this.ResourceGroupName, this.Name))
                {
                    vnaPage = this.VirtualNetworkAppliancesClient.List(this.ResourceGroupName);
                }
                else
                {
                    vnaPage = this.VirtualNetworkAppliancesClient.ListAll();
                }

                // Get all resources by polling on next page link
                var vnaList = ListNextLink<VirtualNetworkAppliance>.GetAllResourcesByPollingNextLink(vnaPage, this.VirtualNetworkAppliancesClient.ListNext);

                var psVnas = new List<PSVirtualNetworkAppliance>();

                foreach (var vna in vnaList)
                {
                    var psVna = this.ToPsVirtualNetworkAppliance(vna);
                    psVna.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vna.Id);
                    psVnas.Add(psVna);
                }

                WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psVnas), true);
            }
        }
    }
}
