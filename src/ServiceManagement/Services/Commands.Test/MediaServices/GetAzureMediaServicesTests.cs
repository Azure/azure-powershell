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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.MediaServices;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.MediaServices
{
    
    public class GetAzureMediaServicesTests : TestBase
    {
        protected string SubscriptionId = "DE8C2681-0BCD-47DB-A8A6-A103D2D4A1B9";

        public GetAzureMediaServicesTests()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();
        }

        [Fact]
        public void ProcessGetMediaServicesTest()
        {
            // Setup
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();

            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            MediaServicesAccountListResponse response = new MediaServicesAccountListResponse();
            response.Accounts.Add(new MediaServicesAccountListResponse.MediaServiceAccount
            {
                AccountId = id1.ToString(),
                Name = "WAMS Account 1"
            });
            response.Accounts.Add(new MediaServicesAccountListResponse.MediaServiceAccount
            {
                   AccountId = id2.ToString(),
                   Name = "WAMS Account 2"
               });


            clientMock.Setup(f => f.GetMediaServiceAccountsAsync()).Returns(Task.Factory.StartNew(() => response));

            // Test
            GetAzureMediaServiceCommand getAzureMediaServiceCommand = new GetAzureMediaServiceCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                MediaServicesClient = clientMock.Object,
            };

            AzureSession.SetCurrentContext(new AzureSubscription {Id = new Guid(SubscriptionId)}, null, null);

            getAzureMediaServiceCommand.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)getAzureMediaServiceCommand.CommandRuntime).OutputPipeline.Count);
            IEnumerable<MediaServiceAccount> accounts = (IEnumerable<MediaServiceAccount>)((MockCommandRuntime)getAzureMediaServiceCommand.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.NotNull(accounts);
            Assert.True(accounts.Any(mediaservice => (mediaservice).AccountId == id1));
            Assert.True(accounts.Any(mediaservice => (mediaservice).AccountId == id2));
            Assert.True(accounts.Any(mediaservice => (mediaservice).Name.Equals("WAMS Account 1")));
            Assert.True(accounts.Any(mediaservice => (mediaservice).Name.Equals("WAMS Account 2")));
        }

        [Fact]
        public void ProcessGetMediaServiceByNameShouldReturnOneMatchingEntry()
        {
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();


            const string expectedName = "WAMS Account 1";
            MediaServicesAccountGetResponse detail = new MediaServicesAccountGetResponse
            {
                Account = new MediaServicesAccount() { AccountName = expectedName }
            };

            clientMock.Setup(f => f.GetMediaServiceAsync(detail.Account.AccountName)).Returns(Task.Factory.StartNew(() => detail));

            // Test
            GetAzureMediaServiceCommand getAzureMediaServiceCommand = new GetAzureMediaServiceCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                MediaServicesClient = clientMock.Object,
                Name = expectedName
            };
            AzureSession.SetCurrentContext(new AzureSubscription { Id = new Guid(SubscriptionId) }, null, null);
            getAzureMediaServiceCommand.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)getAzureMediaServiceCommand.CommandRuntime).OutputPipeline.Count);
            MediaServiceAccountDetails accounts = (MediaServiceAccountDetails)((MockCommandRuntime)getAzureMediaServiceCommand.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.NotNull(accounts);
            Assert.Equal(expectedName, accounts.Name);
        }

        [Fact]
        public void ProcessGetMediaServiceByNameShouldNotReturnEntriesForNoneMatchingName()
        {
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();
            string mediaServicesAccountName = Guid.NewGuid().ToString();


            clientMock.Setup(f => f.GetMediaServiceAsync(mediaServicesAccountName)).Returns(Task.Factory.StartNew(() =>
            {
                if (String.IsNullOrEmpty(mediaServicesAccountName))
                {
                    return new MediaServicesAccountGetResponse();
                }
                throw new ServiceManagementClientException(HttpStatusCode.NotFound,
                    new ServiceManagementError
                    {
                        Code = HttpStatusCode.NotFound.ToString(),
                        Message = "Account not found"
                    },
                    string.Empty);
            }));

            // Test
            GetAzureMediaServiceCommand getAzureMediaServiceCommand = new GetAzureMediaServiceCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                MediaServicesClient = clientMock.Object,
                Name = mediaServicesAccountName
            };

            AzureSession.SetCurrentContext(new AzureSubscription { Id = new Guid(SubscriptionId) }, null, null);
            Assert.Throws<ServiceManagementClientException>(()=> getAzureMediaServiceCommand.ExecuteCmdlet());
            Assert.Equal(0, ((MockCommandRuntime)getAzureMediaServiceCommand.CommandRuntime).OutputPipeline.Count);
        }
    }
}