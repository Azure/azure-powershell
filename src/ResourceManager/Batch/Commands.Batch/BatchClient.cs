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

using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch
{
    public class BatchClient
    {
        public IBatchManagementClient BatchManagementClient{ get; private set; }

        public IResourceManagementClient ResourceManagementClient { get; private set; }

        private static string batchProvider = "Microsoft.Batch";
        private static string accountObject = "batchAccounts";
        private static string accountSearch = batchProvider + "/" + accountObject;

        public BatchClient()
        { }

        /// <summary>
        /// Creates new BatchClient instance
        /// </summary>
        /// <param name="batchManagementClient">The IBatchManagementClient instance</param>
        public BatchClient(IBatchManagementClient batchManagementClient, IResourceManagementClient resourceManagementClient)
        {
            BatchManagementClient = batchManagementClient;
            ResourceManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Creates new ResourceManagementClient
        /// </summary>
        /// <param name="subscription">Context with subscription containing a batch account to manipulate</param>
        public BatchClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<BatchManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager),
            AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        #region Account verbs
        /// <summary>
        /// Creates a new Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group in which to create the account</param>
        /// <param name="accountName">The account name</param>
        /// <param name="location">The location to use when creating the account</param>
        /// <param name="tags">The tags to associate with the account</param>
        /// <returns>A BatchAccountContext object representing the new account</returns>
        public virtual BatchAccountContext CreateAccount(string resourceGroupName, string accountName, string location, Hashtable[] tags)
        {
            // use the group lookup to validate whether account already exists. We don't care about the returned
            // group name nor the exception
            if (GetGroupForAccountNoThrow(accountName) != null)
            {
                throw new CloudException(Resources.NBA_AccountAlreadyExists);
            }

            Dictionary<string, string> tagDictionary = Helpers.CreateTagDictionary(tags, validate: true);
            
            var response = BatchManagementClient.Accounts.Create(resourceGroupName, accountName, new BatchAccountCreateParameters()
            {
                Location = location,
                Tags = tagDictionary
            });

            var context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(response.Resource);
            return context;
        }

        /// <summary>
        /// Updates an existing Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <param name="tags">New tags to associate with the account</param>
        /// <returns>A BatchAccountContext object representing the updated account</returns>
        public virtual BatchAccountContext UpdateAccount(string resourceGroupName, string accountName, Hashtable[] tags)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            Dictionary<string, string> tagDictionary = Helpers.CreateTagDictionary(tags, validate: true);


            // need to the location in order to call 
            var getResponse = BatchManagementClient.Accounts.Get(resourceGroupName, accountName);

            var response = BatchManagementClient.Accounts.Create(resourceGroupName, accountName, new BatchAccountCreateParameters()
            {
                Location = getResponse.Resource.Location,
                Tags = tagDictionary
            });

            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(response.Resource);

            return context;
        }

        /// <summary>
        /// Get details about the Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <returns>A BatchAccountContext object representing the account</returns>
        public virtual BatchAccountContext GetAccount(string resourceGroupName, string accountName)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }
            var response = BatchManagementClient.Accounts.Get(resourceGroupName, accountName);

            return BatchAccountContext.ConvertAccountResourceToNewAccountContext(response.Resource);
        }

        /// <summary>
        /// Gets the keys associated with the Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <returns>A BatchAccountContext object with the account keys</returns>
        public virtual BatchAccountContext ListKeys(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            var context = GetAccount(resourceGroupName, accountName);
            var keysResponse = BatchManagementClient.Accounts.ListKeys(resourceGroupName, accountName);
            context.PrimaryAccountKey = keysResponse.PrimaryKey;
            context.SecondaryAccountKey = keysResponse.SecondaryKey;

            return context;
        }

        /// <summary>
        /// Lists all accounts in a subscription or in a resource group if its name is specified
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to search under for accounts. If unspecified, all accounts will be looked up.</param>
        /// <param name="tag">The tag to filter accounts on</param>
        /// <returns>A collection of BatchAccountContext objects</returns>
        public virtual IEnumerable<BatchAccountContext> ListAccounts(string resourceGroupName, Hashtable tag)
        {
            List<BatchAccountContext> accounts = new List<BatchAccountContext>();

            // no account name so we're doing some sort of list. If no resource group, then list all accounts under the
            // subscription otherwise all accounts in the resource group.
            var response = BatchManagementClient.Accounts.List(new AccountListParameters { ResourceGroupName = resourceGroupName });

            // filter out the accounts if a tag was specified
            IList<AccountResource> accountResources = new List<AccountResource>();
            if (tag != null && tag.Count > 0)
            {
                accountResources = Helpers.FilterAccounts(response.Accounts, tag);
            }
            else
            {
                accountResources = response.Accounts;
            }

            foreach (AccountResource resource in accountResources)
            {
                accounts.Add(BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource));
            }

            var nextLink = response.NextLink;

            while (nextLink != null)
            {
                response = ListNextAccounts(nextLink);

                foreach (AccountResource resource in response.Accounts)
                {
                    accounts.Add(BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource));
                }

                nextLink = response.NextLink;
            }

            return accounts;
        }

        /// <summary>
        /// Generates new key for the Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <param name="keyType">The type of key to regenerate</param>
        /// <returns>The BatchAccountContext object with the regenerated keys</returns>
        public virtual BatchAccountContext RegenerateKeys(string resourceGroupName, string accountName, AccountKeyType keyType)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            // build a new context to put the keys into
            var context = GetAccount(resourceGroupName, accountName);

            var regenResponse = BatchManagementClient.Accounts.RegenerateKey(resourceGroupName, accountName, new BatchAccountRegenerateKeyParameters
            {
                KeyName = keyType
            });

            context.PrimaryAccountKey = regenResponse.PrimaryKey;
            context.SecondaryAccountKey = regenResponse.SecondaryKey;
            return context;
        }

        /// <summary>
        /// Deletes the specified account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <returns>The status of delete account operation</returns>
        public virtual OperationResponse DeleteAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }
            return BatchManagementClient.Accounts.Delete(resourceGroupName, accountName);
        }
        #endregion

        /// <summary>
        /// Lists all accounts in a subscription or in a resource group if its name is specified
        /// </summary>
        /// <param name="nextLink">Next link to use when querying for accounts</param>
        /// <returns>The status of list operation</returns>
        internal BatchAccountListResponse ListNextAccounts(string NextLink)
        {
            return BatchManagementClient.Accounts.ListNext(NextLink);
        }

        internal string GetGroupForAccountNoThrow(string accountName)
        {
            var response = ResourceManagementClient.Resources.List(new Management.Resources.Models.ResourceListParameters()
            {
                ResourceType = accountSearch
            });

            string groupName = null;

            foreach (var res in response.Resources)
            {
                if (res.Name == accountName)
                {
                    groupName = ExtractResourceGroupName(res.Id);
                }
            }

            return groupName;
        }

        internal string GetGroupForAccount(string accountName)
        {
            var groupName = GetGroupForAccountNoThrow(accountName);
            if (groupName == null)
            {
                throw new CloudException(Resources.ResourceNotFound);
            }

            return groupName;
        }

        private string ExtractResourceGroupName(string id)
        {
            var idParts = id.Split('/');
            if (idParts.Length < 4)
            {
                throw new CloudException(String.Format(Resources.MissingResGroupName, id));
            }

            return idParts[4];
        }
    }
}
