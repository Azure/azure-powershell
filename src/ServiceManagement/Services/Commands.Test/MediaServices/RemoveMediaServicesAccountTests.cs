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
using Moq;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.MediaServices
{
    
    public class RemoveMediaServicesAccountTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProcessRemoveMediaServicesAccountTest()
        {
            // Setup
            Mock<IMediaServicesClient> clientMock = new Mock<IMediaServicesClient>();

            const string expectedName = "testacc";

            clientMock.Setup(f => f.DeleteAzureMediaServiceAccountAsync(expectedName)).Returns(
                Task.Factory.StartNew(() => new AzureOperationResponse { StatusCode = HttpStatusCode.NoContent }));

            // Test
            RemoveAzureMediaServiceCommand command = new RemoveAzureMediaServiceCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = expectedName,
                MediaServicesClient = clientMock.Object,
            };

            command.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            bool response = (bool)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.True(response);
        }
    }
}