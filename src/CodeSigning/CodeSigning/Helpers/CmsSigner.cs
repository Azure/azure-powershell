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

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
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
    }
}
