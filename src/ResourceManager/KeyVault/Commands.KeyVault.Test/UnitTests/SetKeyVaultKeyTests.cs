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
using Xunit;
using WebKey = Microsoft.Azure.Commands.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class SetKeyVaultKeyTests : KeyVaultUnitTestBase
    {
        private SetAzureKeyVaultKey cmdlet;
        private KeyAttributes keyAttributes;
        private WebKey.JsonWebKey webKey;
        private KeyBundle keyBundle;

        public SetKeyVaultKeyTests()
        {
            base.SetupTest();

            keyAttributes = new KeyAttributes(true, DateTime.Now, DateTime.Now, null, null);
            webKey = new WebKey.JsonWebKey();
            keyBundle = new KeyBundle() { Attributes = keyAttributes, Key = webKey, Name = KeyName, VaultName = VaultName, Version = KeyVersion };

            cmdlet = new SetAzureKeyVaultKey()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = VaultName,
                Enable = (bool)keyAttributes.Enabled,
                Expires = keyAttributes.Expires,
                NotBefore = keyAttributes.NotBefore,
                Name = KeyName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetKeyTest()
        {
            KeyBundle expected = keyBundle;
            keyVaultClientMock.Setup(kv => kv.SetKey(VaultName, KeyName, 
                It.Is<KeyAttributes>(kt => kt.Enabled == keyAttributes.Enabled
                        && kt.Expires == keyAttributes.Expires
                        && kt.NotBefore == keyAttributes.NotBefore
                        && kt.KeyType == keyAttributes.KeyType
                        && kt.KeyOps == keyAttributes.KeyOps)))
                .Returns(expected).Verifiable();

            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorSetKeyTest()
        {
            KeyBundle expected = keyBundle;
            keyVaultClientMock.Setup(kv => kv.SetKey(VaultName, KeyName,
                It.Is<KeyAttributes>(kt => kt.Enabled == keyAttributes.Enabled
                        && kt.Expires == keyAttributes.Expires
                        && kt.NotBefore == keyAttributes.NotBefore
                        && kt.KeyType == keyAttributes.KeyType
                        && kt.KeyOps == keyAttributes.KeyOps)))
                .Throws(new Exception("exception")).Verifiable();

            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteError(It.IsAny<ErrorRecord>()), Times.Once());
        }
    }
}
