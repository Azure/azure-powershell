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
using Azure.Identity;
using Microsoft.Azure.Commands.CodeSigning.Helpers;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Azure.Core;

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

        private Metadata Metadata { get; }

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
            var options = new CertificateProfileClientOptions();
            options.Diagnostics.IsTelemetryEnabled = false;
            options.Diagnostics.IsLoggingEnabled = false;
            options.Diagnostics.IsLoggingContentEnabled = false;

            TokenCredential user_creds;

            var clientCred = new CodeSigningServiceCredential(authFactory, context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
            var tenantId = clientCred.TenantId;
            user_creds = (TokenCredential)clientCred.GetAccessToken();           

            CertificateProfileClient = new CertificateProfileClient(
                user_creds,
                new Uri(Metadata.Endpoint),
                options);
        }
                
        public string GetCodeSigningEku(string accountName, string profileName, string endpoint)
        {
             var eku = CertificateProfileClient.GetSignEku(accountName, profileName);
            return eku;
        }
        public string GetCodeSigningEku(string metadataPath)
        {

            var accountName = "";
            var profileName = "";
            var eku = CertificateProfileClient.GetSignEku(accountName, profileName);
            return eku;
        }

        public byte[] GetCodeSigningRootCert(string accountName, string profileName, string endpoint)
        {
            throw new NotImplementedException();
        }

        public void SubmitCIPolicySigning(string accountName, string profileName, string endpoint)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCodeSigningRootCert(string metadataPath)
        {
            throw new NotImplementedException();
        }

        public void SubmitCIPolicySigning(string metadataPath)
        {
            throw new NotImplementedException();
        }
    }
}
