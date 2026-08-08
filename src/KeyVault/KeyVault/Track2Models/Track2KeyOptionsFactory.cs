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
    ///     derives it from the key type; MHSM always passes <c>true</c>).
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
        /// Builds <see cref="CreateOctKeyOptions"/> for an octet (AES) key.
        ///
        /// <para>The caller is responsible for passing the correct
        /// <paramref name="hardwareProtected"/> flag:</para>
        /// <list type="bullet">
        ///   <item><description><see cref="Track2HsmClient"/> always passes <c>true</c>
        ///   (Managed HSM is HSM-backed by definition).</description></item>
        ///   <item><description><see cref="Track2VaultClient"/> derives it from the
        ///   requested <c>KeyType</c> (<c>OctHsm</c> = true, <c>Oct</c> = false) so
        ///   that the user's <c>-Destination</c> choice is honored and any
        ///   service-side restriction (e.g. software oct not being supported on AKV)
        ///   surfaces as the authoritative service error rather than a silently
        ///   promoted HSM create.</description></item>
        /// </list>
        /// </summary>
        internal static CreateOctKeyOptions BuildOctKeyOptions(string keyName, bool hardwareProtected,
            PSKeyVaultKeyAttributes attrs, int? size)
        {
            var options = new CreateOctKeyOptions(keyName, hardwareProtected) { KeySize = size };
            ApplyCommonAttributes(options, attrs);
            return options;
        }

        /// <summary>
        /// Builds <see cref="CreateExternalKeyOptions"/> for an External Key Manager
        /// (EKM) backed key. The service rejects client-specified key type, size,
        /// curve and key operations for external keys, so only the lifecycle dates,
        /// enabled flag, tags and release policy are applied.
        /// </summary>
        internal static CreateExternalKeyOptions BuildExternalKeyOptions(string keyName, string externalKeyId,
            PSKeyVaultKeyAttributes attrs)
        {
            var options = new CreateExternalKeyOptions(keyName, new ExternalKey(externalKeyId));
            if (attrs != null)
            {
                options.NotBefore = attrs.NotBefore;
                options.ExpiresOn = attrs.Expires;
                options.Enabled = attrs.Enabled;
                options.ReleasePolicy = attrs.ReleasePolicy?.ToKeyReleasePolicy();

                if (attrs.Tags != null)
                {
                    foreach (DictionaryEntry entry in attrs.Tags)
                    {
                        options.Tags.Add(entry.Key.ToString(), entry.Value.ToString());
                    }
                }
            }
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
