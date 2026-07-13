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

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectBlock", DefaultParameterSetName = "DefaultParameterSet")]
    [OutputType(typeof(PSInterconnectBlock))]
    public class GetAzureInterconnectBlock : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string ByResourceGroupParameterSet = "ByResourceGroupParameterSet";
        private const string ByNameParameterSet = "ByNameParameterSet";

        [Parameter(
            Mandatory = false,
            ParameterSetName = ByResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The expand expression to apply. 'instanceView' retrieves runtime properties of the Interconnect Block.")]
        public string Expand { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (this.IsParameterBound(c => c.Name))
                {
                    // Get single block
                    var result = this.IsParameterBound(c => c.Expand)
                        ? InterconnectBlocksClient.Get(this.ResourceGroupName, this.Name, this.Expand)
                        : InterconnectBlocksClient.Get(this.ResourceGroupName, this.Name);
                    var psObject = new PSInterconnectBlock();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlock>(result, psObject);
                    WriteObject(psObject);
                }
                else if (this.IsParameterBound(c => c.ResourceGroupName))
                {
                    // List by resource group
                    var list = InterconnectBlocksClient.ListByResourceGroup(this.ResourceGroupName);
                    var psObjects = new List<PSInterconnectBlockList>();
                    foreach (var item in list)
                    {
                        psObjects.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlockList>(item));
                    }
                    WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psObjects), true);
                }
                else
                {
                    // List by subscription
                    var list = InterconnectBlocksClient.ListBySubscription();
                    var psObjects = new List<PSInterconnectBlockList>();
                    foreach (var item in list)
                    {
                        psObjects.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlockList>(item));
                    }
                    WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psObjects), true);
                }
            });
        }
    }
}
