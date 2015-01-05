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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Security.Cryptography;
using Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Microsoft.Azure.Commands.RecoveryServices.lib
{
    public static class CertUtils
    {
        public const string MsEnhancedProv = "Microsoft Enhanced Cryptographic Provider v1.0"; // MS_ENHANCED_PROV;
        private const string DefaultIssuer = "CN=Windows Azure Tools";
        private const string DefaultPassword = "";

        public const string OIDClientAuthValue = "1.3.6.1.5.5.7.3.2";
        public const string OIDClientAuthFriendlyName = "Client Authentication";
        public const int KeySize2048 = 2048;

        /// <summary>
        /// Windows Azure Service Management API requires 2048bit RSA keys.
        /// The private key needs to be exportable so we can save it to .pfx for sharing with team members.
        /// </summary>
        /// <returns>A 2048 bit RSA key</returns>
        private static CngKey Create2048RsaKey()
        {
            var keyCreationParameters = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowExport,
                KeyCreationOptions = CngKeyCreationOptions.None,
                KeyUsage = CngKeyUsages.AllUsages,
                Provider = new CngProvider(MsEnhancedProv)
            };

            keyCreationParameters.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(KeySize2048), CngPropertyOptions.None));

            return CngKey.Create(CngAlgorithm2.Rsa, null, keyCreationParameters);
        }

        /// <summary>
        /// Method to generate a self signed certifficate
        /// </summary>
        /// <param name="validForHours">number of hours for which the certificate is valid.</param>
        /// <param name="subscriptionId">subscriptionId in question</param>
        /// <param name="certificateNamePrefix">prefix for the certificate name</param>
        /// <param name="issuer">issuer for the certificate</param>
        /// <param name="password">certificate passwor</param>
        /// <returns>certificate as an object</returns>
        public static X509Certificate2 CreateSelfSignedCertificate(
            int validForHours,
            string subscriptionId,
            string certificateNamePrefix,
            string issuer = DefaultIssuer,
            string password = DefaultPassword)
        {
            string friendlyName = GenerateCertFriendlyName(subscriptionId, certificateNamePrefix);
            DateTime startTime = DateTime.UtcNow.AddMinutes(-10);
            DateTime endTime = DateTime.UtcNow.AddHours(validForHours);

            var key = Create2048RsaKey();

            var creationParams = new X509CertificateCreationParameters(new X500DistinguishedName(issuer))
            {
                TakeOwnershipOfKey = true,
                StartTime = startTime,
                EndTime = endTime
            };

            //// adding client authentication, -eku = 1.3.6.1.5.5.7.3.2, 
            //// This is mandatory for the upload to be successful
            OidCollection oidCollection = new OidCollection();
            oidCollection.Add(new Oid(OIDClientAuthValue, OIDClientAuthFriendlyName));
            creationParams.Extensions.Add(new X509EnhancedKeyUsageExtension(oidCollection, false));

            // Documentation of CreateSelfSignedCertificate states:
            // If creationParameters have TakeOwnershipOfKey set to true, the certificate
            // generated will own the key and the input CngKey will be disposed to ensure
            // that the caller doesn't accidentally use it beyond its lifetime (which is
            // now controlled by the certificate object).
            // We don't dispose it ourselves in this case.
            var cert = key.CreateSelfSignedCertificate(creationParams);
            key = null;
            cert.FriendlyName = friendlyName;

            // X509 certificate needs PersistKeySet flag set.  
            // Reload a new X509Certificate2 instance from exported bytes in order to set the PersistKeySet flag.
            var bytes = cert.Export(X509ContentType.Pfx, password);

            // PfxValidation is not done here because these are newly created certs and assumed valid.
            return NewX509Certificate2(bytes, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable, doPfxValidation: false);
        }

        /// <summary>
        /// Generates friendly name
        /// </summary>
        /// <param name="subscriptionId">subscription id</param>
        /// <param name="prefix">prefix, likely resource name</param>
        /// <returns>friendly name</returns>
        private static string GenerateCertFriendlyName(string subscriptionId, string prefix = "")
        {
            return string.Format("{0}{1}-{2}-vaultcredentials", prefix, subscriptionId, DateTime.Now.ToString("M-d-yyyy"));
        }

        /// <summary>
        /// Provides a similar API call to new X509Certificate(byte[],string,X509KeyStorageFlags)
        /// </summary>
        /// <param name="rawData">The bytes that represent the certificate</param>
        /// <param name="password">The certificate private password</param>
        /// <param name="keyStorageFlags">The certificate loading options</param>
        /// <param name="doPfxValidation">Flag to indicate if pfx file should validated. Set to true if the rawData is retrieved from an untrusted source.</param>
        /// <returns>An instance of the X509Certificate</returns>
        public static X509Certificate2 NewX509Certificate2(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags, bool doPfxValidation)
        {
            string temporaryFileName = Path.GetTempFileName();

            try
            {
                X509ContentType contentType = X509Certificate2.GetCertContentType(rawData);
                File.WriteAllBytes(temporaryFileName, rawData);
                return new X509Certificate2(temporaryFileName, password, keyStorageFlags);
            }
            finally
            {
                try
                {
                    File.Delete(temporaryFileName);
                }
                catch (Exception)
                {
                    // Not deleting the file is fine
                }
            }
        }
    }
}