using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifacts",
         DefaultParameterSetName = BlueprintConstants.ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ImportAzureRmBlueprint : BlueprintCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name for the new blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string BlueprintName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "File path to blueprint and ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string InputPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = this.IsParameterBound(c => c.ManagementGroupId) 
                ? Utils.GetScopeForManagementGroup(ManagementGroupId) 
                : Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);

            var resolvedPath = this.ResolveUserPath(InputPath);
            ImportBlueprint(scope, resolvedPath);
            ImportArtifacts(scope, resolvedPath);

        }

        private void ImportBlueprint(string scope, string resolvedPath)
        {
            DirectoryInfo directory = new DirectoryInfo(resolvedPath);
            FileInfo[] files = directory.GetFiles("*.json");
            var blueprintFileCounter = 0;

            files.ForEach( file => { if (File.Exists(file.FullName)) blueprintFileCounter++; });

            if (blueprintFileCounter > 1)
            {
                // say there is more than one blueprint file detected. Delete some.
                throw new Exception(
                    "Multiple blueprint files detected. Please have only one blueprint file in this location.");
            }

            foreach (var file in files)
            {
                var bpObject = JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(file.FullName),
                    DefaultJsonSettings.DeserializerSettings);

                var blueprintExists = BlueprintClient.GetBlueprint(scope, BlueprintName) != null;

                this.ConfirmAction(
                    Force || !blueprintExists,
                    $"This will overwrite the unpublished changes in the blueprint {BlueprintName} and its artifacts. Would you like to continue?",
                    "Overwriting the unpublished blueprint and artifacts",
                    BlueprintName,
                    () => DeleteBlueprintArtifactsIfExist(scope, BlueprintName)
                );

                BlueprintClient.CreateOrUpdateBlueprint(scope,
                    BlueprintName, bpObject);
            }
        }

        private void ImportArtifacts(string scope, string resolvedPath)
        {
            // if everything is right to start import, do so:
            var artifactsPath = System.IO.Path.Combine(resolvedPath, "Artifacts");
            if (!Directory.Exists(artifactsPath))
            {
                throw new DirectoryNotFoundException("Can't find the Artifacts folder.");
            }

            DirectoryInfo artifactsDirectory = new DirectoryInfo(artifactsPath);
            FileInfo[] artifactsFiles = artifactsDirectory.GetFiles("*.json");
            foreach (var artifactFile in artifactsFiles)
            {
                if (File.Exists(artifactFile.FullName))
                {
                    Artifact artifactObject = null;
                    try
                    {
                        //To-Do: why the artifact name doesn't get deserialized?
                        artifactObject = JsonConvert.DeserializeObject<Artifact>(
                            File.ReadAllText(ResolveUserPath(artifactFile.FullName)),
                            DefaultJsonSettings.DeserializerSettings);
                    }
                    catch
                    {
                        throw new Exception("Can't deserialize the JSON file: " + artifactFile.FullName);
                    }

                    BlueprintClient.CreateArtifact(scope, BlueprintName,
                        System.IO.Path.GetFileNameWithoutExtension(artifactFile.Name), artifactObject);

                }
            }
        }

        private void DeleteBlueprintArtifactsIfExist(string scope, string blueprintName)
        {
            var artifactList = BlueprintClient.ListArtifacts(scope, blueprintName, null);

            artifactList.ForEach(artifact => BlueprintClient.DeleteArtifact(scope, blueprintName, artifact.Name));
        }
    }
}
