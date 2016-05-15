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

namespace Microsoft.AzureStack.Commands
{
    using Microsoft.Azure;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.AzureStack.Management;
    using System;
    using System.Management.Automation;
    using System.Net;

    /// <summary>
    /// Base Admin API cmdlet class
    /// </summary>
    public abstract class AdminApiCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The default API version.
        /// </summary>
        private const string DefaultApiVersion = "1.0";

        /// <summary>
        /// Gets or sets the admin base URI
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateAbsoluteUri]
        public Uri AdminUri { get; set; }

        /// <summary>
        /// Gets or sets the authentication token
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable certificate validation.
        /// </summary>
        [Parameter]
        public SwitchParameter DisableCertificateValidation { get; set; }

        /// <summary>
        /// Gets the current default context. overriding it here since DefaultContext could be null for Windows Auth/ADFS environments
        /// </summary>
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
        /// Execute this cmdlet.
        /// </summary>
        /// <remarks>
        /// Descendant classes must override this methods instead of Cmdlet.ProcessRecord, so
        /// we can have a unique place where log all errors.
        /// </remarks>
        protected override void ProcessRecord()
        {
            var originalValidateCallback = ServicePointManager.ServerCertificateValidationCallback;
            object result;

            this.ValidateParameters();

            try
            {
                // Note: (bryanr) Adding the tracing interceptor requires using a message pump and action queue. See relevant thread in PowerShell Discussions.
                ////CloudContext.Configuration.Tracing.AddTracingInterceptor(this);

                // TODO (bryanr) - Evaluate if this should be removed entirely
                if (this.DisableCertificateValidation)
                {
                    this.WriteWarning(Resources.WarningDisableCertificateValidation);
                    ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                }

                // Initialize parameters bound from the pipeline
                this.ApiVersion = this.ApiVersion ?? DefaultApiVersion;

                // Execute the API call(s) for the current cmdlet
                result = this.ExecuteCore();
            }
            finally
            {
                if (this.DisableCertificateValidation)
                {
                    ServicePointManager.ServerCertificateValidationCallback = originalValidateCallback;
                }

                ////CloudContext.Configuration.Tracing.RemoveTracingInterceptor(this);
            }

            // Write the object to the pipeline only after the certificate validation callback has been restored.
            // This will prevent other cmdlets in the pipeline from inheriting this security vulnerability.
            if (result != null)
            {
                this.WriteObject(result, enumerateCollection: true);
            }
        }

        private void ValidateParameters()
        {
            // if Token is empty, make sure that we have a valid azure profile
            if (string.IsNullOrEmpty(this.Token))
            {
                if (this.DefaultContext == null)
                {
                    throw new ApplicationException(Resources.InvalidProfile);
                }
            }
            else
            {
                // if token is specified, AdminUri is required as well
                if (this.AdminUri == null)
                {
                    throw new ApplicationException(Resources.TokenAndAdminUriRequired);
                }
            }
        }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected abstract object ExecuteCore();

        /// <summary>
        /// Gets the Azure Stack management client.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        protected AzureStackClient GetAzureStackClient(string subscriptionId = null)
        {
            if (string.IsNullOrEmpty(this.Token))
            {
                return GetAzureStackClientThruAzureSession();
            }

            if (string.IsNullOrEmpty(subscriptionId))
            {
                return new AzureStackClient(
                    baseUri: this.AdminUri,
                    credentials: new TokenCloudCredentials(token: this.Token),
                    apiVersion: this.ApiVersion);
            }
            else
            {
                return new AzureStackClient(
                    baseUri: this.AdminUri,
                    credentials: new TokenCloudCredentials(subscriptionId: subscriptionId, token: this.Token),
                    apiVersion: this.ApiVersion);
            }
        }

        /// <summary>
        /// Gets the Azures Stack management client.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        protected AzureStackClient GetAzureStackClient(Guid subscriptionId)
        {
            return this.GetAzureStackClient(subscriptionId.ToString());
        }

        private AzureStackClient GetAzureStackClientThruAzureSession()
        {
            var armUri = this.DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            var credentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(this.DefaultContext);

            return AzureSession.ClientFactory.CreateCustomClient<AzureStackClient>(armUri, credentials, this.ApiVersion);
        }
    }
}
