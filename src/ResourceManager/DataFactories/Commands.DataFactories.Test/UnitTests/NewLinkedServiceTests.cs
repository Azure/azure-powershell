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
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test.UnitTests
{
    public class NewLinkedServiceTests : DataFactoryUnitTestBase
    {
        private const string linkedServiceName = "foo1";

        private const string filePath = "linkedService.json";

        private const string rawJsonContent = @"
{
    name: ""foo2"",
    properties:
    {
        type: ""HDInsightBYOCLinkedService"",
        clusterUri: ""https://MyCluster.azurehdinsight.net/"",
        userName: ""MyUserName"",
        password: ""$EncryptedString$MyEncryptedPassword"",
        linkedServiceName: ""MyStorageAssetName"",
    }
}
";

        private NewAzureDataFactoryLinkedServiceCommand cmdlet;

        public NewLinkedServiceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            cmdlet = new NewAzureDataFactoryLinkedServiceCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                Name = linkedServiceName,
                DataFactoryName = DataFactoryName,
                ResourceGroupName = ResourceGroupName
            };
        }

        // ToDo: enable the tests when we can set readonly provisioning state in test
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateLinkedService()
        {
            // Arrange
            LinkedService expected = new LinkedService()
            {
                Name = linkedServiceName,
                Properties = new LinkedServiceProperties(new AzureStorageLinkedService("myconnectionstring"))
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSLinkedService(
                        It.Is<CreatePSLinkedServiceParameters>(
                            parameters =>
                                parameters.Name == linkedServiceName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdateLinkedService(ResourceGroupName, DataFactoryName, linkedServiceName, rawJsonContent))
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
                        It.Is<PSLinkedService>(
                            ls =>
                                ResourceGroupName == ls.ResourceGroupName &&
                                DataFactoryName == ls.DataFactoryName &&
                                expected.Name == ls.LinkedServiceName &&
                                expected.Properties == ls.Properties)),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowIfLinkedServiceProvisioningFailed()
        {
            // Arrange
            LinkedService expected = new LinkedService()
            {
                Name = linkedServiceName,
                Properties = new LinkedServiceProperties(new AzureStorageLinkedService("myconnectionstring"))
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSLinkedService(
                        It.Is<CreatePSLinkedServiceParameters>(
                            parameters =>
                                parameters.Name == linkedServiceName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdateLinkedService(ResourceGroupName, DataFactoryName, linkedServiceName, rawJsonContent))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.File = filePath;
            cmdlet.Force = true;

            // Assert
            Assert.Throws<ProvisioningFailedException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidJsonLinkedService()
        {
            string malformedJson = rawJsonContent.Replace(":", "-");

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
               .Returns(malformedJson)
               .Verifiable();

            // Action
            cmdlet.File = filePath;
            cmdlet.Force = true;

            Assert.Throws<JsonSerializationException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}
