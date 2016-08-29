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

using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.AzureStack.Management.StorageAdmin;
using System;
using System.Management.Automation;
using System.Net;
using System.Net.Security;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     Admin cmdlet base
    /// </summary>
    public abstract class AdminCmdlet : AzureRMCmdlet, IDisposable
    {
        private bool disposed;

        /// <summary>
        ///     Storage Admin Management Client
        /// </summary>
        public StorageAdminManagementClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// Subscription identifier
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Authentication token
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Token { get; set; }

        /// <summary>
        /// Azure package admin URL
        /// </summary>
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateAbsoluteUri]
        public Uri AdminUri { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Disable certification validation
        /// </summary>
        [Parameter]
        public SwitchParameter SkipCertificateValidation { get; set; }

        ~AdminCmdlet()
        {
            Dispose(false);
        }

        private RemoteCertificateValidationCallback originalValidateCallback;

        private static readonly RemoteCertificateValidationCallback unCheckCertificateValidation = (s, certificate, chain, sslPolicyErrors) => true;

        //TODO: take back the validation
        private void ValidateParameters()
        {
            if (string.IsNullOrEmpty(Token))
            {
                if (DefaultContext == null)
                {
                    throw new ApplicationException(Resources.InvalidProfile);
                }
            }
            else
            {
                // if token is specified, AdminUri is required as well. 
                if (AdminUri == null || SubscriptionId == null)
                {
                    throw new ApplicationException(Resources.TokenAndAdminUriRequired);
                }
            }
        }


        /// <summary>
        ///     Initial StorageAdminManagementClient
        /// </summary>
        /// <returns></returns>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            originalValidateCallback = ServicePointManager.ServerCertificateValidationCallback;

            if (SkipCertificateValidation)
            {
                ServicePointManager.ServerCertificateValidationCallback = unCheckCertificateValidation;
            }

            ValidateParameters();

            Client = GetClient();
        }

        protected override AzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null)
                {
                    return null;
                }

                return DefaultProfile.Context;
            }
        }

        /// <summary>
        ///     Dispose StorageAdminManagementClient
        /// </summary>
        /// <returns></returns>
        protected override void EndProcessing()
        {
            StorageAdminManagementClient client = Client;
            if (client != null)
            {
                client.Dispose();
            }
            Client = null;
            if (SkipCertificateValidation)
            {
                if (originalValidateCallback != null)
                {
                    ServicePointManager.ServerCertificateValidationCallback = originalValidateCallback;
                }
            }

            base.EndProcessing();
        }

        protected override void ProcessRecord()
        {
            Execute();
            base.ProcessRecord();
        }

        protected virtual void Execute()
        {
        }

        /// <summary>
        /// Get token credentials
        /// </summary>
        /// <returns></returns>
        protected TokenCloudCredentials GetTokenCredentials()
        {
            return new TokenCloudCredentials(SubscriptionId, Token);
        }

        /// <summary>
        /// Dispose the resources
        /// </summary>
        /// <param name="disposing">Indicates whether the managed resources should be disposed or not</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (Client != null)
                {
                    Client.Dispose();
                    Client = null;
                }

                disposed = true;
            }
            base.Dispose(disposing);
        }

        protected StorageAdminManagementClient GetClient()
        {
            // get client from azure session if token is null or empty
            if (string.IsNullOrEmpty(Token))
            {
                return GetClientThruAzureSession();
            }

            return new StorageAdminManagementClient(
                    baseUri: AdminUri,
                    credentials: new TokenCloudCredentials(subscriptionId: SubscriptionId, token: Token));
        }

        private StorageAdminManagementClient GetClientThruAzureSession()
        {
            var context = DefaultContext;

            var armUri = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);

            var credentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);

            if (string.IsNullOrEmpty(SubscriptionId))
            {
                SubscriptionId = credentials.SubscriptionId;
            }

            return AzureSession.ClientFactory.CreateCustomClient<StorageAdminManagementClient>(credentials, armUri);
        }
    }
}
