// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricCommonCmdletBase : AzureRMCmdlet
    {
        internal static int WriteVerboseIntervalInSec = 20;

        private Lazy<IResourceManagementClient> resourcesClient;

        internal IResourceManagementClient ResourcesClient
        {
            get { return resourcesClient.Value; }
            set { resourcesClient = new Lazy<IResourceManagementClient>(() => value); }
        }

        public ServiceFabricCommonCmdletBase()
        {
            InitializeManagementClients();
        }

        private void InitializeManagementClients()
        {
            this.resourcesClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));
        }

        #region Helper

        protected void GetParametersByResourceId(string resourceId, string resourceType, out string resourceGroup, out string resourceName, out string parentResourceName, out string grandParentResourceName)
        {
            ResourceIdentifier rId = new ResourceIdentifier(resourceId);
            if (!rId.ResourceType.EndsWith(resourceType, StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(string.Format("Invalid resource id {0}", resourceId));
            }

            resourceGroup = rId.ResourceGroupName;
            resourceName = rId.ResourceName;
            parentResourceName = string.Empty;
            grandParentResourceName = string.Empty;
            if (!string.IsNullOrEmpty(rId.ParentResource))
            {
                var parent = rId.ParentResource.Split('/');
                if (parent.Length == 4)
                {
                    parentResourceName = parent[3];
                    grandParentResourceName = parent[1];
                }
                else if (parent.Length == 2)
                {
                    parentResourceName = parent[1];
                }
            }
        }

        protected void GetParametersByResourceId(string resourceId, string resourceType, out string resourceGroup, out string resourceName, out string parentResourceName)
        {
            ResourceIdentifier rId = new ResourceIdentifier(resourceId);
            if (!rId.ResourceType.EndsWith(resourceType, StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(string.Format("Invalid resource id {0}", resourceId));
            }

            resourceGroup = rId.ResourceGroupName;
            resourceName = rId.ResourceName;
            parentResourceName = string.Empty;
            if (!string.IsNullOrEmpty(rId.ParentResource))
            {
                var parent = rId.ParentResource.Split('/');
                parentResourceName = parent.Length == 2 ? parent[1] : null;
            }
        }

        protected void GetParametersByResourceId(string resourceId, string resourceType, out string resourceGroup, out string resourceName)
        {
            this.GetParametersByResourceId(resourceId, resourceType, out resourceGroup, out resourceName, out _);
        }

        protected T SafeGetResource<T>(Func<T> action, bool ingoreAllError=false)
        {
            try
            {
                return action();
            }
            catch (CloudException ce)
            {
                if (ce.Response != null && ce.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }

                if (ingoreAllError)
                {
                    WriteWarning(ce.ToString());
                    return default(T);
                }

                throw;
            }
            catch (Management.ServiceFabric.Models.ErrorModelException e)
            {
                if ((e.Body?.Error != null &&
                    (e.Body.Error.Code.Equals("ResourceGroupNotFound", StringComparison.OrdinalIgnoreCase) ||
                     e.Body.Error.Code.Equals("ResourceNotFound", StringComparison.OrdinalIgnoreCase) ||
                     e.Body.Error.Code.Equals("NotFound", StringComparison.OrdinalIgnoreCase))) ||
                     e.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }

                if (ingoreAllError)
                {
                    WriteWarning(e.ToString());
                    return default(T);
                }

                throw;
            }
            catch (Management.ServiceFabricManagedClusters.Models.ErrorModelException e)
            {
                if ((e.Body?.Error != null &&
                    (e.Body.Error.Code.Equals("ResourceGroupNotFound", StringComparison.OrdinalIgnoreCase) ||
                     e.Body.Error.Code.Equals("ResourceNotFound", StringComparison.OrdinalIgnoreCase) ||
                     e.Body.Error.Code.Equals("NotFound", StringComparison.OrdinalIgnoreCase))) ||
                     e.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }

                if (ingoreAllError)
                {
                    WriteWarning(e.ToString());
                    return default(T);
                }

                throw;
            }
            catch (Exception e)
            {
                if (ingoreAllError)
                {
                    WriteWarning(e.ToString());
                    return default(T);
                }

                throw;
            }
        }

        protected IEnumerable<T> ReturnListByPageResponse<T>(IPage<T> page, Func<string, IPage<T>> listNextFunction) where T : class
        {
            var listResult = new List<T>();
            do
            {
                listResult.AddRange(page);
            } while (!string.IsNullOrEmpty(page.NextPageLink) &&
                    (page = listNextFunction(page.NextPageLink)) != null);


            return listResult;
        }

        protected void PrintSdkExceptionDetail(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            while (!(exception is CloudException || 
                     exception is Management.ServiceFabric.Models.ErrorModelException || 
                     exception is Management.ServiceFabricManagedClusters.Models.ErrorModelException) 
                   && exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is CloudException)
            {
                var cloudException = (CloudException)exception;
                if (cloudException.Body != null)
                {
                    var cloudErrorMessage = GetCloudErrorMessage(cloudException.Body);
                    var ex = new Exception(cloudErrorMessage);
                    WriteError(
                        new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
            else if (exception is Management.ServiceFabricManagedClusters.Models.ErrorModelException)
            {
                var errorModelException = (Management.ServiceFabricManagedClusters.Models.ErrorModelException)exception;
                if (errorModelException.Body != null)
                {
                    var cloudErrorMessage = GetErrorModelErrorMessage(errorModelException.Body);
                    if (!string.IsNullOrEmpty(cloudErrorMessage))
                    {
                        var ex = new Exception(cloudErrorMessage);
                        WriteError(
                            new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                    }
                }

                if (errorModelException.Response?.Content != null)
                {
                    var exMessage = GetResponseExceptionMessage(errorModelException.Response?.Content);
                    if (!string.IsNullOrEmpty(exMessage))
                    {
                        var ex = new Exception(exMessage);
                        WriteError(
                            new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                    }
                }
            }
            else if (exception is Management.ServiceFabric.Models.ErrorModelException)
            {
                var errorModelException = (Management.ServiceFabric.Models.ErrorModelException)exception;
                if (errorModelException.Body != null)
                {
                    var cloudErrorMessage = GetErrorModelErrorMessage(errorModelException.Body);
                    if (!string.IsNullOrEmpty(cloudErrorMessage))
                    {
                        var ex = new Exception(cloudErrorMessage);
                        WriteError(
                            new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                    }
                }

                if (errorModelException.Response?.Content != null)
                {
                    var exMessage = GetResponseExceptionMessage(errorModelException.Response?.Content);
                    if (!string.IsNullOrEmpty(exMessage))
                    {
                        var ex = new Exception(exMessage);
                        WriteError(
                            new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                    }
                }
            }
            else
            {
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null));
            }
        }

        private string GetCloudErrorMessage(CloudError error)
        {
            if (error == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            if (error.Details != null)
            {
                foreach (var detail in error.Details)
                {
                    sb.Append(GetCloudErrorMessage(detail));
                }
            }

            var message = string.Format(
                "Code: {0}, Message: {1}{2}Details: {3}{2}",
                error.Code,
                error.Message,
                Environment.NewLine,
                sb);

            return message;
        }

        private string GetErrorModelErrorMessage(Management.ServiceFabricManagedClusters.Models.ErrorModel error)
        {
            if (error == null || error.Error == null)
            {
                return string.Empty;
            }

            var message = string.Format(
                "Code: {0}, Message: {1}{2}",
                error.Error.Code,
                error.Error.Message,
                Environment.NewLine);

            return message;
        }

        private string GetErrorModelErrorMessage(Management.ServiceFabric.Models.ErrorModel error)
        {
            if (error == null || error.Error == null)
            {
                return string.Empty;
            }

            var message = string.Format(
                "Code: {0}, Message: {1}{2}",
                error.Error.Code,
                error.Error.Message,
                Environment.NewLine);

            return message;
        }

        private string GetResponseExceptionMessage(string responseContent)
        {
            try
            {
                var contentJObject = JObject.Parse(responseContent);
                string correlationId = string.Empty;
                if (contentJObject.TryGetValue("request", StringComparison.OrdinalIgnoreCase, out JToken requestValue))
                {
                    var requestString = (string)requestValue;
                    if (!string.IsNullOrEmpty(requestString))
                    {
                        string correlationHeader = "x-ms-correlation-request-id: ";
                        var index = requestString.IndexOf(correlationHeader, StringComparison.OrdinalIgnoreCase);
                        int guidLength = 36;
                        if (index != -1 && requestString.Length > index + correlationHeader.Length + guidLength + 1)
                        {
                            correlationId = requestString.Substring(index + correlationHeader.Length, guidLength);
                        }
                    }
                }

                if (contentJObject.TryGetValue("exception", StringComparison.OrdinalIgnoreCase, out JToken exceptionValue))
                {
                    return exceptionValue != null ? $"CorrelationId: {correlationId} - Exception: {(string)exceptionValue}" : responseContent;
                }

                return responseContent;
            }
            catch (JsonReaderException)
            {
                return responseContent;
            }
        }

        #endregion
    }
}