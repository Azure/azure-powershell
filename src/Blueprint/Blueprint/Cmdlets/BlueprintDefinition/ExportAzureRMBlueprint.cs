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
    public class ExportAzureRmBlueprint : BlueprintCmdletBase
    {
        private const string ExportToFileParamSet = "ExportToFile";
        private const string ExportToStringParamSet = "ExportToJSON";

        [Parameter(Mandatory = true, HelpMessage = "The Blueprint definition object to export.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSBlueprintBase Blueprint { get; set; }

        /*[Parameter(ParameterSetName = ExportToFileParamSet, Mandatory = true, HelpMessage = "Path to a file on disk where to export the Blueprint definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }*/

        [Parameter(ParameterSetName = ExportToFileParamSet, Mandatory = false, HelpMessage = "Version of the blueprint.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            // Get blueprint, serialize it and write it to disk
            string serializedDefinition = BlueprintClient.GetBlueprintDefinitionJsonFromObject(Blueprint, Version);

            var currentPath = this.SessionState.Path.CurrentFileSystemLocation.Path;
            var definitionFileFullPath = Path.Combine(currentPath, Blueprint.Name + " - Copy.json");

            this.ConfirmAction(
                this.Force || !File.Exists(definitionFileFullPath),
                "Want to overwriting the output file?",
                "Overwriting the output file",
                definitionFileFullPath,
                () => File.WriteAllText(definitionFileFullPath, serializedDefinition)
            );

            // Get artifacts from this blueprint, serialize it and write it to disk

            var artifacts = BlueprintClient.ListArtifacts(Blueprint.Scope, Blueprint.Name, Version);

            foreach (var artifact in artifacts)
            {
                string serializedArtifact = BlueprintClient.GetBlueprintArtifactJsonFromObject(Blueprint.Scope, Blueprint.Name, artifact.Name, Version);

                var artifactFileFullPath = Path.Combine(currentPath, artifact.Name + " - Copy.json");

                this.ConfirmAction(
                    this.Force || !File.Exists(artifactFileFullPath),
                    "Want to overwriting the output file?",
                    "Overwriting the output file",
                    artifactFileFullPath,
                    () => File.WriteAllText(artifactFileFullPath, serializedArtifact)
                );
            }

        }
    }
}
