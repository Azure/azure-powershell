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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Management.DataLake.Analytics;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    public class DataLakeAnalyticsClient
    {
        private readonly DataLakeAnalyticsAccountManagementClient _accountClient;
        private readonly DataLakeAnalyticsCatalogManagementClient _catalogClient;
        private readonly DataLakeAnalyticsJobManagementClient _jobClient;
        private readonly Guid _subscriptionId;
        private static Queue<Guid> _jobIdQueue;

        /// <summary>
        /// Gets or sets the job identifier queue, which is used exclusively as a test hook.
        /// </summary>
        /// <value>
        /// The job identifier queue.
        /// </value>
        public static Queue<Guid> JobIdQueue
        {
            get { return _jobIdQueue ?? (_jobIdQueue = new Queue<Guid>()); }
            set { _jobIdQueue = value; }
        }

        public DataLakeAnalyticsClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }
            
            _accountClient = DataLakeAnalyticsCmdletBase.CreateAdlaClient<DataLakeAnalyticsAccountManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
            _subscriptionId = context.Subscription.GetId();

            _jobClient = DataLakeAnalyticsCmdletBase.CreateAdlaClient<DataLakeAnalyticsJobManagementClient>(context,
                AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, true);

            _catalogClient = DataLakeAnalyticsCmdletBase.CreateAdlaClient<DataLakeAnalyticsCatalogManagementClient>(context,
                AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, true);
        }

        #region Account Related Operations

        public DataLakeAnalyticsAccount CreateOrUpdateAccount(string resourceGroupName, string accountName,
            string location,
            AddDataLakeStoreWithAccountParameters defaultDataLakeStoreAccount = null,
            IList<AddDataLakeStoreWithAccountParameters> additionalDataLakeStoreAccounts = null,
            IList<AddStorageAccountWithAccountParameters> additionalStorageAccounts = null,
            Hashtable customTags = null,
            int? maxAnalyticsUnits = 0,
            int? maxJobCount = 0,
            int? queryStoreRetention = 0,
            TierType? tier = null,
            FirewallState? firewallState = null,
            FirewallAllowAzureIpsState? allowAzureIps = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var tags = TagsConversionHelper.CreateTagDictionary(customTags, true);

            var parameters = new CreateDataLakeAnalyticsAccountParameters
            {
                Location = location,
                Tags = tags ?? new Dictionary<string, string>()
            };

            if (defaultDataLakeStoreAccount != null)
            {
                parameters.DefaultDataLakeStoreAccount =
                    defaultDataLakeStoreAccount.Name;
            }

            if (additionalStorageAccounts != null && additionalStorageAccounts.Count > 0)
            {
                parameters.StorageAccounts = additionalStorageAccounts;
            }

            if (additionalDataLakeStoreAccounts != null && additionalDataLakeStoreAccounts.Count > 0)
            {
                if (defaultDataLakeStoreAccount != null)
                {
                    additionalDataLakeStoreAccounts.Add(defaultDataLakeStoreAccount);
                }

                parameters.DataLakeStoreAccounts = additionalDataLakeStoreAccounts;
            }
            else if (defaultDataLakeStoreAccount != null)
            {
                parameters.DataLakeStoreAccounts = new List<AddDataLakeStoreWithAccountParameters>
                {
                    defaultDataLakeStoreAccount
                };
            }

            if (maxAnalyticsUnits.HasValue && maxAnalyticsUnits > 0)
            {
                parameters.MaxDegreeOfParallelism = maxAnalyticsUnits;
            }

            if (maxJobCount.HasValue && maxJobCount > 0)
            {
                parameters.MaxJobCount = maxJobCount;
            }

            if (queryStoreRetention.HasValue && queryStoreRetention > 0)
            {
                parameters.QueryStoreRetention = queryStoreRetention;
            }

            if (tier.HasValue)
            {
                parameters.NewTier = tier;
            }

            if (firewallState.HasValue)
            {
                parameters.FirewallState = firewallState;
            }

            if (allowAzureIps.HasValue)
            {
                parameters.FirewallAllowAzureIps = allowAzureIps;
            }

            var accountExists = false;
            try
            {
                if (GetAccount(resourceGroupName, accountName) != null)
                {
                    accountExists = true;
                }
            }
            catch
            {
                // intentionally empty since if there is any exception attempting to 
                // get the account we know it doesn't exist and we will attempt to create it fresh.
            }

            return accountExists
                ? _accountClient.Accounts.Update(resourceGroupName, accountName, new UpdateDataLakeAnalyticsAccountParameters
                {
                    MaxDegreeOfParallelism = parameters.MaxDegreeOfParallelism,
                    MaxJobCount = parameters.MaxJobCount,
                    QueryStoreRetention = parameters.QueryStoreRetention,
                    Tags = parameters.Tags,
                    NewTier = parameters.NewTier,
                    FirewallState = parameters.FirewallState,
                    FirewallAllowAzureIps = parameters.FirewallAllowAzureIps
                })
                : _accountClient.Accounts.Create(resourceGroupName, accountName, parameters);
        }

        public void DeleteAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            if (!TestAccount(resourceGroupName, accountName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.AccountDoesNotExist, accountName));
            }

            _accountClient.Accounts.Delete(resourceGroupName, accountName);
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

        public DataLakeAnalyticsAccount GetAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.Accounts.Get(resourceGroupName, accountName);
        }

        public List<DataLakeAnalyticsAccountBasic> ListAccounts(string resourceGroupName, string filter, int? top, int? skip)
        {
            var parameters = new ODataQuery<DataLakeAnalyticsAccountBasic>
            {
                Filter = filter,
                Top = top,
                Skip = skip
            };

            var accountList = new List<DataLakeAnalyticsAccountBasic>();
            var response = string.IsNullOrEmpty(resourceGroupName)
                ? _accountClient.Accounts.List(parameters)
                : _accountClient.Accounts.ListByResourceGroup(resourceGroupName, parameters);
            accountList.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = ListAccountsWithNextLink(response.NextPageLink);
                accountList.AddRange(response);
            }

            return accountList;
        }

        public void AddDataLakeStoreAccount(string resourceGroupName, string accountName,
            DataLakeStoreAccountInformation storageToAdd)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.DataLakeStoreAccounts.Add(resourceGroupName, accountName,
                storageToAdd.Name);
        }

        public IEnumerable<DataLakeStoreAccountInformation> ListDataLakeStoreAccounts(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var response = _accountClient.DataLakeStoreAccounts.ListByAccount(resourceGroupName, accountName);
            var toReturn = new List<DataLakeStoreAccountInformation>();
            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _accountClient.DataLakeStoreAccounts.ListByAccountNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public DataLakeStoreAccountInformation GetDataLakeStoreAccount(string resourceGroupName, string accountName, string dataLakeStoreAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.DataLakeStoreAccounts.Get(resourceGroupName, accountName, dataLakeStoreAccountName);
        }

        public void RemoveDataLakeStoreAccount(string resourceGroupName, string accountName,
            string dataLakeStoreAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.DataLakeStoreAccounts.Delete(resourceGroupName, accountName,
                dataLakeStoreAccountName);
        }

        public void AddStorageAccount(string resourceGroupName, string accountName, string storageAccountName, AddStorageAccountParameters storageParams)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.StorageAccounts.Add(resourceGroupName, accountName, storageAccountName, storageParams);
        }

        public void SetStorageAccount(string resourceGroupName, string accountName, string storageAccountName, UpdateStorageAccountParameters storageParams)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.StorageAccounts.Update(resourceGroupName, accountName, storageAccountName, storageParams);
        }

        public IEnumerable<StorageAccountInformation> ListStorageAccounts(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var response = _accountClient.StorageAccounts.ListByAccount(resourceGroupName, accountName);
            var toReturn = new List<StorageAccountInformation>();
            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _accountClient.StorageAccounts.ListByAccountNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public StorageAccountInformation GetStorageAccount(string resourceGroupName, string accountName, string storageAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.StorageAccounts.Get(resourceGroupName, accountName, storageAccountName);
        }

        public void RemoveStorageAccount(string resourceGroupName, string accountName, string storageAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.StorageAccounts.Delete(resourceGroupName, accountName,
                storageAccountName);
        }

        public IEnumerable<AdlDataSource> GetAllDataSources(string resourceGroupName, string accountName)
        {
            var toReturn = new List<AdlDataSource>();
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var defaultAdls = GetAccount(resourceGroupName, accountName).DefaultDataLakeStoreAccount;
            foreach(var adlsAcct in ListDataLakeStoreAccounts(resourceGroupName, accountName))
            {
                toReturn.Add(new AdlDataSource(adlsAcct, adlsAcct.Name.Equals(defaultAdls, StringComparison.OrdinalIgnoreCase)));
            }

            foreach (var storageAcct in ListStorageAccounts(resourceGroupName, accountName))
            {
                toReturn.Add(new AdlDataSource(storageAcct));
            }

            return toReturn;
        }

        private IPage<DataLakeAnalyticsAccountBasic> ListAccountsWithNextLink(string nextLink)
        {
            return _accountClient.Accounts.ListNext(nextLink);
        }
        #endregion
        #region Firewall Management

        public FirewallRule AddOrUpdateFirewallRule(string resourceGroupName, string accountName, string ruleName, string startIp, string endIp, Cmdlet runningCommand)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            if (_accountClient.Accounts.Get(resourceGroupName, accountName).FirewallState == FirewallState.Disabled)
            {
                runningCommand.WriteWarning(string.Format(Properties.Resources.FirewallDisabledWarning, accountName));
            }

            return _accountClient.FirewallRules.CreateOrUpdate(
                resourceGroupName,
                accountName,
                ruleName,
                new CreateOrUpdateFirewallRuleParameters
                {
                    StartIpAddress = startIp,
                    EndIpAddress = endIp

                });
        }

        public void DeleteFirewallRule(string resourceGroupName, string accountName, string ruleName, Cmdlet runningCommand)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            if (_accountClient.Accounts.Get(resourceGroupName, accountName).FirewallState == FirewallState.Disabled)
            {
                runningCommand.WriteWarning(string.Format(Properties.Resources.FirewallDisabledWarning, accountName));
            }

            _accountClient.FirewallRules.Delete(resourceGroupName, accountName, ruleName);
        }

        public FirewallRule GetFirewallRule(string resourceGroupName, string accountName, string ruleName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.FirewallRules.Get(resourceGroupName, accountName, ruleName);
        }

        public List<FirewallRule> ListFirewallRules(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var toReturn = new List<FirewallRule>();
            var response = _accountClient.FirewallRules.ListByAccount(resourceGroupName, accountName);

            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = ListFirewallRulesWithNextLink(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        #endregion

        #region Catalog Operations

        public void CreateSecret(string accountName, string databaseName,
            string secretName, string password, string hostUri)
        {
// TODO: Remove IfDef
#if NETSTANDARD
            _catalogClient.Catalog.CreateCredential(accountName, databaseName, secretName,
                new DataLakeAnalyticsCatalogCredentialCreateParameters
                {
                    Password = password,
                    Uri = hostUri
                });
#else
            _catalogClient.Catalog.CreateSecret(accountName, databaseName, secretName,
                new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                {
                    Password = password,
                    Uri = hostUri
                });
#endif
        }

        public USqlSecret UpdateSecret(string accountName, string databaseName,
            string secretName, string password, string hostUri)
        {
// TODO: Remove IfDef
#if NETSTANDARD
            _catalogClient.Catalog.UpdateCredential(accountName, databaseName, secretName,
                new DataLakeAnalyticsCatalogCredentialUpdateParameters
                {
                    Password = password,
                    Uri = hostUri
                });
#else
            _catalogClient.Catalog.UpdateSecret(accountName, databaseName, secretName,
                new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                {
                    Password = password,
                    Uri = hostUri
                });
#endif

            // TODO: Remove this during the next breaking change release.
            return null;
        }

        public void DeleteSecret(string accountName, string databaseName, string secretName)
        {
// TODO: Remove IfDef
#if NETSTANDARD
            if (string.IsNullOrEmpty(secretName))
            {
                var credentials = _catalogClient.Catalog.ListCredentials(accountName, databaseName);
                foreach (var credential in credentials)
                {
                    _catalogClient.Catalog.DeleteCredential(accountName, databaseName, credential.Name);
                }
            }
            else
            {
                _catalogClient.Catalog.DeleteCredential(accountName, databaseName, secretName);
            }
#else
            if (string.IsNullOrEmpty(secretName))
            {
                _catalogClient.Catalog.DeleteAllSecrets(accountName, databaseName);
            }
            else
            {
                _catalogClient.Catalog.DeleteSecret(accountName, databaseName, secretName);
            }
#endif
        }

// TODO: Remove IfDef
#if NETSTANDARD
        public USqlCredential GetSecret(string accountName, string databaseName, string secretName)
        {
            return _catalogClient.Catalog.GetCredential(accountName, databaseName, secretName);
        }
#else
        public USqlSecret GetSecret(string accountName, string databaseName, string secretName)
        {
            return _catalogClient.Catalog.GetSecret(accountName, databaseName, secretName);
        }
#endif

        public bool TestCatalogItem(string accountName, CatalogPathInstance path,
            DataLakeAnalyticsEnums.CatalogItemType itemType)
        {
            try
            {
                var result = GetCatalogItem(accountName, path, itemType);
                return result != null && result.Count > 0;
            }
            catch (CloudException ex)
            {
                if (ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        public void CreateCredential(string accountName, string databaseName,
            string credentialName, string userId, string password, string hostUri)
        {
            _catalogClient.Catalog.CreateCredential(accountName, databaseName, credentialName,
                new DataLakeAnalyticsCatalogCredentialCreateParameters
                {
                    Password = password,
                    Uri = hostUri,
                    UserId = userId
                });
        }

        public void UpdateCredentialPassword(string accountName, string databaseName,
            string credentialName, string userId, string password, string newPassword, string hostUri)
        {
            _catalogClient.Catalog.UpdateCredential(accountName, databaseName, credentialName,
                new DataLakeAnalyticsCatalogCredentialUpdateParameters
                {
                    Password = password,
                    NewPassword = newPassword,
                    Uri = hostUri,
                    UserId = userId
                });
        }

        public void DeleteCredential(string accountName, string databaseName, string credentialName, string password = null, bool cascade = false)
        {
            _catalogClient.Catalog.DeleteCredential(accountName,
                databaseName,
                credentialName,
                string.IsNullOrEmpty(password) ? null : new DataLakeAnalyticsCatalogCredentialDeleteParameters(password),
                cascade);
        }
        

        public IList<CatalogItem> GetCatalogItem(string accountName, CatalogPathInstance path,
            DataLakeAnalyticsEnums.CatalogItemType itemType)
        {
            if (path == null && itemType != DataLakeAnalyticsEnums.CatalogItemType.Database)
            {
                throw new InvalidOperationException(Properties.Resources.EmptyCatalogPath);
            }

            var isList = IsCatalogItemOrList(path, itemType);
            var toReturn = new List<CatalogItem>();

            switch (itemType)
            {
                case DataLakeAnalyticsEnums.CatalogItemType.Database:
                    if (isList)
                    {
                        toReturn.AddRange(GetDatabases(accountName));
                    }
                    else
                    {
                        toReturn.Add(GetDatabase(accountName, path.DatabaseName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Schema:
                    if (isList)
                    {
                        toReturn.AddRange(GetSchemas(accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetSchema(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Assembly:
                    if (isList)
                    {
                        toReturn.AddRange(GetAssemblies(accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetAssembly(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.ExternalDataSource:
                    if (isList)
                    {
                        toReturn.AddRange(GetExternalDataSources(accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetExternalDataSource(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Credential:
                    if (isList)
                    {
                        toReturn.AddRange(GetCredentials(accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetCredential(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Table:
                    if (isList)
                    {
                        toReturn.AddRange(GetTables(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetTable(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.TablePartition:
                    if (isList)
                    {
                        toReturn.AddRange(GetTablePartitions(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }
                    else
                    {
                        toReturn.Add(GetTablePartition(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName, path.TableStatisticsOrPartitionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.TableValuedFunction:
                    if (isList)
                    {
                        toReturn.AddRange(GetTableValuedFunctions(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetTableValuedFunction(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.TableStatistics:
                    if (isList)
                    {
                        toReturn.AddRange(GetTableStatistics(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }
                    else
                    {
                        toReturn.Add(GetTableStatistic(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName,
                            path.TableStatisticsOrPartitionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.View:
                    if (isList)
                    {
                        toReturn.AddRange(GetViews(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetView(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Package:
                    if (isList)
                    {
                        toReturn.AddRange(GetPackages(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetPackage(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Procedure:
                    if (isList)
                    {
                        toReturn.AddRange(GetProcedures(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetProcedure(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Types:
                    if (isList)
                    {
                        toReturn.AddRange(GetTypes(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        throw new InvalidOperationException(Properties.Resources.InvalidUSqlTypeRequest);
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Secret:
                    if (isList)
                    {
                        throw new InvalidOperationException(Properties.Resources.InvalidUSqlSecretRequest);
                    }
                    else
                    {
                        toReturn.Add(GetSecret(accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
            }

            return toReturn;
        }

        public List<Acl> GetCatalogItemAclEntry(string accountName, CatalogPathInstance path, string catalogItemType, IEnumerable<string> requiredAceTypes)
        {
            IPage<Acl> firstPage;
            Func<string, IPage<Acl>> getNextPage;

            // If catalog item type is not specified, the entire ACL of catalog will be retrieved
            if (string.IsNullOrEmpty(catalogItemType))
            {
                firstPage = _catalogClient.Catalog.ListAcls(accountName);
                getNextPage = nextPageLink => _catalogClient.Catalog.ListAclsNext(nextPageLink);
            }
            else
            {
                // If catalog item type is specified, ACL of the specified catalog item will be retrieved.
                if (string.IsNullOrEmpty(path?.FullCatalogItemPath))
                {
                    throw new InvalidOperationException(Properties.Resources.MissingCatalogPathForAclOperation);
                }

                var itemType = (DataLakeAnalyticsEnums.CatalogItemType)Enum.Parse(typeof(DataLakeAnalyticsEnums.CatalogItemType), catalogItemType, true);
                switch (itemType)
                {
                    case DataLakeAnalyticsEnums.CatalogItemType.Database:
                        firstPage = _catalogClient.Catalog.ListAclsByDatabase(accountName, path.DatabaseName);
                        getNextPage = nextPageLink => _catalogClient.Catalog.ListAclsByDatabase(nextPageLink, path.DatabaseName);
                        break;

                    default: throw new ArgumentException($"ACL operations are unsupported for catatlog item type: {itemType}");
                }
            }

            var toReturn = GetCatalogItemAclEntry(firstPage, getNextPage);
            return toReturn.Where(acl => acl?.AceType != null && requiredAceTypes.Contains(acl.AceType)).ToList();
        }

        public void AddOrUpdateCatalogItemAclEntry(
            string accountName,
            CatalogPathInstance path,
            string catalogItemType,
            string aceType,
            Guid principalId,
            DataLakeAnalyticsEnums.PermissionType permissions)
        {
            // Make sure principal ID is not empty GUID. 
            // When principal ID is empty GUID:
            // If ACE type is User or Group: principal ID should be provided by end user so an exception will be thrown;
            // In other cases (Other/UserOwner/GroupOwner), a new GUID will be created and served as principal id.
            if (principalId == Guid.Empty)
            {
                if (aceType != AclType.Other && aceType != AclType.UserObj && aceType != AclType.GroupObj)
                {
                    throw new InvalidOperationException(Properties.Resources.MissingPrincipalId);
                }

                principalId = Guid.NewGuid();
            }

            var parameters = new AclCreateOrUpdateParameters(aceType, principalId, GetPermissionType(permissions));

            // If catalog item type is not specified, grant an ACL entry to catalog
            if (string.IsNullOrEmpty(catalogItemType))
            {
                _catalogClient.Catalog.GrantAcl(accountName, parameters);
            }
            else
            {
                // If catalog item type is specified, grant an ACL entry to catalog item
                if (string.IsNullOrEmpty(path?.FullCatalogItemPath))
                {
                    throw new InvalidOperationException(Properties.Resources.MissingCatalogPathForAclOperation);
                }

                var itemType = (DataLakeAnalyticsEnums.CatalogItemType)Enum.Parse(typeof(DataLakeAnalyticsEnums.CatalogItemType), catalogItemType, true);
                switch (itemType)
                {
                    case DataLakeAnalyticsEnums.CatalogItemType.Database:
                        _catalogClient.Catalog.GrantAclToDatabase(accountName, path.DatabaseName, parameters);
                        break;

                    default: throw new ArgumentException($"ACL operations are unsupported for catatlog item type: {itemType}");
                }
            }
        }

        public void RemoveCatalogItemAclEntry(
            string accountName,
            CatalogPathInstance path,
            string catalogItemType,
            string aceType,
            Guid principalId)
        {
            // Make sure principal ID is not empty GUID. 
            // When principal ID is empty GUID:
            // If ACE type is User or Group: principal ID should be provided by end user so an exception will be thrown;
            // If ACE type is Other, a new GUID will be created and served as principal id.
            if (principalId == Guid.Empty)
            {
                if (aceType != AclType.Other && aceType != AclType.UserObj && aceType != AclType.GroupObj)
                {
                    throw new InvalidOperationException(Properties.Resources.MissingPrincipalId);
                }

                principalId = Guid.NewGuid();
            }

            var parameters = new AclDeleteParameters(aceType, principalId);

            // If catalog item type is not specified, revoke an ACL entry to catalog
            if (string.IsNullOrEmpty(catalogItemType))
            {
                _catalogClient.Catalog.RevokeAcl(accountName, parameters);
            }
            else
            {
                // If catalog item type is specified, revoke an ACL entry to catalog item
                if (string.IsNullOrEmpty(path?.FullCatalogItemPath))
                {
                    throw new InvalidOperationException(Properties.Resources.MissingCatalogPathForAclOperation);
                }

                var itemType = (DataLakeAnalyticsEnums.CatalogItemType)Enum.Parse(typeof(DataLakeAnalyticsEnums.CatalogItemType), catalogItemType, true);
                switch (itemType)
                {
                    case DataLakeAnalyticsEnums.CatalogItemType.Database:
                        _catalogClient.Catalog.RevokeAclFromDatabase(accountName, path.DatabaseName, parameters);
                        break;

                    default: throw new ArgumentException($"ACL operations are unsupported for catatlog item type: {itemType}");
                }
            }
        }

        private USqlDatabase GetDatabase(string accountName, string databaseName)
        {
            return _catalogClient.Catalog.GetDatabase(accountName, databaseName);
        }

        private IList<USqlDatabase> GetDatabases(string accountName)
        {
            var toReturn = new List<USqlDatabase>();
            var response = _catalogClient.Catalog.ListDatabases(accountName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListDatabasesNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlAssembly GetAssembly(string accountName, string databaseName,
            string assemblyName)
        {
            return
                _catalogClient.Catalog.GetAssembly(accountName, databaseName, assemblyName);
        }

        private IList<USqlAssemblyClr> GetAssemblies(string accountName, string databaseName)
        {
            var toReturn = new List<USqlAssemblyClr>();
            var response = _catalogClient.Catalog.ListAssemblies(accountName, databaseName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListAssembliesNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlExternalDataSource GetExternalDataSource(string accountName,
            string databaseName, string dataSourceName)
        {
            return
                _catalogClient.Catalog.GetExternalDataSource(accountName, databaseName,
                    dataSourceName);
        }

        private IList<USqlExternalDataSource> GetExternalDataSources(string accountName,
            string databaseName)
        {
            var toReturn = new List<USqlExternalDataSource>();
            var response = _catalogClient.Catalog.ListExternalDataSources(accountName, databaseName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListExternalDataSourcesNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlCredential GetCredential(string accountName, string databaseName, string credName)
        {
            return _catalogClient.Catalog.GetCredential(accountName, databaseName, credName);
        }

        private IList<USqlCredential> GetCredentials(string accountName, string databaseName)
        {
            var toReturn = new List<USqlCredential>();
            var response = _catalogClient.Catalog.ListCredentials(accountName, databaseName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListCredentialsNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlSchema GetSchema(string accountName, string databaseName,
            string schemaName)
        {
            return _catalogClient.Catalog.GetSchema(accountName, databaseName, schemaName);
        }

        private IList<USqlSchema> GetSchemas(string accountName, string databaseName)
        {
            var toReturn = new List<USqlSchema>();
            var response = _catalogClient.Catalog.ListSchemas(accountName, databaseName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListSchemasNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlTable GetTable(string accountName, string databaseName, string schemaName,
            string tableName)
        {
            return
                _catalogClient.Catalog.GetTable(accountName, databaseName, schemaName, tableName);
        }

        private IList<USqlTable> GetTables(string accountName, string databaseName,
            string schemaName)
        {
            var toReturn = new List<USqlTable>();
            if (string.IsNullOrEmpty(schemaName))
            {
                var response = _catalogClient.Catalog.ListTablesByDatabase(accountName, databaseName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTablesByDatabaseNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            else
            {
                var response = _catalogClient.Catalog.ListTables(accountName, databaseName, schemaName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTablesNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            return toReturn;
        }

        private USqlTablePartition GetTablePartition(string accountName, string databaseName, string schemaName,
            string tableName, string partitionName)
        {
            return
                _catalogClient.Catalog.GetTablePartition(accountName, databaseName, schemaName, tableName, partitionName);
        }

        private IList<USqlTablePartition> GetTablePartitions(string accountName, string databaseName,
            string schemaName, string tableName)
        {
            var toReturn = new List<USqlTablePartition>();
            var response = _catalogClient.Catalog.ListTablePartitions(accountName, databaseName, schemaName, tableName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListTablePartitionsNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlTableValuedFunction GetTableValuedFunction(string accountName,
            string databaseName, string schemaName, string tableValuedFunctionName)
        {
            return
                _catalogClient.Catalog.GetTableValuedFunction(accountName, databaseName, schemaName,
                    tableValuedFunctionName);
        }

        private IList<USqlTableValuedFunction> GetTableValuedFunctions(string accountName,
            string databaseName, string schemaName)
        {
            var toReturn = new List<USqlTableValuedFunction>();
            if (string.IsNullOrEmpty(schemaName))
            {
                var response = _catalogClient.Catalog.ListTableValuedFunctionsByDatabase(accountName, databaseName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTableValuedFunctionsByDatabaseNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            else
            {
                var response = _catalogClient.Catalog.ListTableValuedFunctions(accountName, databaseName, schemaName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTableValuedFunctionsNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            return toReturn;
        }

        private USqlTableStatistics GetTableStatistic(string accountName, string databaseName,
            string schemaName, string tableName, string statisticsName)
        {
            return
                _catalogClient.Catalog.GetTableStatistic(accountName, databaseName, schemaName,
                    tableName, statisticsName);
        }

        private IList<USqlTableStatistics> GetTableStatistics(string accountName,
            string databaseName, string schemaName, string tableName)
        {
            var toReturn = new List<USqlTableStatistics>();
            if (string.IsNullOrEmpty(schemaName) && string.IsNullOrEmpty(tableName))
            {
                var response = _catalogClient.Catalog.ListTableStatisticsByDatabase(accountName, databaseName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTableStatisticsByDatabaseNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            else if (!string.IsNullOrEmpty(schemaName) && string.IsNullOrEmpty(tableName))
            {
                var response = _catalogClient.Catalog.ListTableStatisticsByDatabaseAndSchema(accountName, databaseName, schemaName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTableStatisticsByDatabaseAndSchemaNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            else
            {
                var response = _catalogClient.Catalog.ListTableStatistics(accountName, databaseName, schemaName, tableName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListTableStatisticsNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            return toReturn;
        }

        private USqlView GetView(string accountName, string databaseName, string schemaName,
            string viewName)
        {
            return
                _catalogClient.Catalog.GetView(accountName, databaseName, schemaName, viewName);
        }

        private IList<USqlView> GetViews(string accountName, string databaseName,
            string schemaName)
        {
            var toReturn = new List<USqlView>();
            if (string.IsNullOrEmpty(schemaName))
            {
                var response = _catalogClient.Catalog.ListViewsByDatabase(accountName, databaseName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListViewsByDatabaseNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }
            else
            {
                var response = _catalogClient.Catalog.ListViews(accountName, databaseName, schemaName);
                toReturn.AddRange(response);
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = _catalogClient.Catalog.ListViewsNext(response.NextPageLink);
                    toReturn.AddRange(response);
                }
            }

            return toReturn;
        }

        private USqlProcedure GetProcedure(string accountName, string databaseName, string schemaName,
            string procName)
        {
            return
                _catalogClient.Catalog.GetProcedure(accountName, databaseName, schemaName, procName);
        }

        private IList<USqlProcedure> GetProcedures(string accountName, string databaseName,
            string schemaName)
        {
            var toReturn = new List<USqlProcedure>();
            var response = _catalogClient.Catalog.ListProcedures(accountName, databaseName, schemaName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListProceduresNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private USqlPackage GetPackage(string accountName, string databaseName, string schemaName,
            string packageName)
        {
            return
                _catalogClient.Catalog.GetPackage(accountName, databaseName, schemaName, packageName);
        }

        private IList<USqlPackage> GetPackages(string accountName, string databaseName,
            string schemaName)
        {
            var toReturn = new List<USqlPackage>();
            var response = _catalogClient.Catalog.ListPackages(accountName, databaseName, schemaName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListPackagesNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        private IList<USqlType> GetTypes(string accountName, string databaseName,
            string schemaName)
        {
            var toReturn = new List<USqlType>();
            var response = _catalogClient.Catalog.ListTypes(accountName, databaseName, schemaName);
            toReturn.AddRange(response);
            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _catalogClient.Catalog.ListTypesNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

#endregion
#region Compute Policy Operations
        public ComputePolicy CreateComputePolicy(string resourceGroupName, string accountName, string policyName, Guid objectId, string objectType, int? maxAnalyticsUnitsPerJob = null, int? minPriorityPerJob = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.ComputePolicies.CreateOrUpdate(resourceGroupName, accountName, policyName, new CreateOrUpdateComputePolicyParameters
            {
                ObjectId = objectId,
                ObjectType = objectType,
                MaxDegreeOfParallelismPerJob = maxAnalyticsUnitsPerJob,
                MinPriorityPerJob = minPriorityPerJob
            });
        }

        public ComputePolicy UpdateComputePolicy(string resourceGroupName, string accountName, string policyName, int? maxAnalyticsUnitsPerJob = null, int? minPriorityPerJob = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.ComputePolicies.Update(resourceGroupName, accountName, policyName, new UpdateComputePolicyParameters
            {
                MaxDegreeOfParallelismPerJob = maxAnalyticsUnitsPerJob,
                MinPriorityPerJob = minPriorityPerJob
            });
        }

        public ComputePolicy GetComputePolicy(string resourceGroupName, string accountName, string policyName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _accountClient.ComputePolicies.Get(resourceGroupName, accountName, policyName);
        }

        public List<ComputePolicy> ListComputePolicy(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var toReturn = new List<ComputePolicy>();
            var response = _accountClient.ComputePolicies.ListByAccount(resourceGroupName, accountName);

            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _accountClient.ComputePolicies.ListByAccountNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public void DeleteComputePolicy(string resourceGroupName, string accountName, string policyName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.ComputePolicies.Delete(resourceGroupName, accountName, policyName);
        }

#endregion
#region Job Related Operations

        public JobRecurrenceInformation GetJobReccurence(string accountName, Guid recurrenceId, DateTimeOffset? start = null, DateTimeOffset? end = null)
        {
            return _jobClient.Recurrence.Get(accountName, recurrenceId, start, end);
        }

        public List<JobRecurrenceInformation> ListJobRecurrence(string accountName, DateTimeOffset? start = null, DateTimeOffset? end = null)
        {
            var toReturn = new List<JobRecurrenceInformation>();
            var response = _jobClient.Recurrence.List(accountName, start, end);
            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _jobClient.Recurrence.ListNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public JobPipelineInformation GetJobPipeline(string accountName, Guid pipelineId, DateTimeOffset? start = null, DateTimeOffset? end = null)
        {
            return _jobClient.Pipeline.Get(accountName, pipelineId, start, end);
        }

        public List<JobPipelineInformation> ListJobPipeline(string accountName, DateTimeOffset? start = null, DateTimeOffset? end = null)
        {
            var toReturn = new List<JobPipelineInformation>();
            var response = _jobClient.Pipeline.List(accountName, start, end);
            toReturn.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = _jobClient.Pipeline.ListNext(response.NextPageLink);
                toReturn.AddRange(response);
            }

            return toReturn;
        }

        public JobInformation GetJob(string accountName, Guid jobId)
        {
            return _jobClient.Job.Get(accountName, jobId);
        }

        public JobInformation SubmitJob(string accountName, Guid jobId, CreateJobParameters jobToSubmit)
        {
            return _jobClient.Job.Create(accountName, jobId, jobToSubmit);
        }

        public JobInformation BuildJob(string accountName, BuildJobParameters jobToBuild)
        {
            return _jobClient.Job.Build(accountName, jobToBuild);
        }

        public void CancelJob(string accountName, Guid jobId)
        {
            _jobClient.Job.Cancel(accountName, jobId);
        }

        public JobDataPath GetDebugDataPaths(string accountName, Guid jobId)
        {
            return _jobClient.Job.GetDebugDataPath(accountName, jobId);
        }

        public JobStatistics GetJobStatistics(string accountName, Guid jobId)
        {
            return _jobClient.Job.GetStatistics(accountName, jobId);
        }

        public List<JobInformationBasic> ListJobs(string accountName, string filter, int? top,
            int? skip, string orderBy, out bool moreJobs)
        {
            moreJobs = false;
            // top is used to return a total number, not top per page.
            if (!top.HasValue)
            {
                top = 500;
            }

            var parameters = new ODataQuery<JobInformationBasic>
            {
                Filter = filter,
                Skip = skip,
                OrderBy = orderBy
            };

            var jobList = new List<JobInformationBasic>();
            var response = _jobClient.Job.List(accountName, parameters);
            jobList.AddRange(response);
            var curCount = jobList.Count;
            while (!string.IsNullOrEmpty(response.NextPageLink) && curCount <= top.Value)
            {
                response = ListJobsWithNextLink(response.NextPageLink);
                jobList.AddRange(response);
                curCount = jobList.Count;
            }

            
            if (curCount > top.Value || !string.IsNullOrEmpty(response.NextPageLink))
            {
                moreJobs = true;
                
            }

            // return only the jobs requested if there are fewer than top.
            return jobList.GetRange(0, Math.Min(curCount, top.Value));
        }

#endregion

#region internal helpers
        internal string GetResourceGroupByAccountName(string accountName)
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

        internal string GetWildcardFilterString(string propertyName, string value)
        {
            if (!value.Contains("*"))
            {
                // no wildcards, return an equal
                return string.Format("{0} eq '{1}'", propertyName, value);
            }

            var subStrings = value.Split('*');
            if(subStrings.Length != 2)
            {
                throw new InvalidOperationException("Exactly one wildcard ('*') character is supported for expansion. Please remove extra wildcards and try again");
            }

            if(string.IsNullOrEmpty(subStrings[0]))
            {
                // only ends with required
                return string.Format("endswith({0},'{1}')", propertyName, subStrings[1]);
            }

            if(string.IsNullOrEmpty(subStrings[1]))
            {
                // only starts with
                return string.Format("startswith({0},'{1}')", propertyName, subStrings[0]);
            }


            // default case requires both
            return string.Format("startswith({0},'{1}') and endswith({0},'{2}')", propertyName, subStrings[0], subStrings[1]);
        }
#endregion

#region private helpers

        private IPage<JobInformationBasic> ListJobsWithNextLink(string nextLink)
        {
            return _jobClient.Job.ListNext(nextLink);
        }

        private IPage<FirewallRule> ListFirewallRulesWithNextLink(string nextLink)
        {
            return _accountClient.FirewallRules.ListByAccountNext(nextLink);
        }

        private bool IsCatalogItemOrList(CatalogPathInstance path, DataLakeAnalyticsEnums.CatalogItemType type)
        {
            var isList = false;
            if (path == null || string.IsNullOrEmpty(path.FullCatalogItemPath))
            {
                // in this case, it is a list of ALL catalog items of the specified type across the entire catalog.
                return true;
            }

            switch (type)
            {
                case DataLakeAnalyticsEnums.CatalogItemType.Database:
                    if (string.IsNullOrEmpty(path.DatabaseName))
                    {
                        isList = true;
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Schema:
                case DataLakeAnalyticsEnums.CatalogItemType.Assembly:
                case DataLakeAnalyticsEnums.CatalogItemType.ExternalDataSource:
                case DataLakeAnalyticsEnums.CatalogItemType.Secret:
                case DataLakeAnalyticsEnums.CatalogItemType.Credential:
                    if (string.IsNullOrEmpty(path.DatabaseName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName))
                    {
                        isList = true;
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Procedure:
                case DataLakeAnalyticsEnums.CatalogItemType.Types:
                case DataLakeAnalyticsEnums.CatalogItemType.Package:
                    if (string.IsNullOrEmpty(path.DatabaseName) ||
                        string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.TableOrTableValuedFunctionName))
                    {
                        isList = true;
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Table:
                case DataLakeAnalyticsEnums.CatalogItemType.TableValuedFunction:
                case DataLakeAnalyticsEnums.CatalogItemType.View:
                    if (string.IsNullOrEmpty(path.DatabaseName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.TableOrTableValuedFunctionName) ||
                        string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName))
                    {
                        isList = true;
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.TablePartition:
                    if (string.IsNullOrEmpty(path.DatabaseName) ||
                        string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName) ||
                        string.IsNullOrEmpty(path.TableOrTableValuedFunctionName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.TableStatisticsOrPartitionName))
                    {
                        isList = true;
                    }
                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.TableStatistics:
                    if (string.IsNullOrEmpty(path.DatabaseName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.TableStatisticsOrPartitionName) ||
                        string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName))
                    {
                        isList = true;
                    }
                    break;
            }

            return isList;
        }

        private static List<Acl> GetCatalogItemAclEntry(IPage<Acl> firstPage, Func<string, IPage<Acl>> listAclsNext)
        {
            var toReturn = new List<Acl>();
            var currentPage = firstPage;
            toReturn.AddRange(currentPage);
            while (!string.IsNullOrEmpty(currentPage.NextPageLink))
            {
                currentPage = listAclsNext(currentPage.NextPageLink);
                toReturn.AddRange(currentPage);
            }

            return toReturn;
        }

        private static string GetPermissionType(DataLakeAnalyticsEnums.PermissionType permission)
        {
            switch (permission)
            {
                case DataLakeAnalyticsEnums.PermissionType.None: return PermissionType.None;
                case DataLakeAnalyticsEnums.PermissionType.Read: return PermissionType.Use;
                case DataLakeAnalyticsEnums.PermissionType.ReadWrite: return PermissionType.All;
                default: throw new ArgumentException("PermissionType is invalid");
            }
        }
        #endregion
    }
}
