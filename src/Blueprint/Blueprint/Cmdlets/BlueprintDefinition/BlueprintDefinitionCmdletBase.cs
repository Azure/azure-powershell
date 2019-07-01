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
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

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

        protected string FormatManagementGroupAncestorScope(string mg) => string.Format(BlueprintConstants.ManagementGroupScope, mg);

        protected void ImportBlueprint(string blueprintName, string scope, string inputPath, bool force)
        {
            const string blueprintFileName = "Blueprint";
            var blueprintPath = GetValidatedFilePath(inputPath, blueprintFileName);

            BlueprintModel bpObject;
            try
            {
                bpObject = JsonConvert.DeserializeObject<BlueprintModel>(AzureSession.Instance.DataStore.ReadFileAsText(blueprintPath),
                    DefaultJsonSettings.DeserializerSettings);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.CantDeserializeJson, blueprintPath, ex.Message));
            }

            this.ConfirmAction(
                force || !BlueprintExists(scope, blueprintName),
                string.Format(Resources.OverwriteUnpublishedChangesProcessMessage, blueprintName, blueprintName),
                Resources.OverwriteUnpublishedChangesContinueMessage,
                blueprintName,
                () => CreateUpdateBlueprintWithArtifacts(scope, blueprintName, bpObject)
            );
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
                    // if the exception is due to some other error, halt the execution and let the user know.
                    throw new Exception(string.Format(Resources.UnexpectedErrorWhileCheckingIfBlueprintExists, ex.Message));
                }
            }

            return blueprint != null;
        }

        protected string CreateFolderIfNotExist(string path, string folderName)
        {
            var folderPath = Path.Combine(path, folderName);

            if (AzureSession.Instance.DataStore.DirectoryExists(folderPath))
            {
                AzureSession.Instance.DataStore.EmptyDirectory(folderPath);

                if (AzureSession.Instance.DataStore.DirectoryExists(Path.Combine(folderPath, "Artifacts")))
                {
                    AzureSession.Instance.DataStore.DeleteDirectory(Path.Combine(folderPath, "Artifacts"));
                }
            }
            else
            { 
                AzureSession.Instance.DataStore.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        protected void ImportArtifacts(string blueprintName, string scope, string inputPath)
        {
            const string artifacts = "Artifacts";

            var artifactsPath = GetValidatedFolderPath(inputPath, artifacts);

            if (artifactsPath == null)
            {
                return; // if blueprint doesn't contain artifacts don't proceed.
            }

            var artifactFiles = AzureSession.Instance.DataStore.GetFiles(artifactsPath, "*.json", SearchOption.TopDirectoryOnly);

            foreach (var artifactFile in artifactFiles)
            {
                Artifact artifactObject;

                try
                {
                    artifactObject = JsonConvert.DeserializeObject<Artifact>(
                        AzureSession.Instance.DataStore.ReadFileAsText(ResolveUserPath(artifactFile)),
                        DefaultJsonSettings.DeserializerSettings);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(Resources.CantDeserializeJson, artifactFile, ex.Message));
                }

                // Artifact name comes from the file name
                BlueprintClient.CreateArtifact(scope, blueprintName, Path.GetFileNameWithoutExtension(artifactFile), artifactObject);
            }
        }

        private void CreateUpdateBlueprintWithArtifacts(string scope, string blueprintName, BlueprintModel bpObject)
        {
            if (BlueprintExists(scope, blueprintName))
            {
                var artifactList = BlueprintClient.ListArtifacts(scope, blueprintName, null);

                artifactList.ForEach(artifact => BlueprintClient.DeleteArtifact(scope, blueprintName, artifact.Name));
            }

            BlueprintClient.CreateOrUpdateBlueprint(scope, blueprintName, bpObject);
        }


        protected BlueprintModel CreateBlueprint(string filePath)
        {
            // To-Do: In good case the JSON file will be deserialized, though it might throw. Then we'll relay that to the user.
            return JsonConvert.DeserializeObject<BlueprintModel>(AzureSession.Instance.DataStore.ReadFileAsText(filePath),
                DefaultJsonSettings.DeserializerSettings);
        }

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
