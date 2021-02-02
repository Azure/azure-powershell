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
using System.Runtime.CompilerServices;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
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
        protected const string NameValueFormatString = "{0}({1})";
        protected readonly IDictionary<string, string> ValueRegexToReadingStringMap = new Dictionary<string, string>
        {
            {"^[a-zA-Z0-9]$|^[a-zA-Z0-9][-_a-zA-Z0-9]{0,61}[a-zA-Z0-9]$", " The value should be starting and ending with alphanumeric, allowed characters are alphanumeric, underscore and hyphen in the middle of name, the total length is between 1 and 63." },
            {"^[a-z][a-z0-9]{0,11}$", " The value should be starting with lower case letter, followed by from 0 to at most 11 lower case letter or digit." }
        };

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
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var newEx = new AzPSResourceNotFoundCloudException(ex.Message, innerException: ex)
                    {
                        Request = ex.Request,
                        Response = ex.Response,
                        Body = ex.Body,
                    };
                    throw newEx;
                }
                else if (string.Equals(ex.Body?.Code, "AgentPoolK8sVersionNotSupported", StringComparison.InvariantCultureIgnoreCase))
                {
                    var newEx = new AzPSCloudException(Resources.K8sVersionNotSupported, Resources.K8sVersionNotSupported, ex)
                    {
                        Request = ex.Request,
                        Response = ex.Response,
                        Body = ex.Body,
                    };
                    throw newEx;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ex.Body?.Code))
                    {
                        ex.Data[AzurePSErrorDataKeys.CloudErrorCodeKey] = ex.Body.Code;
                    }
                    throw;
                }
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

        internal bool HandleValidationException(ValidationException e, IDictionary<string, CmdletParameterNameValuePair> parametersMap, [CallerFilePath] string callerFilePath = null)
        {
            if (string.IsNullOrEmpty(e.Target) || !parametersMap.ContainsKey(e.Target))
            {
                e.Data[AzurePSErrorDataKeys.ErrorKindKey] = ErrorKind.UserError;
                //ValidationException thrown by SDK doesn't contain sensitive information
                e.Data[AzurePSErrorDataKeys.DesensitizedErrorMessageKey] = e.Message;
                return false;
            }

            var desensitizedMessage = e.Message?.Replace(e.Target, parametersMap[e.Target].Name);
            var errorMessage = e.Message?.Replace(e.Target, NameValueFormatString.FormatInvariant(parametersMap[e.Target].Name, parametersMap[e.Target].Value ?? string.Empty));

            foreach(var pair in ValueRegexToReadingStringMap)
            {
                if(errorMessage.Contains(pair.Key))
                {
                    errorMessage += pair.Value;
                }
            }
            throw new AzPSArgumentException(errorMessage, parametersMap[e.Target].Name, desensitizedMessage, filePath: callerFilePath);
        }
    }
}