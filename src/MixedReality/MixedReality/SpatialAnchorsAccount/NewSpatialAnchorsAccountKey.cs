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

    [Cmdlet("New", AzureRMConstants.AzureRMPrefix + ResourceType + "Key", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSpatialAnchorsAccountKeys))]
    public sealed class NewSpatialAnchorsAccountKey : SpatialAnchorsAccountCmdletBase
    {
        public const string RegeneratePrimaryKeyParameterSetName = "RegeneratePrimaryKeyParameterSet";
        public const string RegenerateSecondaryKeyParameterSetName = "RegenerateSecondaryKeyParameterSet";

        public const string ResourceIdParameterSetPrefix = "ResourceId";
        public const string PipelineParameterSetPrefix = "Pipeline";

        public const string ResourceGroupNameHelpMessage = "Resource Group Name.";
        public const string NameHelpMessage = "Spatial Anchors Account Name.";
        public const string ResourceIdHelpMessage = "Resource ID of Spatial Anchors Account.";
        public const string InputObjectHelpMessage = "The custom domain object.";
        public const string PrimarySwitchHelpMessage = "Regenerate primary key of Spatial Anchors Account.";
        public const string SecondarySwitchHelpMessage = "Regenerate secondary key of Spatial Anchors Account.";

        [Parameter(Mandatory = true, ParameterSetName = RegeneratePrimaryKeyParameterSetName, HelpMessage = ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = RegenerateSecondaryKeyParameterSetName, HelpMessage = ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegeneratePrimaryKeyParameterSetName, HelpMessage = NameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = RegenerateSecondaryKeyParameterSetName, HelpMessage = NameHelpMessage)]
        [ResourceNameCompleter(FullQualifiedResourceType, nameof(ResourceGroupName))]
        [Alias("SpatialAnchorsAccountName", "AccountName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSetPrefix + RegeneratePrimaryKeyParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSetPrefix + RegenerateSecondaryKeyParameterSetName, ValueFromPipelineByPropertyName = true, HelpMessage = ResourceIdHelpMessage)]
        [ResourceIdCompleter(FullQualifiedResourceType)]
        [Alias("Id")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PipelineParameterSetPrefix + RegeneratePrimaryKeyParameterSetName, ValueFromPipeline = true, HelpMessage = InputObjectHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = PipelineParameterSetPrefix + RegenerateSecondaryKeyParameterSetName, ValueFromPipeline = true, HelpMessage = InputObjectHelpMessage)]
        [ValidateNotNull]
        public PSSpatialAnchorsAccount InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegeneratePrimaryKeyParameterSetName, HelpMessage = PrimarySwitchHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSetPrefix + RegeneratePrimaryKeyParameterSetName, HelpMessage = PrimarySwitchHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = PipelineParameterSetPrefix + RegeneratePrimaryKeyParameterSetName, HelpMessage = PrimarySwitchHelpMessage)]
        public SwitchParameter Primary { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegenerateSecondaryKeyParameterSetName, HelpMessage = SecondarySwitchHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSetPrefix + RegenerateSecondaryKeyParameterSetName, HelpMessage = SecondarySwitchHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = PipelineParameterSetPrefix + RegenerateSecondaryKeyParameterSetName, HelpMessage = SecondarySwitchHelpMessage)]
        public SwitchParameter Secondary { get; set; }

        [Parameter()]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.StartsWith(ResourceIdParameterSetPrefix))
            {
                var resourceId = new ResourceId(ResourceId);

                ResourceGroupName = resourceId.ResourceGroupName;
                Name = resourceId.SpatialAnchorsAccountName;
            }

            if (ParameterSetName.StartsWith(PipelineParameterSetPrefix))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
            }
            
            var serial = default(int?);
            var key = default(string);

            if (Primary.IsPresent)
            {
                serial = 1;
                key = "primary";
            }
            else if (Secondary.IsPresent)
            {
                serial = 2;
                key = "secondary";
            }

            ConfirmAction(
                Force,
                $"Are you sure you want to regenerate {key} key of Spatial Anchors Account '{Name}' in resource group '{ResourceGroupName}' ?",
                this.MyInvocation.InvocationName,
                Name, 
                () => 
                {
                    var result = Client.SpatialAnchorsAccounts.RegenerateKeys(ResourceGroupName, Name, serial);

                    WriteObject(result);
                });
        }
    }
}
