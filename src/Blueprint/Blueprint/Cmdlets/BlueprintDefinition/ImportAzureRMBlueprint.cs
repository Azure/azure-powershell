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
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope for the blueprint ", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);

            if (this.IsParameterBound(c => c.ManagementGroupId))
            {
                scope = Utils.GetScopeForManagementGroup(ManagementGroupId);}


            var resolvedPath = this.ResolveUserPath(Path);
            var blueprintPath = System.IO.Path.Combine(resolvedPath, "Blueprint");
            if (!Directory.Exists(blueprintPath))
            {
                throw new DirectoryNotFoundException("Can't find Blueprint directory.");
            }

            DirectoryInfo directory = new DirectoryInfo(blueprintPath);
            FileInfo[] files = directory.GetFiles("*.json");
            int blueprintFileCounter = 0;
        
            foreach (var file in files)
            {
                if (File.Exists(file.FullName))
                {
                    blueprintFileCounter++;
                }
            }

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

                BlueprintClient.CreateOrUpdateBlueprint(scope,
                    BlueprintName, bpObject);
            }


            // if everything is right to start import do so:
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
    }
}
