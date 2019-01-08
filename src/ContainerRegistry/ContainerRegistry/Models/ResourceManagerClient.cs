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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ResourceManagerClient
    {
        private ResourceManagementClient _client;

        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }

        public ResourceManagerClient(IAzureContext context)
        {
            _client = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public DeploymentExtended CreateClassicRegistry(
            string resourceGroupName,
            string registryName,
            string location,
            bool? adminUserEnabled,
            IDictionary<string, string> tags = null)
        {
            var storageAccountName = registryName.ToLowerInvariant();
            if (storageAccountName.Length > 18)
            {
                storageAccountName = storageAccountName.Substring(0, 18);
            }
            storageAccountName += DateTime.UtcNow.ToString("hhmmss");

            var deploymentName = $"ContainerRegistry_{registryName}";
            Deployment deployment = new Deployment()
            {
                Properties = new DeploymentProperties()
                {
                    Template = DeploymentTemplateHelper.DeploymentTemplateNewStorage(
                        registryName, location, SkuName.Classic, storageAccountName, adminUserEnabled),
                    Mode = DeploymentMode.Incremental
                }
            };

            return _client.Deployments.CreateOrUpdate(resourceGroupName, deploymentName, deployment);
        }

        public string GetStorageAccountId(string storageAccountName)
        {
            var filterExpression = $"ResourceType eq 'Microsoft.Storage/storageAccounts' AND name eq '{storageAccountName}'";
            var odataQuery = new ODataQuery<GenericResourceFilter>() { Filter = filterExpression };
            var result = _client.Resources.List(odataQuery);

            var resource = result.FirstOrDefault();
            while (resource == null && result.NextPageLink != null)
            {
                result = _client.Resources.ListNext(result.NextPageLink);
                resource = result.FirstOrDefault();
            }

            if (resource == null)
            {
                throw new InvalidOperationException($"Storage account {storageAccountName} doesn't exist.");
            }

            return resource.Id;
        }

        public string GetResourceGroupLocation(string resourceGroupName)
        {
            var resourceGroup = _client.ResourceGroups.Get(resourceGroupName);
            return resourceGroup.Location;
        }
    }
}
