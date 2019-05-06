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
using System.Management.Automation;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifacts", DefaultParameterSetName =
         ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ExportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true, HelpMessage = "The Blueprint definition object to export.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportToFileParameterSet, Mandatory = true, HelpMessage = "Path to a file on disk where to export the Blueprint definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportToFileParameterSet, Mandatory = false, HelpMessage = "Version of the blueprint.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ExportToFileParameterSet, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            // Get serialized blueprint and write it to disk
            string serializedDefinition = BlueprintClient.GetBlueprintDefinitionJsonFromObject(Blueprint, Version);

            var blueprintFolderPath = CreateFolderIfNotExist(OutputPath, Blueprint.Name);
            var blueprintJsonFilePath = Path.Combine(blueprintFolderPath, $"{Blueprint.Name}.json");

            this.ConfirmAction(
                this.Force || !File.Exists(blueprintJsonFilePath),
                "Do you want to overwrite the output file " + $"{Blueprint.Name}.json?",
                "Overwriting the output file.",
                blueprintJsonFilePath,
                () => File.WriteAllText(blueprintJsonFilePath, serializedDefinition)
            );

            // Get serialized artifacts from this blueprint and write it to disk
            var artifactsPath = CreateFolderIfNotExist(OutputPath, "Artifacts");

            var artifacts = BlueprintClient.ListArtifacts(Blueprint.Scope, Blueprint.Name, Version);
            
            foreach (var artifact in artifacts)
            {
                string serializedArtifact = BlueprintClient.GetBlueprintArtifactJsonFromObject(Blueprint.Scope, Blueprint.Name, artifact, Version);

                var artifactFilePath = Path.Combine(artifactsPath, artifact.Name + ".json");

                this.ConfirmAction(
                    this.Force || !File.Exists(artifactFilePath),
                    "Do you want to overwrite the output file " + $"{artifact.Name}.json?",
                    "Overwriting the output file.",
                    artifactFilePath,
                    () => File.WriteAllText(artifactFilePath, serializedArtifact)
                );
            }
        }
        #endregion
    }
}
