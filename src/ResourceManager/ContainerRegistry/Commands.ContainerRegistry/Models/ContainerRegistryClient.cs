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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ContainerRegistryClient
    {
        private ContainerRegistryManagementClient _client;
        private StorageManagementClient _storageClient;

        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }

        public ContainerRegistryClient(IAzureContext context)
        {
            _client = AzureSession.Instance.ClientFactory.CreateArmClient<ContainerRegistryManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            _storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public string GetStorageAccountAccessKey(string resourceGroupName, string accountName)
        {
            return _storageClient.StorageAccounts.ListKeys(resourceGroupName, accountName).Keys[0].Value;
        }

        public Registry GetRegistry(string resourceGroupName, string registryName)
        {
            return _client.Registries.Get(resourceGroupName, registryName);
        }

        public Registry UpdateRegistry(
            string resourceGroupName,
            string registryName,
            bool? adminUserEnabled,
            string storageAccountName = null,
            string storageAccountResourceGroup = null,
            IDictionary<string, string> tags = null)
        {
            var parameters = new RegistryUpdateParameters()
            {
                AdminUserEnabled = adminUserEnabled
            };

            if (storageAccountName != null)
            {
                if (storageAccountResourceGroup == null)
                {
                    throw new ArgumentNullException("Storage account resource group cannot be null.");
                }

                var storageAccountAccessKey = GetStorageAccountAccessKey(storageAccountResourceGroup, storageAccountName);

                parameters.StorageAccount = new StorageAccountParameters()
                {
                    Name = storageAccountName,
                    AccessKey = storageAccountAccessKey
                };
            }

            if (tags != null)
            {
                parameters.Tags = tags;
            }

            return _client.Registries.Update(resourceGroupName, registryName, parameters);
        }

        public void DeleteRegistry(string resourceGroupName, string registryName)
        {
            _client.Registries.Delete(resourceGroupName, registryName);
        }

        public IPage<Registry> ListRegistries(string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Registries.List();
            }
            else
            {
                return _client.Registries.ListByResourceGroup(resourceGroupName);
            }
        }

        public IPage<Registry> ListRegistriesUsingNextLink(string resourceGroupName, string nextLink)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Registries.ListNext(nextPageLink: nextLink);
            }
            else
            {
                return _client.Registries.ListByResourceGroupNext(nextPageLink: nextLink);
            }
        }

        public RegistryListCredentialsResult ListRegistryCredentials(string resourceGroupName, string registryName)
        {
            return _client.Registries.ListCredentials(resourceGroupName, registryName);
        }

        public RegistryListCredentialsResult RegenerateRegistryCredential(string resourceGroupName, string registryName, PasswordName passwordName)
        {
            return _client.Registries.RegenerateCredential(resourceGroupName, registryName, passwordName);
        }

        public RegistryNameStatus CheckRegistryNameAvailability(string registryName)
        {
            return _client.Registries.CheckNameAvailability(registryName);
        }
    }
}
