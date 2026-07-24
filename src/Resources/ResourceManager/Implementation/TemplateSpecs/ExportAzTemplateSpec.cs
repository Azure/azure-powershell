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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        "Export",
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = ExportAzTemplateSpec.ExportByNameParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSObject))]

    public class ExportAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ExportByNameParameterSet = nameof(ExportByNameParameterSet);
        internal const string ExportByIdParameterSet = nameof(ExportByIdParameterSet);
        
        [Parameter(
            Position = 0,
            ParameterSetName = ExportByNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the template spec's resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = ExportByNameParameterSet,
            Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs", "ResourceGroupName")]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(
            Position = 0,
            ParameterSetName = ExportByIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/templateSpecs")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the template spec to export.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Resources/templateSpecs/versions", "ResourceGroupName", "Name")]
        public string Version { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The path to the folder where the template spec version will be output to.")]
        [ValidateNotNullOrEmpty]
        public string OutputFolder { get; set; }

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

                // Get the template spec version model from the SDK:
                TemplateSpecVersion specificVersion = 
                    TemplateSpecsSdkClient.TemplateSpecsClient.TemplateSpecVersions.Get(
                        ResourceGroupName,
                        Name,
                        Version
                    );

                // Get the parent template spec from the SDK. We do this because we want to retrieve the
                // template spec name with its proper casing for naming our main template output file (the 
                // Name parameter may have mismatched casing):
                TemplateSpec parentTemplateSpec =
                    TemplateSpecsSdkClient.TemplateSpecsClient.TemplateSpecs.Get(ResourceGroupName, Name);

                PackagedTemplate packagedTemplate = new PackagedTemplate(specificVersion);

                // TODO: Handle overwriting prompts...

                // Ensure our output path is resolved based on the current powershell working
                // directory instead of the current process directory:
                OutputFolder = ResolveUserPath(OutputFolder);

                string mainTemplateFileName = $"{parentTemplateSpec.Name}.{specificVersion.Name}.json";
                string uiFormDefinitionFileName = $"{parentTemplateSpec.Name}.{specificVersion.Name}.uiformdefinition.json";
                string fullRootTemplateFilePath = Path.GetFullPath(
                    Path.Combine(OutputFolder, mainTemplateFileName)
                );

                if (ShouldProcess(specificVersion.Id, $"Export to '{fullRootTemplateFilePath}'"))
                {
                    TemplateSpecPackagingEngine.Unpack(
                        packagedTemplate, OutputFolder, mainTemplateFileName, uiFormDefinitionFileName);
                }

                WriteObject(PowerShellUtilities.ConstructPSObject(null, "Path", fullRootTemplateFilePath));
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion Cmdlet Overrides
    }
}
