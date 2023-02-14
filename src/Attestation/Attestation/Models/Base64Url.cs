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
using System.Text;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public static class Base64Url
    {
        /// <summary>Encode a string as a Base64URL encoded string.</summary>
        /// <param name="value"></param>
        /// <returns>The UTF8 bytes for the string, encoded as a Base64URL string.</returns>
        public static string EncodeString(string value)
        {
            return EncodeBytes(UTF8Encoding.UTF8.GetBytes(value));
        }

        /// <summary>Encode a byte array as a Base64URL encoded string.</summary>
        /// <param name="bytes">Raw byte input buffer.</param>
        /// <returns>The bytes, encoded as a Base64URL string.</returns>
        public static string EncodeBytes(byte[] bytes)
        {
            return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        /// <summary> Converts a Base64URL encoded string to a string</summary>
        /// <param name="encoded">The Base64Url encoded string containing UTF8 bytes for a string</param>
        /// <returns>The string represented by the Base64URL encoded string</returns>
        public static string DecodeString(string encoded)
        {
            return UTF8Encoding.UTF8.GetString(DecodeBytes(encoded));
        }

        /// <summary>Converts a Base64URL encoded string to a byte array</summary>
        /// <param name="encoded">The Base64Url encoded string</param>
        /// <returns>The byte array represented by the Base64URL encoded string</returns>
        public static byte[] DecodeBytes(string encoded)
        {
            encoded = encoded.Replace('-', '+').Replace('_', '/');
            encoded = FixPadding(encoded);
            return Convert.FromBase64String(encoded);
        }

        /// <summary>Adds missing padding to a Base64 encoded string.</summary>
        /// <param name="unpadded">The unpadded input string.</param>
        /// <returns>The padded string</returns>
        private static string FixPadding(string unpadded)
        {
            var count = 3 - ((unpadded.Length + 3) % 4);
            return unpadded + new string('=', count);
        }
    }
}
