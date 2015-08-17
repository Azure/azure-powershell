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

using System.Threading;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// Contains Batch account details for use when interacting with the Batch service.
    /// </summary>
    public class BatchAccountContext
    {
        private AccountKeyType keyInUse;
        private BatchClient batchOMClient;

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
        public string AccountName { get; private set; }

        /// <summary>
        /// The region in which the account was created.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// The name of the resource group that the account resource is under.
        /// </summary>
        public string ResourceGroupName { get; private set; }

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
        public string TaskTenantUrl { get; private set; }

        /// <summary>
        /// Tags associated with the account resource.
        /// </summary>
        public Hashtable[] Tags { get; private set; }

        /// <summary>
        /// A string representation of the Tags property.
        /// </summary>
        public string TagsTable
        {
            get { return Helpers.FormatTagsTable(Tags); }
        }

        /// <summary>
        /// The key to use when interacting with the Batch service. Be default, the primary key will be used.
        /// </summary>
        public AccountKeyType KeyInUse 
        { 
            get { return this.keyInUse; }
            set
            {
                if (value != this.keyInUse)
                {
                    this.batchOMClient.Dispose();
                    this.batchOMClient = null;
                }
                this.keyInUse = value;
            } 
        }

        internal BatchClient BatchOMClient
        {
            get
            {
                if (this.batchOMClient == null)
                {
                    if ((KeyInUse == AccountKeyType.Primary && string.IsNullOrEmpty(PrimaryAccountKey)) ||
                        (KeyInUse == AccountKeyType.Secondary && string.IsNullOrEmpty(SecondaryAccountKey)))
                    {
                        throw new InvalidOperationException(string.Format(Resources.KeyNotPresent, KeyInUse));
                    }
                    string key = KeyInUse == AccountKeyType.Primary ? PrimaryAccountKey : SecondaryAccountKey;
                    BatchSharedKeyCredentials credentials = new BatchSharedKeyCredentials(TaskTenantUrl, AccountName, key);
                    this.batchOMClient = Microsoft.Azure.Batch.BatchClient.Open(credentials);
                }
                return this.batchOMClient;
            }
        }

        internal BatchAccountContext()
        {
            this.keyInUse = AccountKeyType.Primary;
        }

        internal BatchAccountContext(string accountEndpoint) : this()
        {
            this.AccountEndpoint = accountEndpoint;
        }

        /// <summary>
        /// Take an AccountResource and turn it into a BatchAccountContext
        /// </summary>
        /// <param name="resource">Resource info returned by RP</param>
        /// <returns>Void</returns>
        internal void ConvertAccountResourceToAccountContext(AccountResource resource)
        {
            var accountEndpoint = resource.Properties.AccountEndpoint;
            if (Uri.CheckHostName(accountEndpoint) != UriHostNameType.Dns)
            {
                throw new ArgumentException(String.Format(Resources.InvalidEndpointType, accountEndpoint), "AccountEndpoint");
            }

            this.Id = resource.Id;
            this.AccountEndpoint = accountEndpoint;
            this.Location = resource.Location;
            this.State = resource.Properties.ProvisioningState.ToString();
            this.Tags = Helpers.CreateTagHashtable(resource.Tags);

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
        /// <returns>new instance of BatchAccountContext</returns>
        internal static BatchAccountContext ConvertAccountResourceToNewAccountContext(AccountResource resource)
        {
            var baContext = new BatchAccountContext();
            baContext.ConvertAccountResourceToAccountContext(resource);
            return baContext;
        }
    }
}
