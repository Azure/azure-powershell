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

using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

using Track2 = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Verifies that <c>KeySize</c> is populated for every JWK key type returned
    /// from Key Vault / Managed HSM (RSA, RSA-HSM, EC, EC-HSM, oct, oct-HSM), in
    /// both the Track1 <see cref="KeyBundle"/> path and the Track2
    /// <see cref="Track2.KeyVaultKey"/> path on
    /// <see cref="PSKeyVaultKey"/>, <see cref="PSDeletedKeyVaultKey"/>, and the
    /// shared <see cref="PSKeyVaultKeyIdentityItem"/> base.
    ///
    /// Historically <c>KeySize</c> was only set for RSA keys via
    /// <c>JwkHelper.ConvertToRSAKey</c> (which has since been removed in favor
    /// of <see cref="JwkHelper.ComputeKeySize(JsonWebKey)"/>); these tests pin
    /// the new behavior and the wiring of <c>KeyProperties.KeySize</c> (added
    /// to <c>Azure.Security.KeyVault.Keys</c> 4.10.0) through the PS models.
    /// </summary>
    public class JwkHelperKeySizeTests
    {
        private const string VaultDnsSuffix = "vault.azure.net";
        private const string HsmDnsSuffix = "managedhsm.azure.net";
        private const string OctHsm = "oct-HSM";

        // ---- ComputeKeySize: RSA / RSA-HSM ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Rsa, 2048)]
        [InlineData(JsonWebKeyType.Rsa, 3072)]
        [InlineData(JsonWebKeyType.Rsa, 4096)]
        [InlineData(JsonWebKeyType.RsaHsm, 2048)]
        [InlineData(JsonWebKeyType.RsaHsm, 4096)]
        public void ComputeKeySize_RsaFamily_ReturnsModulusBits(string kty, int size)
        {
            var jwk = new JsonWebKey { Kty = kty, N = new byte[size / 8] };
            Assert.Equal(size, JwkHelper.ComputeKeySize(jwk));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Rsa)]
        [InlineData(JsonWebKeyType.RsaHsm)]
        public void ComputeKeySize_RsaFamilyWithoutModulus_ReturnsNull(string kty)
        {
            var jwk = new JsonWebKey { Kty = kty, N = null };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Rsa)]
        [InlineData(JsonWebKeyType.RsaHsm)]
        public void ComputeKeySize_RsaFamilyWithEmptyModulus_ReturnsNull(string kty)
        {
            // Empty material is "size unknown", not a 0-bit key.
            var jwk = new JsonWebKey { Kty = kty, N = new byte[0] };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        // ---- ComputeKeySize: oct / oct-HSM ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Octet, 128)]
        [InlineData(JsonWebKeyType.Octet, 192)]
        [InlineData(JsonWebKeyType.Octet, 256)]
        [InlineData(OctHsm, 128)]
        [InlineData(OctHsm, 192)]
        [InlineData(OctHsm, 256)]
        public void ComputeKeySize_OctFamily_ReturnsSymmetricBits(string kty, int size)
        {
            var jwk = new JsonWebKey { Kty = kty, K = new byte[size / 8] };
            Assert.Equal(size, JwkHelper.ComputeKeySize(jwk));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Octet)]
        [InlineData(OctHsm)]
        public void ComputeKeySize_OctFamilyWithoutMaterial_ReturnsNull(string kty)
        {
            var jwk = new JsonWebKey { Kty = kty, K = null };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Octet)]
        [InlineData(OctHsm)]
        public void ComputeKeySize_OctFamilyWithEmptyMaterial_ReturnsNull(string kty)
        {
            // Empty material is "size unknown", not a 0-bit key.
            var jwk = new JsonWebKey { Kty = kty, K = new byte[0] };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        // ---- ComputeKeySize: EC / EC-HSM ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P256, 256)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P256K, 256)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P384, 384)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P521, 521)]
        [InlineData(JsonWebKeyType.EllipticCurveHsm, JsonWebKeyCurveName.P256, 256)]
        [InlineData(JsonWebKeyType.EllipticCurveHsm, JsonWebKeyCurveName.P256K, 256)]
        [InlineData(JsonWebKeyType.EllipticCurveHsm, JsonWebKeyCurveName.P384, 384)]
        [InlineData(JsonWebKeyType.EllipticCurveHsm, JsonWebKeyCurveName.P521, 521)]
        public void ComputeKeySize_EcFamily_ReturnsCurveBits(string kty, string curve, int expected)
        {
            var jwk = new JsonWebKey { Kty = kty, CurveName = curve };
            Assert.Equal(expected, JwkHelper.ComputeKeySize(jwk));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("P-999")]
        public void ComputeKeySize_EcWithMissingOrUnknownCurve_ReturnsNull(string curve)
        {
            var jwk = new JsonWebKey { Kty = JsonWebKeyType.EllipticCurve, CurveName = curve };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        // ---- ComputeKeySize: edges ----

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ComputeKeySize_NullJwk_ReturnsNull()
        {
            Assert.Null(JwkHelper.ComputeKeySize(null));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("WUT")]
        public void ComputeKeySize_UnknownKty_ReturnsNull(string kty)
        {
            var jwk = new JsonWebKey { Kty = kty };
            Assert.Null(JwkHelper.ComputeKeySize(jwk));
        }

        // ---- PSKeyVaultKey: Track1 KeyBundle path ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Rsa, 2048)]
        [InlineData(JsonWebKeyType.Rsa, 4096)]
        [InlineData(JsonWebKeyType.RsaHsm, 2048)]
        public void PSKeyVaultKey_Track1_RsaBundle_PopulatesKeySize(string kty, int size)
        {
            var bundle = BuildRsaBundle(VaultDnsSuffix, kty, size);
            var psKey = new PSKeyVaultKey(bundle, new VaultUriHelper(VaultDnsSuffix));
            Assert.Equal(size, psKey.KeySize);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(128)]
        [InlineData(192)]
        [InlineData(256)]
        public void PSKeyVaultKey_Track1_OctHsmBundle_PopulatesKeySize(int size)
        {
            var bundle = BuildOctBundle(HsmDnsSuffix, OctHsm, size);
            var psKey = new PSKeyVaultKey(bundle, new VaultUriHelper(HsmDnsSuffix), isHsm: true);
            Assert.Equal(size, psKey.KeySize);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P256, 256)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P384, 384)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P521, 521)]
        [InlineData(JsonWebKeyType.EllipticCurveHsm, JsonWebKeyCurveName.P256K, 256)]
        public void PSKeyVaultKey_Track1_EcBundle_PopulatesKeySize(string kty, string curve, int expected)
        {
            var bundle = BuildEcBundle(VaultDnsSuffix, kty, curve);
            var psKey = new PSKeyVaultKey(bundle, new VaultUriHelper(VaultDnsSuffix));
            Assert.Equal(expected, psKey.KeySize);
        }

        // ---- PSDeletedKeyVaultKey: Track1 DeletedKeyBundle path ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(JsonWebKeyType.Rsa, 2048)]
        [InlineData(OctHsm, 256)]
        [InlineData(JsonWebKeyType.EllipticCurve, JsonWebKeyCurveName.P384)]
        public void PSDeletedKeyVaultKey_Track1_DeletedBundle_PopulatesKeySize(string kty, object sizeOrCurve)
        {
            var deleted = new DeletedKeyBundle
            {
                Key = MakeJwk(VaultDnsSuffix, "deleted-key", "v1", kty, sizeOrCurve),
                Attributes = new KeyAttributes { Enabled = true },
            };
            var psKey = new PSDeletedKeyVaultKey(deleted, new VaultUriHelper(VaultDnsSuffix));

            int? expected = ExpectedKeySize(kty, sizeOrCurve);
            Assert.Equal(expected, psKey.KeySize);
        }

        // ---- PSKeyVaultKey: Track2 KeyVaultKey path ----

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSKeyVaultKey_Track2_PrefersKeyPropertiesKeySize()
        {
            // Build a JWK whose RSA modulus is 2048-bit, then have the service
            // report 4096 via KeyProperties.KeySize. The PS model must surface
            // 4096 (the service is the source of truth — this matters for
            // HSM-backed keys where the JWK material is not returned at all).
            var key = BuildTrack2RsaKeyVaultKey(rsaBits: 2048, reportedKeySize: 4096);
            var psKey = new PSKeyVaultKey(key, new VaultUriHelper(VaultDnsSuffix), isHsm: false);

            Assert.Equal(4096, psKey.KeySize);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSKeyVaultKey_Track2_FallsBackToJwk_WhenKeyPropertiesKeySizeIsNull()
        {
            // Without a service-reported size, the JWK material drives the
            // computed size — proves the fallback path still works against
            // older service responses.
            var key = BuildTrack2RsaKeyVaultKey(rsaBits: 3072, reportedKeySize: null);
            var psKey = new PSKeyVaultKey(key, new VaultUriHelper(VaultDnsSuffix), isHsm: false);

            Assert.Equal(3072, psKey.KeySize);
        }

        // ---- PSKeyVaultKeyIdentityItem: Track2 KeyProperties path ----

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2048)]
        [InlineData(3072)]
        [InlineData(256)]
        [InlineData(null)]
        public void PSKeyVaultKeyIdentityItem_Track2_KeyProperties_PopulatesKeySize(int? reportedKeySize)
        {
            // The identity item is what Get-AzKeyVaultKey (list, no -Name) returns.
            // With SDK 4.10+ the service-reported KeySize is available on
            // KeyProperties itself, so list output can surface it without
            // fetching the full key material.
            var props = NewTrack2KeyProperties(VaultDnsSuffix, "key-A", version: "v1", keySize: reportedKeySize);
            var item = new PSKeyVaultKeyIdentityItem(props, new VaultUriHelper(VaultDnsSuffix));

            Assert.Equal(reportedKeySize, item.KeySize);
        }

        // ---- builders ----

        private static KeyBundle BuildRsaBundle(string dnsSuffix, string kty, int sizeBits)
        {
            return new KeyBundle
            {
                Key = MakeJwk(dnsSuffix, "rsa-key", "v1", kty, sizeBits),
                Attributes = new KeyAttributes { Enabled = true },
            };
        }

        private static KeyBundle BuildOctBundle(string dnsSuffix, string kty, int sizeBits)
        {
            return new KeyBundle
            {
                Key = MakeJwk(dnsSuffix, "oct-key", "v1", kty, sizeBits),
                Attributes = new KeyAttributes { Enabled = true },
            };
        }

        private static KeyBundle BuildEcBundle(string dnsSuffix, string kty, string curve)
        {
            return new KeyBundle
            {
                Key = MakeJwk(dnsSuffix, "ec-key", "v1", kty, curve),
                Attributes = new KeyAttributes { Enabled = true },
            };
        }

        private static JsonWebKey MakeJwk(string dnsSuffix, string keyName, string version, string kty, object sizeOrCurve)
        {
            var jwk = new JsonWebKey
            {
                Kid = $"https://test.{dnsSuffix}/keys/{keyName}/{version}",
                Kty = kty,
                KeyOps = Array.Empty<string>(),
            };

            if (string.Equals(kty, JsonWebKeyType.Rsa, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(kty, JsonWebKeyType.RsaHsm, StringComparison.OrdinalIgnoreCase))
            {
                int bits = Convert.ToInt32(sizeOrCurve);
                jwk.N = new byte[bits / 8];
                jwk.E = new byte[] { 1, 0, 1 };
            }
            else if (string.Equals(kty, JsonWebKeyType.Octet, StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(kty, OctHsm, StringComparison.OrdinalIgnoreCase))
            {
                int bits = Convert.ToInt32(sizeOrCurve);
                jwk.K = new byte[bits / 8];
            }
            else if (JwkHelper.IsEC(kty))
            {
                jwk.CurveName = (string)sizeOrCurve;
            }

            return jwk;
        }

        private static int? ExpectedKeySize(string kty, object sizeOrCurve)
        {
            if (string.Equals(kty, JsonWebKeyType.Rsa, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(kty, JsonWebKeyType.RsaHsm, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(kty, JsonWebKeyType.Octet, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(kty, OctHsm, StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToInt32(sizeOrCurve);
            }
            if (JwkHelper.IsEC(kty))
            {
                switch ((string)sizeOrCurve)
                {
                    case JsonWebKeyCurveName.P256:
                    case JsonWebKeyCurveName.P256K:
                        return 256;
                    case JsonWebKeyCurveName.P384:
                        return 384;
                    case JsonWebKeyCurveName.P521:
                        return 521;
                }
            }
            return null;
        }

        // ---- Track2 SDK construction via reflection ----
        //
        // Azure.Security.KeyVault.Keys.KeyVaultKey deliberately exposes only an
        // internal way to assemble itself (it's normally built by the JSON
        // deserializer). For unit tests we set the non-public Key/Properties and
        // the internal KeySize via reflection — this is the supported in-test
        // workaround for testing models that wrap an internal-set SDK contract.

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
            // backing field. This is the supported in-test pattern for SDK models
            // that expose only a JSON-deserializer-driven setter.
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
