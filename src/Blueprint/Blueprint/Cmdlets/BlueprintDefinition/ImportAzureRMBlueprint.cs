using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintWithArtifacts",
         DefaultParameterSetName = BlueprintConstants.ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ImportAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the blueprint to import. ", ValueFromPipeline = true)]
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
          
            ImportBlueprint(scope, InputPath);
            ImportArtifacts(scope, InputPath);
        }

        private void ImportBlueprint(string scope, string InputPath)
        {
            var blueprintPath = GetValidatedFilePath(InputPath, BlueprintName);

            BlueprintModel bpObject;
            try
            {
                bpObject = JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(blueprintPath),
                    DefaultJsonSettings.DeserializerSettings);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't deserialize the JSON file: " + blueprintPath + ". " + ex.Message);
            }
           
            this.ConfirmAction(
                Force || !BlueprintExists(scope, BlueprintName),
                $"This will overwrite any unpublished changes in the blueprint {BlueprintName} and its artifacts. Would you like to continue?",
                "Overwriting the unpublished blueprint and artifacts",
                BlueprintName,
                () => DeleteBlueprintArtifactsIfExist(scope, BlueprintName)
            );

            BlueprintClient.CreateOrUpdateBlueprint(scope, BlueprintName, bpObject);
        }

        private bool BlueprintExists(string scope, string blueprintName)
        {
            PSBlueprintBase blueprint = null;
            try
            {
                blueprint = BlueprintClient.GetBlueprint(scope, blueprintName);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                   // Blueprint doesn't exists. Ignore the exception and continue.
                }
                else
                {
                    // if the exception is due to some other error, halt and let the user know.
                    throw new Exception("An unexpected error occured while checking if blueprint already exists. Try again in a few minutes." + ex.Message);
                }
            }

            return blueprint != null;
        }

        private string GetValidatedFilePath(string inputPath, string fileName)
        {
            var resolvedPath = ResolveUserPath(inputPath);

            var blueprintPath = Path.Combine(resolvedPath, fileName + ".json");

            if (!File.Exists(blueprintPath))
            {
                throw new Exception(
                    $"Cannot locate a file with the name {fileName} in: {resolvedPath}.");
            }

            return blueprintPath;
        }

        private string GetValidatedFolderPath(string inputPath, string folderName)
        {
            var resolvedPath = ResolveUserPath(inputPath);

            var artifactsPath = Path.Combine(resolvedPath, folderName);

            if (!Directory.Exists(artifactsPath))
            {
                throw new DirectoryNotFoundException($"Can't find folder {folderName} in path {resolvedPath}.");
            }

            return artifactsPath;
        }

        private void ImportArtifacts(string scope, string inputPath)
        {
            // if everything is right, start import:
            const string artifacts = "Artifacts";

            var artifactsPath = GetValidatedFolderPath(inputPath, artifacts);

            DirectoryInfo artifactsDirectory = new DirectoryInfo(artifactsPath);
            FileInfo[] artifactsFiles = artifactsDirectory.GetFiles("*.json");

            foreach (var artifactFile in artifactsFiles)
            {
                Artifact artifactObject;

                try
                {
                    artifactObject = JsonConvert.DeserializeObject<Artifact>(
                        File.ReadAllText(ResolveUserPath(artifactFile.FullName)),
                        DefaultJsonSettings.DeserializerSettings);
                }
                catch (Exception ex)
                {
                    throw new Exception("Can't deserialize the JSON file: " + artifactFile.FullName + ". " + ex.Message);
                }

                // Artifact name comes from the file name
                BlueprintClient.CreateArtifact(scope, BlueprintName, Path.GetFileNameWithoutExtension(artifactFile.Name), artifactObject);
            }
        }

        private void DeleteBlueprintArtifactsIfExist(string scope, string blueprintName)
        {
            // If blueprint doesn't exists, return
            if (!BlueprintExists(scope, blueprintName)) return;

            var artifactList = BlueprintClient.ListArtifacts(scope, blueprintName, null);

            artifactList.ForEach(artifact => BlueprintClient.DeleteArtifact(scope, blueprintName, artifact.Name));
        }
    }
}
