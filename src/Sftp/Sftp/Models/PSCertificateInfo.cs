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

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models
{
    /// <summary>
    /// PowerShell object representing SSH certificate information
    /// </summary>
    public class PSCertificateInfo
    {
        /// <summary>
        /// Path to the generated SSH certificate file
        /// </summary>
        public string CertificatePath { get; set; }

        /// <summary>
        /// Path to the public key file used for certificate generation
        /// </summary>
        public string PublicKeyPath { get; set; }

        /// <summary>
        /// Path to the private key file (if generated or provided)
        /// </summary>
        public string PrivateKeyPath { get; set; }

        /// <summary>
        /// Certificate validity start time
        /// </summary>
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Certificate validity end time
        /// </summary>
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Microsoft Entra principal used for certificate generation
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// Parameter set used for certificate generation
        /// </summary>
        public string ParameterSet { get; set; }

        /// <summary>
        /// Local user name (if applicable)
        /// </summary>
        public string LocalUser { get; set; }

        /// <summary>
        /// Whether the certificate was generated for local user authentication
        /// </summary>
        public bool IsLocalUserCertificate => !string.IsNullOrEmpty(LocalUser);

        /// <summary>
        /// Whether the certificate is currently valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                var now = DateTime.Now;
                return ValidFrom.HasValue && ValidUntil.HasValue && 
                       now >= ValidFrom.Value && now <= ValidUntil.Value;
            }
        }

        /// <summary>
        /// Time remaining before certificate expires
        /// </summary>
        public TimeSpan? TimeRemaining
        {
            get
            {
                if (ValidUntil.HasValue)
                {
                    var remaining = ValidUntil.Value - DateTime.Now;
                    return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
                }
                return null;
            }
        }

        public override string ToString()
        {
            var validity = ValidUntil.HasValue ? $" (valid until {ValidUntil.Value})" : "";
            var userInfo = IsLocalUserCertificate ? $" for local user '{LocalUser}'" : "";
            return $"SSH Certificate: {CertificatePath}{userInfo}{validity}";
        }
    }
}
