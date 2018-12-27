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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest;
using System;
using System.Collections;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// Contains Batch account details for use when interacting with the Batch service.
    /// </summary>
    public class BatchAccountContext
    {
        private AccountKeyType keyInUse;
        private BatchClient batchOMClient;
        private IAzureContext azureContext;

        /// <summary>
        /// The account resource Id.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The account endpoint.
        /// </summary>
        public string AccountEndpoint { get; private set; }

        /// <summary>
        /// The primary account key.
        /// </summary>
        public string PrimaryAccountKey { get; internal set; }

        /// <summary>
        /// The secondary account key.
        /// </summary>
        public string SecondaryAccountKey { get; internal set; }

        /// <summary>
        /// The name of the Batch account.
        /// </summary>
        public string AccountName { get; protected set; }

        /// <summary>
        /// The region in which the account was created.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// The name of the resource group that the account resource is under.
        /// </summary>
        public string ResourceGroupName { get; internal set; }

        /// <summary>
        /// The subscription Id that the account belongs to.
        /// </summary>
        public string Subscription { get; private set; }

        /// <summary>
        /// The provisioning state of the account resource.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// The Batch service endpoint.
        /// </summary>
        public string TaskTenantUrl { get; protected set; }

        /// <summary>
        /// Tags associated with the account resource.
        /// </summary>
        public Hashtable Tags { get; private set; }

        /// <summary>
        /// A string representation of the Tags property.
        /// </summary>
        public string TagsTable
        {
            get { return Helpers.FormatTagsTable(Tags); }
        }

        /// <summary>
        /// The core quota for this Batch account.
        /// </summary>
        public int CoreQuota { get; private set; }

        /// <summary>
        /// The pool quota for this Batch account.
        /// </summary>
        public int PoolQuota { get; private set; }

        /// <summary>
        /// The active job and job schedule quota for this Batch account.
        /// </summary>
        public int ActiveJobAndJobScheduleQuota { get; private set; }

        /// <summary>
        /// Contains information about the auto storage associated with a Batch account.
        /// </summary>
        public AutoStorageProperties AutoStorageProperties { get; set; }

        /// <summary>
        /// The allocation mode to use for creating pools in the Batch account.
        /// </summary>
        public PoolAllocationMode? PoolAllocationMode { get; private set; }

        /// <summary>
        /// A reference to the Azure key vault associated with the Batch account.
        /// </summary>
        public KeyVaultReference KeyVaultReference { get; private set; }

        /// <summary>
        /// The key to use when interacting with the Batch service. Be default, the primary key will be used.
        /// </summary>
        public AccountKeyType KeyInUse
        {
            get { return this.keyInUse; }
            set
            {
                if (this.batchOMClient != null && this.HasKeys && value != this.keyInUse)
                {
                    this.batchOMClient.Dispose();
                    this.batchOMClient = null;
                }
                this.keyInUse = value;
            }
        }

        internal bool HasKeys
        {
            get { return !string.IsNullOrEmpty(PrimaryAccountKey) || !string.IsNullOrEmpty(SecondaryAccountKey);  }
        }

        internal BatchClient BatchOMClient
        {
            get
            {
                if (this.batchOMClient == null)
                {
                    ServiceClientCredentials credentials;
                    if (this.HasKeys)
                    {
                        // Use shared key auth
                        string key = KeyInUse == AccountKeyType.Primary ? PrimaryAccountKey : SecondaryAccountKey;
                        credentials = new BatchSharedKeyCredential(AccountName, key);
                    }
                    else
                    {
                        // Use AAD auth
                        credentials = new TokenCredentials(new BatchAadTokenProvider(this.azureContext));
                    }
                    BatchServiceClient restClient = CreateBatchRestClient(TaskTenantUrl, credentials);
                    this.batchOMClient = Microsoft.Azure.Batch.BatchClient.Open(restClient);
                }
                return this.batchOMClient;
            }
        }

        public BatchAccountContext(IAzureContext azureContext)
        {
            this.KeyInUse = AccountKeyType.Primary;
            this.azureContext = azureContext;
        }

        /// <summary>
        /// Take an AccountResource and turn it into a BatchAccountContext
        /// </summary>
        /// <param name="resource">Resource info returned by RP</param>
        /// <returns>Void</returns>
        internal void ConvertAccountResourceToAccountContext(BatchAccount resource)
        {
            var accountEndpoint = resource.AccountEndpoint;
            if (Uri.CheckHostName(accountEndpoint) != UriHostNameType.Dns)
            {
                throw new ArgumentException(String.Format(Resources.InvalidEndpointType, accountEndpoint), "AccountEndpoint");
            }

            this.Id = resource.Id;
            this.AccountEndpoint = accountEndpoint;
            this.Location = resource.Location;
            this.State = resource.ProvisioningState.ToString();
            this.Tags = TagsConversionHelper.CreateTagHashtable(resource.Tags);
            this.CoreQuota = resource.CoreQuota;
            this.PoolQuota = resource.PoolQuota;
            this.ActiveJobAndJobScheduleQuota = resource.ActiveJobAndJobScheduleQuota;
            this.PoolAllocationMode = resource.PoolAllocationMode;
            
            if (resource.AutoStorage != null)
            {
                this.AutoStorageProperties = new AutoStorageProperties()
                {
                    StorageAccountId = resource.AutoStorage.StorageAccountId,
                    LastKeySync = resource.AutoStorage.LastKeySync,
                };
            }

            if (resource.KeyVaultReference != null)
            {
                this.KeyVaultReference = resource.KeyVaultReference;
            }

            // extract the host and strip off the account name for the TaskTenantUrl and AccountName
            var hostParts = accountEndpoint.Split('.');
            this.AccountName = hostParts[0];
            this.TaskTenantUrl = Uri.UriSchemeHttps + Uri.SchemeDelimiter + accountEndpoint;

            // get remaining fields from Id which looks like:
            // /subscriptions/4a06fe24-c197-4353-adc1-058d1a51924e/resourceGroups/clwtest/providers/Microsoft.Batch/batchAccounts/clw
            var idParts = resource.Id.Split('/');
            if (idParts.Length < 5)
            {
                throw new ArgumentException(String.Format(Resources.InvalidResourceId, resource.Id), "Id");
            }

            this.Subscription = idParts[2];
            this.ResourceGroupName = idParts[4];
        }

        /// <summary>
        /// Create a new BAC and fill it in
        /// </summary>
        /// <param name="resource">Resource info returned by RP</param>
        /// <param name="azureContext">The Azure Context</param>
        /// <returns>new instance of BatchAccountContext</returns>
        internal static BatchAccountContext ConvertAccountResourceToNewAccountContext(BatchAccount resource, IAzureContext azureContext)
        {
            var baContext = new BatchAccountContext(azureContext);
            baContext.ConvertAccountResourceToAccountContext(resource);
            return baContext;
        }

        protected virtual BatchServiceClient CreateBatchRestClient(string url, ServiceClientCredentials creds, DelegatingHandler handler = default(DelegatingHandler))
        {
            BatchServiceClient restClient = handler == null ? new BatchServiceClient(new Uri(url), creds) : new BatchServiceClient(new Uri(url), creds, handler);

            restClient.HttpClient.DefaultRequestHeaders.UserAgent.Add(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.UserAgentValue);

            restClient.SetRetryPolicy(null); //Force there to be no retries
            restClient.HttpClient.Timeout = Timeout.InfiniteTimeSpan; //Client side timeout will be set per-request

            return restClient;
        }
    }
}
