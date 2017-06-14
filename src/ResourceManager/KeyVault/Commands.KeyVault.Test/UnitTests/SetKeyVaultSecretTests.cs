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
using System.Management.Automation;
using System.Security;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class SetKeyVaultSecretTests : KeyVaultUnitTestBase
    {
        private SetAzureKeyVaultSecret cmdlet;
        private SecretAttributes secretAttributes;
        private SecureString secureSecretValue;
        private Secret secret;

        public SetKeyVaultSecretTests()
        {
            base.SetupTest();

            secretAttributes = new SecretAttributes(true, null, null, null, null);
            secureSecretValue = SecretValue.ConvertToSecureString();
            secret = new Secret() { VaultName = VaultName, Name = SecretName, Version = SecretVersion, SecretValue = secureSecretValue, Attributes = secretAttributes };

            cmdlet = new SetAzureKeyVaultSecret()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = secret.VaultName,
                Name = secret.Name,
                SecretValue = secret.SecretValue,
                Disable = new SwitchParameter(!(secretAttributes.Enabled.Value)),
                Expires = secretAttributes.Expires,
                NotBefore = secretAttributes.NotBefore,
                ContentType = secretAttributes.ContentType,
                Tag = secretAttributes.Tags
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetSecretTest()
        {
            Secret expected = secret;
            keyVaultClientMock.Setup(kv => kv.SetSecret(VaultName, SecretName, secureSecretValue,
                It.Is<SecretAttributes>(st => st.Enabled == secretAttributes.Enabled
                        && st.Expires == secretAttributes.Expires
                        && st.NotBefore == secretAttributes.NotBefore
                        && st.ContentType == secretAttributes.ContentType
                        && st.Tags == secretAttributes.Tags))).Returns(expected).Verifiable();

            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);

            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorSetSecretTest()
        {
            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);

            keyVaultClientMock.Setup(kv => kv.SetSecret(VaultName, SecretName, secureSecretValue,
                It.Is<SecretAttributes>(st => st.Enabled == secretAttributes.Enabled
                        && st.Expires == secretAttributes.Expires
                        && st.NotBefore == secretAttributes.NotBefore
                        && st.ContentType == secretAttributes.ContentType
                        && st.Tags == secretAttributes.Tags)))
                .Throws(new Exception("exception")).Verifiable();

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
