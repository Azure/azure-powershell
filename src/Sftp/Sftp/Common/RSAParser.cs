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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common
{
    /// <summary>
    /// Parser for SSH RSA public keys
    /// </summary>
    public class RSAParser
    {
        private const string RSAAlgorithm = "ssh-rsa";
        
        public string Algorithm { get; private set; }
        public string Modulus { get; private set; }
        public string Exponent { get; private set; }

        public RSAParser()
        {
            Algorithm = string.Empty;
            Modulus = string.Empty;
            Exponent = string.Empty;
        }

        /// <summary>
        /// Parse SSH RSA public key text
        /// </summary>
        /// <param name="publicKeyText">Public key in format 'ssh-rsa base64data [comment]'</param>
        public void Parse(string publicKeyText)
        {
            if (string.IsNullOrWhiteSpace(publicKeyText))
            {
                throw new ArgumentException("Public key text cannot be null or empty", nameof(publicKeyText));
            }

            var textParts = publicKeyText.Split(' ');
            if (textParts.Length < 2)
            {
                throw new FormatException("Incorrectly formatted public key. " +
                                        "Key must be format '<algorithm> <base64_key>'");
            }

            var algorithm = textParts[0];
            if (algorithm != RSAAlgorithm)
            {
                throw new FormatException($"Public key is not ssh-rsa algorithm ({algorithm})");
            }

            byte[] keyBytes;
            try
            {
                keyBytes = Convert.FromBase64String(textParts[1]);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid base64 encoding in public key");
            }

            var fields = GetFields(keyBytes);
            if (fields.Count < 3)
            {
                throw new FormatException("Incorrectly encoded public key. " +
                                        "Encoded key must be base64 encoded <algorithm><exponent><modulus>");
            }

            var encodedAlgorithm = Encoding.ASCII.GetString(fields[0]);
            if (encodedAlgorithm != RSAAlgorithm)
            {
                throw new FormatException($"Encoded public key is not ssh-rsa algorithm ({encodedAlgorithm})");
            }

            Algorithm = encodedAlgorithm;
            Exponent = Base64UrlEncode(fields[1]);
            Modulus = Base64UrlEncode(fields[2]);
        }

        /// <summary>
        /// Extract fields from SSH key byte array
        /// </summary>
        private List<byte[]> GetFields(byte[] keyBytes)
        {
            var fields = new List<byte[]>();
            int read = 0;

            while (read < keyBytes.Length)
            {
                if (read + 4 > keyBytes.Length)
                {
                    break; // Not enough bytes for length field, we're done
                }

                // Read 4-byte length field (SSH uses network byte order - big endian)
                int length = ReadInt32(keyBytes, read);
                read += 4;

                // Validate length is reasonable
                if (length < 0)
                {
                    throw new FormatException("Invalid SSH key format: negative field length");
                }

                // If the field would extend beyond available data, just take what we have
                if (read + length > keyBytes.Length)
                {
                    length = keyBytes.Length - read;
                    if (length <= 0)
                    {
                        break; // No more data
                    }
                }

                // Read data field
                var data = new byte[length];
                if (length > 0)
                {
                    Array.Copy(keyBytes, read, data, 0, length);
                }
                read += length;

                fields.Add(data);
            }

            return fields;
        }

        /// <summary>
        /// Read a 32-bit integer from byte array at specified offset (big-endian/network byte order)
        /// </summary>
        private int ReadInt32(byte[] buffer, int offset)
        {
            // Big-endian (network byte order) - SSH standard
            return (buffer[offset] << 24) |
                   (buffer[offset + 1] << 16) |
                   (buffer[offset + 2] << 8) |
                   buffer[offset + 3];
        }

        /// <summary>
        /// Convert bytes to URL-safe base64 encoding
        /// </summary>
        private static string Base64UrlEncode(byte[] data)
        {
            // Standard base64 encoding
            string base64 = Convert.ToBase64String(data);
            
            // Convert to URL-safe format
            return base64.Replace('+', '-')
                         .Replace('/', '_')
                         .TrimEnd('=');
        }
    }
}