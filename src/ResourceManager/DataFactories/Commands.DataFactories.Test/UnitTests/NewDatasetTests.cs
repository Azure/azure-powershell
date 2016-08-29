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
    public class NewDatasetTests : DataFactoryUnitTestBase
    {
        private const string datasetName = "foo1";

        private const string filePath = "dataset.json";

        private const string rawJsonContent = @"
{
    name: ""foo2"",
    properties:
    {
        structure:  
        [ 
            { name: ""slicetimestamp"", position: 0, type: ""String""},
            { name: ""projectname"", position: 1, type: ""String""},
            { name: ""pageviews"", position: 2, type: ""Decimal""}
        ],
        location: 
        {
            type: ""AzureBlobLocation"",
            blobPath: ""$$Text.Format('wikidatagateway/wikisampledataout/{0:yyyyMMddHH}', SliceStart)"",
            tableName: ""LinkedService-CuratedWikiData""
        },
        availability: 
        {
            frequency: ""Hour"",
            interval: 1
        }
    }
}
";

        private NewAzureDataFactoryDatasetCommand cmdlet;

        public NewDatasetTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup((m) => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            cmdlet = new NewAzureDataFactoryDatasetCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                Name = datasetName,
                DataFactoryName = DataFactoryName,
                ResourceGroupName = ResourceGroupName
            };
        }

        // ToDo: enable the tests when we can set readonly provisioning state in test
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateDataset()
        {
            // Arrange
            Dataset expected = new Dataset()
            {
                Name = datasetName,
                Properties = new DatasetProperties()
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSDataset(
                        It.Is<CreatePSDatasetParameters>(
                            parameters =>
                                parameters.Name == datasetName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdateDataset(ResourceGroupName, DataFactoryName, datasetName, rawJsonContent))
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
                        It.Is<PSDataset>(
                            tbl =>
                                ResourceGroupName == tbl.ResourceGroupName &&
                                DataFactoryName == tbl.DataFactoryName &&
                                expected.Name == tbl.DatasetName)),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowIfDatasetProvisioningFailed()
        {
            // Arrange
            Dataset expected = new Dataset()
            {
                Name = datasetName,
                Properties = new DatasetProperties()
            };

            dataFactoriesClientMock.Setup(c => c.ReadJsonFileContent(It.IsAny<string>()))
                .Returns(rawJsonContent)
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreatePSDataset(
                        It.Is<CreatePSDatasetParameters>(
                            parameters =>
                                parameters.Name == datasetName &&
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(
                c =>
                    c.CreateOrUpdateDataset(ResourceGroupName, DataFactoryName, datasetName, rawJsonContent))
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
