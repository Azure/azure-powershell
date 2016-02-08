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
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using System;
using System.Net;
using System.Threading;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public class ClientAdapterBase
    {
        /// <summary>
        /// Cloud credentials for client calls
        /// </summary>
        protected SubscriptionCloudCredentials CloudCreds { get; set; }

        /// <summary>
        /// Base URI for client calls
        /// </summary>
        protected Uri BaseURI { get; set; }

        /// <summary>
        /// Client request id.
        /// </summary>
        protected string ClientRequestId;

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public CancellationToken CmdletCancellationToken;

        public ClientAdapterBase(SubscriptionCloudCredentials creds, Uri baseUri)
        {
            CloudCreds = creds;
            BaseURI = baseUri;

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
    }
}

