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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectBlock", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSInterconnectBlock))]
    public class GetAzureInterconnectBlock : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";

        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The expand expression to apply. 'instanceView' retrieves runtime properties of the Interconnect Block.")]
        public string Expand { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string name = this.Name;

                if (ShouldGetByName(resourceGroupName, name))
                {
                    // Exact, non-wildcard RG + Name → single GET
                    var result = this.IsParameterBound(c => c.Expand)
                        ? InterconnectBlocksClient.Get(resourceGroupName, name, this.Expand)
                        : InterconnectBlocksClient.Get(resourceGroupName, name);
                    var psObject = new PSInterconnectBlock();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlock>(result, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, name))
                {
                    // Exact RG, Name absent or wildcard → list by RG then wildcard-filter
                    var list = InterconnectBlocksClient.ListByResourceGroup(resourceGroupName);
                    var psObjects = new List<PSInterconnectBlockList>();
                    foreach (var item in list)
                    {
                        psObjects.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlockList>(item));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, name, psObjects), true);
                }
                else
                {
                    // No RG (or wildcard RG) → list by subscription then wildcard-filter
                    var list = InterconnectBlocksClient.ListBySubscription();
                    var psObjects = new List<PSInterconnectBlockList>();
                    foreach (var item in list)
                    {
                        psObjects.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlockList>(item));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, name, psObjects), true);
                }
            });
        }
    }
}
