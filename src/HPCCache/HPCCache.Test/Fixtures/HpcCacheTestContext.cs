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

namespace Microsoft.Azure.Commands.HPCCache.Test.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Azure.Commands.HPCCache.Test.ScenarioTests;
    using Microsoft.Azure.Commands.HPCCache.Test.Utilities;
    using Microsoft.Azure.Commands.TestFx.Recorder;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Authorization.Models;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Internal.Resources.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    /// Defines the <see cref="HpcCacheTestContext" />.
    /// </summary>
    public class HpcCacheTestContext : IDisposable
    {
        /// <summary>
        /// Defines the mockContext.
        /// </summary>
        private readonly MockContext mockContext;

        /// <summary>
        /// Defines the serviceClientCache.
        /// </summary>
        private readonly Dictionary<Type, IDisposable> serviceClientCache = new Dictionary<Type, IDisposable>();

        /// <summary>
        /// Defines the disposedValue.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheTestContext"/> class.
        /// </summary>
        /// <param name="suiteObject">Class object.</param>
        /// <param name="methodName">Method name of the calling method.</param>
        public HpcCacheTestContext(
            string suiteObject,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = ".ctor")
        {
            BuildMockServer();
            this.mockContext = MockContext.Start(suiteObject, methodName);
            this.RegisterSubscriptionForResource("Microsoft.StorageCache");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheTestContext"/> class.
        /// </summary>
        /// <param name="type">Class type.</param>
        /// <param name="methodName">Method name of the calling method.</param>
        public HpcCacheTestContext(
            Type type,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = ".ctor")
        {
            BuildMockServer();
            this.mockContext = MockContext.Start(type.Name, methodName);
            this.RegisterSubscriptionForResource("Microsoft.StorageCache");
        }

        private void BuildMockServer()
        {
            var rpToIgnore = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Network", null },
            };
            var uaToIgnore = new Dictionary<string, string>
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" },
                { "Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10" },
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, rpToIgnore, uaToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(GetTestProjectPath(), "SessionRecords");
        }

        private string GetTestProjectPath()
        {
            var testAssembly = Assembly.GetExecutingAssembly();
            var testProjectPath = testAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().Single(a => a.Key == "TestProjectPath").Value;

            if (string.IsNullOrEmpty(testProjectPath))
            {
                throw new InvalidOperationException($"Unable to determine the test directory for {testAssembly}");
            }

            return testProjectPath;
        }

        /// <summary>
        /// Get service client.
        /// </summary>
        /// <param name="delegationHandler">HTTP delegation handler.</param>
        /// <typeparam name="TServiceClient">The type of the service client to return.</typeparam>
        /// <returns>A management client, created from the current context (environment variables).</returns>
        public TServiceClient GetClient<TServiceClient>()
            where TServiceClient : class, IDisposable
        {
            if (this.serviceClientCache.TryGetValue(typeof(TServiceClient), out IDisposable clientObject))
            {
                return (TServiceClient)clientObject;
            }

            TServiceClient client = this.mockContext.GetServiceClient<TServiceClient>();
            this.serviceClientCache.Add(typeof(TServiceClient), client);
            return client;
        }

        /// <summary>
        /// Get or create resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="location">Location where resource group is to be created.</param>
        /// <returns>ResourceGroup object.</returns>
        public ResourceGroup GetOrCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceManagementClient resourceClient = this.GetClient<ResourceManagementClient>();
            ResourceGroup resourceGroup = this.GetResourceGroupIfExists(resourceGroupName);

            if (resourceGroup == null)
            {
                resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { resourceGroupName, DateTime.UtcNow.ToString("u") } },
                });
            }

            return resourceGroup;
        }

        /// <summary>
        /// Get or create virtual network.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="virtualNetworkName">The name of the virtual network.</param>
        /// <returns>VirtualNetwork object.</returns>
        public VirtualNetwork GetOrCreateVirtualNetwork(ResourceGroup resourceGroup, string virtualNetworkName)
        {
            NetworkManagementClient networkManagementClient = this.GetClient<NetworkManagementClient>();
            VirtualNetwork virtualNetwork = null;
            try
            {
                virtualNetwork = networkManagementClient.VirtualNetworks.Get(resourceGroup.Name, virtualNetworkName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            if (virtualNetwork == null)
            {
                var vnet = new VirtualNetwork()
                {
                    Location = resourceGroup.Location,
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string> { "10.1.0.0/16" },
                    },
                };
                virtualNetwork = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroup.Name, virtualNetworkName, vnet);
            }

            return virtualNetwork;
        }

        /// <summary>
        /// Get Or create subnet.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="virtualNetwork">Object representing a virtual network.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <returns>Subnet object.</returns>
        public Subnet GetOrCreateSubnet(ResourceGroup resourceGroup, VirtualNetwork virtualNetwork, string subnetName)
        {
            NetworkManagementClient networkManagementClient = this.GetClient<NetworkManagementClient>();
            Subnet subNet = null;
            try
            {
                subNet = networkManagementClient.Subnets.Get(resourceGroup.Name, virtualNetwork.Name, subnetName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code != "NotFound")
                {
                    throw;
                }
            }

            if (subNet == null)
            {
                var snet = new Subnet()
                {
                    Name = subnetName,
                    AddressPrefix = "10.1.0.0/24",
                };

                subNet = networkManagementClient.Subnets.CreateOrUpdate(resourceGroup.Name, virtualNetwork.Name, subnetName, snet);
            }

            return subNet;
        }

        /// <summary>
        /// Get cache if exists.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="cacheName">The name of the cache.</param>
        /// <returns>Cache object if cache exists else null.</returns>
        public Cache GetCacheIfExists(ResourceGroup resourceGroup, string cacheName)
        {
            StorageCacheManagementClient storagecacheManagementClient = this.GetClient<StorageCacheManagementClient>();
            storagecacheManagementClient.ApiVersion = Constants.DefaultAPIVersion;
            try
            {
                return storagecacheManagementClient.Caches.Get(resourceGroup.Name, cacheName);
            }
            catch (CloudErrorException ex)
            {
                if (ex.Body.Error.Code == "ResourceNotFound")
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Get resource group if exists.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <returns>ResourceGroup object if resource group exists else null.</returns>
        public ResourceGroup GetResourceGroupIfExists(string resourceGroupName)
        {
            ResourceManagementClient resourceManagementClient = this.GetClient<ResourceManagementClient>();
            try
            {
                return resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code == "ResourceGroupNotFound")
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Register subscription for resource.
        /// </summary>
        /// <param name="providerName">Resource provider name.</param>
        public void RegisterSubscriptionForResource(string providerName)
        {
            ResourceManagementClient resourceManagementClient = this.GetClient<ResourceManagementClient>();
            var reg = resourceManagementClient.Providers.Register(providerName);
            StorageCacheTestUtilities.ThrowIfTrue(reg == null, $"Failed to register provider {providerName}");
            var result = resourceManagementClient.Providers.Get(providerName);
            StorageCacheTestUtilities.ThrowIfTrue(result == null, $"Failed to register provier {providerName}");
        }

        /// <summary>
        /// Add role assignment by role name.
        /// </summary>
        /// <param name="context">Object representing a HpcCacheTestContext.</param>
        /// <param name="scope">The scope of the role assignment to create.</param>
        /// <param name="roleName">The role name.</param>
        /// <param name="assignmentName">The name of the role assignment to create.</param>
        public void AddRoleAssignment(HpcCacheTestContext context, string scope, string roleName, string assignmentName)
        {
            AuthorizationManagementClient authorizationManagementClient = context.GetClient<AuthorizationManagementClient>();
            var roleDefinition = authorizationManagementClient.RoleDefinitions
                .List(scope)
                .First(role => role.RoleName.StartsWith(roleName));

            var newRoleAssignment = new RoleAssignmentCreateParameters()
            {
                RoleDefinitionId = roleDefinition.Id,
                PrincipalId = Constants.StorageCacheResourceProviderPrincipalId,
            };

            authorizationManagementClient.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Dispose managed state.
        /// </summary>
        /// <param name="disposing">true if we should dispose managed state, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose clients
                    foreach (IDisposable client in this.serviceClientCache.Values)
                    {
                        client.Dispose();
                    }

                    // Dispose context
                    this.mockContext.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
