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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test.UnitTests
{
    public class NewPipelineTests : DataFactoryUnitTestBase
    {
        private const string pipelineName = "foo1";

        private const string filePath = "pipeline.json";

        private const string rawJsonContent = @"{
    name: ""foo"",
    properties:
    {
        description : ""Sample Data Pipeline""        
    }
}";

        private NewAzureDataFactoryPipelineCommand cmdlet;

        public NewPipelineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            cmdlet = new NewAzureDataFactoryPipelineCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                Name = pipelineName,
                DataFactoryName = DataFactoryName,
                ResourceGroupName = ResourceGroupName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreatePipeline()
        {
            // Arrange
            Pipeline expected = new Pipeline()
            {
                Name = pipelineName,
                Properties = new PipelineProperties() { ProvisioningState = "Succeeded" }
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSPipeline(
                        It.Is<CreatePSPipelineParameters>(
                            parameters =>
                                parameters.Name == pipelineName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdatePipeline(ResourceGroupName, DataFactoryName, pipelineName, rawJsonContent))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.File = filePath;
            cmdlet.Force = true;
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<PSPipeline>(
                            p =>
                                ResourceGroupName == p.ResourceGroupName &&
                                DataFactoryName == p.DataFactoryName &&
                                expected.Name == p.PipelineName)),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowIfPipelineProvisioningFailed()
        {
            // Arrange
            Pipeline expected = new Pipeline()
            {
                Name = pipelineName,
                Properties = new PipelineProperties() { ProvisioningState = "Failed" }
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSPipeline(
                        It.Is<CreatePSPipelineParameters>(
                            parameters =>
                                parameters.Name == pipelineName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdatePipeline(ResourceGroupName, DataFactoryName, pipelineName, rawJsonContent))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.File = filePath;
            cmdlet.Force = true;

            // Assert
            Assert.Throws<ProvisioningFailedException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}
