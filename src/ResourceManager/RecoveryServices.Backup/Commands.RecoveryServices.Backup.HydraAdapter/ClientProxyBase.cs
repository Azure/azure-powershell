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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter
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

        public static AzureRmRecoveryServicesVaultCreds recoveryServicesVaultCreds = new AzureRmRecoveryServicesVaultCreds();

        public ClientProxyBase(params object[] parameters)
        {
            Parameters = parameters;

            RefreshClientRequestId();

            // Temp code to be able to test internal env.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public void RefreshClientRequestId()
        {
            ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-PS";
        }

        public string GetClientRequestId()
        {
            return ClientRequestId;
        }

        public static void UpdateCurrentVaultContext(AzureRmRecoveryServicesVaultCreds vaultCreds)
        {
            object updateVaultContextOneAtATime = new object();
            lock (updateVaultContextOneAtATime)
            {
                recoveryServicesVaultCreds.ResourceName =
                    vaultCreds.ResourceName;
                recoveryServicesVaultCreds.ResourceGroupName =
                    vaultCreds.ResourceGroupName;
                recoveryServicesVaultCreds.Location =
                    vaultCreds.Location;                
            }
        }
    }
}
