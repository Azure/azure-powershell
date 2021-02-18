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

<<<<<<< HEAD
using Microsoft.Azure.KeyVault.WebKey;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
<<<<<<< HEAD
using Microsoft.Azure.KeyVault.Models;
=======
using Track2Sdk = Azure.Security.KeyVault.Keys;
using Track1Sdk = Microsoft.Azure.KeyVault.WebKey;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class PfxWebKeyConverter : IWebKeyConverter
    {
        public PfxWebKeyConverter(IWebKeyConverter next = null)
        {
            this.next = next;
        }

<<<<<<< HEAD
        public JsonWebKey ConvertKeyFromFile(FileInfo fileInfo, SecureString password)
=======
        public Track1Sdk.JsonWebKey ConvertKeyFromFile(FileInfo fileInfo, SecureString password, WebKeyConverterExtraInfo extraInfo = null)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            if (CanProcess(fileInfo))
                return Convert(fileInfo.FullName, password);
            if (next != null)
<<<<<<< HEAD
                return next.ConvertKeyFromFile(fileInfo, password);
=======
                return next.ConvertKeyFromFile(fileInfo, password, extraInfo);
            throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedFileFormat, fileInfo.Name));
        }

        public Track2Sdk.JsonWebKey ConvertToTrack2SdkKeyFromFile(FileInfo fileInfo, SecureString password)
        {
            if (CanProcess(fileInfo))
                return ConvertToTrack2SdkJsonWebKey(fileInfo.FullName, password);
            if (next != null)
                return next.ConvertToTrack2SdkKeyFromFile(fileInfo, password);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedFileFormat, fileInfo.Name));
        }

        private bool CanProcess(FileInfo fileInfo)
        {
            if (fileInfo == null ||
                string.IsNullOrEmpty(fileInfo.Extension))
            {
                return false;
            }

            return PfxFileExtension.Equals(fileInfo.Extension, StringComparison.OrdinalIgnoreCase);
        }

<<<<<<< HEAD
        private JsonWebKey Convert(string pfxFileName, SecureString pfxPassword)
=======
        private Track1Sdk.JsonWebKey Convert(string pfxFileName, SecureString pfxPassword)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            X509Certificate2 certificate;

            if (pfxPassword != null)
                certificate = new X509Certificate2(pfxFileName, pfxPassword, X509KeyStorageFlags.Exportable);
            else
                certificate = new X509Certificate2(pfxFileName);

            if (!certificate.HasPrivateKey)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidKeyBlob, "pfx"));

            var key = certificate.PrivateKey as RSA;

            if (key == null)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidKeyBlob, "pfx"));

            return CreateJWK(key);
        }

<<<<<<< HEAD
        private static JsonWebKey CreateJWK(RSA rsa)
=======
        private Track2Sdk.JsonWebKey ConvertToTrack2SdkJsonWebKey(string pfxFileName, SecureString pfxPassword)
        {
            X509Certificate2 certificate;

            if (pfxPassword != null)
                certificate = new X509Certificate2(pfxFileName, pfxPassword, X509KeyStorageFlags.Exportable);
            else
                certificate = new X509Certificate2(pfxFileName);

            if (!certificate.HasPrivateKey)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidKeyBlob, "pfx"));

            var rsaKey = certificate.PrivateKey as RSA;
            if (rsaKey != null)
                return CreateTrack2SdkJWK(rsaKey);

            var ecKey = certificate.PrivateKey as ECDsa;
            if(ecKey != null)
                return CreateTrack2SdkJWK(ecKey);

            // to do: support converting oct to jsonwebKey

            throw new ArgumentException(string.Format(KeyVaultProperties.Resources.ImportNotSupported, "oct-HSM"));

        }

        private static Track1Sdk.JsonWebKey CreateJWK(RSA rsa)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            if (rsa == null)
                throw new ArgumentNullException("rsa");
            RSAParameters rsaParameters = rsa.ExportParameters(true);
<<<<<<< HEAD
            var webKey = new JsonWebKey()
            {
                Kty = JsonWebKeyType.Rsa,
=======
            var webKey = new Track1Sdk.JsonWebKey()
            {
                Kty = Track1Sdk.JsonWebKeyType.Rsa,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                E = rsaParameters.Exponent,
                N = rsaParameters.Modulus,
                D = rsaParameters.D,
                DP = rsaParameters.DP,
                DQ = rsaParameters.DQ,
                QI = rsaParameters.InverseQ,
                P = rsaParameters.P,
                Q = rsaParameters.Q
            };

            return webKey;
        }

<<<<<<< HEAD
=======
        private static Track2Sdk.JsonWebKey CreateTrack2SdkJWK(RSA rsa)
        {
            if (rsa == null)
                throw new ArgumentNullException("rsa");
            RSAParameters rsaParameters = rsa.ExportParameters(true);
            var webKey = new Track2Sdk.JsonWebKey(rsa)
            {
                // note: Keyvault need distinguish RSA and RSA-HSM
                KeyType = Track2Sdk.KeyType.RsaHsm,
                N = rsaParameters.Modulus,
                E = rsaParameters.Exponent,
                DP = rsaParameters.DP,
                DQ = rsaParameters.DQ,
                QI = rsaParameters.InverseQ,
                Q = rsaParameters.Q,
                D = rsaParameters.D,
                P = rsaParameters.P
            };

            return webKey;
        }

        private static Track2Sdk.JsonWebKey CreateTrack2SdkJWK(ECDsa ecdSa)
        {
            if (ecdSa == null)
            {
                throw new ArgumentNullException("ecdSa");
            }

            System.Security.Cryptography.ECParameters ecParameters = ecdSa.ExportParameters(true);
            var webKey = new Track2Sdk.JsonWebKey(ecdSa)
            {
                // note: Keyvault need distinguish EC and EC-HSM
                KeyType = Track2Sdk.KeyType.EcHsm,
                CurveName = ecParameters.Curve.CurveType.ToString(),
                D = ecParameters.D,
                X = ecParameters.Q.X,
                Y = ecParameters.Q.Y
            };

            return webKey;

        }

        private static Track2Sdk.JsonWebKey CreateTrack2SdkJWK(Aes aes)
        {
            throw new NotImplementedException();
        }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        private IWebKeyConverter next;
        private const string PfxFileExtension = ".pfx";
    }
}
