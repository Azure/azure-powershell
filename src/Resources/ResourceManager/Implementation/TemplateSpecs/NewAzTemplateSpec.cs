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
        VerbsCommon.New,
        AzureRMConstants.AzureRMPrefix + "TemplateSpec",
        DefaultParameterSetName = NewAzTemplateSpec.FromJsonStringParameterSet)]
    [OutputType(typeof(PSTemplateSpecSingleVersion))]
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
            HelpMessage = "The file path to the local Azure Resource Manager template JSON file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateJsonFile { get; set; }

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
                        string filePath = this.TryResolvePath(TemplateJsonFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateJsonFile)
                            );
                        }

                        packagedTemplate = TemplateSpecPackagingEngine.Pack(filePath);
                        break;
                    case FromJsonStringParameterSet:
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
                    ResourceGroupName,
                    Name,
                    Version,
                    Location,
                    packagedTemplate,
                    templateSpecDescription: Description,
                    templateSpecDisplayName: DisplayName
                );

                WriteObject(templateSpecVersion);
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion Cmdlet Overrides
    }
}
