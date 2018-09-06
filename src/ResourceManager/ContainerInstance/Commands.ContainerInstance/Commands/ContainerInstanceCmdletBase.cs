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
using System.Text.RegularExpressions;
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
        protected const string ContainerInstanceLogNoun = "AzureRmContainerInstanceLog";

        /// <summary>
        /// Azure File volume name.
        /// </summary>
        private const string AzureFileVolumeName = "azurefile";

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

            if (!string.IsNullOrEmpty(parameters.AzureFileVolumeMountPath))
            {
                container.VolumeMounts = new List<VolumeMount>
                {
                    new VolumeMount
                    {
                        Name = ContainerInstanceCmdletBase.AzureFileVolumeName,
                        MountPath = parameters.AzureFileVolumeMountPath
                    }
                };
            }

            var containerGroup = new ContainerGroup()
            {
                Location = parameters.Location,
                Tags = parameters.Tags,
                Containers = new List<Container>() { container },
                OsType = parameters.OsType,
                RestartPolicy = parameters.RestartPolicy
            };

            if (string.Equals(IpAddress.Type, parameters.IpAddressType, StringComparison.OrdinalIgnoreCase) || 
                !string.IsNullOrEmpty(parameters.DnsNameLabel))
            {
                container.Ports = parameters.Ports.Select(p => new ContainerPort(p)).ToList();
                containerGroup.IpAddress = new IpAddress(
                    ports: parameters.Ports.Select(p => new Port(p)).ToList(),
                    dnsNameLabel: parameters.DnsNameLabel);
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

            if (!string.IsNullOrEmpty(parameters.AzureFileVolumeMountPath))
            {
                var azureFileVolume = new AzureFileVolume
                {
                    ShareName = parameters.AzureFileVolumeShareName,
                    StorageAccountName = parameters.AzureFileVolumeAccountName,
                    StorageAccountKey = parameters.AzureFileVolumeAccountKey
                };

                containerGroup.Volumes = new List<Volume>
                {
                    new Volume
                    {
                        Name = ContainerInstanceCmdletBase.AzureFileVolumeName,
                        AzureFile = azureFileVolume
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
        /// Parse resource group from resource id.
        /// </summary>
        /// <param name="resourceId">A resource id.</param>
        public string ParseResourceGroupFromResourceId(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException("resourceId");
            }

            Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);

            if (!m.Success)
            {
                throw new ArgumentException("Invalid format of resourceId");
            }

            return m.Groups["rgname"].Value;
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
