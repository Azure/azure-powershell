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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test.UnitTests
{
    public class RemovePipelineTests : DataFactoryUnitTestBase
    {
        private const string pipelineName = "foo";

        private RemoveAzureDataFactoryPipelineCommand cmdlet;

        public RemovePipelineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            cmdlet = new RemoveAzureDataFactoryPipelineCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                Name = pipelineName,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Force = true
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRemovePipeline()
        {
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

            // Arrange
            dataFactoriesClientMock.Setup(
                f => f.DeletePipeline(ResourceGroupName, DataFactoryName, pipelineName))
                .Returns(expectedStatusCode)
                .Verifiable();

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.VerifyAll();
        }
    }
}
