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

using Azure.CodeSigning;
using Azure.Core;
using Microsoft.Azure.Commands.CodeSigning.Helpers;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    internal class CodeSigningServiceClient : ICodeSigningServiceClient
    {
        /// <summary>
        /// Parameterless constructor for Mocking.
        /// </summary>
        public CodeSigningServiceClient()
        {
        }
        private CertificateProfileClient CertificateProfileClient { get; set; }
        private Metadata Metadata { get; set; }

        TokenCredential user_creds;

        public CodeSigningServiceClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Environment == null)
                //throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);
                throw new ArgumentException("Invalid Environment");

            Initialize(authFactory, context);
        }

        private Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }

        private void Initialize(IAuthenticationFactory authFactory, IAzureContext context)
        {
            user_creds = new UserSuppliedCredential(new CodeSigningServiceCredential(authFactory, context, "https://codesigning.azure.net/"));
        }

        private void GetCertificateProfileClient(string endpoint)
        {
            var options = new CertificateProfileClientOptions();
            options.Diagnostics.IsTelemetryEnabled = false;
            options.Diagnostics.IsLoggingEnabled = false;
            options.Diagnostics.IsLoggingContentEnabled = false;

            CertificateProfileClient = new CertificateProfileClient(
             user_creds,
             new Uri(endpoint),
             options);
        }

        public string[] GetCodeSigningEku(string accountName, string profileName, string endpoint)
        {
            GetCertificateProfileClient(endpoint);

            var eku = CertificateProfileClient.GetSignEku(accountName, profileName);

            return eku.Value?.Distinct().ToArray();
        }
        public string[] GetCodeSigningEku(string metadataPath)
        {
            var rawMetadata = File.ReadAllText(metadataPath);
            Metadata = JsonConvert.DeserializeObject<Metadata>(rawMetadata);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
            var endpoint = Metadata.Endpoint;

            return GetCodeSigningEku(accountName, profileName, endpoint);
        }

        public Stream GetCodeSigningRootCert(string accountName, string profileName, string endpoint)
        {
            GetCertificateProfileClient(endpoint);

            var rootCert = CertificateProfileClient.GetSignCertificateRoot(accountName, profileName);
            return rootCert;
        }

        public Stream GetCodeSigningRootCert(string metadataPath)
        {
            var rawMetadata = File.ReadAllText(metadataPath);
            Metadata = JsonConvert.DeserializeObject<Metadata>(rawMetadata);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
            var endpoint = Metadata.Endpoint;

            return GetCodeSigningRootCert(accountName, profileName, endpoint);
        }

        public Stream GetCodeSigningCertChain(string accountName, string profileName, string endpoint)
        {
            GetCertificateProfileClient(endpoint);

            var certChain = CertificateProfileClient.GetSignCertificateChain(accountName, profileName);
            return certChain;
        }

        public Stream GetCodeSigningCertChain(string metadataPath)
        {
            var rawMetadata = File.ReadAllText(metadataPath);
            Metadata = JsonConvert.DeserializeObject<Metadata>(rawMetadata);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
            var endpoint = Metadata.Endpoint;

            return GetCodeSigningCertChain(accountName, profileName, endpoint);
        }

        public void SubmitCIPolicySigning(string accountName, string profileName, string endpoint,
            string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl = null)
        {
            var cipolicySigner = new CmsSigner();
            cipolicySigner.SignCIPolicy(user_creds, accountName, profileName, endpoint, unsignedCIFilePath, signedCIFilePath, timeStamperUrl);
        }

        public void SubmitCIPolicySigning(string metadataPath, string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl)
        {
            var rawMetadata = File.ReadAllText(metadataPath);
            Metadata = JsonConvert.DeserializeObject<Metadata>(rawMetadata);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
            var endpoint = Metadata.Endpoint;

            SubmitCIPolicySigning(accountName, profileName, endpoint, unsignedCIFilePath, signedCIFilePath, timeStamperUrl);
        }
    }
}
