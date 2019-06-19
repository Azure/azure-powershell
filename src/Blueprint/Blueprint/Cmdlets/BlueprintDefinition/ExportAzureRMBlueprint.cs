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

using Microsoft.Azure.Commands.Blueprint.Models;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifact", SupportsShouldProcess = true, DefaultParameterSetName =
         ParameterSetNames.ExportBlueprintParameterSet), OutputType(typeof(bool))]
    public class ExportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.ExportBlueprintParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.ExportBlueprintObject)]
        [ValidateNotNullOrEmpty]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportBlueprintParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ExportOutputFile)]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportBlueprintParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionVersion)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportBlueprintParameterSet, Mandatory = false, HelpMessage = ParameterHelpMessages.ForceHelpMessage)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            const string blueprintFileName = "Blueprint";

            // Get serialized blueprint definition
            string serializedDefinition = BlueprintClient.GetBlueprintDefinitionJsonFromObject(Blueprint, Version);

            var resolvedPath = ResolveUserPath(OutputPath);

            var blueprintFolderPath = Path.Combine(resolvedPath, Blueprint.Name);

            // if directory exists, let's ask if we can clean contents of it. If directory doesn't exist, we'll create one.
            this.ConfirmAction(
                this.Force || !AzureSession.Instance.DataStore.DirectoryExists(blueprintFolderPath),
                string.Format(Resources.DeleteBlueprintFolderContentsProcessString, Blueprint.Name),
                Resources.DeleteBlueprintFolderContentsContinueMessage,
                blueprintFolderPath,
                () => CreateFolderIfNotExist(resolvedPath, Blueprint.Name)
            );
            
            var blueprintJsonFilePath = Path.Combine(blueprintFolderPath, $"{blueprintFileName}.json");

            AzureSession.Instance.DataStore.WriteFile(blueprintJsonFilePath, serializedDefinition);
           
            var artifacts = BlueprintClient.ListArtifacts(Blueprint.Scope, Blueprint.Name, Version);

            if (artifacts != null && artifacts.Any())
            {
                // Get serialized artifacts from this blueprint and write them to disk
                var artifactsPath = CreateFolderIfNotExist(blueprintFolderPath, "Artifacts");

                foreach (var artifact in artifacts)
                {
                    string serializedArtifact =
                        BlueprintClient.GetBlueprintArtifactJsonFromObject(Blueprint.Scope, Blueprint.Name, artifact,
                            Version);

                    var artifactFilePath = Path.Combine(artifactsPath, artifact.Name + ".json");

                    AzureSession.Instance.DataStore.WriteFile(artifactFilePath, serializedArtifact);
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
        #endregion
    }
}
