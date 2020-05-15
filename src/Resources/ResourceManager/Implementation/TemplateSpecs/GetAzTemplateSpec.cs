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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        VerbsCommon.Get,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = GetAzTemplateSpec.ListTemplateSpec)]
    [OutputType(typeof(PSTemplateSpec))]
    public class GetAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ListTemplateSpec = "ListTemplateSpec";
        internal const string GetTemplateSpecByName = "GetTemplateSpecByName";
        internal const string GetTemplateSpecById = "GetTemplateSpecById";

        [Parameter(Position = 0, ParameterSetName = ListTemplateSpec, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [Parameter(Position = 0, ParameterSetName = GetTemplateSpecByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetTemplateSpecByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetTemplateSpecByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The version of the template spec.")]
        [Parameter(Position = 1, ParameterSetName = GetTemplateSpecById, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The version of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs/versions", "ResourceGroupName", "Name")]
        public string Version { get; set; }

        [Alias("ResourceId")]
        [Parameter(Position = 0, ParameterSetName = GetTemplateSpecById, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/templateSpecs")]
        public string Id { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetTemplateSpecByName:
                        WriteObject(
                            TemplateSpecsSdkClient.GetTemplateSpec(Name, ResourceGroupName, Version)
                        );
                        break;
                    case GetTemplateSpecById:
                        WriteObject(
                            TemplateSpecsSdkClient.GetTemplateSpec(
                                ResourceIdUtility.GetResourceName(this.Id),
                                ResourceIdUtility.GetResourceGroupName(this.Id),
                                Version
                            )
                        );
                        break;
                    case ListTemplateSpec:
                        WriteObject(!string.IsNullOrEmpty(ResourceGroupName)
                            ? TemplateSpecsSdkClient.ListTemplateSpecsByResourceGroup(ResourceGroupName)
                            : TemplateSpecsSdkClient.ListTemplateSpecsBySubscription());
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion Cmdlet Overrides
    }
}
