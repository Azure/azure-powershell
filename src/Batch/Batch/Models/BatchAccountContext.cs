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
using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.Azure.Commands.Batch.Track2.Workarounds;
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
using System.Collections.Generic;
using AzureNamedKeyCredential = Azure.AzureNamedKeyCredential;
using HttpPipelinePosition = Azure.Core.HttpPipelinePosition;
using RetryMode = Azure.Core.RetryMode;
using Track2BatchClient = Azure.Compute.Batch.BatchClient;
using Track2BatchClientOptions = Azure.Compute.Batch.BatchClientOptions;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// Contains Batch account details for use when interacting with the Batch service.
    /// </summary>
    public class BatchAccountContext
    {
        private AccountKeyType keyInUse;
        private BatchClient batchOMClient;
        private Track2BatchClient track2Client;
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
        public string Subscription { get; internal set; }

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
        /// The dedicated core quota for this Batch account.
        /// </summary>
        public int? DedicatedCoreQuota { get; private set; }

        /// <summary>
        /// The low priority core quota for this Batch account.
        /// </summary>
        public int? LowPriorityCoreQuota { get; private set; }

        /// <summary>
        /// If dedicated core quota is enforced per-family.
        /// </summary>
        public bool DedicatedCoreQuotaPerVMFamilyEnforced { get; private set; }

        /// <summary>
        /// The dedicated core quota per VM family. This value is only enforced if <see cref="DedicatedCoreQuotaPerVMFamilyEnforced"/> is set to true.
        /// </summary>
        public Hashtable DedicatedCoreQuotaPerVMFamily { get; private set; }

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
        /// A list of private endpoint connections associated with the account.
        /// </summary>
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; private set; }

        /// <summary>
        /// The public network access type
        /// </summary>
        public PublicNetworkAccessType? PublicNetworkAccess { get; private set; }

        /// <summary>
        /// The identity of the Batch account, if configured. This is only used when the
        /// user specifies 'Microsoft.KeyVault' as their Batch account encryption configuration.
        /// </summary>
        public BatchAccountIdentity Identity { get; private set; }

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
                if (this.HasKeys && value != this.keyInUse)
                {
                    this.track2Client = null;
                }
                this.keyInUse = value;
            }
        }

        /// <summary>
        /// Gets the encryption configuration for the Batch account.
        /// </summary>
        /// <remarks>
        /// Configures how customer data is encrypted inside the Batch account.
        /// By default, accounts are encrypted using a Microsoft managed key.
        /// For additional control, a customer-managed key can be used instead.
        /// </remarks>
        public EncryptionProperties Encryption { get; private set; }

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

        /// <summary>
        /// The Track 2 (Azure.Compute.Batch) client for this account. Uses the same sign-in as the Track 1 client:
        /// shared key when the context has keys, otherwise Microsoft Entra ID for the current cloud.
        /// </summary>
        internal Track2BatchClient Track2Client
        {
            get
            {
                if (this.track2Client == null)
                {
                    Uri endpoint = new Uri(TaskTenantUrl);
                    Track2BatchClientOptions options = CreateTrack2ClientOptions();
                    if (this.HasKeys)
                    {
                        string key = KeyInUse == AccountKeyType.Primary ? PrimaryAccountKey : SecondaryAccountKey;
                        this.track2Client = new Track2BatchClient(endpoint, new AzureNamedKeyCredential(AccountName, key), options);
                    }
                    else
                    {
                        this.track2Client = new Track2BatchClient(endpoint, new BatchTokenCredential(new BatchAadTokenProvider(this.azureContext)), options);
                    }
                }
                return this.track2Client;
            }
        }

        /// <summary>
        /// Options for the Track 2 client. Retries and time-outs are the same as Track 1's (Microsoft.Azure.Batch
        /// 16.3.1): exponential retry starting at 1 second, up to 6 retries; 1 minute per request, 3 minutes for the
        /// requests Track 1 treated as long running. Tests override this to send the requests to a test handler.
        /// </summary>
        protected virtual Track2BatchClientOptions CreateTrack2ClientOptions()
        {
            Track2BatchClientOptions options = new Track2BatchClientOptions();
            options.Retry.Mode = RetryMode.Exponential;
            options.Retry.Delay = TimeSpan.FromSeconds(1);
            options.Retry.MaxRetries = 6;
            options.Retry.NetworkTimeout = BatchRequestTimeoutPolicy.RequestTimeout;
            options.AddPolicy(new BatchRequestTimeoutPolicy(), HttpPipelinePosition.PerCall);
            options.AddPolicy(new BatchWorkaroundsPolicy(), HttpPipelinePosition.PerCall);
            options.AddPolicy(new BatchUserAgentPolicy(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.UserAgentValue.ToString()), HttpPipelinePosition.PerRetry);
            return options;
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
            this.DedicatedCoreQuota = resource.DedicatedCoreQuota;
            this.LowPriorityCoreQuota = resource.LowPriorityCoreQuota;
            this.DedicatedCoreQuotaPerVMFamilyEnforced = resource.DedicatedCoreQuotaPerVMFamilyEnforced;
            this.DedicatedCoreQuotaPerVMFamily = CreateQuotaHashTable(resource.DedicatedCoreQuotaPerVMFamily);
            this.PoolQuota = resource.PoolQuota;
            this.ActiveJobAndJobScheduleQuota = resource.ActiveJobAndJobScheduleQuota;
            this.PoolAllocationMode = resource.PoolAllocationMode;
            this.PublicNetworkAccess = resource.PublicNetworkAccess;
            this.Identity = resource.Identity;
            this.Encryption = resource.Encryption;

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

            this.PrivateEndpointConnections = resource.PrivateEndpointConnections;

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


        private static Hashtable CreateQuotaHashTable(IList<VirtualMachineFamilyCoreQuota> quotas)
        {
            Hashtable result = new Hashtable();

            if(quotas == null)
            {
                return result;
            }

            foreach (var quota in quotas)
            {
                result.Add(quota.Name, quota.CoreQuota);
            }

            return result;
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
            BatchServiceClient restClient = handler == null ? new BatchServiceClient(creds) : new BatchServiceClient(creds, handler);
            restClient.BatchUrl = url;

            restClient.HttpClient.DefaultRequestHeaders.UserAgent.Add(Microsoft.WindowsAzure.Commands.Common.AzurePowerShell.UserAgentValue);

            restClient.SetRetryPolicy(null); //Force there to be no retries
            restClient.HttpClient.Timeout = Timeout.InfiniteTimeSpan; //Client side timeout will be set per-request

            return restClient;
        }
    }
}
