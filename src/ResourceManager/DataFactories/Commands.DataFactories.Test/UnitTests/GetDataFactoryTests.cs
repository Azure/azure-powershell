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
    public class GetDataFactoryTests : DataFactoryUnitTestBase
    {
        private GetAzureDataFactoryCommand cmdlet;

        public GetDataFactoryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            cmdlet = new GetAzureDataFactoryCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetDataFactory()
        {
            // Arrange
            PSDataFactory expected = new PSDataFactory() { DataFactoryName = DataFactoryName, ResourceGroupName = ResourceGroupName };

            dataFactoriesClientMock.Setup(
                c =>
                    c.FilterPSDataFactories(
                        It.Is<DataFactoryFilterOptions>(
                            options =>
                                options.Name == DataFactoryName &&
                                options.ResourceGroupName == ResourceGroupName &&
                                options.NextLink == null)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(c => c.GetDataFactory(ResourceGroupName, DataFactoryName))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.ResourceGroupName = ResourceGroupName;
            cmdlet.Name = "  ";
            Exception whiteSpace = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Name = "";
            Exception empty = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Name = DataFactoryName;
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();
            Assert.Contains("Value cannot be null", whiteSpace.Message);
            Assert.Contains("Value cannot be null", empty.Message);
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListDataFactories()
        {
            List<PSDataFactory> expected = new List<PSDataFactory>()
            {
                new PSDataFactory() {DataFactoryName = DataFactoryName, ResourceGroupName = ResourceGroupName},
                new PSDataFactory() {DataFactoryName = "datafactory1", ResourceGroupName = ResourceGroupName}
            };

            // Arrange
            dataFactoriesClientMock.Setup(
                c =>
                    c.FilterPSDataFactories(
                        It.Is<DataFactoryFilterOptions>(
                            options => options.Name == null && options.ResourceGroupName == ResourceGroupName && options.NextLink == null)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock.Setup(c => c.ListDataFactories(It.Is<DataFactoryFilterOptions>(
                options =>
                    options.Name == null && options.ResourceGroupName == ResourceGroupName && options.NextLink == null)))
                .Returns(expected)
                .Verifiable();

            cmdlet.ResourceGroupName = ResourceGroupName;

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(expected, true), Times.Once());
        }
    }
}
