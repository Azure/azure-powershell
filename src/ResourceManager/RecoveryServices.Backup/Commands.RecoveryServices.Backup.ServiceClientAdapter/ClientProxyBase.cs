﻿// ----------------------------------------------------------------------------------
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
using System.Net;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Basic utilities and initializations for client proxy
    /// </summary>
    public class ClientProxyBase
    {
        protected IAzureContext Context;

        /// <summary>
        /// Client request id.
        /// </summary>
        protected string ClientRequestId;

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public CancellationToken CmdletCancellationToken;

        /// <summary>
        /// AzureContext based ctor
        /// </summary>
        /// <param name="context">Azure Context</param>
        public ClientProxyBase(IAzureContext context)
        {
            Context = context;

            RefreshClientRequestId();

            // Temp code to be able to test internal env.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        /// <summary>
        /// Assigns a new client request ID to be used in each service client call - for logging purposes
        /// </summary>
        public void RefreshClientRequestId()
        {
            ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-PS";
        }

        /// <summary>
        /// Gets the client request ID set by the context
        /// </summary>
        /// <returns>Client request ID</returns>
        public string GetClientRequestId()
        {
            return ClientRequestId;
        }

        /// <summary>
        /// Gets Recovery Services vault name from the vault context
        /// </summary>
        /// <returns></returns>
        public string GetResourceName()
        {
            if (string.IsNullOrEmpty(PSRecoveryServicesClient.arsVault.Name))
            {
                throw new ArgumentException(Resources.SetVaultContextFirst);
            }
            return PSRecoveryServicesClient.arsVault.Name;
        }

        /// <summary>
        /// Gets Recovery Services Vault's resource group name from the vault context
        /// </summary>
        /// <returns></returns>
        public string GetResourceGroupName()
        {
            if (string.IsNullOrEmpty(PSRecoveryServicesClient.arsVault.ResourceGroupName))
            {
                throw new ArgumentException(Resources.SetVaultContextFirst);
            }
            return PSRecoveryServicesClient.arsVault.ResourceGroupName;
        }

        /// <summary>
        /// Gets Recovery Services Vault's location from the vault context
        /// </summary>
        /// <returns></returns>
        public string GetResourceLocation()
        {
            if (string.IsNullOrEmpty(PSRecoveryServicesClient.arsVault.Location))
            {
                throw new ArgumentException(Resources.SetVaultContextFirst);
            }
            return PSRecoveryServicesClient.arsVault.Location;
        }
    }
}
