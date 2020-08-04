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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        VerbsCommon.Get,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = GetAzTemplateSpec.ListTemplateSpecsParameterSet)]
    [OutputType(typeof(PSTemplateSpec))]
    public class GetAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ListTemplateSpecsParameterSet = nameof(ListTemplateSpecsParameterSet);
        internal const string GetTemplateSpecByNameParameterSet = nameof(GetTemplateSpecByNameParameterSet);
        internal const string GetTemplateSpecByIdParameterSet = nameof(GetTemplateSpecByIdParameterSet);

        [Parameter(Position = 0, ParameterSetName = ListTemplateSpecsParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [Parameter(Position = 0, ParameterSetName = GetTemplateSpecByNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetTemplateSpecByNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetTemplateSpecByNameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The version of the template spec.")]
        [Parameter(Position = 1, ParameterSetName = GetTemplateSpecByIdParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The version of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs/versions", "ResourceGroupName", "Name")]
        public string Version { get; set; }

        [Alias("Id")]
        [Parameter(Position = 0, ParameterSetName = GetTemplateSpecByIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/templateSpecs")]
        public string ResourceId { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetTemplateSpecByNameParameterSet:
                        WriteObject(
                            TemplateSpecsSdkClient.GetTemplateSpec(Name, ResourceGroupName, Version)
                        );
                        break;
                    case GetTemplateSpecByIdParameterSet:
                        WriteObject(
                            TemplateSpecsSdkClient.GetTemplateSpec(
                                ResourceIdUtility.GetResourceName(this.ResourceId),
                                ResourceIdUtility.GetResourceGroupName(this.ResourceId),
                                Version
                            )
                        );
                        break;
                    case ListTemplateSpecsParameterSet:
                        var templateSpecs = !string.IsNullOrEmpty(ResourceGroupName)
                            ? TemplateSpecsSdkClient.ListTemplateSpecsByResourceGroup(ResourceGroupName)
                            : TemplateSpecsSdkClient.ListTemplateSpecsBySubscription();

                        var templateSpecListItems = templateSpecs
                            .Select(ts => PSTemplateSpecListItem.FromTemplateSpec(ts))
                            .GroupBy(ts=>ts.Id).Select(g=>g.First()) // Required due to current backend bug returning duplicates
                            .OrderBy(ts=>ts.ResourceGroupName)
                            .ThenBy(ts=>ts.Name)
                            .Distinct()
                            .ToList();

                        WriteObject(templateSpecListItems);
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
