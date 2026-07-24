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

using System;
using System.Reflection;
using System.Security.Cryptography;

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

using Track2 = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Verifies that <c>KeySize</c> is populated end-to-end on the PS models.
    /// Track 1 (Microsoft.Azure.KeyVault) only computes KeySize for RSA keys
    /// (the historic behaviour, preserved). Track 2 (Azure.Security.KeyVault.Keys
    /// 4.10.0+) reads KeySize directly from KeyProperties.KeySize; when the
    /// service does not report it (e.g. EC keys) the property is left null.
    /// </summary>
    public class JwkHelperKeySizeTests
    {
        private const string VaultDnsSuffix = "vault.azure.net";

        // ---- Track 1: PSKeyVaultKey from KeyBundle ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2048)]
        [InlineData(3072)]
        [InlineData(4096)]
        public void PSKeyVaultKey_Track1_RsaBundle_PopulatesKeySize(int size)
        {
            var bundle = new KeyBundle
            {
                Key = MakeRealRsaJwk(size, $"https://test.{VaultDnsSuffix}/keys/rsa-key/v1"),
                Attributes = new KeyAttributes { Enabled = true },
            };
            var psKey = new PSKeyVaultKey(bundle, new VaultUriHelper(VaultDnsSuffix));
            Assert.Equal(size, psKey.KeySize);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P256)]
        [InlineData("oct", null)]
        public void PSKeyVaultKey_Track1_NonRsaBundle_KeySizeIsNull(string kty, string curve)
        {
            // Track 1 has no size to give us for non-RSA keys — the reader should
            // leave KeySize null rather than fabricating a value from the curve
            // (bit-size alone can't distinguish e.g. P-256 from secp256k1) or
            // from HSM-backed material we may not have.
            var bundle = new KeyBundle
            {
                Key = new JsonWebKey
                {
                    Kid = $"https://test.{VaultDnsSuffix}/keys/other-key/v1",
                    Kty = kty,
                    CurveName = curve,
                    K = kty == "oct" ? new byte[32] : null,
                    KeyOps = Array.Empty<string>(),
                },
                Attributes = new KeyAttributes { Enabled = true },
            };
            var psKey = new PSKeyVaultKey(bundle, new VaultUriHelper(VaultDnsSuffix));
            Assert.Null(psKey.KeySize);
        }

        // ---- Track 1: PSDeletedKeyVaultKey ----

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSDeletedKeyVaultKey_Track1_RsaBundle_PopulatesKeySize()
        {
            var deleted = new DeletedKeyBundle
            {
                Key = MakeRealRsaJwk(2048, $"https://test.{VaultDnsSuffix}/keys/rsa-deleted/v1"),
                Attributes = new KeyAttributes { Enabled = true },
            };
            var psKey = new PSDeletedKeyVaultKey(deleted, new VaultUriHelper(VaultDnsSuffix));
            Assert.Equal(2048, psKey.KeySize);
        }

        private static JsonWebKey MakeRealRsaJwk(int sizeBits, string kid)
        {
            // ConvertToRSAKey validates the modulus via ImportParameters, so we need
            // a genuine RSA key rather than a zero-filled byte array.
            using (var rsa = RSA.Create(sizeBits))
            {
                var p = rsa.ExportParameters(false);
                return new JsonWebKey
                {
                    Kid = kid,
                    Kty = JsonWebKeyType.Rsa,
                    N = p.Modulus,
                    E = p.Exponent,
                    KeyOps = Array.Empty<string>(),
                };
            }
        }

        // ---- Track 2: PSKeyVaultKey reads KeyProperties.KeySize verbatim ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2048)]
        [InlineData(3072)]
        [InlineData(4096)]
        [InlineData(256)]
        public void PSKeyVaultKey_Track2_ReadsKeyPropertiesKeySize(int reportedKeySize)
        {
            var key = BuildTrack2RsaKeyVaultKey(rsaBits: 2048, reportedKeySize: reportedKeySize);
            var psKey = new PSKeyVaultKey(key, new VaultUriHelper(VaultDnsSuffix), isHsm: false);
            Assert.Equal(reportedKeySize, psKey.KeySize);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSKeyVaultKey_Track2_NoServiceKeySize_LeavesKeySizeNull()
        {
            // Mirrors what the service returns for EC keys: JWK material present
            // but KeyProperties.KeySize is null. The reader must not fall back to
            // any client-side computation.
            var key = BuildTrack2RsaKeyVaultKey(rsaBits: 2048, reportedKeySize: null);
            var psKey = new PSKeyVaultKey(key, new VaultUriHelper(VaultDnsSuffix), isHsm: false);
            Assert.Null(psKey.KeySize);
        }

        // ---- Track 2: PSKeyVaultKeyIdentityItem (Get-AzKeyVaultKey list view) ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2048)]
        [InlineData(3072)]
        [InlineData(256)]
        [InlineData(null)]
        public void PSKeyVaultKeyIdentityItem_Track2_KeyProperties_PopulatesKeySize(int? reportedKeySize)
        {
            var props = NewTrack2KeyProperties(VaultDnsSuffix, "key-A", version: "v1", keySize: reportedKeySize);
            var item = new PSKeyVaultKeyIdentityItem(props, new VaultUriHelper(VaultDnsSuffix));
            Assert.Equal(reportedKeySize, item.KeySize);
        }

        // ---- Track 2 SDK construction via reflection ----
        //
        // Azure.Security.KeyVault.Keys.KeyVaultKey and KeyProperties expose only
        // internal setters (they're normally hydrated by the JSON deserializer).
        // The reflection helper below is the supported in-test workaround for
        // exercising models that wrap an internal-set SDK contract.

        private static Track2.KeyVaultKey BuildTrack2RsaKeyVaultKey(int rsaBits, int? reportedKeySize)
        {
            using (var rsa = RSA.Create(rsaBits))
            {
                var jwk = new Track2.JsonWebKey(rsa, includePrivateParameters: false);
                jwk.Id = $"https://test.{VaultDnsSuffix}/keys/rsa-key/v1";

                var key = new Track2.KeyVaultKey("rsa-key");
                SetNonPublicProperty(key, nameof(Track2.KeyVaultKey.Key), jwk);

                var props = NewTrack2KeyProperties(VaultDnsSuffix, "rsa-key", "v1", reportedKeySize);
                SetNonPublicProperty(key, nameof(Track2.KeyVaultKey.Properties), props);

                return key;
            }
        }

        private static Track2.KeyProperties NewTrack2KeyProperties(string dnsSuffix, string keyName, string version, int? keySize)
        {
            var props = new Track2.KeyProperties(new Uri($"https://test.{dnsSuffix}/keys/{keyName}/{version}"));
            if (keySize.HasValue)
            {
                SetNonPublicProperty(props, nameof(Track2.KeyProperties.KeySize), keySize);
            }
            return props;
        }

        private static void SetNonPublicProperty(object target, string propertyName, object value)
        {
            var type = target.GetType();
            var prop = type.GetProperty(
                propertyName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (prop == null)
            {
                throw new InvalidOperationException($"Property '{propertyName}' not found on '{type.FullName}'.");
            }
            var setter = prop.GetSetMethod(nonPublic: true);
            if (setter != null)
            {
                setter.Invoke(target, new[] { value });
                return;
            }

            // Getter-only auto-property: fall back to writing the compiler-generated
            // backing field. Supported in-test pattern for SDK models that expose only
            // a JSON-deserializer-driven setter.
            var backingField = type.GetField(
                $"<{propertyName}>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (backingField == null)
            {
                throw new InvalidOperationException(
                    $"Property '{propertyName}' on '{type.FullName}' has no setter or backing field.");
            }
            backingField.SetValue(target, value);
        }
    }
}
