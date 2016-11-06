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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using CloudException = Hyak.Common.CloudException;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Creates a new Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group in which to create the account</param>
        /// <param name="accountName">The account name</param>
        /// <param name="location">The location to use when creating the account</param>
        /// <param name="tags">The tags to associate with the account</param>
        /// <param name="autoStorageAccountId">The resource id of the storage account to be used for auto storage.</param>
        /// <returns>A BatchAccountContext object representing the new account</returns>
        public virtual BatchAccountContext CreateAccount(string resourceGroupName, string accountName, string location, Hashtable tags, string autoStorageAccountId)
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            AutoStorageBaseProperties autoStorage = (string.IsNullOrEmpty(autoStorageAccountId)) ? null : new AutoStorageBaseProperties
            {
                StorageAccountId = autoStorageAccountId
            };

            var response = BatchManagementClient.Account.Create(resourceGroupName, accountName, new BatchAccountCreateParameters()
            {
                Location = location,
                Tags = tagDictionary,
                AutoStorage = autoStorage
            });

            var context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(response);
            return context;
        }

        /// <summary>
        /// Updates an existing Batch account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        /// <param name="tags">New tags to associate with the account</param>
        /// <param name="autoStorageAccountId">The resource id of the storage account to be used for auto storage.</param>
        /// <returns>A BatchAccountContext object representing the updated account</returns>
        public virtual BatchAccountContext UpdateAccount(string resourceGroupName, string accountName, Hashtable tags, string autoStorageAccountId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(tags, validate: true);
            
            // need to the location in order to call
            var getResponse = BatchManagementClient.Account.Get(resourceGroupName, accountName);

            AutoStorageBaseProperties autoStorage = (autoStorageAccountId == null) ? null : new AutoStorageBaseProperties
            {
                StorageAccountId = autoStorageAccountId
            };

            var response = BatchManagementClient.Account.Create(resourceGroupName, accountName, new BatchAccountCreateParameters()
            {
                Location = getResponse.Location,
                Tags = tagDictionary,
                AutoStorage = autoStorage
            });

            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(response);

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
            var response = BatchManagementClient.Account.Get(resourceGroupName, accountName);

            return BatchAccountContext.ConvertAccountResourceToNewAccountContext(response);
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
            var keysResponse = BatchManagementClient.Account.ListKeys(resourceGroupName, accountName);
            context.PrimaryAccountKey = keysResponse.Primary;
            context.SecondaryAccountKey = keysResponse.Secondary;

            return context;
        }

        /// <summary>
        /// Lists all accounts in a subscription or in a resource group if its name is specified
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to search under for accounts. If unspecified, all accounts will be looked up.</param>
        /// <param name="tag">The tag to filter accounts on</param>
        /// <returns>A collection of BatchAccountContext objects</returns>
        public virtual IEnumerable<BatchAccountContext> ListAccounts(Hashtable tag, string resourceGroupName = default(string))
        {
            // no account name so we're doing some sort of list. If no resource group, then list all accounts under the
            // subscription otherwise all accounts in the resource group.
            var response = string.IsNullOrEmpty(resourceGroupName)
                ? BatchManagementClient.Account.List()
                : BatchManagementClient.Account.ListByResourceGroup(resourceGroupName);

            var batchAccountContexts =
                ListAllAccounts(response).
                Where(acct => Helpers.MatchesTag(acct, tag)).
                Select(resource => BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource));

            return batchAccountContexts;
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

            var regenResponse = BatchManagementClient.Account.RegenerateKey(resourceGroupName, accountName, new BatchAccountRegenerateKeyParameters
            {
                KeyName = keyType
            });

            var context = GetAccount(resourceGroupName, accountName);
            context.PrimaryAccountKey = regenResponse.Primary;
            context.SecondaryAccountKey = regenResponse.Secondary;

            // build a new context to put the keys into
            return context;
        }

        /// <summary>
        /// Deletes the specified account
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the account is under. If unspecified, it will be looked up.</param>
        /// <param name="accountName">The account name</param>
        public virtual void DeleteAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            try
            {
                BatchManagementClient.Account.Delete(resourceGroupName, accountName);
            }
            catch (Rest.Azure.CloudException ex)
            {
                // TODO: Cleanup after TFS: 5914832
                // RP puts the operation status token under the account that's
                // being deleted, so we get a 404 from our Get Operation Status call when the
                // deletion completes. We want 404 to throw an error on the initial delete
                // request, but for now we want to consider a 404 error on the operation status
                // polling as a success.
                if (!(ex.Request.Method == HttpMethod.Get &&
                    ex.Message.Contains("Long running operation failed with status 'NotFound'")))
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Lists the node agent SKUs matching the specified filter options.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="filterClause">The level of detail</param>
        /// <param name="maxCount">The number of results.</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform.</param>
        /// <returns>The node agent SKUs matching the specified filter.</returns>
        public IEnumerable<PSNodeAgentSku> ListNodeAgentSkus(
            BatchAccountContext context,
            string filterClause = default(string),
            int maxCount = default(int),
            IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            PoolOperations poolOperations = context.BatchOMClient.PoolOperations;
            ODATADetailLevel filterLevel = new ODATADetailLevel(filterClause: filterClause);

            IPagedEnumerable<NodeAgentSku> nodeAgentSkus = poolOperations.ListNodeAgentSkus(filterLevel, additionalBehaviors);
            Func<NodeAgentSku, PSNodeAgentSku> mappingFunction = p => { return new PSNodeAgentSku(p); };

            return PSPagedEnumerable<PSNodeAgentSku, NodeAgentSku>.CreateWithMaxCount(nodeAgentSkus, mappingFunction,
                maxCount, () => WriteVerbose(string.Format(Resources.MaxCount, maxCount)));
        }

        /// <summary>
        /// Appends all accounts into a list.
        /// </summary>
        /// <param name="response">The list of accounts.</param>
        /// <returns>All accounts for the response</returns>
        internal IEnumerable<AccountResource> ListAllAccounts(IPage<AccountResource> response)
        {
            var accountResources = new List<AccountResource>();
            accountResources.AddRange(response);

            var nextLink = response.NextPageLink;
            while (nextLink != null)
            {
                response = ListNextAccounts(nextLink);
                accountResources.AddRange(response);
                nextLink = response.NextPageLink;
            }

            return accountResources;
        }

        /// <summary>
        /// Lists all accounts in a subscription or in a resource group if its name is specified
        /// </summary>
        /// <param name="NextLink">Next link to use when querying for accounts</param>
        /// <returns>The status of list operation</returns>
        internal IPage<AccountResource> ListNextAccounts(string NextLink)
        {
            return BatchManagementClient.Account.ListNext(NextLink);
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
