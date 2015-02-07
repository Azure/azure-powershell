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
    /// Supported JsonWebKey operations
    /// </summary>
    public static class JsonWebKeyOperation
    {
        public const string Encrypt = "encrypt";
        public const string Decrypt = "decrypt";
        public const string Sign    = "sign";
        public const string Verify  = "verify";
        public const string Wrap    = "wrapKey";
        public const string Unwrap  = "unwrapKey";

        /// <summary>
        /// All operations names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllOperations
        {
            get { return (string[])_allOperations.Clone(); }
        }

        private static readonly string[] _allOperations = 
            new string[] { Encrypt, Decrypt, Sign, Verify, Wrap, Unwrap };
    }
}
