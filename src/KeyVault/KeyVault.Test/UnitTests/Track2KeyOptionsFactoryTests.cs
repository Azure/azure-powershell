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
using System.Collections;
using System.Linq;

using Azure.Security.KeyVault.Keys;

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Track2Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Pure unit tests for <see cref="Track2KeyOptionsFactory"/>.
    ///
    /// These tests pin the translation from <see cref="PSKeyVaultKeyAttributes"/>
    /// (+ size + curve) into the SDK's <c>Create*KeyOptions</c> objects. They are
    /// the safety net that lets us refactor the per-type dispatch in
    /// <see cref="Track2HsmClient"/> and <see cref="Track2VaultClient"/> without
    /// regressing the wire-level shape of the create requests.
    ///
    /// They deliberately do NOT touch the SDK's <c>KeyClient</c> — option-building
    /// is pure, so no mock transport is needed.
    /// </summary>
    public class Track2KeyOptionsFactoryTests
    {
        private const string KeyName = "test-key";

        private static PSKeyVaultKeyAttributes EmptyAttrs() => new PSKeyVaultKeyAttributes();

        // ---------- BuildRsa ----------

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(2048, true)]
        [InlineData(3072, true)]
        [InlineData(4096, true)]
        [InlineData(2048, false)]
        public void BuildRsa_SetsKeySizeAndHsmFlag(int size, bool hardwareProtected)
        {
            var options = Track2KeyOptionsFactory.BuildRsaKeyOptions(KeyName, hardwareProtected, EmptyAttrs(), size);

            Assert.Equal(KeyName, options.Name);
            Assert.Equal(size, options.KeySize);
            Assert.Equal(hardwareProtected, options.HardwareProtected);
        }

        // ---------- BuildEc ----------

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("P-256")]
        [InlineData("P-384")]
        [InlineData("P-521")]
        [InlineData("P-256K")]
        public void BuildEc_WithCurveName_SetsCurve(string curveName)
        {
            var options = Track2KeyOptionsFactory.BuildEcKeyOptions(KeyName, hardwareProtected: true, EmptyAttrs(), curveName);

            Assert.Equal(KeyName, options.Name);
            Assert.True(options.HardwareProtected);
            Assert.NotNull(options.CurveName);
            Assert.Equal(curveName, options.CurveName.Value.ToString());
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        public void BuildEc_NullOrEmptyCurveName_LeavesCurveNull(string curveName)
        {
            var options = Track2KeyOptionsFactory.BuildEcKeyOptions(KeyName, hardwareProtected: false, EmptyAttrs(), curveName);

            // A null CurveName lets the service apply its default; this is the
            // documented behavior the original code preserved explicitly.
            Assert.Null(options.CurveName);
            Assert.False(options.HardwareProtected);
        }

        // ---------- BuildOct ----------

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(128, true)]
        [InlineData(192, true)]
        [InlineData(256, true)]
        [InlineData(256, false)]
        public void BuildOct_SetsKeySizeAndHardwareProtectedFromCaller(int size, bool hardwareProtected)
        {
            // The factory no longer hardcodes hardwareProtected: callers (Track2VaultClient /
            // Track2HsmClient) decide based on the requested KeyType (Oct vs OctHsm) and the
            // backing service. The factory just forwards the flag verbatim.
            var options = Track2KeyOptionsFactory.BuildOctKeyOptions(KeyName, hardwareProtected, EmptyAttrs(), size);

            Assert.Equal(KeyName, options.Name);
            Assert.Equal(size, options.KeySize);
            Assert.Equal(hardwareProtected, options.HardwareProtected);
        }

        // ---------- ApplyCommonAttributes ----------

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_CopiesScalarFields()
        {
            var notBefore = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expires = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var attrs = new PSKeyVaultKeyAttributes
            {
                Enabled = true,
                NotBefore = notBefore,
                Expires = expires,
                Exportable = false,
            };

            // Build via BuildRsa just to exercise ApplyCommonAttributes through
            // the public surface; the asserts only inspect common fields.
            var options = Track2KeyOptionsFactory.BuildRsaKeyOptions(KeyName, hardwareProtected: false, attrs, 2048);

            Assert.True(options.Enabled);
            Assert.Equal(notBefore, options.NotBefore);
            Assert.Equal(expires, options.ExpiresOn);
            Assert.Equal(false, options.Exportable);
            Assert.Null(options.ReleasePolicy);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_NullKeyOps_DoesNotThrow()
        {
            var attrs = new PSKeyVaultKeyAttributes { KeyOps = null };

            var options = Track2KeyOptionsFactory.BuildRsaKeyOptions(KeyName, hardwareProtected: false, attrs, 2048);

            Assert.Empty(options.KeyOperations);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_KeyOps_AddsAllAsKeyOperation()
        {
            var attrs = new PSKeyVaultKeyAttributes { KeyOps = new[] { "encrypt", "decrypt", "wrapKey" } };

            var options = Track2KeyOptionsFactory.BuildRsaKeyOptions(KeyName, hardwareProtected: false, attrs, 2048);

            // KeyOperation values round-trip through string equality with the
            // input op names; that's what the JWK kty key_ops field expects.
            var ops = options.KeyOperations.Select(op => op.ToString()).ToArray();
            Assert.Equal(new[] { "encrypt", "decrypt", "wrapKey" }, ops);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_NullTags_DoesNotThrow()
        {
            var attrs = new PSKeyVaultKeyAttributes { Tags = null };

            var options = Track2KeyOptionsFactory.BuildOctKeyOptions(KeyName, hardwareProtected: true, attrs, 256);

            Assert.Empty(options.Tags);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_Tags_CopiedAsKeyValuePairs()
        {
            var attrs = new PSKeyVaultKeyAttributes
            {
                Tags = new Hashtable { { "scenario", "aes-validate" }, { "runId", "abc123" } }
            };

            var options = Track2KeyOptionsFactory.BuildOctKeyOptions(KeyName, hardwareProtected: true, attrs, 256);

            Assert.Equal(2, options.Tags.Count);
            Assert.Equal("aes-validate", options.Tags["scenario"]);
            Assert.Equal("abc123", options.Tags["runId"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplyCommonAttributes_NullReleasePolicy_LeavesPropertyNull()
        {
            // Guards the `attrs.ReleasePolicy?.ToKeyReleasePolicy()` null-conditional:
            // a missing release policy must not produce an empty KeyReleasePolicy.
            var attrs = new PSKeyVaultKeyAttributes { /* ReleasePolicy left null */ };

            var options = Track2KeyOptionsFactory.BuildEcKeyOptions(KeyName, hardwareProtected: false, attrs, "P-256");

            Assert.Null(options.ReleasePolicy);
        }
    }
}


