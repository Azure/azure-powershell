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

using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintDefinitionCmdletBase : BlueprintCmdletBase
    {
        /// <summary>
        /// Get management group ancestors for a given subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        protected List<string> GetManagementGroupAncestorsForSubscription(string subscriptionId)
        {
            List<string> managementGroupAncestors = new List<string>();

            if (subscriptionId != null)
            {
                string result = GetManagementGroupAncestorsAsync(subscriptionId).GetAwaiter().GetResult();
                var resultJObjects = JObject.Parse(result);
                var managementGroupAncestorsObjects = resultJObjects["managementGroupAncestors"].Children().ToList();

                foreach (var mgObject in managementGroupAncestorsObjects)
                {
                    managementGroupAncestors.Add(mgObject.ToString());
                }
            }
            return managementGroupAncestors;
        }

        /// <summary>
        /// Task for get management group ancestors
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        private async Task<string> GetManagementGroupAncestorsAsync(string subscriptionId)
        {
            var url = string.Format(BlueprintConstants.MgAncestorsRequestUrlTemplate, subscriptionId);
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);

            HttpResponseMessage httpResponse = null;
            string responseContent = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    await ClientCredentials.ProcessHttpRequestAsync(httpRequest, new CancellationToken(false)).ConfigureAwait(false);
                    httpResponse = await client.SendAsync(httpRequest, new CancellationToken(false));

                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    // If we can't find the given subscription in the tenant, show error message.
                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        CloudException cex = new CloudException(string.Format("Subscription Id '{0}' could not be found in current tenant.", subscriptionId));
                        throw cex;
                    }

                    responseContent = httpResponse.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                }
                return responseContent;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        protected string FormatManagementGroupAncestorScope(string mg) => string.Format(BlueprintConstants.ManagementGroupScope, mg);

        protected void ImportBlueprint(string blueprintName, string scope, string inputPath, bool force)
        {
            var blueprintPath = GetValidatedFilePath(inputPath, blueprintName);

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
                force || !BlueprintExists(scope, blueprintName),
                $"This will overwrite any unpublished changes in the blueprint {blueprintName} and its artifacts. Would you like to continue?",
                "Overwriting the unpublished blueprint and artifacts",
                blueprintName,
                () => DeleteBlueprintArtifactsIfExist(scope, blueprintName)
            );

            BlueprintClient.CreateOrUpdateBlueprint(scope, blueprintName, bpObject);
        }

        protected bool BlueprintExists(string scope, string blueprintName)
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

        /// <summary>
        /// Expects a string that consist of full file path with file extension and check if it exists.
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        protected string GetValidatedFilePath(string fileFullName)
        {
            // To-Do: work with relative paths?
            var filePath = ResolveUserPath(fileFullName);
            if (filePath == null || !new FileInfo(filePath).Exists)
            {
                throw new FileNotFoundException(string.Format("Cannot find path: " + fileFullName));
            }

            return filePath;
        }

        /// <summary>
        ///  This overloaded function expects a folder path and a file name and combines them. Checks if resulting full file name exist.
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected string GetValidatedFilePath(string path, string fileName)
        {
            var resolvedPath = ResolveUserPath(path);

            var blueprintPath = Path.Combine(resolvedPath, fileName + ".json");

            if (!File.Exists(blueprintPath))
            {
                throw new Exception(
                    $"Cannot locate a file with the name {fileName} in: {resolvedPath}.");
            }

            return blueprintPath;
        }

        /// <summary>
        /// Combines input folder path and folder name and check if the resulting path exists.
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        protected string GetValidatedFolderPath(string path, string folderName)
        {
            var resolvedPath = ResolveUserPath(path);

            var artifactsPath = Path.Combine(resolvedPath, folderName);

            if (!Directory.Exists(artifactsPath))
            {
                throw new DirectoryNotFoundException($"Can't find folder {folderName} in path {resolvedPath}.");
            }

            return artifactsPath;
        }

        protected string CreateFolderIfNotExist(string path, string folderName)
        {
            var folderPath = Path.Combine(path, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }


        protected void ImportArtifacts(string blueprintName, string scope, string inputPath)
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
                BlueprintClient.CreateArtifact(scope, blueprintName, Path.GetFileNameWithoutExtension(artifactFile.Name), artifactObject);
            }
        }

        private void DeleteBlueprintArtifactsIfExist(string scope, string blueprintName)
        {
            // If blueprint doesn't exists, return
            if (!BlueprintExists(scope, blueprintName)) return;

            var artifactList = BlueprintClient.ListArtifacts(scope, blueprintName, null);

            artifactList.ForEach(artifact => BlueprintClient.DeleteArtifact(scope, blueprintName, artifact.Name));
        }


        protected BlueprintModel CreateBlueprint(string filePath)
        {
            // To-Do: In good case the JSON file will be deserialized, though it might throw 
            return JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(filePath),
                DefaultJsonSettings.DeserializerSettings);
        }


        // To-Do: Update exception messages
        protected void ThrowIfBlueprintExits(string scope, string name)
        {
            PSBlueprint blueprint = null;

            try
            {
                blueprint = BlueprintClient.GetBlueprint(scope, name);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (blueprint != null)
            {
                throw new Exception(string.Format(Resources.BlueprintExists, name, scope));
            }
        }

        protected void ThrowIfBlueprintNotExist(string scope, string name)
        {
            PSBlueprint blueprint = null;

            try
            {
                blueprint = BlueprintClient.GetBlueprint(scope, name);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (blueprint == null)
            {
                throw new Exception(string.Format(Resources.BlueprintNotExist, name, scope));
            }
        }
    }
}
