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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpoint", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSVirtualNetwork))]
    [Alias("Get-AzInterfaceEndpoint")]
    public class GetAzurePrivateEndpointCommand : PrivateEndpointBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/privateEndpoints", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var pe = this.GetPrivateEndpoint(this.ResourceGroupName, this.Name, this.ExpandResource);
                WriteObject(pe);
            }
            else
            {
                IPage<PrivateEndpoint> pePage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    pePage = this.PrivateEndpointClient.List(this.ResourceGroupName);
                }
                else
                {
                    pePage = this.PrivateEndpointClient.ListBySubscription();
                }

                var peList = ListNextLink<PrivateEndpoint>.GetAllResourcesByPollingNextLink(pePage, this.PrivateEndpointClient.ListNext);
                var psPEs = new List<PSPrivateEndpoint>();
                foreach (var pe in peList)
                {
                    var psPE = this.ToPsPrivateEndpoint(pe);
                    psPE.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(pe.Id);
                    psPEs.Add(psPE);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psPEs), true);
            }

        }
    }
}
