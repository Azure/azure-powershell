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

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    internal class DeploymentTemplate
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }
        public string ContentVersion { get; set; }
        public AzureResource[] Resources { get; set; }
    }

    internal class AzureResource
    {
        public string Name { get; set; }
        public virtual string Type { get; set; }
        public string Location { get; set; }
        public string ApiVersion { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public Sku Sku { get; set; }
        public string[] DependsOn { get; set; }
    }

    internal class Sku
    {
        public string Name { get; set; }
    }

    internal class RegistryResource : AzureResource
    {
        public override string Type => "Microsoft.ContainerRegistry/registries";
        [JsonProperty(Order = 1)]
        public RegistryProperties Properties { get; set; }
    }

    internal class RegistryProperties
    {
        public bool AdminUserEnabled { get; set; }
        public StorageAccount StorageAccount { get; set; }
    }

    internal class StorageAccount
    {
        public string Id { get; set; }
    }

    internal class StorageResource : AzureResource
    {
        public override string Type => "Microsoft.Storage/storageAccounts";
        [JsonProperty(Order = 1)]
        public string Kind => "Storage";
        [JsonProperty(Order = 1)]
        public IDictionary<string, object> Properties => new Dictionary<string, object>()
        {
            { "encryption", new Dictionary<string, object> {
                { "services", new Dictionary<string, object> {
                    { "blob", new Dictionary<string, bool> {
                        { "enabled", true }
                    } }
                } },
                { "keySource", "Microsoft.Storage" }
            } }
        };
    }

    internal static class DeploymentTemplateHelper
    {
        private const string RegistryApiVersion = "2017-10-01";
        private const string StorageApiVersion = "2016-12-01";
        private const string StorageAccountSku = "Standard_LRS";

        internal static string ToJsonString(this DeploymentTemplate template)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(template, settings);
        }

        internal static string DeploymentTemplateNewStorage(
            string registryName,
            string registryLocation,
            string registrySku,
            string storageAccountName,
            bool? adminUserEnabled,
            IDictionary<string, string> tags = null)
        {
            var template = new DeploymentTemplate
            {
                Schema = "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
                ContentVersion = "1.0.0.0",
                Resources = new AzureResource[]
                {
                    new StorageResource
                    {
                        Name = storageAccountName,
                        Location = registryLocation,
                        ApiVersion = StorageApiVersion,
                        Tags = new Dictionary<string, string>
                        {
                            { "containerregistry", registryName }
                        },
                        Sku = new Sku
                        {
                            Name = StorageAccountSku
                        }
                    },
                    new RegistryResource
                    {
                        Name = registryName,
                        Location = registryLocation,
                        ApiVersion = RegistryApiVersion,
                        Tags = tags,
                        Sku = new Sku
                        {
                            Name = registrySku
                        },
                        DependsOn = new string[]
                        {
                            $"[resourceId('Microsoft.Storage/storageAccounts', '{storageAccountName}')]"
                        },
                        Properties = new RegistryProperties
                        {
                            AdminUserEnabled = adminUserEnabled != null ? adminUserEnabled.Value : false,
                            StorageAccount = new StorageAccount
                            {
                                Id = $"[resourceId('Microsoft.Storage/storageAccounts', '{storageAccountName}')]"
                            }
                        }
                    }
                }
            };

            return template.ToJsonString();
        }
    }
}
