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
using Azure.CodeSigning;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Text.Json;
using System.IO;
using Azure.Core;
using Microsoft.Azure.Commands.CodeSigning.Helpers;

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
            //if need modify inner exception
            //if (exception is KeyVaultErrorException kvEx && kvEx?.Body?.Error != null)
            //{
            //    var detailedMsg = exception.Message;
            //    detailedMsg += string.Format(Environment.NewLine + "Code: {0}", kvEx.Body.Error.Code);
            //    detailedMsg += string.Format(Environment.NewLine + "Message: {0}", kvEx.Body.Error.Message);
            //    exception = new KeyVaultErrorException(detailedMsg, kvEx);
            //}
            return exception;
        }

        private void Initialize(IAuthenticationFactory authFactory, IAzureContext context)
        {
            user_creds = new UserSuppliedCredential(new CodeSigningServiceCredential(authFactory, context, "api://cf2ab426-f71a-4b61-bb8a-9e505b85bc2e"));            
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

        public string GetCodeSigningEku(string accountName, string profileName, string endpoint)
        {
            GetCertificateProfileClient(endpoint);

            var eku = CertificateProfileClient.GetSignEku(accountName, profileName);
            return string.Join(",", ((List<string>)eku).ToArray()); 
        }
        public string GetCodeSigningEku(string metadataPath)
        {
            var rawMetadata = File.ReadAllBytes(metadataPath);
            Metadata = JsonSerializer.Deserialize<Metadata>(rawMetadata);

            GetCertificateProfileClient(Metadata.Endpoint);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
            var eku = CertificateProfileClient.GetSignEku(accountName, profileName);
            return string.Join(",", ((List<string>)eku).ToArray());
        }

        public Stream GetCodeSigningRootCert(string accountName, string profileName, string endpoint)
        {
            GetCertificateProfileClient(endpoint);

            var rootCert = CertificateProfileClient.GetSignCertificateRoot(accountName, profileName);
            return rootCert;
        }

        public void SubmitCIPolicySigning(string accountName, string profileName, string endpoint, 
            string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl = null)
        {            
           var cipolicySigner = new CmsSigner();
           cipolicySigner.SignCIPolicy(user_creds, accountName, profileName, endpoint, unsignedCIFilePath, signedCIFilePath, timeStamperUrl);
        }

        public Stream GetCodeSigningRootCert(string metadataPath)
        {
            var rawMetadata = File.ReadAllBytes(metadataPath);
            Metadata = JsonSerializer.Deserialize<Metadata>(rawMetadata);

            GetCertificateProfileClient(Metadata.Endpoint);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;

            var rootCert = CertificateProfileClient.GetSignCertificateRoot(accountName, profileName);
            return rootCert;
        }

        public void SubmitCIPolicySigning(string metadataPath, string unsignedCIFilePath, string signedCIFilePath, string timeStamperUrl)
        {
            var rawMetadata = File.ReadAllBytes(metadataPath);
            Metadata = JsonSerializer.Deserialize<Metadata>(rawMetadata);

            var accountName = Metadata.CodeSigningAccountName;
            var profileName = Metadata.CertificateProfileName;
        }
    }
}
