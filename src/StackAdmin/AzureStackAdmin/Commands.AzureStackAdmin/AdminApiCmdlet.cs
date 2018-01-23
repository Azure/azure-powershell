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


using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure;
    using Microsoft.AzureStack.Management;

    /// <summary>
    /// Base Admin API cmdlet class
    /// </summary>
    public abstract class AdminApiCmdlet : AzureRMCmdlet
    {

        protected const string SubscriptionApiVersion = "2015-11-01";
        protected const string GalleryAdminApiVersion = "2015-04-01";
        protected const string UsageApiVersion = "2015-06-01-preview";

        /// <summary>
        /// Gets or sets the API version. Not a parameter that is to bes passed from outside
        /// </summary>
        protected string ApiVersion { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        protected AdminApiCmdlet()
        {
            this.ApiVersion = SubscriptionApiVersion;
        }

        /// <summary>
        /// Gets the current default context. overriding it here since DefaultContext could be null for Windows Auth/ADFS environments
        /// </summary>
        protected override IAzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null)
                {
                    return null;
                }

                return DefaultProfile.DefaultContext;
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

            if (this.MyInvocation.BoundParameters.Keys.Contains("ResourceGroup", StringComparer.OrdinalIgnoreCase))
            {
                this.WriteWarning("The parameter alias ResourceGroup will be deprecated in a future release. Please use the parameter ResourceGroupName instead");
            }

            // Execute the API call(s) for the current cmdlet
            this.ExecuteCore();

        }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected abstract void ExecuteCore();

        /// <summary>
        /// Gets the Azure Stack management client.
        /// </summary>
        protected AzureStackClient GetAzureStackClient()
        {
           return GetAzureStackClientThruAzureSession();
        }

        private AzureStackClient GetAzureStackClientThruAzureSession()
        {
            var armUri = this.DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            var credentials = AzureSession.Instance.AuthenticationFactory.GetSubscriptionCloudCredentials(this.DefaultContext);

            return AzureSession.Instance.ClientFactory.CreateCustomClient<AzureStackClient>(armUri, credentials, this.ApiVersion);
        }
    }
}
