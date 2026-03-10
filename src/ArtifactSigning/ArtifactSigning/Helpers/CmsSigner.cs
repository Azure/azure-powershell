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

using Azure.Developer.TrustedSigning.CryptoProvider;
using Azure.Core;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;

namespace Microsoft.Azure.Commands.ArtifactSigning.Helpers
{
    internal class CmsSigner
    {
        public CmsSigner() { }
        public void SignCIPolicy(TokenCredential tokenCred, string accountName, string certProfile,
            string endpointUrl, string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl)
        {
            int retry = 5;

            while (retry > 0)
            {
                try
                {
                    var context = new AzSignContext(tokenCred, accountName, certProfile, new Uri(endpointUrl));

                    var cert = context.GetSigningCertificate();
                    RSA rsa = new RSAAzSign(context);

                    var cipolicy = File.ReadAllBytes(unsignedCIFilePath);
                    var cmscontent = new ContentInfo(new Oid("1.3.6.1.4.1.311.79.1"), cipolicy);
                    var cms = new SignedCms(cmscontent, false);

                    var signer = new System.Security.Cryptography.Pkcs.CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, cert, rsa);
                    cms.ComputeSignature(signer);

                    cms.CheckSignature(true);
                    //Console.WriteLine(Util.BytesToHex(cms.Encode(), " ", 16));

                    var signedData = cms.Encode();

                    UpdateCMSVersion(signedData);

                    if (!string.IsNullOrWhiteSpace(timeStamperUrl))
                    {
                        var timestampingUri = new Uri("http://www.microsoft.com");
                        try
                        {
                            timestampingUri = new Uri(timeStamperUrl);

                            var signedAndTimestampedFullFileContents = TimeStampingHelper.Rfc3161Timestamp(
                                input: signedData,
                                timestampServerUrl: timestampingUri.ToString());

                            if (signedAndTimestampedFullFileContents == null)
                            {
                                throw new Exception("Timestamping failed. ");
                            }

                            File.WriteAllBytes(signedCIFilePath, signedAndTimestampedFullFileContents); ;
                        }
                        catch
                        {
                            throw new Exception("Input TimeStamperUrl is not valid Uri. Please check.");
                        }
                    }
                    else
                    {
                        File.WriteAllBytes(signedCIFilePath, signedData);
                    }
                    return;
                }
                catch(Exception ex)
                {
                    retry--;
                    if (retry == 0 || ex.Message == "Input TimeStamperUrl is not valid Uri. Please check.")
                    {
                        throw;
                    }
                }
            }
        }

        private byte[] UpdateCMSVersion(byte[] signedData)
        {

            /* Find and update CMSVersion to 1 if current version is 3.
             *
             * Ref: https://datatracker.ietf.org/doc/html/rfc2315
             *
             *
             * ContentInfo ::= SEQUENCE {
             *      ContentType ::= OBJECT IDENTIFIER,
             *      Content ([0] EXPLICIT ANY DEFINED BY contentType OPTIONAL)
             *          SignedData ::= SEQUENCE {
                             version Version ::= INTEGER, // https://datatracker.ietf.org/doc/html/rfc2315#section-6.9
                             digestAlgorithms DigestAlgorithmIdentifiers,
                             contentInfo ContentInfo,
                             certificates
                                [0] IMPLICIT ExtendedCertificatesAndCertificates
                                  OPTIONAL,
                             crls
                               [1] IMPLICIT CertificateRevocationLists OPTIONAL,
                             signerInfos SignerInfos } }
             *
             * The OID takes 11 bytes. Each other constructed element has a minimum of 2 bytes
             * for tag and length, so start looking at offset 15 for a SEQUENCE followed
             * immediately by INTEGER 3 (02 01 03).
             *
             */

            const int startOffset = 15; // Start checking from this index
            const int endOffset = 100; // Stop checking at this index
            const byte asn1SequenceTag = 0x30; // ASN.1 SEQUENCE tag
            const byte asn1LengthBit = 0x80; // Bit indicating a constructed ASN.1 length
            const byte cmsVersionTag = 0x02; // ASN.1 INTEGER tag for cmsVersion
            const byte cmsVersionLength = 0x01; // CMS version value length
            const byte cmsVersionV1 = 0x01; // cmsVersion 1

            // Iterate over the specified range in the data
            for (int i = startOffset; i < endOffset; i++)
            {
                // Check if the current byte marks the start of an ASN.1 SEQUENCE
                if (signedData[i] == asn1SequenceTag && (signedData[i + 1] & asn1LengthBit) == asn1LengthBit)
                {
                    // Extract the length of the SEQUENCE
                    int sequenceLength = signedData[i + 1] & ~asn1LengthBit; // 0x7F

                    // Calculate the index of the cmsVersion value
                    int cmsVersionIndex = i + 4 + sequenceLength;

                    if (cmsVersionIndex >= signedData.Length) continue;

                    // Verify that the structure matches the expected pattern
                    if (signedData[i + 2 + sequenceLength] == cmsVersionTag && // tag for cmsVersion
                        signedData[i + 3 + sequenceLength] == cmsVersionLength // CMS version value length
                        )
                    {
                        // Update cmsVersion to 1
                        signedData[cmsVersionIndex] = cmsVersionV1;
                    }
                }
            }

            return signedData;
        }
    }
}
