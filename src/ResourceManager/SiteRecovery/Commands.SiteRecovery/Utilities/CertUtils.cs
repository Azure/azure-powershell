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

using Security.Cryptography;
using Security.Cryptography.X509Certificates;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Class to provide methods to manage the certificates.
    /// </summary>
    public static class CertUtils
    {
        /// <summary>
        /// Enhancement provider
        /// </summary>
        private const string MsEnhancedProv = "Microsoft Enhanced Cryptographic Provider v1.0";

        /// <summary>
        /// Client Authentication Value
        /// </summary>
        private const string OIDClientAuthValue = "1.3.6.1.5.5.7.3.2";

        /// <summary>
        /// Client Authentication Friendly name
        /// </summary>
        private const string OIDClientAuthFriendlyName = "Client Authentication";

        /// <summary>
        /// Key size
        /// </summary>
        private const int KeySize2048 = 2048;

        /// <summary>
        /// default issuer name
        /// </summary>
        private const string DefaultIssuer = "CN=Windows Azure Tools";

        /// <summary>
        /// default password.
        /// </summary>
        private const string DefaultPassword = "";

        /// <summary>
        /// Method to generate a self signed certificate
        /// </summary>
        /// <param name="validForHours">number of hours for which the certificate is valid.</param>
        /// <param name="subscriptionId">subscriptionId in question</param>
        /// <param name="certificateNamePrefix">prefix for the certificate name</param>
        /// <param name="issuer">issuer for the certificate</param>
        /// <param name="password">certificate password</param>
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
            return NewX509Certificate2(bytes, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable, shouldValidatePfx: false);
        }

        /// <summary>
        /// Provides a similar API call to new X509Certificate(byte[],string,X509KeyStorageFlags)
        /// </summary>
        /// <param name="rawData">The bytes that represent the certificate</param>
        /// <param name="password">The certificate private password</param>
        /// <param name="keyStorageFlags">The certificate loading options</param>
        /// <param name="shouldValidatePfx">Flag to indicate if file should validated. Set to true if the rawData is retrieved from an untrusted source.</param>
        /// <returns>An instance of the X509Certificate</returns>
        public static X509Certificate2 NewX509Certificate2(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags, bool shouldValidatePfx)
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

        /// <summary>
        /// Method to get the Certificate's base 64 encoded string
        /// </summary>
        /// <param name="certFileName">Certificate File Name</param>
        /// <returns>Base 64 encoded string of the certificate</returns>
        public static string GetCertInBase64EncodedForm(string certFileName)
        {
            FileStream fileStream = null;
            byte[] data = null;
            string certInBase64EncodedForm = null;

            try
            {
                fileStream = new FileStream(certFileName, FileMode.Open, FileAccess.Read);

                // If the file size is more than 1MB, fail the call - this is just to avoid Dos Attacks
                if (fileStream.Length > 1048576)
                {
                    throw new Exception("The Certficate size exceeds 1MB. Please provide a file whose size is utmost 1 MB");
                }

                int size = (int)fileStream.Length;
                data = new byte[size];
                size = fileStream.Read(data, 0, size);

                // Check if the file is a valid certificate before sending it to service
                X509Certificate2 x509 = new X509Certificate2();
                x509.Import(data);
                if (string.IsNullOrEmpty(x509.Thumbprint))
                {
                    throw new Exception("The thumbprint of Certificate is null or empty");
                }

                certInBase64EncodedForm = Convert.ToBase64String(data);
            }
            catch (Exception e)
            {
                certInBase64EncodedForm = null;
                throw new ArgumentException(e.Message, certFileName, e);
            }
            finally
            {
                if (null != fileStream)
                {
                    fileStream.Close();
                }
            }

            return certInBase64EncodedForm;
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
        /// Windows Azure Service Management API requires 2048bit RSA keys.
        /// The private key needs to be exportable so we can save it for sharing with team members.
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
    }
}