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
using Microsoft.Azure.Commands.DataFactories.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Security;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.DataFactory
{
    public class NewDataFactoryEncryptValueTests : DataFactoryUnitTestBase
    {
        public NewDataFactoryEncryptValueTests()
        {
            base.SetupTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOnPermDatasourceEncryptionWithRawJsonContent()
        {
            SecureString secureString = new SecureString();
            string expectedOutput = "My encrypted string " + Guid.NewGuid();

            var cmdlet = new NewAzureDataFactoryEncryptValueCommand
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                DataFactoryClient = this.dataFactoriesClientMock.Object,
                Value = secureString,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                GatewayName = GatewayName
            };

            // Arrange
            this.dataFactoriesClientMock.Setup(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName)).Returns(expectedOutput);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            this.dataFactoriesClientMock.Verify(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(expectedOutput), Times.Once());
        }
    }
}