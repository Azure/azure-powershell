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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Security;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class RemoveKeyVaultSecretTests : KeyVaultUnitTestBase
    {
        private RemoveAzureKeyVaultSecret cmdlet;

        public RemoveKeyVaultSecretTests()
        {
            base.SetupTest();

            cmdlet = new RemoveAzureKeyVaultSecret()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = VaultName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRemoveSecretWithPassThruTest()
        {
            SecureString secureSecretValue = SecretValue.ConvertToSecureString();
            Secret expected = new Secret() { Name = SecretName, VaultName = VaultName, SecretValue = secureSecretValue };
            keyVaultClientMock.Setup(kv => kv.DeleteSecret(VaultName, SecretName)).Returns(expected).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = SecretName;
            cmdlet.Force = true;
            cmdlet.PassThru = true;
            cmdlet.ExecuteCmdlet();

            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());

            //No force but should continue
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(cr => cr.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.Force = false;
            cmdlet.PassThru = true;
            cmdlet.ExecuteCmdlet();

            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Exactly(2));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRemoveSecretWithNoPassThruTest()
        {
            SecureString secureSecretValue = SecretValue.ConvertToSecureString();
            Secret expected = new Secret() { Name = SecretName, VaultName = VaultName, SecretValue = secureSecretValue };
            keyVaultClientMock.Setup(kv => kv.DeleteSecret(VaultName, SecretName)).Returns(expected).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = SecretName;
            cmdlet.Force = true;
            cmdlet.ExecuteCmdlet();

            keyVaultClientMock.VerifyAll();

            // Without PassThru never call WriteObject
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CannotRemoveSecretWithoutShouldProcessOrForceConfirmationTest()
        {
            // Should process but without force
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);

            Secret expected = null;

            cmdlet.Name = SecretName;
            cmdlet.PassThru = true;
            cmdlet.ExecuteCmdlet();

            // Write object should be called with null input
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
            cmdlet.ExecuteCmdlet();

            // Write object should be called with null input
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Exactly(2));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorRemoveSecretWithPassThruTest()
        {
            keyVaultClientMock.Setup(kv => kv.DeleteSecret(VaultName, SecretName)).Throws(new Exception()).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = SecretName;
            cmdlet.Force = true;
            cmdlet.PassThru = true;
            try
            {
                cmdlet.ExecuteCmdlet();
            }
            catch { }

            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<Secret>()), Times.Never());
        }
    }
}
