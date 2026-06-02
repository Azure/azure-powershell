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
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;
using WebKey = Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Verifies the cmdlet-level wiring for creating oct (AES) HSM-backed keys
    /// via Add-AzKeyVaultKey, on both Premium AKV and Managed HSM.
    ///
    /// These are pure cmdlet plumbing tests: they mock IKeyVaultDataServiceClient
    /// (the same type used by Track2DataClient) and assert that the cmdlet:
    ///   1. Translates -KeyType oct -Destination HSM into PSKeyVaultKeyAttributes
    ///      with KeyType == "oct-HSM" before calling the service client.
    ///   2. Forwards the requested -Size to the service client unchanged.
    ///   3. Routes vault calls through CreateKey and HSM calls through
    ///      CreateManagedHsmKey.
    ///
    /// Server-side behavior (e.g. the Track2 SDK CreateOctKeyOptions wire format,
    /// or the eventual KeyProperties.KeySize read-back) is intentionally out of
    /// scope here and is covered by manual validation / Pester scripts.
    /// </summary>
    public class AddKeyVaultOctKeyTests : KeyVaultUnitTestBase
    {
        private const string HsmName = "hsmname";

        private readonly AddAzureKeyVaultKey cmdlet;
        private readonly Mock<IKeyVaultDataServiceClient> track2DataClientMock;

        public AddKeyVaultOctKeyTests()
        {
            base.SetupTest();

            // KeyVaultUnitTestBase sets up keyVaultClientMock for Track1; create
            // a separate mock for the Track2 client, since AddAzureKeyVaultKey
            // routes oct/RSA/EC creation through Track2DataClient.
            track2DataClientMock = new Mock<IKeyVaultDataServiceClient>();

            cmdlet = new AddAzureKeyVaultKey
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataServiceClient = keyVaultClientMock.Object,
                Track2DataClient = track2DataClientMock.Object,
            };

            // ConfirmAction / ShouldProcess must return true for ExecuteCmdlet
            // to reach the create call.
            commandRuntimeMock
                .Setup(cr => cr.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
        }

        private static PSKeyVaultKey StubKey(string vaultName, string name, string kty)
        {
            return new PSKeyVaultKey
            {
                VaultName = vaultName,
                Name = name,
                Key = new WebKey.JsonWebKey { Kty = kty },
                Attributes = new PSKeyVaultKeyAttributes(true, null, null, kty, null, null),
            };
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(128)]
        [InlineData(192)]
        [InlineData(256)]
        public void OctKeyOnVaultIsCreatedAsOctHsm(int size)
        {
            // Capture the attributes the cmdlet hands to the service client so
            // we can assert KeyType is rewritten from 'oct' -> 'oct-HSM'.
            PSKeyVaultKeyAttributes captured = null;
            int? capturedSize = null;

            track2DataClientMock
                .Setup(c => c.CreateKey(VaultName, KeyName,
                    It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Callback<string, string, PSKeyVaultKeyAttributes, int?, string>(
                    (_, __, attrs, sz, ___) => { captured = attrs; capturedSize = sz; })
                .Returns(StubKey(VaultName, KeyName, "oct-HSM"))
                .Verifiable();

            cmdlet.VaultName = VaultName;
            cmdlet.Name = KeyName;
            cmdlet.KeyType = JsonWebKeyType.Octet;       // "oct"
            cmdlet.Destination = "HSM";
            cmdlet.Size = size;

            cmdlet.ExecuteCmdlet();

            track2DataClientMock.VerifyAll();
            Assert.NotNull(captured);
            Assert.Equal("oct-HSM", captured.KeyType);
            Assert.Equal(size, capturedSize);

            // Track1 client must not be used for creation on the vault path.
            keyVaultClientMock.Verify(c => c.CreateKey(
                It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()),
                Times.Never());
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(128)]
        [InlineData(256)]
        public void OctKeyOnManagedHsmRoutesToCreateManagedHsmKeyWithSize(int size)
        {
            PSKeyVaultKeyAttributes captured = null;
            int? capturedSize = null;

            track2DataClientMock
                .Setup(c => c.CreateManagedHsmKey(HsmName, KeyName,
                    It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Callback<string, string, PSKeyVaultKeyAttributes, int?, string>(
                    (_, __, attrs, sz, ___) => { captured = attrs; capturedSize = sz; })
                .Returns(StubKey(HsmName, KeyName, "oct-HSM"))
                .Verifiable();

            cmdlet.HsmName = HsmName;
            cmdlet.Name = KeyName;
            cmdlet.KeyType = JsonWebKeyType.Octet;       // "oct"
            // Note: -Destination is not used on the HSM path; Managed HSM keys
            // are always HSM-backed, so the cmdlet does not rewrite the kty.
            // The service still emits 'oct-HSM' on the wire.
            cmdlet.Size = size;

            cmdlet.ExecuteCmdlet();

            track2DataClientMock.VerifyAll();
            Assert.NotNull(captured);
            // On the MHSM path the cmdlet does not rewrite kty: it forwards the
            // user-supplied "oct" unchanged. Track2HsmClient is what unconditionally
            // sets hardwareProtected=true when calling the SDK.
            Assert.Equal(JsonWebKeyType.Octet, captured.KeyType);
            Assert.Equal(size, capturedSize);

            // Vault create must not be invoked on the HSM path.
            track2DataClientMock.Verify(c => c.CreateKey(
                It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()),
                Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RsaKeyOnVaultWithHsmDestinationStaysAsRsaHsm()
        {
            // Regression guard: the new oct-HSM rewrite must not disturb the
            // existing RSA / EC -> RSA-HSM / EC-HSM rewrites.
            PSKeyVaultKeyAttributes captured = null;

            track2DataClientMock
                .Setup(c => c.CreateKey(VaultName, KeyName,
                    It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Callback<string, string, PSKeyVaultKeyAttributes, int?, string>(
                    (_, __, attrs, ___, ____) => captured = attrs)
                .Returns(StubKey(VaultName, KeyName, JsonWebKeyType.RsaHsm));

            cmdlet.VaultName = VaultName;
            cmdlet.Name = KeyName;
            cmdlet.KeyType = JsonWebKeyType.Rsa;
            cmdlet.Destination = "HSM";
            cmdlet.Size = 2048;

            cmdlet.ExecuteCmdlet();

            Assert.NotNull(captured);
            Assert.Equal(JsonWebKeyType.RsaHsm, captured.KeyType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RsaKeyOnVaultWithSoftwareDestinationStaysAsRsa()
        {
            // Software-backed RSA on a Standard or Premium AKV is the default
            // path. The cmdlet must NOT rewrite the kty (stays plain "RSA")
            // and must still route through Track2DataClient.CreateKey.
            PSKeyVaultKeyAttributes captured = null;

            track2DataClientMock
                .Setup(c => c.CreateKey(VaultName, KeyName,
                    It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Callback<string, string, PSKeyVaultKeyAttributes, int?, string>(
                    (_, __, attrs, ___, ____) => captured = attrs)
                .Returns(StubKey(VaultName, KeyName, JsonWebKeyType.Rsa))
                .Verifiable();

            cmdlet.VaultName = VaultName;
            cmdlet.Name = KeyName;
            cmdlet.KeyType = JsonWebKeyType.Rsa;
            cmdlet.Destination = "Software";
            cmdlet.Size = 2048;

            cmdlet.ExecuteCmdlet();

            track2DataClientMock.VerifyAll();
            Assert.NotNull(captured);
            Assert.Equal(JsonWebKeyType.Rsa, captured.KeyType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OctKeyOnVaultWithoutHsmDestinationIsNotRewritten()
        {
            // Documents that the cmdlet only rewrites oct -> oct-HSM when
            // -Destination HSM is set on a vault. Without it, kty stays "oct"
            // and the request would be rejected server-side (no software-backed
            // oct keys exist on AKV). We can't exercise the service rejection
            // here, but we can pin the cmdlet-side contract.
            PSKeyVaultKeyAttributes captured = null;

            track2DataClientMock
                .Setup(c => c.CreateKey(VaultName, KeyName,
                    It.IsAny<PSKeyVaultKeyAttributes>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Callback<string, string, PSKeyVaultKeyAttributes, int?, string>(
                    (_, __, attrs, ___, ____) => captured = attrs)
                .Returns(StubKey(VaultName, KeyName, JsonWebKeyType.Octet));

            cmdlet.VaultName = VaultName;
            cmdlet.Name = KeyName;
            cmdlet.KeyType = JsonWebKeyType.Octet;       // "oct"
            // No Destination set -> kty must NOT be rewritten to "oct-HSM".
            cmdlet.Size = 256;

            cmdlet.ExecuteCmdlet();

            Assert.NotNull(captured);
            Assert.Equal(JsonWebKeyType.Octet, captured.KeyType);
            Assert.NotEqual("oct-HSM", captured.KeyType);
        }
    }
}
