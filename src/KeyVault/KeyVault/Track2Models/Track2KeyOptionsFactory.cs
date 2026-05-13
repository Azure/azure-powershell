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

using System.Collections;

using Azure.Security.KeyVault.Keys;

using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    /// <summary>
    /// Pure builders for the Track2 SDK <c>Create*KeyOptions</c> types.
    ///
    /// Both <see cref="Track2HsmClient"/> and <see cref="Track2VaultClient"/>
    /// translate a <see cref="PSKeyVaultKeyAttributes"/> + size + curve into a
    /// concrete <c>CreateRsaKeyOptions</c> / <c>CreateEcKeyOptions</c> /
    /// <c>CreateOctKeyOptions</c> and call the corresponding
    /// <c>KeyClient.Create*Key</c> overload. Centralizing the option building
    /// here:
    ///   - removes the duplication the original code carried as a // todo,
    ///   - keeps the option-building free of any SDK I/O so it can be unit
    ///     tested without an Azure endpoint or a mocked <c>KeyClient</c>,
    ///   - lets each client pass its own <c>hardwareProtected</c> flag (vault
    ///     uses <c>isHsm = (kty == RsaHsm || EcHsm)</c>; MHSM is always true).
    ///
    /// The actual SDK call and the <c>PSKeyVaultKey</c> wrapping (with the
    /// per-client output <c>isHsm</c> flag) stay in each client's dispatcher.
    /// </summary>
    internal static class Track2KeyOptionsFactory
    {
        internal static CreateRsaKeyOptions BuildRsaKeyOptions(string keyName, bool hardwareProtected,
            PSKeyVaultKeyAttributes attrs, int? size)
        {
            var options = new CreateRsaKeyOptions(keyName, hardwareProtected) { KeySize = size };
            ApplyCommonAttributes(options, attrs);
            return options;
        }

        internal static CreateEcKeyOptions BuildEcKeyOptions(string keyName, bool hardwareProtected,
            PSKeyVaultKeyAttributes attrs, string curveName)
        {
            var options = new CreateEcKeyOptions(keyName, hardwareProtected)
            {
                // Empty/null curve leaves CurveName null so the service applies
                // its default. Original code preserved this explicitly.
                CurveName = string.IsNullOrEmpty(curveName) ? (KeyCurveName?)null : new KeyCurveName(curveName)
            };
            ApplyCommonAttributes(options, attrs);
            return options;
        }

        /// <summary>
        /// Octet (AES) keys are always HSM-protected on both AKV Premium and
        /// Managed HSM, so <c>hardwareProtected</c> is fixed to true.
        /// </summary>
        internal static CreateOctKeyOptions BuildOctKeyOptions(string keyName,
            PSKeyVaultKeyAttributes attrs, int? size)
        {
            var options = new CreateOctKeyOptions(keyName, hardwareProtected: true) { KeySize = size };
            ApplyCommonAttributes(options, attrs);
            return options;
        }

        /// <summary>
        /// Copies fields common to every <c>Create*KeyOptions</c>: lifecycle
        /// dates, enabled / exportable flags, release policy, key operations,
        /// tags. Defensive against null <see cref="PSKeyVaultKeyAttributes.KeyOps"/>
        /// and null <see cref="PSKeyVaultKeyAttributes.Tags"/>.
        /// </summary>
        internal static void ApplyCommonAttributes(CreateKeyOptions options, PSKeyVaultKeyAttributes attrs)
        {
            options.NotBefore = attrs.NotBefore;
            options.ExpiresOn = attrs.Expires;
            options.Enabled = attrs.Enabled;
            options.Exportable = attrs.Exportable;
            options.ReleasePolicy = attrs.ReleasePolicy?.ToKeyReleasePolicy();

            if (attrs.KeyOps != null)
            {
                foreach (var keyOp in attrs.KeyOps)
                {
                    options.KeyOperations.Add(new KeyOperation(keyOp));
                }
            }

            if (attrs.Tags != null)
            {
                foreach (DictionaryEntry entry in attrs.Tags)
                {
                    options.Tags.Add(entry.Key.ToString(), entry.Value.ToString());
                }
            }
        }
    }
}
