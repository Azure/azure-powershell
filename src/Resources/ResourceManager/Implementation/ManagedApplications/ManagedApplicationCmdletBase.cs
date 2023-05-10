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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Newtonsoft.Json.Linq;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using System;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.IO;
    using Microsoft.WindowsAzure.Commands.Common;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Application;
    using Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Operations;

    /// <summary>
    /// Base class for policy assignment cmdlets.
    /// </summary>
    public abstract class ManagedApplicationCmdletBase : ResourceManagerCmdletBaseWithApiVersion
    {
        /// <summary>
        /// Gets the next set of resources using the <paramref name="nextLink"/>
        /// </summary>
        /// <param name="nextLink">The next link.</param>
        protected Task<ResponseWithContinuation<TType[]>> GetNextLink<TType>(string nextLink)
        {
            return this
                .GetResourcesClient()
                .ListNextBatch<TType>(nextLink: nextLink, cancellationToken: this.CancellationToken.Value);
        }

        /// <summary>
        /// Converts the resource object to specified resource type object.
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="resources">The policy definition resource object.</param>
        protected PSObject[] GetOutputObjects(string resourceType, params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource =>
                {
                    var psobject = resource.ToResource().ToPsObject();
                    psobject.Properties.Add(new PSNoteProperty(resourceType, psobject.Properties["ResourceId"].Value));
                    return psobject;
                });
        }

        /// <summary>
        /// Gets a resource.
        /// </summary>
        protected async Task<JObject> GetExistingResource(string resourceId, string apiVersion)
        {
            return await this
                .GetResourcesClient()
                .GetResource<JObject>(
                    resourceId: resourceId,
                    apiVersion: apiVersion,
                    cancellationToken: this.CancellationToken.Value)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Gets the authorization object
        /// </summary>
        protected JToken GetAuthorizationObject(string[] authorizations)
        {
            List<ApplicationProviderAuthorization> lstAuth = new List<ApplicationProviderAuthorization>();
            if (authorizations != null)
            {
                foreach (string s in authorizations)
                {
                    string[] auth = s.Split(':');
                    if (auth != null)
                    {
                        lstAuth.Add(new ApplicationProviderAuthorization
                        {
                            PrincipalId = auth[0],
                            RoleDefinitionId = auth[1]
                        });
                    }
                }
            }
            return lstAuth.ToJToken();
        }

        /// <summary>
        /// Gets the JToken object from parameter
        /// </summary>
        protected JToken GetObjectFromParameter(string parameter)
        {
            Uri outUri = null;
            if (Uri.TryCreate(parameter, UriKind.Absolute, out outUri))
            {
                if (outUri.Scheme == Uri.UriSchemeFile)
                {
                    string filePath = this.TryResolvePath(parameter);
                    if (File.Exists(filePath))
                    {
                        return JToken.FromObject(FileUtilities.DataStore.ReadFileAsText(filePath));
                    }
                    else
                    {
                        throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidFilePath, parameter));
                    }
                }
                else if (outUri.Scheme != Uri.UriSchemeHttp && outUri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new PSInvalidOperationException(ProjectResources.InvalidUriScheme);
                }
                else if (!Uri.IsWellFormedUriString(outUri.AbsoluteUri, UriKind.Absolute))
                {
                    throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidUriString, parameter));
                }
                else
                {
                    string contents = GeneralUtilities.DownloadFile(outUri.AbsoluteUri);
                    if (string.IsNullOrEmpty(contents))
                    {
                        throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidUriContent, parameter));
                    }
                    return JToken.FromObject(contents);
                }
            }

            //for non absolute file paths
            string path = this.TryResolvePath(parameter);

            return File.Exists(path)
                ? JToken.FromObject(FileUtilities.DataStore.ReadFileAsText(path))
                : JToken.FromObject(parameter);
        }

        /// <summary>
        /// Processes and outputs the result of the operation.
        /// </summary>
        protected void ProcessResult(string result, string resourceId, string apiVersion)
        {
            if (result.TryConvertTo<AzureAsyncOperationResource>(out var operationResource) && operationResource != null)
            {
                if (String.Equals(operationResource.Status, "Succeeded", StringComparison.OrdinalIgnoreCase))
                {
                    var getResult = this.GetResourcesClient()
                        .GetResource<JObject>(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            cancellationToken: this.CancellationToken.Value)
                        .Result;
                    this.WriteObject(this.GetOutputObjects("ManagedApplicationId", getResult), enumerateCollection: true);
                }
                else
                {
                    this.WriteObject(operationResource.Error.ToJToken());
                }
            }
            else
            {
                throw new InvalidOperationException("The operation failed because the operation status could not be de-serialized.");
            }
        }
    }
}