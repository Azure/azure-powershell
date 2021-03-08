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

using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest;

using CloudException = Microsoft.Rest.Azure.CloudException;

namespace Microsoft.Azure.Commands.Aks
{
    public abstract class KubeCmdletBase : AzureRMCmdlet
    {
        private IContainerServiceClient _client;
        private IResourceManagementClient _rmClient;
        private IAuthorizationManagementClient _authClient;
        private IGraphRbacManagementClient _graphClient;

        protected const string KubeNounStr = "AzureRmAks";

        protected IContainerServiceClient Client => _client ?? (_client = BuildClient<ContainerServiceClient>());

        protected IResourceManagementClient RmClient =>
            _rmClient ?? (_rmClient = BuildClient<ResourceManagementClient>());

        protected IAuthorizationManagementClient AuthClient =>
            _authClient ?? (_authClient = BuildClient<AuthorizationManagementClient>());

        protected IGraphRbacManagementClient GraphClient =>
            _graphClient ?? (_graphClient = BuildClient<GraphRbacManagementClient>(endpoint: AzureEnvironment.Endpoint.Graph, postBuild: instance =>
            {
                instance.TenantID = DefaultContext.Tenant.Id;
                return instance;
            }));

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action"></param>
        protected void RunCmdLet(Action action)
        {
            try
            {
                action();
            }
            catch (CloudException ex)
            {
                if (string.Equals(ex.Body?.Code, "AgentPoolK8sVersionNotSupported", StringComparison.InvariantCultureIgnoreCase))
                    throw new PSInvalidOperationException(Resources.K8sVersionNotSupported);
                else
                    throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }

        private T BuildClient<T>(string endpoint = null, Func<T, T> postBuild = null) where T : ServiceClient<T>
        {
            var instance = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, endpoint ?? AzureEnvironment.Endpoint.ResourceManager);
            return postBuild == null ? instance : postBuild(instance);
        }

        private string AzConfigDir => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".azure");

        protected string AcsSpFilePath => Path.Combine(AzConfigDir, "acsServicePrincipal.json");

        protected static IList<T> ListPaged<T>(
            Func<Rest.Azure.IPage<T>> listFirstPage,
            Func<string, Rest.Azure.IPage<T>> listNextPage)
        {
            var resultsList = new List<T>();

            var pagedResponse = listFirstPage();
            resultsList.AddRange(pagedResponse);

            while (!string.IsNullOrEmpty(pagedResponse.NextPageLink))
            {
                pagedResponse = listNextPage(pagedResponse.NextPageLink);
                resultsList.AddRange(pagedResponse);
            }

            return resultsList;
        }
    }
}