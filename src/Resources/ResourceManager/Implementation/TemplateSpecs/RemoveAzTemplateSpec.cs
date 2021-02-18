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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        VerbsCommon.Remove, 
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = RemoveAzTemplateSpec.RemoveByNameParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]

    public class RemoveAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByNameParameterSet = nameof(RemoveByNameParameterSet);
        internal const string RemoveByIdParameterSet = nameof(RemoveByIdParameterSet);

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Position = 0, 
            ParameterSetName = RemoveByNameParameterSet, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the template spec's resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1, 
            ParameterSetName = RemoveByNameParameterSet, 
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(
            Position = 2, 
            Mandatory = false, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The version of the template spec to delete.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs/versions", "ResourceGroupName", "Name")]
        public string Version { get; set; }

        [Alias("Id")]
        [Parameter(
            Position = 0, 
            ParameterSetName = RemoveByIdParameterSet, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
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
                ResourceIdentifier resourceIdentifier = (ResourceId != null) 
                    ? new ResourceIdentifier(ResourceId)
                    : null;

                ResourceGroupName = ResourceGroupName ?? resourceIdentifier.ResourceGroupName;
                Name = Name ?? ResourceIdUtility.GetResourceName(ResourceId);

                if (ResourceId != null && Version == null)
                {
                    // Check if the resource id includes a version...
                    string resourceType = resourceIdentifier.ResourceType;
                    if (!string.IsNullOrEmpty(resourceType) &&
                        resourceType.Equals("Microsoft.Resources/templateSpecs/versions", StringComparison.OrdinalIgnoreCase))
                    {
                        // It does...
                        Version = resourceIdentifier.ResourceName;
                    }
                }

                string confirmationMessage = (Version != null)
                    ? $"Are you sure you want to remove version '{Version}' of Template Spec '{Name}'"
                    : $"Are you sure you want to remove Template Spec '{Name}'";

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Template Spec...",
                    Version ?? Name,
                    () => TemplateSpecsSdkClient.DeleteTemplateSpec(ResourceGroupName, Name, Version)
                );

                WriteObject(true);
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion Cmdlet Overrides
    }
}
