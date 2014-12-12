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

namespace Microsoft.Azure.Commands.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public static class JsonWebKeyType
    {
        public const string EllipticCurve = "EC";
        public const string Rsa           = "RSA";
        public const string RsaHsm        = "RSA-HSM";
        public const string Octet         = "oct";

        /// <summary>
        /// All types names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllTypes
        {
            get { return (string[])_allTypes.Clone(); }
        }

        private static readonly string[] _allTypes = { EllipticCurve, Rsa, RsaHsm, Octet };
    }
}
