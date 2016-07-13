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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test.UnitTests
{
    public class NewDataFactoryTests : DataFactoryUnitTestBase
    {
        private NewAzureDataFactoryCommand cmdlet;

        private IDictionary<string, string> tags;

        public NewDataFactoryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            tags = new Dictionary<string, string>() { { "foo", "bar" } };

            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            cmdlet = new NewAzureDataFactoryCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                Name = DataFactoryName,
                Location = Location,
                ResourceGroupName = ResourceGroupName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateDataFactory()
        {
            // Arrange
            DataFactory expected = new DataFactory()
            {
                Name = DataFactoryName,
                Location = Location,
                Properties = new DataFactoryProperties() { ProvisioningState = "Succeeded" }
            };

            dataFactoriesClientMock.Setup(
                f =>
                    f.CreatePSDataFactory(
                        It.Is<CreatePSDataFactoryParameters>(
                            parameters =>
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName &&
                                parameters.Location == Location)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                f => f.CreateOrUpdateDataFactory(ResourceGroupName, DataFactoryName, Location, tags))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.Tags = tags.ToHashtable();
            cmdlet.Force = true;
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<PSDataFactory>(
                            df =>
                                df.DataFactoryName == expected.Name &&
                                df.Location == expected.Location)),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowIfDataFactoryProvisioningFailed()
        {
            // Arrange
            DataFactory expected = new DataFactory()
            {
                Name = DataFactoryName,
                Location = Location,
                Properties = new DataFactoryProperties() { ProvisioningState = "Failed" }
            };

            dataFactoriesClientMock.Setup(
                f =>
                    f.CreatePSDataFactory(
                        It.Is<CreatePSDataFactoryParameters>(
                            parameters =>
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName &&
                                parameters.Location == Location)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                f => f.CreateOrUpdateDataFactory(ResourceGroupName, DataFactoryName, Location, tags))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.Tags = tags.ToHashtable();
            cmdlet.Force = true;

            // Assert
            Assert.Throws<ProvisioningFailedException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}
