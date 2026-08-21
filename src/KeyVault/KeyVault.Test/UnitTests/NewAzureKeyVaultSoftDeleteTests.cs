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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using KVSku = Microsoft.Azure.Management.KeyVault.Models.Sku;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Verify that New-AzKeyVault explicitly sets EnableSoftDelete=true in the request body
    /// so that Azure Policy checks requiring the property to be present are satisfied.
    /// </summary>
    public class NewAzureKeyVaultSoftDeleteTests : KeyVaultUnitTestBase
    {
        private VaultCreateOrUpdateParameters _capturedSdkParameters;
        private VaultManagementClient _vaultManagementClient;

        /// <summary>
        /// A fake HTTP handler that returns an empty resource list for any GET (FilterResources)
        /// and prevents real network calls during unit tests.
        /// </summary>
        private class FakeHttpHandler : HttpClientHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"value\":[]}")
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return Task.FromResult(response);
            }
        }

        private void SetupVaultManagementClient()
        {
            _capturedSdkParameters = null;

            var mockVaultsOps = new Mock<IVaultsOperations>();
            mockVaultsOps
                .Setup(v => v.CreateOrUpdateWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<VaultCreateOrUpdateParameters>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, VaultCreateOrUpdateParameters, Dictionary<string, List<string>>, CancellationToken>(
                    (rg, name, parameters, headers, ct) => _capturedSdkParameters = parameters)
                .Returns(Task.FromResult(new AzureOperationResponse<Vault>
                {
                    Body = new Vault(
                        properties: new VaultProperties
                        {
                            TenantId = Guid.NewGuid(),
                            Sku = new KVSku(SkuName.Standard),
                            AccessPolicies = new AccessPolicyEntry[] { },
                            VaultUri = "https://testvault.vault.azure.net"
                        },
                        name: "testvault",
                        location: "eastus")
                }));

            var mockKvMgmtClient = new Mock<IKeyVaultManagementClient>();
            mockKvMgmtClient.Setup(c => c.Vaults).Returns(mockVaultsOps.Object);

            _vaultManagementClient = new VaultManagementClient();
            typeof(VaultManagementClient)
                .GetProperty("KeyVaultManagementClient", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(_vaultManagementClient, mockKvMgmtClient.Object);
        }

        private ResourceManagementClient CreateFakeResourceClient()
        {
            var client = new ResourceManagementClient(
                new Microsoft.Rest.TokenCredentials("fake-token"),
                new FakeHttpHandler());
            client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
            return client;
        }

        /// <summary>
        /// Exercises NewAzureKeyVault.ExecuteCmdlet() end-to-end and verifies that
        /// the cmdlet hardcodes EnableSoftDelete=true in the outgoing request.
        /// This test would FAIL if the assignment at NewAzureKeyVault.cs line 171
        /// were removed, because VaultManagementClient is a pure pass-through
        /// (as proved by VaultManagementClient_Does_Not_Default_EnableSoftDelete).
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_Sets_EnableSoftDelete_True_In_Request()
        {
            // Arrange
            SetupVaultManagementClient();

            var cmdRuntimeMock = new Mock<ICommandRuntime>();
            cmdRuntimeMock.Setup(cr => cr.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var cmdlet = new NewAzureKeyVault
            {
                CommandRuntime = cmdRuntimeMock.Object,
                Name = "test-vault",
                ResourceGroupName = "test-rg",
                Location = "eastus"
            };
            cmdlet.KeyVaultManagementClient = _vaultManagementClient;
            cmdlet.ResourceClient = CreateFakeResourceClient();

            // Act
            cmdlet.ExecuteCmdlet();

            // Assert
            Assert.NotNull(_capturedSdkParameters);
            Assert.True(_capturedSdkParameters.Properties.EnableSoftDelete,
                "NewAzureKeyVault.ExecuteCmdlet() must set EnableSoftDelete=true in the request body " +
                "so that Azure Policy checks requiring the property to be present are satisfied.");
        }

        /// <summary>
        /// Proves VaultManagementClient.CreateNewVault is a pure pass-through:
        /// it does NOT inject a default for EnableSoftDelete.
        /// Combined with ExecuteCmdlet_Sets_EnableSoftDelete_True_In_Request, this proves
        /// that only the cmdlet's hardcoded assignment provides the value.
        /// If someone removes EnableSoftDelete=true from NewAzureKeyVault.cs,
        /// the request would go out with EnableSoftDelete=null and Azure Policy would reject it.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VaultManagementClient_Does_Not_Default_EnableSoftDelete()
        {
            // Arrange
            SetupVaultManagementClient();

            var createParameters = new VaultCreationOrUpdateParameters
            {
                Name = "testvault",
                ResourceGroupName = "testrg",
                Location = "eastus",
                SkuFamilyName = "A",
                SkuName = "Standard",
                TenantId = Guid.NewGuid(),
                EnableSoftDelete = null, // Deliberately not set
                SoftDeleteRetentionInDays = 90,
                NetworkAcls = new NetworkRuleSet()
            };

            // Act
            _vaultManagementClient.CreateNewVault(createParameters);

            // Assert - null in means null out; client does NOT inject a default
            Assert.NotNull(_capturedSdkParameters);
            Assert.Null(_capturedSdkParameters.Properties.EnableSoftDelete);
        }
    }
}
