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
using Microsoft.Rest;
using System;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Provider = Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models.Provider;
using System.Linq;
using System.Net.Http;

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
            // To save time, we'll check the registration state first before making the register call.
            ResourceManagerClient.SubscriptionId = subscriptionId;
            Provider provider = ResourceManagerClient.Providers.Get(BlueprintConstants.BlueprintProviderNamespace);

            if (provider.RegistrationState == RegistrationState.Registered)
            {
                return;
            }

            // The reason we poll for the registrationState for RP registration is because we'd like to make sure the RP registering
            // happens before the blueprint creation/assignment request is submitted. This should help alleviate the spike in
            // blueprint creation/assignment failures due to RP not being registered.
            const int MaxPoll = 20;
            int pollCount = 0;

            do
            {
                if (pollCount > MaxPoll)
                {
                    // We should ideally throw a timeout exception here but we're collecting logs on service side about RP registration failures
                    // and would like to continue with blueprint/assignment creation flow.
                    //
                    // To-Do: Add TimeoutException
                    break;
                }

                provider = ResourceManagerClient.Providers.Register(BlueprintConstants
                    .BlueprintProviderNamespace); // Instead of Get, do Register call again since GET takes its sweet time to return the status.

                TestMockSupport.Delay(TimeSpan.FromSeconds(1));

                pollCount++;

            } while (provider.RegistrationState != RegistrationState.Registered);
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
        ///  Returns the blueprint file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected string GetValidatedFilePathForBlueprint(string path)
        {
            var blueprintFileName = AzureSession.Instance.DataStore.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                .Select(file => Path.GetFileName(file))
                .FirstOrDefault(name => String.Equals(name, "blueprint.json", StringComparison.OrdinalIgnoreCase));
                    
            if (blueprintFileName == null)
            {
                throw new Exception(
                    $"Cannot locate Blueprint.json in: {path}.");
            }

            return Path.Combine(path, blueprintFileName);
        }

        /// <summary>
        /// Returns the artifacts folder path. 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected string GetValidatedFolderPathForArtifacts(string path)
        {
            var artifactsFolderName = AzureSession.Instance.DataStore.GetDirectories(path)
                .Select(folder => Path.GetFileName(folder))
                .FirstOrDefault(name => String.Equals(name, "artifacts", StringComparison.OrdinalIgnoreCase));

            return artifactsFolderName == null ? null : Path.Combine(path, artifactsFolderName);
        }

        /// <summary>
        /// Unregisters delegating handler if registered.  
        /// </summary>
        protected void UnregisterDelegatingHandlerIfRegistered()
        {
            var apiExpandHandler = GetExpandHandler();

            if (apiExpandHandler != null)
            {
                AzureSession.Instance.ClientFactory.RemoveHandler(apiExpandHandler.GetType());
            }
        }

        /// <summary>
        /// Returns expand handler, if exists.  
        /// </summary>
        private DelegatingHandler GetExpandHandler()
        {
            return AzureSession.Instance.ClientFactory.GetCustomHandlers()?
                .Where(handler => handler.GetType().Equals(typeof(ApiExpandHandler))).FirstOrDefault();
        }
    }
}
