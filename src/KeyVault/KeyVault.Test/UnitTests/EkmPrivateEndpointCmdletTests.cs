using Azure;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Commands.EkmConnection;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class EkmPrivateEndpointCmdletTests : KeyVaultUnitTestBase
    {
        public EkmPrivateEndpointCmdletTests()
        {
            SetupTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Create_DeclinedShouldProcessDoesNotWrite()
        {
            commandRuntimeMock.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var cmdlet = new NewAzKeyVaultManagedHsmEkmPrivateEndpoint
            {
                HsmName = "hsm", Name = "pe2", PrivateLinkServiceAlias = "proxy.region.azure.privatelinkservice",
                Track2DataClient = keyVaultClientMock.Object, CommandRuntime = commandRuntimeMock.Object
            };

            cmdlet.ExecuteCmdlet();

            keyVaultClientMock.Verify(client => client.CreateManagedHsmEkmPrivateEndpoint(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/privateLinkServices/proxy")]
        public void Create_RejectsInvalidAlias(string alias)
        {
            var cmdlet = new NewAzKeyVaultManagedHsmEkmPrivateEndpoint
            {
            HsmName = "hsm", Name = "pe2", PrivateLinkServiceAlias = alias,
                Track2DataClient = keyVaultClientMock.Object, CommandRuntime = commandRuntimeMock.Object
            };

            Assert.Throws<AzPSArgumentException>(() => cmdlet.ExecuteCmdlet());
            Assert.Empty(keyVaultClientMock.Invocations);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProvisioningWait_DoesNotRequireProviderApproval()
        {
            var endpoint = new PSKeyVaultEkmPrivateEndpoint
            {
                Name = "pe2", ProvisioningState = "Succeeded",
                PrivateLinkServiceConnectionState = new PSKeyVaultEkmPrivateEndpointConnectionState { Status = "Pending" }
            };
            keyVaultClientMock.Setup(client => client.GetManagedHsmEkmPrivateEndpoint("hsm", "pe2", It.IsAny<CancellationToken>()))
                .Returns(new[] { endpoint });
            var cmdlet = CreateWait();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(runtime => runtime.WriteObject(endpoint), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApprovalWait_StopsOnRejectedConnection()
        {
            keyVaultClientMock.Setup(client => client.GetManagedHsmEkmPrivateEndpoint("hsm", "pe2", It.IsAny<CancellationToken>()))
                .Returns(new[] { new PSKeyVaultEkmPrivateEndpoint
                {
                    Name = "pe2", ProvisioningState = "Succeeded",
                    PrivateLinkServiceConnectionState = new PSKeyVaultEkmPrivateEndpointConnectionState { Status = "Rejected" }
                } });
            var cmdlet = CreateWait();
            cmdlet.ConnectionStatus = "Approved";

            Assert.Throws<AzPSInvalidOperationException>(() => cmdlet.ExecuteCmdlet());
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(404)]
        [InlineData(403)]
        public void DeletionWait_OnlyAcceptsNotFound(int responseStatus)
        {
            keyVaultClientMock.Setup(client => client.GetManagedHsmEkmPrivateEndpoint("hsm", "pe2", It.IsAny<CancellationToken>()))
                .Throws(new RequestFailedException(responseStatus, "Service response"));
            var cmdlet = CreateWait();
            cmdlet.Deleted = true;

            if (responseStatus == 404)
            {
                cmdlet.ExecuteCmdlet();
            }
            else
            {
                Assert.Throws<RequestFailedException>(() => cmdlet.ExecuteCmdlet());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Wait_CancellationPreventsFurtherReads()
        {
            var cmdlet = new CancellableWait
            {
                HsmName = "hsm", Name = "pe2", Track2DataClient = keyVaultClientMock.Object,
                CommandRuntime = commandRuntimeMock.Object
            };
            cmdlet.Cancel();

            Assert.Throws<OperationCanceledException>(() => cmdlet.ExecuteCmdlet());
            Assert.Empty(keyVaultClientMock.Invocations);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Wait_RejectsConflictingConditions()
        {
            var cmdlet = CreateWait();
            cmdlet.Deleted = true;
            cmdlet.Exist = true;

            Assert.Throws<AzPSArgumentException>(() => cmdlet.ExecuteCmdlet());
            Assert.Empty(keyVaultClientMock.Invocations);
        }

        private WaitAzKeyVaultManagedHsmEkmPrivateEndpoint CreateWait()
        {
            return new WaitAzKeyVaultManagedHsmEkmPrivateEndpoint
            {
                HsmName = "hsm", Name = "pe2", Timeout = 1, Interval = 1,
                Track2DataClient = keyVaultClientMock.Object, CommandRuntime = commandRuntimeMock.Object
            };
        }

        private class CancellableWait : WaitAzKeyVaultManagedHsmEkmPrivateEndpoint
        {
            public void Cancel()
            {
                StopProcessing();
            }
        }
    }
}