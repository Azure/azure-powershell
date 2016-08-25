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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public class ClientProxyBase
    {   
        protected object[] Parameters;

        /// <summary>
        /// Client request id.
        /// </summary>
        protected string ClientRequestId;

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public CancellationToken CmdletCancellationToken;
        
        public ClientProxyBase(params object[] parameters)
        {
            Parameters = parameters;

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
