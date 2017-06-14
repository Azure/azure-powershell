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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.MediaServices;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.MediaServices
{
    
    public class NewMediaServicesAccountTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMediaServiceAccountShouldPassWithValidParameters()
        {
            // Setup
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();

            const string storageAccountName = "teststorage";
            const string storageAccountKey = "key";
            const string accountName = "testaccount";
            const string region = "West US";
            const string blobStorageEndpointUri = "http://awesome.blob.core.windows.net/";

            MediaServicesAccountCreateParameters request = new MediaServicesAccountCreateParameters
            {
                AccountName = accountName,
                BlobStorageEndpointUri = new Uri(blobStorageEndpointUri),
                Region = region,
                StorageAccountKey = storageAccountKey,
                StorageAccountName = storageAccountName

            };

            clientMock.Setup(f => f.CreateNewAzureMediaServiceAsync(It.Is<MediaServicesAccountCreateParameters>(creationRequest => request.AccountName == accountName))).Returns(
                Task.Factory.StartNew(() => new MediaServicesAccountCreateResponse
                {
                    Account = new MediaServicesCreatedAccount {
                        AccountId = Guid.NewGuid().ToString(),
                        AccountName = request.AccountName,
                        SubscriptionId = Guid.NewGuid().ToString()
                   }
                }));


            clientMock.Setup(f => f.GetStorageServiceKeysAsync(storageAccountName)).Returns(
                Task.Factory.StartNew(() => new StorageAccountGetKeysResponse
            {
                PrimaryKey = storageAccountKey,
                SecondaryKey = storageAccountKey


            }));


            clientMock.Setup(f => f.GetStorageServicePropertiesAsync(storageAccountName)).Returns(Task.Factory.StartNew(() =>
            {
                StorageAccountGetResponse response = new StorageAccountGetResponse
                {
                    StorageAccount = new StorageAccount
                        {
                            Properties = new StorageAccountProperties()   
                        }
                };
                response.StorageAccount.Properties.Endpoints.Add(new Uri(blobStorageEndpointUri));
                return response;
            }));

            // Test
            NewAzureMediaServiceCommand command = new NewAzureMediaServiceCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = accountName,
                Location = region,
                StorageAccountName = storageAccountName,
                MediaServicesClient = clientMock.Object,
            };

            command.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            AccountCreationResult accountCreationResult = (AccountCreationResult)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.NotNull(accountCreationResult);
            Assert.Equal(accountName, accountCreationResult.Name);
        }
    }
}