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

using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultTestFixture : RMTestBase, IDisposable
    {
        public string tagName = "testtag", tagValue = "testvalue";
        public string resourceGroupName, location, preCreatedVault;
        bool initialized = false;
        public KeyVaultTestFixture()
        { }

        public void Initialize(string className)
        {
            if (initialized)
                return;

            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize(className, "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var testFactory = new CSMTestEnvironmentFactory();
                var testEnv = testFactory.GetTestEnvironment();
                var resourcesClient = TestBase.GetServiceClient<ResourceManagementClient>(testFactory);
                var mgmtClient = TestBase.GetServiceClient<KeyVaultManagementClient>(testFactory);
                var tenantId = testEnv.AuthorizationContext.TenantId;                

                //Figure out which locations are available for Key Vault
                location = GetKeyVaultLocation(resourcesClient);

                //Create a resource group in that location
                preCreatedVault = TestUtilities.GenerateName("pshtestvault");
                resourceGroupName = TestUtilities.GenerateName("pshtestrg");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
                var createResponse = CreateVault(mgmtClient, location, tenantId);                
            }

            initialized = true;
        }

        private static string GetKeyVaultLocation(ResourceManagementClient resourcesClient)
        {
            var providers = resourcesClient.Providers.Get("Microsoft.KeyVault");
            var location = providers.Provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.Name == "vaults")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
            return location.ToLowerInvariant().Replace(" ", "");
        }

        private VaultGetResponse CreateVault(KeyVaultManagementClient mgmtClient, string location, string tenantId)
        {
            var createResponse = mgmtClient.Vaults.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                vaultName: preCreatedVault,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string> { { tagName, tagValue } },
                    Properties = new VaultProperties
                    {
                        EnabledForDeployment = false,
                        Sku = new Sku { Family = "A", Name = "Premium" },
                        TenantId = Guid.Parse(tenantId),
                        VaultUri = "",
                        AccessPolicies = new AccessPolicyEntry[]
                        {

                        }
                    }
                }
                );
            return createResponse;
        }

        public void ResetPreCreatedVault()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var testFactory = new CSMTestEnvironmentFactory();
                var testEnv = testFactory.GetTestEnvironment();
                var resourcesClient = TestBase.GetServiceClient<ResourceManagementClient>(testFactory);
                var mgmtClient = TestBase.GetServiceClient<KeyVaultManagementClient>(testFactory);
                var tenantId = Guid.Parse(testEnv.AuthorizationContext.TenantId);

                var policies = new AccessPolicyEntry[] { };

                mgmtClient.Vaults.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                vaultName: preCreatedVault,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string> { { tagName, tagValue } },
                    Properties = new VaultProperties
                    {
                        EnabledForDeployment = false,
                        Sku = new Sku { Family = "A", Name = "Premium" },
                        TenantId = tenantId,
                        VaultUri = "",
                        AccessPolicies = policies
                    }
                }
                );
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Record && initialized)
                {
                    var testFactory = new CSMTestEnvironmentFactory();
                    var testEnv = testFactory.GetTestEnvironment();
                    var resourcesClient = TestBase.GetServiceClient<ResourceManagementClient>(testFactory);

                    resourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}
