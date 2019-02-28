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

namespace Microsoft.Azure.Commands.MixedReality.SpatialAnchorsAccount
{
    using Management.MixedReality;
    using ResourceManager.Common;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + ResourceType + "Key", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSSpatialAnchorsAccountKeys))]
    public sealed class GetSpatialAnchorsAccountKeys : SpatialAnchorsAccountCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "Spatial Anchors Account Name.")]
        [ResourceNameCompleter(FullQualifiedResourceType, nameof(ResourceGroupName))]
        [Alias("SpatialAnchorsAccountName", "AccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of Spatial Anchors Account.")]
        [ResourceIdCompleter(FullQualifiedResourceType)]
        [Alias("Id")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PipelineParameterSet, ValueFromPipeline = true, HelpMessage = "The custom domain object.")]
        [ValidateNotNull]
        public PSSpatialAnchorsAccount InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceId = new ResourceId(ResourceId);

                ResourceGroupName = resourceId.ResourceGroupName;
                Name = resourceId.SpatialAnchorsAccountName;
            }

            if (ParameterSetName == PipelineParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
            }

            var result = Client.SpatialAnchorsAccounts.GetKeys(ResourceGroupName, Name);

            WriteObject(result);
        }
    }
}
