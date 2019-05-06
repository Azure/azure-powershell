using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifacts", DefaultParameterSetName =
         BlueprintConstants.ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ExportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        private const string ExportToFileParamSet = "ExportToFile";

        [Parameter(Mandatory = true, HelpMessage = "The Blueprint definition object to export.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ExportToFileParamSet, Mandatory = true, HelpMessage = "Path to a file on disk where to export the Blueprint definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(ParameterSetName = ExportToFileParamSet, Mandatory = false, HelpMessage = "Version of the blueprint.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            // Get serialized blueprint and write it to disk
            string serializedDefinition = BlueprintClient.GetBlueprintDefinitionJsonFromObject(Blueprint, Version);

            var blueprintPath = Path.Combine(OutputPath, Blueprint.Name);
            if (!Directory.Exists(blueprintPath))
            {
               Directory.CreateDirectory(blueprintPath);
            }
         
            var definitionFileFullPath = Path.Combine(blueprintPath, $"{Blueprint.Name}.json");

            this.ConfirmAction(
                this.Force || !File.Exists(definitionFileFullPath),
                "Do you want to overwrite the output file " + $"{Blueprint.Name}.json?",
                "Overwriting the output file.",
                definitionFileFullPath,
                () => File.WriteAllText(definitionFileFullPath, serializedDefinition)
            );

            // Get serialized artifacts from this blueprint and write it to disk
            var artifactsPath = Path.Combine(blueprintPath, "Artifacts");
            if (!Directory.Exists(artifactsPath))
            {
                Directory.CreateDirectory(artifactsPath);
            }
   
            var artifacts = BlueprintClient.ListArtifacts(Blueprint.Scope, Blueprint.Name, Version);
            
            foreach (var artifact in artifacts)
            {
                string serializedArtifact = BlueprintClient.GetBlueprintArtifactJsonFromObject(Blueprint.Scope, Blueprint.Name, artifact, Version);

                var artifactFileFullPath = Path.Combine(artifactsPath, artifact.Name + ".json");

                this.ConfirmAction(
                    this.Force || !File.Exists(artifactFileFullPath),
                    "Do you want to overwrite the output file " + $"{artifact.Name}.json?",
                    "Overwriting the output file.",
                    artifactFileFullPath,
                    () => File.WriteAllText(artifactFileFullPath, serializedArtifact)
                );
            }
        }
    }
}
