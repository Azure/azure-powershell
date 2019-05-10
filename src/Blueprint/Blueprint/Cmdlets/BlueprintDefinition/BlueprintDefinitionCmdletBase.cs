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
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintDefinitionCmdletBase : BlueprintCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionName)]
        [ValidatePattern("^[0-9a-zA-Z_-]*$", Options = RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionScope, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionAndName,Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndVersion, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [Parameter(ParameterSetName = ParameterSetNames.BySubscriptionNameAndLatestPublished, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ImportBlueprintParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ManagementGroupScope, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupAndName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndVersion, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroupNameAndLatestPublished, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.DefinitionManagementGroupId)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ImportInputPath)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ImportInputPath)]
        [ValidateNotNullOrEmpty]
        public string BlueprintFile { get; set; }
        #endregion


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
                throw new Exception(string.Format(Resources.CantDeserializeJson, blueprintPath, ex.Message));
            }

            this.ConfirmAction(
                force || !BlueprintExists(scope, blueprintName),
                string.Format(Resources.OverwriteUnpublishedChangesProcessMessage, blueprintName),
                Resources.OverwriteUnpublishedChangesContinueMessage,
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
                    // if the exception is due to some other error, halt the execution and let the user know.
                    throw new Exception(string.Format(Resources.UnexpectedErrorWhileCheckingIfBlueprintExists, ex.Message));
                }
            }

            return blueprint != null;
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
                    throw new Exception(string.Format(Resources.CantDeserializeJson, artifactFile.FullName, ex.Message));
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
            // To-Do: In good case the JSON file will be deserialized, though it might throw. Then we'll relay that to the user.
            return JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(filePath),
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
