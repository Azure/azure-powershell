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

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.MediaServices;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.MediaServices;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Moq;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.MediaServices
{
    
    public class RegenerateMediaServicesAccountTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RegenerateMediaServicesAccountTest()
        {
            // Setup
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();

            const string newKey = "newkey";
            const string expectedName = "testacc";

            clientMock.Setup(f => f.RegenerateMediaServicesAccountAsync(expectedName, MediaServicesKeyType.Primary)).Returns(
                Task.Factory.StartNew(() => new AzureOperationResponse { StatusCode = HttpStatusCode.OK }));

            MediaServicesAccountGetResponse detail = new MediaServicesAccountGetResponse
            {
                Account = new MediaServicesAccount {
                    AccountName = expectedName,
                    StorageAccountKeys = new MediaServicesAccount.AccountKeys
                    {
                        Primary = newKey
                    }
               }
            };

            clientMock.Setup(f => f.GetMediaServiceAsync(expectedName)).Returns(Task.Factory.StartNew(() => detail));

            // Test
            NewAzureMediaServiceKeyCommand command = new NewAzureMediaServiceKeyCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = expectedName,
                KeyType = MediaServicesKeyType.Primary,
                MediaServicesClient = clientMock.Object,
            };

            command.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            string key = (string)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.Equal(newKey, key);
        }
    }
}