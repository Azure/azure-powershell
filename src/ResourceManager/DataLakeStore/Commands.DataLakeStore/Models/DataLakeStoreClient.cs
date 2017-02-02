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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class DataLakeStoreClient
    {
        private readonly DataLakeStoreAccountManagementClient _client;
        private readonly Guid _subscriptionId;

        public DataLakeStoreClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.Id;
            _client = DataLakeStoreCmdletBase.CreateAdlsClient<DataLakeStoreAccountManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        public DataLakeStoreClient()
        {
        }

        #region Account Related Operations

        public DataLakeStoreAccount CreateAccount(
            string resourceGroupName,
            string accountName,
            string defaultGroup, 
            string location, 
            Hashtable customTags = null, 
            EncryptionIdentity identity = null, 
            EncryptionConfig config = null, 
            IList<TrustedIdProvider> trustedProviders = null,
            IList<FirewallRule> firewallRules = null,
            EncryptionConfigType? encryptionType = null,
            TierType? tier = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            var tags = TagsConversionHelper.CreateTagDictionary(customTags, true);

            var parameters = new DataLakeStoreAccount
            {
                Location = location,
                DefaultGroup = defaultGroup,
                Tags = tags ?? new Dictionary<string, string>()
            };

            if (identity != null)
            {
                parameters.EncryptionState = EncryptionState.Enabled;
                parameters.Identity = identity;
                parameters.EncryptionConfig = config ?? new EncryptionConfig
                {
                    Type = EncryptionConfigType.ServiceManaged
                };
            }

            if (trustedProviders != null && trustedProviders.Count > 0)
            {
                parameters.TrustedIdProviders = trustedProviders;
                parameters.TrustedIdProviderState = TrustedIdProviderState.Enabled;
            }

            if (firewallRules != null && firewallRules.Count > 0)
            {
                parameters.FirewallRules = firewallRules;
                parameters.FirewallState = FirewallState.Enabled;
            }

            // if there is no encryption value, then it was not set by the cmdlet which means encryption was explicitly disabled.
            if(!encryptionType.HasValue)
            {
                parameters.EncryptionState = EncryptionState.Disabled;
                parameters.Identity = null;
                parameters.EncryptionConfig = null;
            }

            if (tier.HasValue)
            {
                parameters.NewTier = tier;
            }

            return  _client.Account.Create(resourceGroupName, accountName, parameters);
        }

        public DataLakeStoreAccount UpdateAccount(
            string resourceGroupName,
            string accountName,
            string defaultGroup,
            TrustedIdProviderState providerState,
            FirewallState firewallState,
            Hashtable customTags = null,
            TierType? tier = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            var tags = TagsConversionHelper.CreateTagDictionary(customTags, true);

            var parameters = new DataLakeStoreAccountUpdateParameters
            {
                DefaultGroup = defaultGroup,
                Tags = tags ?? new Dictionary<string, string>(),
                TrustedIdProviderState = providerState,
                FirewallState = firewallState
            };

            if (tier.HasValue)
            {
                parameters.NewTier = tier;
            }

            return _client.Account.Update(resourceGroupName, accountName, parameters);
        }

        public void DeleteAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            if (!TestAccount(resourceGroupName, accountName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.AccountDoesNotExist, accountName));
            }

            _client.Account.Delete(resourceGroupName, accountName);
        }

        public bool TestAccount(string resourceGroupName, string accountName)
        {
            try
            {
                GetAccount(resourceGroupName, accountName);
                return true;
            }
            catch (CloudException ex)
            {
                if ((ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound) || ex.Message.Contains(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, accountName,
                    _subscriptionId)))
                {
                    return false;
                }

                throw;
            }
        }

        public DataLakeStoreAccount GetAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            return _client.Account.Get(resourceGroupName, accountName);
        }
        public FirewallRule AddOrUpdateFirewallRule(string resourceGroupName, string accountName, string ruleName, string startIp, string endIp)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            return _client.FirewallRules.CreateOrUpdate(
                resourceGroupName,
                accountName,
                ruleName,
                new FirewallRule
                {
                    StartIpAddress = startIp,
                    EndIpAddress = endIp
                    
                });
        }

        public void DeleteFirewallRule(string resourceGroupName, string accountName, string ruleName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            _client.FirewallRules.Delete(resourceGroupName, accountName, ruleName);
        }

        public FirewallRule GetFirewallRule(string resourceGroupName, string accountName, string ruleName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            return _client.FirewallRules.Get(resourceGroupName, accountName, ruleName);
        }

        public TrustedIdProvider AddOrUpdateTrustedProvider(string resourceGroupName, string accountName, string providerName, string providerEndpoint)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            return _client.TrustedIdProviders.CreateOrUpdate(
                resourceGroupName,
                accountName,
                providerName,
                new TrustedIdProvider
                {
                    IdProvider = providerEndpoint 
                });
        }

        public void DeleteTrustedProvider(string resourceGroupName, string accountName, string providerName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            _client.TrustedIdProviders.Delete(resourceGroupName, accountName, providerName);
        }

        public TrustedIdProvider GetTrustedProvider(string resourceGroupName, string accountName, string providerName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            return _client.TrustedIdProviders.Get(resourceGroupName, accountName, providerName);
        }

        public List<FirewallRule> ListFirewallRules(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            var toReturn = new List<FirewallRule>();
            var response = _client.FirewallRules.ListByAccount(resourceGroupName, accountName);

            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = ListFirewallRulesWithNextLink(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public List<TrustedIdProvider> ListTrustedProviders(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccount(accountName);
            }

            var toReturn = new List<TrustedIdProvider>();
            var response = _client.TrustedIdProviders.ListByAccount(resourceGroupName, accountName);

            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = ListTrustedIdProvidersWithNextLink(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public List<DataLakeStoreAccount> ListAccounts(string resourceGroupName, string filter, int? top, int? skip)
        {
            var parameters = new ODataQuery<DataLakeStoreAccount>
            {
                Filter = filter,
                Top = top,
                Skip = skip
            };

            var accountList = new List<DataLakeStoreAccount>();
            var response = string.IsNullOrEmpty(resourceGroupName) ?
                _client.Account.List(parameters) :
                _client.Account.ListByResourceGroup(resourceGroupName, parameters);

            accountList.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = ListAccountsWithNextLink(response.NextPageLink);
                accountList.AddRange(response);
            }

            return accountList;
        }

        private IPage<DataLakeStoreAccount> ListAccountsWithNextLink(string nextLink)
        {
            return _client.Account.ListNext(nextLink);
        }

        private IPage<TrustedIdProvider> ListTrustedIdProvidersWithNextLink(string nextLink)
        {
            return _client.TrustedIdProviders.ListByAccountNext(nextLink);
        }

        private IPage<FirewallRule> ListFirewallRulesWithNextLink(string nextLink)
        {
            return _client.FirewallRules.ListByAccountNext(nextLink);
        }

        private string GetResourceGroupByAccount(string accountName)
        {
            try
            {
                var acctId =
                    ListAccounts(null, null, null, null)
                        .Find(x => x.Name.Equals(accountName, StringComparison.InvariantCultureIgnoreCase))
                        .Id;
                var rgStart = acctId.IndexOf("resourceGroups/", StringComparison.InvariantCultureIgnoreCase) +
                              ("resourceGroups/".Length);
                var rgLength = (acctId.IndexOf("/providers/", StringComparison.InvariantCultureIgnoreCase)) - rgStart;
                return acctId.Substring(rgStart, rgLength);
            }
            catch
            {
                throw new CloudException(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, accountName,
                    _subscriptionId));
            }
        }

        #endregion
    }
}