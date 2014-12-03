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

using Microsoft.Azure.Commands.KeyVault.Cmdlets;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Security;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class SetKeyVaultSecretTests : KeyVaultUnitTestBase
    {
        private SetAzureKeyVaultSecret cmdlet;

        public SetKeyVaultSecretTests()
        {
            base.SetupTest();

            cmdlet = new SetAzureKeyVaultSecret()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = VaultName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetSecretTest()
        {
            SecureString secureSecretValue = SecretValue.ToSecureString();
            Secret expected = new Secret() { Name = SecretName, VaultName = VaultName, SecretValue = secureSecretValue, Version = SecretVersion };
            keyVaultClientMock.Setup(kv => kv.SetSecret(VaultName, SecretName, secureSecretValue)).Returns(expected).Verifiable();

            cmdlet.Name = SecretName;
            cmdlet.SecretValue = secureSecretValue;
            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorSetSecretTest()
        {
            SecureString secureSecretValue = SecretValue.ToSecureString();
            keyVaultClientMock.Setup(kv => kv.SetSecret(VaultName, SecretName, secureSecretValue))
                .Throws(new Exception("exception")).Verifiable();

            cmdlet.Name = SecretName;
            cmdlet.SecretValue = secureSecretValue;
            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteError(It.IsAny<ErrorRecord>()), Times.Once());
        }
    }
}
