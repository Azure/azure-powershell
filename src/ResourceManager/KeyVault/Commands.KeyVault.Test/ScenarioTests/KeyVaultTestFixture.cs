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

using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Sku = Microsoft.Azure.Management.KeyVault.Models.Sku;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultTestFixture : RMTestBase, IDisposable
    {
        private readonly HttpRecorderMode _mode;

        public string TagName { get; set; } = "testtag";
        public string TagValue { get; set; } = "testvalue";

        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public string PreCreatedVault { get; set; }

        private bool _initialized;
        public KeyVaultTestFixture()
        {
            // Initialize has bug which causes null reference exception
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();            
            _mode = HttpMockServer.GetCurrentMode();
        }

        public void Initialize(string className)
        {
            if (_initialized)
                return;

            if (_mode == HttpRecorderMode.Record)
            {
                using (MockContext context = MockContext.Start(new StackTrace().GetFrame(1).GetMethod().ReflectedType?.ToString(), new StackTrace().GetFrame(1).GetMethod().Name))
                {
                    var resourcesClient = context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                    var mgmtClient = context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                    var tenantId = TestEnvironmentFactory.GetTestEnvironment().Tenant;

                    //Figure out which locations are available for Key Vault
                    Location = GetKeyVaultLocation(resourcesClient);

                    //Create a resource group in that location
                    PreCreatedVault = TestUtilities.GenerateName("pshtestvault");
                    ResourceGroupName = TestUtilities.GenerateName("pshtestrg");

                    resourcesClient.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup { Location = Location });
                    CreateVault(mgmtClient, Location, tenantId);
                }
            }

            _initialized = true;
        }

        private static string GetKeyVaultLocation(ResourceManagementClient resourcesClient)
        {
            var provider = resourcesClient.Providers.Get("Microsoft.KeyVault");
            var location = provider.ResourceTypes.First(resType => resType.ResourceType.Contains("vaults")).Locations.FirstOrDefault();
            return location?.ToLowerInvariant().Replace(" ", "");
        }

        private void CreateVault(KeyVaultManagementClient mgmtClient, string location, string tenantId)
        {
            mgmtClient.Vaults.CreateOrUpdate(
                ResourceGroupName,
                PreCreatedVault,
                new VaultCreateOrUpdateParameters
                {
                    Location = location,
                    Tags = new Dictionary<string, string> { { TagName, TagValue } },
                    Properties = new VaultProperties
                    {
                        EnabledForDeployment = false,
                        Sku = new Sku { Name = SkuName.Premium },
                        TenantId = Guid.Parse(tenantId),
                        VaultUri = "",
                        AccessPolicies = new AccessPolicyEntry[]{ }
                    }
                });
        }

        public void ResetPreCreatedVault()
        {
            if (_mode == HttpRecorderMode.Record)
            {
                using (MockContext context = MockContext.Start(new StackTrace().GetFrame(1).GetMethod().ReflectedType?.ToString(), new StackTrace().GetFrame(1).GetMethod().Name))
                {
                    var mgmtClient = context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                    var tenantId = Guid.Parse(TestEnvironmentFactory.GetTestEnvironment().Tenant);

                    var policies = new AccessPolicyEntry[] { };

                    mgmtClient.Vaults.CreateOrUpdate(
                    ResourceGroupName,
                    PreCreatedVault,
                    new VaultCreateOrUpdateParameters
                    {
                        Location = Location,
                        Tags = new Dictionary<string, string> { { TagName, TagValue } },
                        Properties = new VaultProperties
                        {
                            EnabledForDeployment = false,
                            Sku = new Sku { Name = SkuName.Premium },
                            TenantId = tenantId,
                            VaultUri = "",
                            AccessPolicies = policies
                        }
                    });
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mode == HttpRecorderMode.Record && _initialized)
                {
                    using (MockContext context = MockContext.Start(new StackTrace().GetFrame(1).GetMethod().ReflectedType?.ToString(), new StackTrace().GetFrame(1).GetMethod().Name))
                    {
                        var resourcesClient = context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                        resourcesClient.ResourceGroups.Delete(ResourceGroupName);
                    }
                }
            }
        }
    }
}
