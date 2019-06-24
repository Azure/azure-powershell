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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// The blueprint client.
        /// </summary>
        private IBlueprintClient blueprintClient;
        public IBlueprintClient BlueprintClient
        {
            get
            {
                return blueprintClient = blueprintClient ?? new BlueprintClient(DefaultProfile.DefaultContext);
            }
            set => blueprintClient = value;
        }

        /// <summary>
        /// Blueprint client with delegating handler. The delegating handler is needed to get blueprint versions info.
        /// </summary>
        private IBlueprintClient blueprintClientWithVersion;
        public IBlueprintClient BlueprintClientWithVersion
        {
            get
            {
                return blueprintClientWithVersion = blueprintClientWithVersion ?? new BlueprintClient(DefaultProfile.DefaultContext, new ApiExpandHandler());
            }
            set => blueprintClientWithVersion = value;
        }

        /// <summary>
        /// Service client credentials client to hold credentials
        /// </summary>
        private ServiceClientCredentials clientCredentials;
        public ServiceClientCredentials ClientCredentials
        {
            get
            {
                return clientCredentials = clientCredentials ?? AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(DefaultProfile.DefaultContext,
                                               AzureEnvironment.Endpoint.ResourceManager);

            }
            set => clientCredentials = value;
        }

        /// <summary>
        /// Authorization client
        /// </summary>
        private IAuthorizationManagementClient authorizationManagementClient;

        public IAuthorizationManagementClient AuthorizationManagementClient
        {
            get
            {
                return authorizationManagementClient = authorizationManagementClient ?? AzureSession.Instance.ClientFactory.CreateArmClient<AuthorizationManagementClient>(DefaultProfile.DefaultContext, 
                                                           AzureEnvironment.Endpoint.ResourceManager);
            }
            set => authorizationManagementClient = value;
        }

        /// <summary>
        /// ARM client
        /// </summary>
        private IResourceManagementClient resourceManagerClient;
        public IResourceManagementClient ResourceManagerClient
        { 
            get
            {
                return resourceManagerClient = resourceManagerClient ?? new ResourceManagementClient(
                                                   DefaultProfile.DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                                   ClientCredentials);
            }
            set => resourceManagerClient = value;
        }

        protected override void WriteExceptionError(Exception ex)
        {
            var aggEx = ex as AggregateException;

            if (aggEx != null && aggEx.InnerExceptions != null)
            {
                foreach (var e in aggEx.Flatten().InnerExceptions)
                {
                    WriteExceptionError(e);
                }
                return;
            }

            base.WriteExceptionError(ex);
        }

        /// <summary>
        /// Register Blueprint RP with a subscription.
        /// </summary>
        /// <param name="subscriptionId"> SubscriptionId passed from the cmdlet</param>
        protected void RegisterBlueprintRp(string subscriptionId)
        {
            ResourceManagerClient.SubscriptionId = subscriptionId;
            var response = ResourceManagerClient.Providers.Register(BlueprintConstants.BlueprintProviderNamespace);

            if (response == null)
            {
                throw new KeyNotFoundException(string.Format(Resources.ResourceProviderRegistrationFailed, BlueprintConstants.BlueprintProviderNamespace));
            }
        }


        /// <summary>
        /// Expects a string that consist of full file path with file extension and check if it exists.
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        protected string GetValidatedFilePath(string fileFullName)
        {
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

            if (!AzureSession.Instance.DataStore.FileExists(blueprintPath))
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

            if (!AzureSession.Instance.DataStore.DirectoryExists(artifactsPath))
            {
                artifactsPath = null;
            }

            return artifactsPath;
        }
    }
}
