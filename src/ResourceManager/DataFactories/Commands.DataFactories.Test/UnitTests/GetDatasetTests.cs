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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public class GetDatasetTests : DataFactoryUnitTestBase
    {
        private const string datasetName = "foo";

        private GetAzureDataFactoryDatasetCommand cmdlet;

        public GetDatasetTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            cmdlet = new GetAzureDataFactoryDatasetCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetDataset()
        {
            // Arrange
            PSDataset expected = new PSDataset()
            {
                DatasetName = datasetName,
                DataFactoryName = DataFactoryName,
                ResourceGroupName = ResourceGroupName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.FilterPSDatasets(
                            It.Is<DatasetFilterOptions>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.Name == datasetName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock
                .Setup(c => c.GetDataset(ResourceGroupName, DataFactoryName, datasetName))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.Name = "  ";
            Exception whiteSpace = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Name = "";
            Exception empty = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Name = datasetName;
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();
            Assert.Contains("Value cannot be null", whiteSpace.Message);
            Assert.Contains("Value cannot be null", empty.Message);
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListDatasets()
        {
            // Arrange
            List<PSDataset> expected = new List<PSDataset>()
            {
                new PSDataset()
                {
                    DatasetName = datasetName,
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName
                },
                new PSDataset()
                {
                    DatasetName = "anotherDataset",
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName
                }
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.FilterPSDatasets(
                            It.Is<DatasetFilterOptions>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.Name == null &&
                                    options.NextLink == null)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock
                .Setup(f => f.ListDatasets(It.Is<DatasetFilterOptions>(
                    options =>
                        options.ResourceGroupName == ResourceGroupName &&
                        options.DataFactoryName == DataFactoryName &&
                        options.Name == null &&
                        options.NextLink == null)))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(expected, true), Times.Once());
        }
    }
}
