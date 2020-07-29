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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MasterCustomIpPrefixTags", SupportsShouldProcess = true), OutputType(typeof(PSMasterCustomIpPrefix))]
    public class UpdateAzureMasterCustomIpPrefixTagsCommand : MasterCustomIpPrefixBaseCmdlet
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = UpdateByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/masterCustomIpPrefix", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = UpdateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The MasterCustomIpPrefix to set.",
            ParameterSetName = UpdateByInputObjectParameterSet)]
        public PSMasterCustomIpPrefix InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id.",
            ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = UpdateByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.Name = resourceInfo.ResourceName;
            }
            else if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.Name = InputObject.Name;
            }

            PSMasterCustomIpPrefix psModel;
            if (this.IsParameterBound(c => c.InputObject))
            {
                psModel = InputObject;
            }
            else
            {
                var existingPsModel = GetMasterCustomIpPrefix(this.ResourceGroupName, this.Name);

                psModel = new PSMasterCustomIpPrefix()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = existingPsModel.Location,
                };
            }
            var sdkModel = NetworkResourceManagerProfile.Mapper.Map<MNM.MasterCustomIpPrefix>(psModel);

            if (this.IsParameterBound(c => c.InputObject))
            {
                sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.IsParameterBound(c => c.Tag) ? this.Tag : InputObject.Tag, validate: true);
            }
            else
            {
                sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            }

            if (this.ShouldProcess($"Name: {this.Name} ResourceGroup: {this.ResourceGroupName}", "Set existing MasterCustomIpPrefix"))
            {
                // Execute the PUT MasterCustomIpPrefix Policy call
                TagsObject tagsObj = new TagsObject(sdkModel.Tags);
                var modifiedSdkModel = this.MasterCustomIpPrefixClient.UpdateTags(this.ResourceGroupName, this.Name, tagsObj);
                var modifiedPsModel = this.ToPsMasterCustomIpPrefix(modifiedSdkModel);
                modifiedPsModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(modifiedPsModel.Id);
                WriteObject(modifiedPsModel);
            }
        }
    }
}
