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
using System.Management.Automation;
using System.Net;
using System.Net.Security;
using Microsoft.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
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

            Client = GetClient();
        }

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
            if(this.MyInvocation.InvocationName.ToLower().Contains("-acs"))
            {
                WriteWarningWithTimestamp("\"-ACS\" aliases will be deprecated soon, please use -Azs cmdlet's");
            }
            Execute();
            base.ProcessRecord();
        }

        protected virtual void Execute()
        {
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
            return GetClientThruAzureSession();
        }

        private StorageAdminManagementClient GetClientThruAzureSession()
        {
            var context = DefaultContext;

            var armUri = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);

            var credentials = AzureSession.Instance.AuthenticationFactory.GetSubscriptionCloudCredentials(context);

            return AzureSession.Instance.ClientFactory.CreateCustomClient<StorageAdminManagementClient>(credentials, armUri);
        }

        protected string ParseNameForQuota(string name)
        {
            // the quota is a nested resource with its resourceName being location/name as presented to ARM
            // extract only the actual quota name from the ARM resource name.
            if (!string.IsNullOrEmpty(name) && name.IndexOf(@"/") != -1)
            {
                name = name.Substring(name.IndexOf(@"/") + 1);
            }

            return name;
        }

    }
}
