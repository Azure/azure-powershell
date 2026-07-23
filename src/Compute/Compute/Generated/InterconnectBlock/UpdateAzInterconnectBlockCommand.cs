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

using System.Collections;
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
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectBlock", DefaultParameterSetName = "DefaultParameterSet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSInterconnectBlock))]
    public class UpdateAzureInterconnectBlock : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PSInterconnectBlock object to update.")]
        public PSInterconnectBlock InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The new SKU capacity (number of VM instances). Must be a multiple of 18.")]
        public long SkuCapacity { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SKU name. This property is immutable after create and will be ignored by the service on update. Included for pipeline compatibility.")]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SKU tier. This property is immutable after create and will be ignored by the service on update.")]
        public string SkuTier { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string name;

                switch (this.ParameterSetName)
                {
                    case InputObjectParameterSet:
                        resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                        name = this.InputObject.Name;
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        name = this.Name;
                        break;
                }

                if (ShouldProcess(name, VerbsData.Update))
                {
                    var updateParams = new InterconnectBlockUpdate();

                    if (this.IsParameterBound(c => c.Tag))
                    {
                        updateParams.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }

                    if (this.IsParameterBound(c => c.SkuCapacity) ||
                        this.IsParameterBound(c => c.SkuName) ||
                        this.IsParameterBound(c => c.SkuTier))
                    {
                        updateParams.Sku = new Sku();
                        if (this.IsParameterBound(c => c.SkuCapacity))
                        {
                            updateParams.Sku.Capacity = this.SkuCapacity;
                        }
                        if (this.IsParameterBound(c => c.SkuName))
                        {
                            updateParams.Sku.Name = this.SkuName;
                        }
                        if (this.IsParameterBound(c => c.SkuTier))
                        {
                            updateParams.Sku.Tier = this.SkuTier;
                        }
                    }

                    var result = InterconnectBlocksClient.Update(resourceGroupName, name, updateParams);
                    var psObject = new PSInterconnectBlock();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<InterconnectBlock, PSInterconnectBlock>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
