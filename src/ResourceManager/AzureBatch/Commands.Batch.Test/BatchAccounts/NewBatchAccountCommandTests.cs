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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Accounts
{
    public class NewBatchAccountCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchAccountCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchAccountCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchAccountTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string location = "location";
            AccountCreateParameters actualCreateParameters = null;

            // Setup the mock client to return a fake response and capture the account create parameters
            BatchAccount accountResource = BatchTestHelpers.CreateAccountResource(accountName, resourceGroup, location);
            BatchAccountContext fakeResponse = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource, null);

            batchClientMock.Setup(b => b.CreateAccount(It.IsAny<AccountCreateParameters>()))
                .Returns(fakeResponse)
                .Callback((AccountCreateParameters p) => actualCreateParameters = p);

            // Setup and run the cmdlet
            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Location = location;
            cmdlet.ExecuteCmdlet();

            // Verify the fake response was written to the pipeline and that the captured account create
            // parameters matched expectations.
            commandRuntimeMock.Verify(r => r.WriteObject(fakeResponse), Times.Once());
            Assert.Equal(accountName, actualCreateParameters.BatchAccount);
            Assert.Equal(resourceGroup, actualCreateParameters.ResourceGroup);
            Assert.Equal(location, actualCreateParameters.Location);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchWithAutoStorageAccountTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string location = "location";
            string storageId = "storageId";
            AccountCreateParameters actualCreateParameters = null;

            // Setup the mock client to return a fake response and capture the account create parameters
            BatchAccount accountResource = BatchTestHelpers.CreateAccountResource(accountName, resourceGroup, location);
            BatchAccountContext fakeResponse = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource, null);

            batchClientMock.Setup(b => b.CreateAccount(It.IsAny<AccountCreateParameters>()))
                .Returns(fakeResponse)
                .Callback((AccountCreateParameters p) => actualCreateParameters = p);

            // Setup and run the cmdlet
            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Location = location;
            cmdlet.AutoStorageAccountId = storageId;
            cmdlet.ExecuteCmdlet();

            // Verify the fake response was written to the pipeline and that the captured account create
            // parameters matched expectations.
            commandRuntimeMock.Verify(r => r.WriteObject(fakeResponse), Times.Once());
            Assert.Equal(accountName, actualCreateParameters.BatchAccount);
            Assert.Equal(resourceGroup, actualCreateParameters.ResourceGroup);
            Assert.Equal(location, actualCreateParameters.Location);
            Assert.Equal(storageId, actualCreateParameters.AutoStorageAccountId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateUserSubscriptionBatchAccount()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string location = "location";
            string keyVaultId = "subscriptions/0000/resourceGroups/resourceGroup/providers/Microsoft.KeyVault/vaults/myVault";
            string keyVaultUrl = "https://myVault.vault.azure.com";
            PoolAllocationMode allocationMode = PoolAllocationMode.UserSubscription;
            AccountCreateParameters actualCreateParameters = null;

            // Setup the mock client to return a fake response and capture the account create parameters
            BatchAccount accountResource = BatchTestHelpers.CreateAccountResource(accountName, resourceGroup, location);
            BatchAccountContext fakeResponse = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource, null);

            batchClientMock.Setup(b => b.CreateAccount(It.IsAny<AccountCreateParameters>()))
                .Returns(fakeResponse)
                .Callback((AccountCreateParameters p) => actualCreateParameters = p);

            // Setup and run the cmdlet
            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Location = location;
            cmdlet.PoolAllocationMode = allocationMode;
            cmdlet.KeyVaultId = keyVaultId;
            cmdlet.KeyVaultUrl = keyVaultUrl;
            cmdlet.ExecuteCmdlet();

            // Verify the fake response was written to the pipeline and that the captured account create
            // parameters matched expectations.
            commandRuntimeMock.Verify(r => r.WriteObject(fakeResponse), Times.Once());
            Assert.Equal(accountName, actualCreateParameters.BatchAccount);
            Assert.Equal(resourceGroup, actualCreateParameters.ResourceGroup);
            Assert.Equal(location, actualCreateParameters.Location);
            Assert.Equal(allocationMode, actualCreateParameters.PoolAllocationMode);
            Assert.Equal(keyVaultId, actualCreateParameters.KeyVaultId);
            Assert.Equal(keyVaultUrl, actualCreateParameters.KeyVaultUrl);
        }
    }
}
