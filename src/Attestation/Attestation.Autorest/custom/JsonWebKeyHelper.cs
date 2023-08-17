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
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api10;

namespace Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api10
{
    public class JsonWebKeyHelper
    {
        public static JsonWebKey[] GetJsonWebKeys(string certificateFileName)
        {
            JsonWebKey[] jsonWebKeys = null;

            if (certificateFileName != null)
            {
                FileInfo certFile = new FileInfo(certificateFileName);

                if (!certFile.Exists)
                {
                    throw new FileNotFoundException(string.Format("Cannot find certificate file '{0}'.", certificateFileName));
                }

                var pem = System.IO.File.ReadAllText(certFile.FullName);

                X509Certificate2Collection certificateCollection = GetX509CertificateFromPEM(pem, "CERTIFICATE");

                if (certificateCollection.Count != 0)
                {
                    jsonWebKeys = GetJsonWebKeysFromX509Certificate(certificateCollection);
                }
            }

            return jsonWebKeys;
        }

        #region implementation details

        private static X509Certificate2Collection GetX509CertificateFromPEM(string pemString, string section)
        {
            X509Certificate2Collection certificateCollection = new X509Certificate2Collection();
            var header = String.Format("-----BEGIN {0}-----", section);
            var footer = String.Format("-----END {0}-----", section);

            var start = 0;
            var lengthOfSection = 0;
            while (true)
            {
                start = pemString.IndexOf(header, StringComparison.Ordinal);

                if (start < 0)
                    break;
                start += header.Length;
                lengthOfSection = pemString.IndexOf(footer, start, StringComparison.Ordinal) - start;
                if (lengthOfSection < 0)
                    break;
                byte[] certBuffer = Convert.FromBase64String(pemString.Substring(start, lengthOfSection));
                X509Certificate2 certs = new X509Certificate2(certBuffer);
                certificateCollection.Add(certs);
                pemString = pemString.Substring(start + lengthOfSection);
            }
            return certificateCollection;
        }

        private static JsonWebKey[] GetJsonWebKeysFromX509Certificate(X509Certificate2Collection certificateCollection)
        {
            var jsonWebKeys = new List<JsonWebKey>();
            foreach (var certificate in certificateCollection)
            {
                var jwk = new JsonWebKey() { Kty = "RSA" };
                jwk.X5C = new List<string>() { System.Convert.ToBase64String(certificate.Export(X509ContentType.Cert)) }.ToArray();
                jsonWebKeys.Add(jwk);
            }
            return jsonWebKeys.ToArray();
        }

        #endregion
    }
}