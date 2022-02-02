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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.IO;
using System.Management.Automation;

using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(
        VerbsCommon.Set,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = NewAzTemplateSpec.FromJsonStringParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSTemplateSpec))]
    public class SetAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string UpdateByIdParameterSet = nameof(UpdateByIdParameterSet);
        internal const string UpdateByNameParameterSet = nameof(UpdateByNameParameterSet);
        internal const string UpdateVersionByIdFromJsonFileParameterSet = nameof(UpdateVersionByIdFromJsonFileParameterSet);
        internal const string UpdateVersionByNameFromJsonFileParameterSet = nameof(UpdateVersionByNameFromJsonFileParameterSet);
        internal const string UpdateVersionByIdFromJsonParameterSet = nameof(UpdateVersionByIdFromJsonParameterSet);
        internal const string UpdateVersionByNameFromJsonParameterSet = nameof(UpdateVersionByNameFromJsonParameterSet);

        [Alias("Id")]
        [Parameter(Position = 0, ParameterSetName = UpdateByIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [Parameter(Position = 0, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [Parameter(Position = 0, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the template spec. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/templateSpecs")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The version of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByIdParameterSet,  Position = 1, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByIdParameterSet, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The display name of the template spec.")]
        public string DisplayName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the template spec. Only required if the template spec does not already exist.")]
        [LocationCompleter("Microsoft.Resources/templateSpecs")]
        public string Location { get; set; }

        [Alias("Tags")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Hashtable of tags for the template spec and/or version")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Resource Manager template JSON.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Resource Manager template JSON.")]
        [ValidateNotNullOrEmpty]
        public string TemplateJson { get; set; }

        [Alias("InputFile")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByNameFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file path to the local Azure Resource Manager template JSON/Bicep file.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateVersionByIdFromJsonFileParameterSet, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file path to the local Azure Resource Manager template JSON/Bicep file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

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


        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "UIForm for the templatespec resource")]
        public string UIFormDefinitionFile { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "UIForm for the templatespec resource")]
        public string UIFormDefinitionString { get; set; }
        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                // TODO: Update the following to use ??= when we upgrade to C# 8.0
                if (ResourceGroupName == null)
                {
                    ResourceGroupName = ResourceIdUtility.GetResourceGroupName(this.ResourceId);
                }

                if (Name == null)
                {
                    Name = ResourceIdUtility.GetResourceName(this.ResourceId);
                }

                if (Version != null)
                {
                    // This is a version specific update...

                    PackagedTemplate packagedTemplate;

                    switch (ParameterSetName)
                    {
                        case UpdateVersionByIdFromJsonFileParameterSet:
                        case UpdateVersionByNameFromJsonFileParameterSet:
                            string filePath = this.TryResolvePath(TemplateFile);
                            if (!File.Exists(filePath))
                            {
                                throw new PSInvalidOperationException(
                                    string.Format(ProjectResources.InvalidFilePath, TemplateFile)
                                );
                            }
                            if (BicepUtility.IsBicepFile(TemplateFile))
                            {
                                filePath = BicepUtility.BuildFile(this.ResolvePath(TemplateFile), this.WriteVerbose, this.WriteWarning);
                            }

                            // Note: We set uiFormDefinitionFilePath to null below because we process the UIFormDefinition
                            // specified by the cmdlet parameters later within this method...
                            packagedTemplate = TemplateSpecPackagingEngine.Pack(filePath, uiFormDefinitionFilePath: null);
                            break;
                        case UpdateVersionByIdFromJsonParameterSet:
                        case UpdateVersionByNameFromJsonParameterSet:
                            JObject parsedTemplate;
                            try
                            {
                                parsedTemplate = JObject.Parse(TemplateJson);
                            }
                            catch
                            {
                                // Check if the user may have inadvertantly passed a file path using "-TemplateJson"
                                // instead of using "-TemplateFile". If they did, display a warning message. Note we
                                // do not currently automatically switch to using a file in this case because if the 
                                // JSON string is coming from an external script/source not authored directly by the
                                // caller it could result in a sensitive template being PUT unintentionally:

                                try
                                {
                                    string asFilePath = this.TryResolvePath(TemplateJson);
                                    if (File.Exists(asFilePath))
                                    {
                                        WriteWarning(
                                            $"'{TemplateJson}' was found to exist as a file. Did you mean to use '-TemplateFile' instead?"
                                        );
                                    }
                                }
                                catch
                                {
                                    // Subsequent failure in the file existence check... Ignore it
                                }

                                throw;
                            }

                            // When we're provided with a raw JSON string for the template we don't
                            // do any special packaging... (ie: we don't pack artifacts because there
                            // is no well known root path):

                            packagedTemplate = new PackagedTemplate
                            {
                                RootTemplate = JObject.Parse(TemplateJson),
                                Artifacts = new LinkedTemplateArtifact[0]
                            };
                            break;
                        default:
                            throw new PSNotSupportedException();
                    }

                    if (!ShouldProcess($"{Name}/versions/{Version}", "Create or Update"))
                    {
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(UIFormDefinitionFile))
                    {
                        string UIFormFilePath = this.TryResolvePath(UIFormDefinitionFile);
                        if (!File.Exists(UIFormFilePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, UIFormDefinitionFile)
                            );
                        }
                        string UIFormJson = FileUtilities.DataStore.ReadFileAsText(UIFormDefinitionFile);
                        packagedTemplate.UIFormDefinition = JObject.Parse(UIFormJson);
                    }
                    else if (!string.IsNullOrWhiteSpace(UIFormDefinitionString))
                    {
                        packagedTemplate.UIFormDefinition = JObject.Parse(UIFormDefinitionString);
                    }

                    var templateSpecVersion = TemplateSpecsSdkClient.CreateOrUpdateTemplateSpecVersion(
                        ResourceGroupName,
                        Name,
                        Version,
                        Location,
                        packagedTemplate,
                        templateSpecDescription: Description,
                        templateSpecDisplayName: DisplayName,
                        versionDescription: VersionDescription,
                        templateSpecTags: Tag, // Note: Only applied if template spec doesn't exist
                        versionTags: Tag
                    );

                    WriteObject(templateSpecVersion);
                }
                else
                {
                    // This is an update to the root template spec only:

                    if (!ShouldProcess(Name, "Create or Update"))
                    {
                        return;
                    }

                    var templateSpec = TemplateSpecsSdkClient.CreateOrUpdateTemplateSpec(
                            ResourceGroupName,
                            Name,
                            Location,
                            templateSpecDescription: Description,
                            templateSpecDisplayName: DisplayName,
                            tags: Tag
                        );

                    // As the root template spec is a seperate resource type, it won't contain version 
                    // details. To provide more information to the user, let's get the template spec
                    // with all of its version details:

                    var templateSpecWithVersions = 
                        TemplateSpecsSdkClient.GetTemplateSpec(templateSpec.Name, templateSpec.ResourceGroupName);

                    WriteObject(templateSpecWithVersions);
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
