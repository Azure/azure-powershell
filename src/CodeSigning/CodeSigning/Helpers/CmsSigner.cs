using Azure.CodeSigning.Client.CryptoProvider;
using Azure.Core;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using Azure.CodeSigning;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    internal class CmsSigner
    {
        public CmsSigner() { }
        public void SignCIPolicy(TokenCredential tokenCred, string accountName, string certProfile,
            string endpointUrl, string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl)
        {
            int retry = 5;
            while (retry-- > 0)
            {
                var context = new AzCodeSignContext(tokenCred, accountName, certProfile, endpointUrl);

                var cert = context.InitializeChainAsync().Result;
                RSA rsa = new RSAAzCodeSign(context);

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
            }
        }
    }
}
