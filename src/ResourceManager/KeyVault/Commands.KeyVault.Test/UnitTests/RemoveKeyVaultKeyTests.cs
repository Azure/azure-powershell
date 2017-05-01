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
using Xunit;
using WebKey = Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class RemoveKeyVaultKeyTests : KeyVaultUnitTestBase
    {
        private RemoveAzureKeyVaultKey cmdlet;
        private KeyAttributes keyAttributes;
        private WebKey.JsonWebKey webKey;
        private KeyBundle keyBundle;

        public RemoveKeyVaultKeyTests()
        {
            base.SetupTest();

            cmdlet = new RemoveAzureKeyVaultKey()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = VaultName
            };

            keyAttributes = new KeyAttributes(true, DateTime.Now, DateTime.Now, "HSM", new string[] { "All" }, null);
            webKey = new WebKey.JsonWebKey();
            keyBundle = new KeyBundle() { Attributes = keyAttributes, Key = webKey, Name = KeyName, VaultName = VaultName };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRemvoeKeyWithPassThruTest()
        {
            KeyBundle expected = keyBundle;
            keyVaultClientMock.Setup(kv => kv.DeleteKey(VaultName, KeyName)).Returns(expected).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(KeyName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = KeyName;
            cmdlet.Force = true;
            cmdlet.PassThru = true;
            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRemoveKeyWithNoPassThruTest()
        {
            KeyBundle expected = keyBundle;
            keyVaultClientMock.Setup(kv => kv.DeleteKey(VaultName, KeyName)).Returns(expected).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(KeyName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = KeyName;
            cmdlet.Force = true;
            cmdlet.ExecuteCmdlet();

            keyVaultClientMock.VerifyAll();

            // Without PassThru never call WriteObject
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CannotRemoveKeyWithoutShouldProcessOrForceConfirmationTest()
        {
            // Should process but without force
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(KeyName, It.IsAny<string>())).Returns(true);

            KeyBundle expected = null;

            cmdlet.Name = KeyName;
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
        public void ErrorRemvoeKeyWithPassThruTest()
        {
            keyVaultClientMock.Setup(kv => kv.DeleteKey(VaultName, KeyName)).Throws(new Exception()).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(KeyName, It.IsAny<string>())).Returns(true);
            cmdlet.Name = KeyName;
            cmdlet.Force = true;
            cmdlet.PassThru = true;
            try
            {
                cmdlet.ExecuteCmdlet();
            }
            catch { }

            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<KeyBundle>()), Times.Never());
        }
    }
}
