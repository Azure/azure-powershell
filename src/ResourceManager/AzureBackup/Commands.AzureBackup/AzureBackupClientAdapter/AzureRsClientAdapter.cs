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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Net;
using System.Threading;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureRsClientAdapter : ClientAdapterBase
    {
        private const string AzureFabricName = "Azure";

        /// <summary>
        /// Azure Recovery Services Backup client
        /// </summary>
        private RecoveryServicesBackupManagementClient azureRsClient;        

        /// <summary>
        /// Azure Recovery Services Backup client
        /// </summary>
        private RecoveryServicesBackupManagementClient AzureRSClient
        {
            get
            {
                if (this.azureRsClient == null)
                {
                    this.azureRsClient = AzureSession.ClientFactory.CreateCustomClient<RecoveryServicesBackupManagementClient>(CloudCreds, BaseURI);
                }

                return this.azureRsClient;
            }
        }

        public AzureRsClientAdapter(SubscriptionCloudCredentials creds, Uri baseUri)
            : base(creds, baseUri) { }

        internal CustomRequestHeaders GetCustomRequestHeaders()
        {
            var customRequestHeaders = new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request to backend service.
                ClientRequestId = this.ClientRequestId,
            };

            return customRequestHeaders;
        }
    }
}

