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

using CERTENROLLLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.VisualStudio.EtwListener.Common
{
    /// <summary>
    /// Help class which provides certificate utitlies
    /// </summary>
    internal static class CertificateHelper
    {
        /// <summary>
        /// Find certificate with given thumbprint from local certificate store.
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        public static X509Certificate2 FindCertificate(string thumbprint)
        {
            if (string.IsNullOrEmpty(thumbprint))
                return null;

            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                var certs = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                if (certs == null || certs.Count == 0)
                {
                    return null;
                }

                return certs[0];
            }
            finally
            {
                store.Close();
            }
        }

        /// <summary>
        /// Create a new self-signed X509 certificate (using the legacy CryptoAPI) and add it to the CurrentUser/My cert store
        /// </summary>
        /// <param name="friendlyName">Human readable name</param>
        /// <param name="subjectName">Subject name</param>
        /// <returns>The generated certificate</returns>
        public static X509Certificate2 CreateCertificate(string friendlyName, string distinguishedNameString)
        {
            if (string.IsNullOrEmpty(distinguishedNameString))
            {
                throw new ArgumentException("distinguishedNameString cannot be null or empty.");
            }

            // create basic constraints. (Required for Vista Sp1)
            CX509ExtensionBasicConstraints basicContraints = new CX509ExtensionBasicConstraints();
            basicContraints.InitializeEncode(false, Int32.MaxValue);

            // create distinguished name
            CX500DistinguishedName distinguishedName = new CX500DistinguishedName();
            distinguishedName.Encode(distinguishedNameString);

            // Create certificate request
            CX509CertificateRequestCertificate certificateRequest = new CX509CertificateRequestCertificate();
            certificateRequest.Initialize(X509CertificateEnrollmentContext.ContextUser);

            // Create private key for the request.
            certificateRequest.PrivateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_FLAG;
            certificateRequest.PrivateKey.LegacyCsp = true;
            certificateRequest.PrivateKey.KeySpec = X509KeySpec.XCN_AT_KEYEXCHANGE;
            certificateRequest.PrivateKey.Length = 2048;
            certificateRequest.PrivateKey.Create();
            CObjectId algorithmObj = new CObjectId();
            algorithmObj.InitializeFromName(CERTENROLL_OBJECTID.XCN_OID_NIST_sha256);
            certificateRequest.HashAlgorithm = algorithmObj;

            CX509Enrollment enrollment;
            try
            {
                // Set certificate properties 
                certificateRequest.Subject = distinguishedName;
                certificateRequest.X509Extensions.Add((CX509Extension)basicContraints);
                certificateRequest.NotAfter = DateTime.Now.ToUniversalTime().AddYears(1);

                // Create new enrollment to initialize the request and create the certificate.
                enrollment = new CX509Enrollment();
                enrollment.CertificateFriendlyName = friendlyName;
                enrollment.InitializeFromRequest(certificateRequest);
                enrollment.CreateRequest(EncodingType.XCN_CRYPT_STRING_BASE64);
            }
            finally
            {
                // We can remove our handle on the private key after the request is created.
                certificateRequest.PrivateKey.Close();
            }

            // Install the certificate.
            enrollment.InstallResponse(InstallResponseRestrictionFlags.AllowNoOutstandingRequest | InstallResponseRestrictionFlags.AllowUntrustedCertificate | InstallResponseRestrictionFlags.AllowUntrustedRoot, certificateRequest.RawData, EncodingType.XCN_CRYPT_STRING_BASE64, String.Empty);

            // Instantiate certificate properties to find the thumbprint 
            CCertProperties properties = new CCertProperties();
            properties.InitializeFromCertificate(false, EncodingType.XCN_CRYPT_STRING_BASE64, certificateRequest.RawData);

            // Enumerate the properties to get the thumbprint property value.
            string thumbprint = null;
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].PropertyId == CERTENROLL_PROPERTYID.XCN_CERT_SHA1_HASH_PROP_ID)
                {
                    thumbprint = properties[i].get_RawData(EncodingType.XCN_CRYPT_STRING_HEXRAW | EncodingType.XCN_CRYPT_STRING_NOCRLF);
                    break;
                }
            }

            // Get X509Certificate2 instance via thumbprint.
            return CertificateHelper.FindCertificate(thumbprint);
        }


        /// <summary>
        /// Enroll certificate to local certificate store
        /// </summary>
        /// <param name="certificate">X509 Certificate</param>
        public static void EnrollCertificate(X509Certificate2 certificate)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            try
            {
                store.Add(certificate);
            }
            finally
            {
                store.Close();
            }
        }

        /// <summary>
        /// Remove certificates from local certificate store
        /// </summary>
        /// <param name="thumbprints">X509 Certificate thumbprints</param>
        public static void RemoveCertificates(IEnumerable<string> thumbprints)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            try
            {
                foreach (string thumbprint in thumbprints)
                {
                    foreach (var cert in store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false))
                    {
                        store.Remove(cert);
                    }
                }
            }
            finally
            {
                store.Close();
            }
        }
    }
}
