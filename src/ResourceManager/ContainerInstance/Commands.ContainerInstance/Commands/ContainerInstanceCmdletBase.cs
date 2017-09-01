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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ContainerInstance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.ContainerInstance
{
    /// <summary>
    /// ContainerInstance cmdlets base.
    /// </summary>
    public abstract class ContainerInstanceCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Noun for container group.
        /// </summary>
        protected const string ContainerGroupNoun = "AzureRmContainerGroup";

        /// <summary>
        /// Noun for container group logs.
        /// </summary>
        protected const string ContainerLogsNoun = "AzureRmContainerGroupLogs";

        /// <summary>
        /// Container instance management client.
        /// </summary>
        private ContainerInstanceManagementClient _containerClient;

        /// <summary>
        /// Resource management client.
        /// </summary>
        private ResourceManagementClient _resourceClient;

        /// <summary>
        /// Gets or sets the ContainerInstanceManagementClient.
        /// </summary>
        public ContainerInstanceManagementClient ContainerClient
        {
            get
            {
                if (this._containerClient == null)
                {
                    this._containerClient = AzureSession.Instance.ClientFactory.CreateArmClient<ContainerInstanceManagementClient>(
                        context: this.DefaultContext,
                        endpoint: AzureEnvironment.Endpoint.ResourceManager);
                }
                return this._containerClient;
            }
            set
            {
                this._containerClient = value;
            }
        }

        /// <summary>
        /// Gets or sets the ResourceManagementClient.
        /// </summary>
        public ResourceManagementClient ResourceClient
        {
            get
            {
                if (this._resourceClient == null)
                {
                    this._resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                        context: this.DefaultContext,
                        endpoint: AzureEnvironment.Endpoint.ResourceManager);
                }
                return this._resourceClient;
            }
            set
            {
                this._resourceClient = value;
            }
        }

        /// <summary>
        /// Create a container group by creation parameters.
        /// </summary>
        public ContainerGroup CreateContainerGroup(ContainerGroupCreationParameters parameters)
        {
            var resources = new ResourceRequirements()
            {
                Requests = new ResourceRequests()
                {
                    Cpu = parameters.Cpu,
                    MemoryInGB = parameters.MemoryInGb,
                }
            };

            var container = new Container()
            {
                Name = parameters.Name,
                Image = parameters.ContainerImage,
                Command = parameters.ContainerCommand,
                Resources = resources,
                EnvironmentVariables = parameters.EnvironmentVariables?.Select(e => new EnvironmentVariable(e.Key, e.Value)).ToList()
            };

            var containerGroup = new ContainerGroup()
            {
                Location = parameters.Location,
                Tags = parameters.Tags,
                Containers = new List<Container>() { container },
                OsType = parameters.OsType
            };

            if (string.Equals(IpAddress.Type, parameters.IpAddressType, StringComparison.OrdinalIgnoreCase))
            {
                container.Ports = new List<ContainerPort>() { new ContainerPort(parameters.Port) };
                containerGroup.IpAddress = new IpAddress(new List<Port>() { new Port(parameters.Port) });
            }

            if (!string.IsNullOrEmpty(parameters.RegistryServer))
            {
                containerGroup.ImageRegistryCredentials = new List<ImageRegistryCredential>()
                {
                    new ImageRegistryCredential()
                    {
                        Server = parameters.RegistryServer,
                        Username = parameters.RegistryUsername,
                        Password = parameters.RegistryPassword
                    }
                };
            }

            return this.ContainerClient.ContainerGroups.CreateOrUpdate(
                resourceGroupName: parameters.ResourceGroupName,
                containerGroupName: parameters.Name,
                containerGroup: containerGroup);
        }

        /// <summary>
        /// Get resource group location.
        /// </summary>
        public string GetResourceGroupLocation(string resourceGroupName)
        {
            var resourceGroup = this.ResourceClient.ResourceGroups.Get(resourceGroupName);
            return resourceGroup?.Location;
        }

        /// <summary>
        /// Convert hashtable to dictionary.
        /// </summary>
        public IDictionary<string, string> ConvertHashtableToDictionary(Hashtable hashtable)
        {
            var dictionary = new Dictionary<string, string>();
            if (hashtable != null)
            {
                foreach (DictionaryEntry entry in hashtable)
                {
                    dictionary[entry.Key.ToString()] = entry.Value.ToString();
                }
            }
            return dictionary;
        }
    }
}
