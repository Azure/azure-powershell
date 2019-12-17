// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
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

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class SetKeyVaultSecretAttributeTests : KeyVaultUnitTestBase
    {
        private SetAzureKeyVaultSecretAttribute cmdlet;
        private SecretAttributes secretAttributes;
        private Secret secret;
        public SetKeyVaultSecretAttributeTests()
        {
            base.SetupTest();

            secretAttributes = new SecretAttributes(true, DateTime.UtcNow.AddYears(2), DateTime.UtcNow, "contenttype", null);
            secret = new Secret() { VaultName = VaultName, Name = SecretName, Version = SecretVersion, SecretValue = null, Attributes = secretAttributes };

            cmdlet = new SetAzureKeyVaultSecretAttribute()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                VaultName = secret.VaultName,
                Name = secret.Name,
                Version = secret.Version,
                Enable = secretAttributes.Enabled,
                Expires = secretAttributes.Expires,
                NotBefore = secretAttributes.NotBefore,
                ContentType = secretAttributes.ContentType,
                Tag = secretAttributes.Tags,
                PassThru = true
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSetSecretAttributeTest()
        {
            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);

            Secret expected = secret;
            keyVaultClientMock.Setup(kv => kv.UpdateSecret(VaultName, SecretName, SecretVersion,
                It.Is<SecretAttributes>(st => st.Enabled == secretAttributes.Enabled
                        && st.Expires == secretAttributes.Expires
                        && st.NotBefore == secretAttributes.NotBefore
                        && st.ContentType == secretAttributes.ContentType
                        && st.Tags == secretAttributes.Tags))).Returns(expected).Verifiable();

            cmdlet.ExecuteCmdlet();

            // Assert
            keyVaultClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorSetSecretAttributeTest()
        {
            // Mock the should process to return true
            commandRuntimeMock.Setup(cr => cr.ShouldProcess(SecretName, It.IsAny<string>())).Returns(true);

            keyVaultClientMock.Setup(kv => kv.UpdateSecret(VaultName, SecretName, SecretVersion,
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
