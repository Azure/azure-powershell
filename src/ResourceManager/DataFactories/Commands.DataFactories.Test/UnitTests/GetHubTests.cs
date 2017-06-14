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
    public class GetHubTests : DataFactoryUnitTestBase
    {
        private const string hubName = "foo";

        private GetAzureDataFactoryHubCommand cmdlet;

        public GetHubTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            cmdlet = new GetAzureDataFactoryHubCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetHub()
        {
            // Arrange
            PSHub expected = new PSHub()
            {
                DataFactoryName = DataFactoryName,
                ResourceGroupName = ResourceGroupName,
                HubName = hubName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.FilterPSHubs(
                            It.Is<HubFilterOptions>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.Name == hubName)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock
                .Setup(c => c.GetHub(ResourceGroupName, DataFactoryName, hubName))
                .Returns(expected)
                .Verifiable();

            // Action
            cmdlet.Name = hubName;
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetHubWithEmptyName()
        {
            // Action
            cmdlet.Name = String.Empty;
            Exception exception = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            // Assert
            Assert.Contains("Value cannot be null", exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetHubWithWhiteSpaceName()
        {
            // Action
            cmdlet.Name = "   ";
            Exception exception = Assert.Throws<PSArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            // Assert
            Assert.Contains("Value cannot be null", exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListHubs()
        {
            // Arrange
            List<PSHub> expected = new List<PSHub>()
            {
                new PSHub()
                {
                    HubName = hubName,
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName
                },
                new PSHub()
                {
                    HubName = "anotherHub",
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName
                }
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.FilterPSHubs(
                            It.Is<HubFilterOptions>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.Name == null &&
                                    options.NextLink == null)))
                .CallBase()
                .Verifiable();

            dataFactoriesClientMock
                .Setup(f => f.ListHubs(It.Is<HubFilterOptions>(
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
