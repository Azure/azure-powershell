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
        VerbsCommon.New,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = NewAzTemplateSpec.FromJsonStringParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSTemplateSpec))]
    public class NewAzTemplateSpec : TemplateSpecCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string FromJsonStringParameterSet = nameof(FromJsonStringParameterSet);
        internal const string FromJsonFileParameterSet = nameof(FromJsonFileParameterSet);

        [Parameter(
            Position = 0,
            ParameterSetName = FromJsonStringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [Parameter(
            Position = 0,
            ParameterSetName = FromJsonFileParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = FromJsonStringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the template spec.")]
        [Parameter(
            Position = 1,
            ParameterSetName = FromJsonFileParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the template spec.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the template spec.")]
        public string Description { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
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
            HelpMessage = "Hashtable of tags for the new template spec resource(s).")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = FromJsonStringParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Resource Manager template JSON.")]
        [ValidateNotNullOrEmpty]
        public string TemplateJson { get; set; }

        [Alias("InputFile")]
        [Parameter(
            ParameterSetName = FromJsonFileParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The file path to the local Azure Resource Manager template JSON/Bicep file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the version.")]
        public string VersionDescription { get; set; }

        [Parameter(Mandatory = false, 
            HelpMessage = "Do not ask for confirmation when overwriting an existing version.")]
        public SwitchParameter Force { get; set; }


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
                PackagedTemplate packagedTemplate;

                switch (ParameterSetName)
                {
                    case FromJsonFileParameterSet:
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
                    case FromJsonStringParameterSet:

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
                            RootTemplate = parsedTemplate,
                            Artifacts = new LinkedTemplateArtifact[0]
                        };
                        break;
                    default:
                        throw new PSNotSupportedException();
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
                else if (!string.IsNullOrEmpty(UIFormDefinitionString))
                {
                    packagedTemplate.UIFormDefinition = JObject.Parse(UIFormDefinitionString);
                }


                Action createOrUpdateAction = () =>
                {
                    var templateSpecVersion = TemplateSpecsSdkClient.CreateOrUpdateTemplateSpecVersion(
                        ResourceGroupName,
                        Name,
                        Version,
                        Location,
                        packagedTemplate,
                        templateSpecDescription: Description,
                        templateSpecDisplayName: DisplayName,
                        versionDescription: VersionDescription,
                        templateSpecTags:Tag, // Note: Only applied if template spec doesn't exist
                        versionTags: Tag
                    );

                    WriteObject(templateSpecVersion);
                };

                if (!Force.IsPresent && TemplateSpecsSdkClient.GetAzureSdkTemplateSpecVersion(
                        ResourceGroupName,
                        Name,
                        Version,
                        throwIfNotExists: false) != null)
                {
                    // The template spec version already exists and force is not present, so 
                    // let's confirm with the user that he/she wishes to overwrite (update) it:

                    string confirmationMessage =
                        $"Template Spec version '{Version}' already exists and this action will overwrite existing " +
                        "data for this version. Are you sure you'd like to overwrite existing " +
                        $"Template Spec version data for Template Spec '{Name}' version '{Version}'?";

                    ConfirmAction(
                        Force.IsPresent,
                        confirmationMessage,
                        "Update",
                        $"{Name}/versions/{Version}",
                        createOrUpdateAction
                    );
                }
                else
                {
                    if (!ShouldProcess($"{Name}/versions/{Version}", "Create"))
                    {
                        return; // Don't perform the actual creation/update action
                    }

                    createOrUpdateAction();
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
