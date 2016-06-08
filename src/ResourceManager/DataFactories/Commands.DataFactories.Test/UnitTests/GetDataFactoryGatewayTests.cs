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

using Microsoft.Azure.Commands.DataFactories;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Test;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Gateway
{
    public class GetDataFactoryGatewayTests : DataFactoryUnitTestBase
    {
        private GetAzureDataFactoryGatewayCommand _cmdlet;

        public GetDataFactoryGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            _cmdlet = new GetAzureDataFactoryGatewayCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetGateway()
        {
            var expectedOutput = new PSDataFactoryGateway
            {
                Name = GatewayName,
                Status = GatewayStatus.NeedRegistration
            };

            dataFactoriesClientMock.Setup(f => f.GetGateway(ResourceGroupName, DataFactoryName, GatewayName))
                                   .Returns(expectedOutput).Verifiable();

            _cmdlet.Name = GatewayName;
            _cmdlet.DataFactoryName = DataFactoryName;

            _cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(expectedOutput), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListGateways()
        {
            var expectedOutputs = new List<PSDataFactoryGateway>()
                {
                    new PSDataFactoryGateway()
                        {
                            Name = GatewayName,
                            Status = GatewayStatus.NeedRegistration
                        },

                    new PSDataFactoryGateway()
                        {
                            Name = "foo2",
                            Status = GatewayStatus.NeedRegistration
                        }
                };


            dataFactoriesClientMock.Setup(f => f.ListGateways(ResourceGroupName, DataFactoryName))
                                    .Returns(expectedOutputs).Verifiable();

            _cmdlet.DataFactoryName = DataFactoryName;

            _cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(expectedOutputs, true), Times.Once());
        }
    }
}
