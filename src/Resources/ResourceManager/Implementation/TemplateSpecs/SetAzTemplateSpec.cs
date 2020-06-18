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
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Management.Automation;

using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        VerbsCommon.Set,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = NewAzTemplateSpec.FromJsonStringParameterSet)]
    [OutputType(typeof(PSTemplateSpecSingleVersion))]
    public class SetAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string UpdateByIdParameterSet = nameof(UpdateByIdParameterSet);
        internal const string UpdateByNameParameterSet = nameof(UpdateByNameParameterSet);
        //internal const string UpdateVersionByIdParameterSet = nameof(UpdateVersionByIdParameterSet);
        //internal const string UpdateVersionByNameParameterSet = nameof(UpdateVersionByNameParameterSet);
        internal const string UpdateVersionByIdFromJsonFileParameterSet = nameof(UpdateVersionByIdFromJsonFileParameterSet);
        internal const string UpdateVersionByNameFromJsonFileParameterSet = nameof(UpdateVersionByNameFromJsonFileParameterSet);
        internal const string UpdateVersionByIdFromJsonParameterSet = nameof(UpdateVersionByIdFromJsonParameterSet);
        internal const string UpdateVersionByNameFromJsonParameterSet = nameof(UpdateVersionByNameFromJsonParameterSet);

        [Alias("Id")]
        [Parameter(Position = 0, ParameterSetName = UpdateByIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        //[Parameter(Position = 0, ParameterSetName = UpdateVersionByIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
          //  HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [Parameter(Position = 0, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [Parameter(Position = 0, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/templateSpecs")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        //[Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            //HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        //[Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
          //          HelpMessage = "The name of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        //[Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameParameterSet, Position = 5, ValueFromPipelineByPropertyName = true,
          //          HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 5, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 5, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        //[Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
          //          HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByIdParameterSet,  Position = 2, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
           // HelpMessage = "The description of the template spec.")]
        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
           // HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByIdParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
          //  HelpMessage = "The display name of the template spec.")]
        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
          //  HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 4, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        public string DisplayName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the template spec. Only required if the template spec does not already exist.")]
        [LocationCompleter("Microsoft.Resources/templateSpecs")]
        public string Location { get; set; }


        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 6, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Resource Manager template JSON.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 5, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Resource Manager template JSON.")]
        [ValidateNotNullOrEmpty]
        public string TemplateJson { get; set; }

        [Alias("InputFile")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 6, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file path to the local Azure Resource Manager template JSON file.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 5, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file path to the local Azure Resource Manager template JSON file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateJsonFile { get; set; }

        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameParameterSet, ValueFromPipelineByPropertyName = true,
            //HelpMessage = "The description of the version.")]
        //[Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdParameterSet, ValueFromPipelineByPropertyName = true,
            //HelpMessage = "The description of the version.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the version.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the version.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the version.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the version.")]
        [ValidateNotNullOrEmpty]
        public string VersionDescription { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                if (Version != null)
                {
                    // This is a version specific update...

                    PackagedTemplate packagedTemplate;

                    switch (ParameterSetName)
                    {
                        case UpdateVersionByIdFromJsonFileParameterSet:
                        case UpdateVersionByNameFromJsonFileParameterSet:
                            string filePath = this.TryResolvePath(TemplateJsonFile);
                            if (!File.Exists(filePath))
                            {
                                throw new PSInvalidOperationException(
                                    string.Format(ProjectResources.InvalidFilePath, TemplateJsonFile)
                                );
                            }

                            packagedTemplate = TemplateSpecPackagingEngine.Pack(filePath);
                            break;
                        case UpdateVersionByIdFromJsonParameterSet:
                        case UpdateVersionByNameFromJsonParameterSet:
                            // When we're provided with a raw JSON string for the template we don't
                            // do any special packaging... (ie: we don't pack artifacts because there
                            // is no well known root path):

                            packagedTemplate = new PackagedTemplate
                            {
                                RootTemplate = JObject.Parse(TemplateJson),
                                Artifacts = new TemplateSpecArtifact[0]
                            };
                            break;
                        default:
                            throw new PSNotSupportedException();
                    }

                    var templateSpecVersion = TemplateSpecsSdkClient.CreateOrUpdateTemplateSpecVersion(
                        ResourceGroupName ?? ResourceIdUtility.GetResourceGroupName(this.ResourceId),
                        Name ?? ResourceIdUtility.GetResourceName(this.ResourceId),
                        Version,
                        Location,
                        packagedTemplate,
                        templateSpecDescription: Description,
                        templateSpecDisplayName: DisplayName,
                        versionDescription: VersionDescription
                    );

                    WriteObject(templateSpecVersion);
                }
                else
                {
                    // This is an update to the root template spec only:

                    var templateSpec = TemplateSpecsSdkClient.CreateOrUpdateTemplateSpec(
                            ResourceGroupName ?? ResourceIdUtility.GetResourceGroupName(this.ResourceId),
                            Name ?? ResourceIdUtility.GetResourceName(this.ResourceId),
                            Location,
                            templateSpecDescription: Description,
                            templateSpecDisplayName: DisplayName
                        );

                    WriteObject(templateSpec);
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
