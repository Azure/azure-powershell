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
using Microsoft.DataTransfer.Gateway.Encryption;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Security;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.DataFactory
{
    public class NewDataFactoryEncryptValueTests : DataFactoryUnitTestBase
    {
        public NewDataFactoryEncryptValueTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOnPremDatasourceEncryptionSQLAuth()
        {
            SecureString secureString = new SecureString();
            string expectedOutput = "My encrypted string " + Guid.NewGuid();
            string linkedServiceType = "OnPremisesSqlLinkedService";
            string nonCredentialValue = "Driver=mydriver;server=myserver";
            string authenticationType = "Basic";
            string serverName = null;
            string databaseName = null;

            var cmdlet = new NewAzureDataFactoryEncryptValueCommand
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                DataFactoryClient = this.dataFactoriesClientMock.Object,
                Value = secureString,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                GatewayName = GatewayName,
                Type = linkedServiceType,
                NonCredentialValue = nonCredentialValue,
                AuthenticationType = authenticationType,
                Server = serverName,
                Database = databaseName
            };

            // Arrange
            this.dataFactoriesClientMock.Setup(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName, null, linkedServiceType, nonCredentialValue, authenticationType, serverName, databaseName)).Returns(expectedOutput);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            this.dataFactoriesClientMock.Verify(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName, null, linkedServiceType, nonCredentialValue, authenticationType, serverName, databaseName), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(expectedOutput), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOnPremDatasourceEncryptionWinAuth()
        {
            SecureString secureString = new SecureString();
            string expectedOutput = "My encrypted string " + Guid.NewGuid();
            string winAuthUserName = "foo";
            SecureString winAuthPassword = new SecureString();
            PSCredential credential = new PSCredential(winAuthUserName, winAuthPassword);
            string linkedServiceType = "OnPremisesFileSystemLinkedService";
            string nonCredentialValue = "Driver=mydriver;server=myserver";
            string authenticationType = "Basic";
            string serverName = null;
            string databaseName = null;

            var cmdlet = new NewAzureDataFactoryEncryptValueCommand
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                DataFactoryClient = this.dataFactoriesClientMock.Object,
                Value = secureString,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                GatewayName = GatewayName,
                Credential = credential,
                Type = linkedServiceType,
                NonCredentialValue = nonCredentialValue,
                AuthenticationType = authenticationType,
                Server = serverName,
                Database = databaseName
            };

            // Arrange
            this.dataFactoriesClientMock.Setup(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName, credential, linkedServiceType, nonCredentialValue, authenticationType, serverName, databaseName)).Returns(expectedOutput);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            this.dataFactoriesClientMock.Verify(f => f.OnPremisesEncryptString(secureString, ResourceGroupName, DataFactoryName, GatewayName, credential, linkedServiceType, nonCredentialValue, authenticationType, serverName, databaseName), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(expectedOutput), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOnPremDatasourceEncryption_LinkedServiceTypeParsing()
        {
            // Built-in linked service types
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesSqlLinkedService") == LinkedServiceType.OnPremisesSqlLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesFileSystemLinkedService") == LinkedServiceType.OnPremisesFileSystemLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesOracleLinkedService") == LinkedServiceType.OnPremisesOracleLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesOdbcLinkedService") == LinkedServiceType.OnPremisesOdbcLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesPostgreSqlLinkedService") == LinkedServiceType.OnPremisesPostgreSqlLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesTeradataLinkedService") == LinkedServiceType.OnPremisesTeradataLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesMySQLLinkedService") == LinkedServiceType.OnPremisesMySQLLinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesDB2LinkedService") == LinkedServiceType.OnPremisesDB2LinkedService);
            Assert.True(DataFactoryClient.GetLinkedServiceType("OnPremisesSybaseLinkedService") == LinkedServiceType.OnPremisesSybaseLinkedService);

            // Generic linked service types should be converted to Unknown type
            Assert.True(DataFactoryClient.GetLinkedServiceType("HdfsLinkedService") == LinkedServiceType.Unknown);
        }
    }
}