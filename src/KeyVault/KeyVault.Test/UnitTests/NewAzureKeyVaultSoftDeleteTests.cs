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
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Verify that New-AzKeyVault explicitly sets EnableSoftDelete=true in the request body
    /// so that Azure Policy checks requiring the property to be present are satisfied.
    /// </summary>
    public class NewAzureKeyVaultSoftDeleteTests : KeyVaultUnitTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateNewVault_Sets_EnableSoftDelete_True_In_VaultProperties()
        {
            // Arrange
            VaultCreateOrUpdateParameters capturedParameters = null;
            var mockVaultsOperations = new Mock<IVaultsOperations>();
            mockVaultsOperations
                .Setup(v => v.CreateOrUpdateWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<VaultCreateOrUpdateParameters>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, VaultCreateOrUpdateParameters, Dictionary<string, List<string>>, CancellationToken>(
                    (rg, name, parameters, headers, ct) => capturedParameters = parameters)
                .Returns(Task.FromResult(new AzureOperationResponse<Vault>
                {
                    Body = new Vault(
                        properties: new VaultProperties
                        {
                            TenantId = Guid.NewGuid(),
                            Sku = new Sku(SkuName.Standard),
                            AccessPolicies = new AccessPolicyEntry[] { },
                            VaultUri = "https://testvault.vault.azure.net"
                        },
                        name: "testvault",
                        location: "eastus")
                }));

            var mockClient = new Mock<IKeyVaultManagementClient>();
            mockClient.Setup(c => c.Vaults).Returns(mockVaultsOperations.Object);

            var vaultManagementClient = new VaultManagementClient();
            // Use reflection to set the private KeyVaultManagementClient property
            var prop = typeof(VaultManagementClient).GetProperty("KeyVaultManagementClient",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(vaultManagementClient, mockClient.Object);

            var createParameters = new VaultCreationOrUpdateParameters
            {
                Name = "testvault",
                ResourceGroupName = "testrg",
                Location = "eastus",
                SkuFamilyName = "A",
                SkuName = "Standard",
                TenantId = Guid.NewGuid(),
                EnableSoftDelete = true,
                SoftDeleteRetentionInDays = 90,
                NetworkAcls = new NetworkRuleSet()
            };

            // Act
            vaultManagementClient.CreateNewVault(createParameters);

            // Assert
            Assert.NotNull(capturedParameters);
            Assert.True(capturedParameters.Properties.EnableSoftDelete,
                "CreateNewVault must set EnableSoftDelete=true in the request body " +
                "to satisfy Azure Policy checks");
        }
    }
}
