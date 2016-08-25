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
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    public static class CertUtilsNewSM
    {
        private const string LocalMachine = "LocalMachine";
        private const string MyStoreName = "My";

        public static bool HasExportablePrivateKey(X509Certificate2 cert)
        {
            if (!cert.HasPrivateKey)
            {
                return false;
            }

            try
            {
                cert.Export(X509ContentType.Pfx);
            }
            catch (CryptographicException)
            {
                return false;
            }

            return true;
        }

        public static ServiceCertificateCreateParameters Create(X509Certificate2 certificate)
        {
            return Create(certificate, false);
        }

        public static ServiceCertificateCreateParameters Create(X509Certificate2 certificate, bool dropPrivateKey)
        {
            if (dropPrivateKey)
            {
                certificate = DropPrivateKey(certificate);
            }

            var password = RandomBase64PasswordString();
            var certificateData = GetCertificateData(certificate, password);
            var certificateFile = new ServiceCertificateCreateParameters
            {
                Data = certificateData,
                Password = password,
                CertificateFormat = CertificateFormat.Pfx
            };

            return certificateFile;
        }

        public static byte[] GetCertificateData(X509Certificate2 cert)
        {
            try
            {
                return cert.HasPrivateKey ? cert.Export(X509ContentType.Pfx) : cert.Export(X509ContentType.Pkcs12);
            }
            catch (CryptographicException)
            {
                return cert.HasPrivateKey ? cert.RawData : cert.Export(X509ContentType.Pkcs12);
            }
        }

        public static byte[] GetCertificateData(X509Certificate2 cert, string password)
        {
            try
            {
                return cert.HasPrivateKey ? cert.Export(X509ContentType.Pfx, password) : cert.Export(X509ContentType.Pkcs12, password);
            }
            catch (CryptographicException)
            {
                return cert.HasPrivateKey ? cert.RawData : cert.Export(X509ContentType.Pkcs12, password);
            }
        }

        public static X509Certificate2 DropPrivateKey(X509Certificate2 cert)
        {
            // export and reimport without private key.
            var noPrivateKey = cert.Export(X509ContentType.Cert);
            return new X509Certificate2(noPrivateKey);
        }

        public static CertificateSettingList GetCertificateSettings(CertificateSettingList Certificates, X509Certificate2[] X509Certificates)
        {
            CertificateSettingList result = null;
            if (Certificates != null && X509Certificates != null)
            {
                var certSettings = from x in X509Certificates
                                   where !Certificates.Any(s => s.Thumbprint.Equals(x.Thumbprint, StringComparison.InvariantCultureIgnoreCase))
                                   select new CertificateSetting
                                   {
                                       StoreLocation = LocalMachine,
                                       StoreName = MyStoreName,
                                       Thumbprint = x.Thumbprint
                                   };
                result = new CertificateSettingList();
                result.AddRange(certSettings);
            }
            else if (Certificates == null && X509Certificates != null)
            {
                var certSettings = from x in X509Certificates
                                   select new CertificateSetting
                                   {
                                       StoreLocation = LocalMachine,
                                       StoreName = MyStoreName,
                                       Thumbprint = x.Thumbprint
                                   };
                result = new CertificateSettingList();
                result.AddRange(certSettings);
            }
            else if (Certificates != null && X509Certificates == null)
            {
                result = new CertificateSettingList();
                result.AddRange(Certificates);
            }

            return result;
        }

        public static string RandomBase64PasswordString()
        {
            return RandomBase64String(32);
        }

        public static string RandomBase64String(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[length];
                rng.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        public static X509Certificate2 FindCertificate(X509Certificate2[] certificates, string thumbprint)
        {
            X509Certificate2 result = null;
            result = certificates.FirstOrDefault(cert => String.Compare(cert.Thumbprint, thumbprint, StringComparison.InvariantCultureIgnoreCase) == 0);
            return result;
        }
    }

}
