using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
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
            
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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
