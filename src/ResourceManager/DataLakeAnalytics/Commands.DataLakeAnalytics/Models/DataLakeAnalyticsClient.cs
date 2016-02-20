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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog;
using Microsoft.Azure.Management.DataLake.AnalyticsCatalog.Models;
using Microsoft.Azure.Management.DataLake.AnalyticsJob;
using Microsoft.Azure.Management.DataLake.AnalyticsJob.Models;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    public class DataLakeAnalyticsClient
    {
        private readonly DataLakeAnalyticsManagementClient _accountClient;
        private readonly DataLakeAnalyticsCatalogManagementClient _catalogClient;
        private readonly DataLakeAnalyticsJobManagementClient _jobClient;
        private readonly Guid _subscriptionId;

        public DataLakeAnalyticsClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            _accountClient = AzureSession.ClientFactory.CreateClient<DataLakeAnalyticsManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
            _accountClient.UserAgentSuffix = " - PowerShell Client";
            _subscriptionId = context.Subscription.Id;
            var creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            _jobClient = AzureSession.ClientFactory.CreateCustomClient<DataLakeAnalyticsJobManagementClient>(creds,
                context.Environment.GetEndpoint(
                    AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix));
            _catalogClient =
                AzureSession.ClientFactory.CreateCustomClient<DataLakeAnalyticsCatalogManagementClient>(creds,
                    context.Environment.GetEndpoint(
                        AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix));

            _jobClient.UserAgentSuffix = " - PowerShell Client";
            _catalogClient.UserAgentSuffix = " - PowerShell Client";
        }

        public DataLakeAnalyticsClient()
        {
        }

        #region Account Related Operations

        public DataLakeAnalyticsAccount CreateOrUpdateAccount(string resourceGroupName, string accountName,
            string location,
            DataLakeStoreAccount defaultDataLakeStoreAccount = null,
            IList<DataLakeStoreAccount> additionalDataLakeStoreAccounts = null,
            IList<StorageAccount> additionalStorageAccounts = null,
            Hashtable[] customTags = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var tags = TagsConversionHelper.CreateTagDictionary(customTags, true);

            var parameters = new DataLakeAnalyticsAccountCreateOrUpdateParameters
            {
                DataLakeAnalyticsAccount = new DataLakeAnalyticsAccount
                {
                    Name = accountName,
                    Location = location,
                    Tags = tags ?? new Dictionary<string, string>()
                }
            };


            parameters.DataLakeAnalyticsAccount.Properties = new DataLakeAnalyticsAccountProperties();

            if (defaultDataLakeStoreAccount != null)
            {
                parameters.DataLakeAnalyticsAccount.Properties.DefaultDataLakeStoreAccount =
                    defaultDataLakeStoreAccount.Name;
            }

            if (additionalStorageAccounts != null && additionalStorageAccounts.Count > 0)
            {
                parameters.DataLakeAnalyticsAccount.Properties.StorageAccounts = additionalStorageAccounts;
            }

            if (additionalDataLakeStoreAccounts != null && additionalDataLakeStoreAccounts.Count > 0)
            {
                if (defaultDataLakeStoreAccount != null)
                {
                    additionalDataLakeStoreAccounts.Add(defaultDataLakeStoreAccount);
                }

                parameters.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts = additionalDataLakeStoreAccounts;
            }
            else if (defaultDataLakeStoreAccount != null)
            {
                parameters.DataLakeAnalyticsAccount.Properties.DataLakeStoreAccounts = new List<DataLakeStoreAccount>
                {
                    defaultDataLakeStoreAccount
                };
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

            var response = accountExists
                ? _accountClient.DataLakeAnalyticsAccount.Update(resourceGroupName, parameters)
                : _accountClient.DataLakeAnalyticsAccount.Create(resourceGroupName, parameters);

            if (response.Status != OperationStatus.Succeeded)
            {
                throw new CloudException(string.Format(Properties.Resources.LongRunningOperationFailed,
                    response.Error.Code, response.Error.Message));
            }

            return
                _accountClient.DataLakeAnalyticsAccount.Get(resourceGroupName, parameters.DataLakeAnalyticsAccount.Name)
                    .DataLakeAnalyticsAccount;
        }

        public AzureOperationResponse DeleteAccount(string resourceGroupName, string accountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            if (!TestAccount(resourceGroupName, accountName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.AccountDoesNotExist, accountName));
            }

            var response = _accountClient.DataLakeAnalyticsAccount.Delete(resourceGroupName, accountName);

            if (response.Status != OperationStatus.Succeeded)
            {
                throw new CloudException(string.Format(Properties.Resources.LongRunningOperationFailed,
                    response.Error.Code, response.Error.Message));
            }

            return response;
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
                if (ex.Response != null && ex.Response.StatusCode == HttpStatusCode.NotFound)
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

            return _accountClient.DataLakeAnalyticsAccount.Get(resourceGroupName, accountName).DataLakeAnalyticsAccount;
        }

        public List<DataLakeAnalyticsAccount> ListAccounts(string resourceGroupName, string filter, int? top, int? skip)
        {
            var parameters = new DataLakeAnalyticsAccountListParameters
            {
                Filter = filter,
                Top = top,
                Skip = skip
            };

            var accountList = new List<DataLakeAnalyticsAccount>();
            var response = _accountClient.DataLakeAnalyticsAccount.List(resourceGroupName, parameters);
            accountList.AddRange(response.Value);

            while (!string.IsNullOrEmpty(response.NextLink))
            {
                response = ListAccountsWithNextLink(response.NextLink);
                accountList.AddRange(response.Value);
            }

            return accountList;
        }

        public void AddDataLakeStoreAccount(string resourceGroupName, string accountName,
            DataLakeStoreAccount storageToAdd)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var storageParams = new AddDataLakeStoreParameters
            {
                Properties = storageToAdd.Properties
            };

            _accountClient.DataLakeAnalyticsAccount.AddDataLakeStoreAccount(resourceGroupName, accountName,
                storageToAdd.Name, storageParams);
        }

        public void RemoveDataLakeStoreAccount(string resourceGroupName, string accountName,
            string dataLakeStoreAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.DataLakeAnalyticsAccount.DeleteDataLakeStoreAccount(resourceGroupName, accountName,
                dataLakeStoreAccountName);
        }

        public void AddStorageAccount(string resourceGroupName, string accountName, StorageAccount storageToAdd)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var storageParams = new AddStorageAccountParameters
            {
                Properties = storageToAdd.Properties
            };

            _accountClient.DataLakeAnalyticsAccount.AddStorageAccount(resourceGroupName, accountName, storageToAdd.Name,
                storageParams);
        }

        public void SetStorageAccount(string resourceGroupName, string accountName, StorageAccount storageToSet)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var storageParams = new AddStorageAccountParameters
            {
                Properties = storageToSet.Properties
            };

            _accountClient.DataLakeAnalyticsAccount.UpdateStorageAccount(resourceGroupName, accountName,
                storageToSet.Name, storageParams);
        }

        public void RemoveStorageAccount(string resourceGroupName, string accountName, string storageAccountName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _accountClient.DataLakeAnalyticsAccount.DeleteStorageAccount(resourceGroupName, accountName,
                storageAccountName);
        }

        public void SetDefaultDataLakeStoreAccount(string resourceGroupName, string accountName,
            DataLakeStoreAccount storageToSet)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var account = GetAccount(resourceGroupName, accountName);
            account.Properties.DefaultDataLakeStoreAccount = storageToSet.Name;

            if (
                !account.Properties.DataLakeStoreAccounts.Any(
                    acct => acct.Name.Equals(storageToSet.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                _accountClient.DataLakeAnalyticsAccount.AddDataLakeStoreAccount(resourceGroupName, accountName,
                    storageToSet.Name, null);
            }

            // null out values that cannot be updated
            account.Properties.DataLakeStoreAccounts = null;
            account.Properties.StorageAccounts = null;

            var updateParams = new DataLakeAnalyticsAccountCreateOrUpdateParameters
            {
                DataLakeAnalyticsAccount = account
            };

            _accountClient.DataLakeAnalyticsAccount.Update(resourceGroupName, updateParams);
        }

        private DataLakeAnalyticsAccountListResponse ListAccountsWithNextLink(string nextLink)
        {
            return _accountClient.DataLakeAnalyticsAccount.ListNext(nextLink);
        }

        #endregion

        #region Catalog Operations

        public USqlSecret CreateSecret(string resourceGroupName, string accountName, string databaseName,
            string secretName, string password, string hostUri)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _catalogClient.Catalog.CreateSecret(resourceGroupName, accountName, databaseName,
                new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                {
                    SecretName = secretName,
                    Password = password,
                    Uri = hostUri
                })
                .Secret;
        }

        public USqlSecret UpdateSecret(string resourceGroupName, string accountName, string databaseName,
            string secretName, string password, string hostUri)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _catalogClient.Catalog.UpdateSecret(accountName, resourceGroupName, databaseName,
                new DataLakeAnalyticsCatalogSecretCreateOrUpdateParameters
                {
                    SecretName = secretName,
                    Password = password,
                    Uri = hostUri
                })
                .Secret;
        }

        public void DeleteSecret(string resourceGroupName, string accountName, string databaseName, string secretName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            _catalogClient.Catalog.DeleteSecret(resourceGroupName, accountName, databaseName, secretName);
        }

        public USqlSecret GetSecret(string resourceGroupName, string accountName, string databaseName, string secretName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _catalogClient.Catalog.GetSecret(resourceGroupName, accountName, databaseName, secretName).Secret;
        }

        public bool TestCatalogItem(string resourceGroupName, string accountName, CatalogPathInstance path,
            DataLakeAnalyticsEnums.CatalogItemType itemType)
        {
            try
            {
                var result = GetCatalogItem(resourceGroupName, accountName, path, itemType);
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

        public IList<CatalogItem> GetCatalogItem(string resourceGroupName, string accountName, CatalogPathInstance path,
            DataLakeAnalyticsEnums.CatalogItemType itemType)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var isList = IsCatalogItemOrList(path, itemType);
            var toReturn = new List<CatalogItem>();

            switch (itemType)
            {
                case DataLakeAnalyticsEnums.CatalogItemType.Database:
                    if (isList)
                    {
                        toReturn.AddRange(GetDatabases(resourceGroupName, accountName));
                    }
                    else
                    {
                        toReturn.Add(GetDatabase(resourceGroupName, accountName, path.DatabaseName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Schema:
                    if (isList)
                    {
                        toReturn.AddRange(GetSchemas(resourceGroupName, accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetSchema(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Assembly:
                    if (isList)
                    {
                        toReturn.AddRange(GetAssemblies(resourceGroupName, accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetAssembly(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.ExternalDataSource:
                    if (isList)
                    {
                        toReturn.AddRange(GetExternalDataSources(resourceGroupName, accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetExternalDataSource(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Credential:
                    if (isList)
                    {
                        toReturn.AddRange(GetCredentials(resourceGroupName, accountName, path.DatabaseName));
                    }
                    else
                    {
                        toReturn.Add(GetCredential(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Table:
                    if (isList)
                    {
                        toReturn.AddRange(GetTables(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetTable(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.TableValuedFunction:
                    if (isList)
                    {
                        toReturn.AddRange(GetTableValuedFunctions(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetTableValuedFunction(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.TableStatistics:
                    if (isList)
                    {
                        toReturn.AddRange(GetTableStatistics(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }
                    else
                    {
                        toReturn.Add(GetTableStatistic(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName,
                            path.TableStatisticsName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.View:
                    if (isList)
                    {
                        toReturn.AddRange(GetViews(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetView(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;

                case DataLakeAnalyticsEnums.CatalogItemType.Procedure:
                    if (isList)
                    {
                        toReturn.AddRange(GetProcedures(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }
                    else
                    {
                        toReturn.Add(GetProcedure(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName, path.TableOrTableValuedFunctionName));
                    }

                    break;
                case DataLakeAnalyticsEnums.CatalogItemType.Types:
                    if (isList)
                    {
                        toReturn.AddRange(GetTypes(resourceGroupName, accountName, path.DatabaseName,
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
                        toReturn.Add(GetSecret(resourceGroupName, accountName, path.DatabaseName,
                            path.SchemaAssemblyOrExternalDataSourceName));
                    }

                    break;
            }

            return toReturn;
        }

        private USqlDatabase GetDatabase(string resourceGroupName, string accountName, string databaseName)
        {
            return _catalogClient.Catalog.GetDatabase(resourceGroupName, accountName, databaseName).Database;
        }

        private IList<USqlDatabase> GetDatabases(string resourceGroupName, string accountName)
        {
            return _catalogClient.Catalog.ListDatabases(resourceGroupName, accountName).DatabaseList.Value;
        }

        private USqlAssembly GetAssembly(string resourceGroupName, string accountName, string databaseName,
            string assemblyName)
        {
            return
                _catalogClient.Catalog.GetAssembly(resourceGroupName, accountName, databaseName, assemblyName).Assembly;
        }

        private IList<USqlAssemblyClr> GetAssemblies(string resourceGroupName, string accountName, string databaseName)
        {
            return
                _catalogClient.Catalog.ListAssemblies(resourceGroupName, accountName, databaseName).AssemblyList.Value;
        }

        private USqlExternalDataSource GetExternalDataSource(string resourceGroupName, string accountName,
            string databaseName, string dataSourceName)
        {
            return
                _catalogClient.Catalog.GetExternalDataSource(resourceGroupName, accountName, databaseName,
                    dataSourceName).ExternalDataSource;
        }

        private IList<USqlExternalDataSource> GetExternalDataSources(string resourceGroupName, string accountName,
            string databaseName)
        {
            return
                _catalogClient.Catalog.ListExternalDataSources(resourceGroupName, accountName, databaseName)
                    .ExternalDataSourceList.Value;
        }

        private USqlCredential GetCredential(string resourceGroupName, string accountName,
            string databaseName, string credName)
        {
            return
                _catalogClient.Catalog.GetCredential(resourceGroupName, accountName, databaseName,
                    credName).Credential;
        }

        private IList<USqlCredential> GetCredentials(string resourceGroupName, string accountName,
            string databaseName)
        {
            return
                _catalogClient.Catalog.ListCredentials(resourceGroupName, accountName, databaseName)
                    .CredentialList.Value;
        }

        private USqlSchema GetSchema(string resourceGroupName, string accountName, string databaseName,
            string schemaName)
        {
            return _catalogClient.Catalog.GetSchema(resourceGroupName, accountName, databaseName, schemaName).Schema;
        }

        private IList<USqlSchema> GetSchemas(string resourceGroupName, string accountName, string databaseName)
        {
            return _catalogClient.Catalog.ListSchemas(resourceGroupName, accountName, databaseName).SchemaList.Value;
        }

        private USqlTable GetTable(string resourceGroupName, string accountName, string databaseName, string schemaName,
            string tableName)
        {
            return
                _catalogClient.Catalog.GetTable(resourceGroupName, accountName, databaseName, schemaName, tableName)
                    .Table;
        }

        private IList<USqlTable> GetTables(string resourceGroupName, string accountName, string databaseName,
            string schemaName)
        {
            return
                _catalogClient.Catalog.ListTables(resourceGroupName, accountName, databaseName, schemaName)
                    .TableList.Value;
        }

        private USqlTableValuedFunction GetTableValuedFunction(string resourceGroupName, string accountName,
            string databaseName, string schemaName, string tableValuedFunctionName)
        {
            return
                _catalogClient.Catalog.GetTableValuedFunction(resourceGroupName, accountName, databaseName, schemaName,
                    tableValuedFunctionName).TableValuedFunction;
        }

        private IList<USqlTableValuedFunction> GetTableValuedFunctions(string resourceGroupName, string accountName,
            string databaseName, string schemaName)
        {
            return
                _catalogClient.Catalog.ListTableValuedFunctions(resourceGroupName, accountName, databaseName, schemaName)
                    .TableValuedFunctionList.Value;
        }

        private USqlTableStatistics GetTableStatistic(string resourceGroupName, string accountName, string databaseName,
            string schemaName, string tableName, string statisticsName)
        {
            return
                _catalogClient.Catalog.GetTableStatistic(resourceGroupName, accountName, databaseName, schemaName,
                    tableName, statisticsName).Statistics;
        }

        private IList<USqlTableStatistics> GetTableStatistics(string resourceGroupName, string accountName,
            string databaseName, string schemaName, string tableName)
        {
            return
                _catalogClient.Catalog.ListTableStatistics(resourceGroupName, accountName, databaseName, schemaName,
                    tableName).StatisticsList.Value;
        }

        private USqlView GetView(string resourceGroupName, string accountName, string databaseName, string schemaName,
            string viewName)
        {
            return
                _catalogClient.Catalog.GetView(resourceGroupName, accountName, databaseName, schemaName, viewName)
                    .View;
        }

        private IList<USqlView> GetViews(string resourceGroupName, string accountName, string databaseName,
            string schemaName)
        {
            return
                _catalogClient.Catalog.ListViews(resourceGroupName, accountName, databaseName, schemaName)
                    .ViewList.Value;
        }

        private USqlProcedure GetProcedure(string resourceGroupName, string accountName, string databaseName, string schemaName,
            string procName)
        {
            return
                _catalogClient.Catalog.GetProcedure(resourceGroupName, accountName, databaseName, schemaName, procName)
                    .Procedure;
        }

        private IList<USqlProcedure> GetProcedures(string resourceGroupName, string accountName, string databaseName,
            string schemaName)
        {
            return
                _catalogClient.Catalog.ListProcedures(resourceGroupName, accountName, databaseName, schemaName)
                    .ProcedureList.Value;
        }

        private IList<USqlType> GetTypes(string resourceGroupName, string accountName, string databaseName,
            string schemaName)
        {
            return
                _catalogClient.Catalog.ListTypes(resourceGroupName, accountName, databaseName, schemaName, null)
                    .TypeList.Value;
        }

        #endregion

        #region Job Related Operations

        public JobInformation GetJob(string resourceGroupName, string accountName, Guid jobId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _jobClient.Jobs.Get(resourceGroupName, accountName, jobId).Job;
        }

        public JobInformation SubmitJob(string resourceGroupName, string accountName, JobInformation jobToSubmit)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return
                _jobClient.Jobs.Create(resourceGroupName, accountName,
                    new JobInfoBuildOrCreateParameters {Job = jobToSubmit}).Job;
        }

        public JobInformation BuildJob(string resourceGroupName, string accountName, JobInformation jobToBuild)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return
                _jobClient.Jobs.Build(resourceGroupName, accountName,
                    new JobInfoBuildOrCreateParameters {Job = jobToBuild}).Job;
        }

        public AzureOperationResponse CancelJob(string resourceGroupName, string accountName, Guid jobId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _jobClient.Jobs.Cancel(resourceGroupName, accountName, jobId);
        }

        public JobDataPath GetDebugDataPaths(string resourceGroupName, string accountName, Guid jobId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _jobClient.Jobs.GetDebugDataPath(resourceGroupName, accountName, jobId).JobData;
        }

        public JobStatistics GetJobStatistics(string resourceGroupName, string accountName, Guid jobId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            return _jobClient.Jobs.GetStatistics(resourceGroupName, accountName, jobId).Statistics;
        }

        public List<JobInformation> ListJobs(string resourceGroupName, string accountName, string filter, int? top,
            int? skip)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByAccountName(accountName);
            }

            var parameters = new JobListParameters
            {
                Filter = filter,
                Top = top,
                Skip = skip
            };

            var jobList = new List<JobInformation>();
            var response = _jobClient.Jobs.List(resourceGroupName, accountName, parameters);

            jobList.AddRange(response.Value);
            while (!string.IsNullOrEmpty(response.NextLink))
            {
                response = ListJobsWithNextLink(response.NextLink, resourceGroupName);
                jobList.AddRange(response.Value);
            }

            return jobList;
        }

        #endregion

        #region private helpers

        private JobInfoListResponse ListJobsWithNextLink(string nextLink, string resourceGroupName)
        {
            return _jobClient.Jobs.ListNext(nextLink, resourceGroupName);
        }

        private string GetResourceGroupByAccountName(string accountName)
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
                case DataLakeAnalyticsEnums.CatalogItemType.Table:
                case DataLakeAnalyticsEnums.CatalogItemType.TableValuedFunction:
                case DataLakeAnalyticsEnums.CatalogItemType.View:
                case DataLakeAnalyticsEnums.CatalogItemType.Procedure:
                case DataLakeAnalyticsEnums.CatalogItemType.Types:
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
                case DataLakeAnalyticsEnums.CatalogItemType.TableStatistics:
                    if (string.IsNullOrEmpty(path.DatabaseName) ||
                        string.IsNullOrEmpty(path.SchemaAssemblyOrExternalDataSourceName) ||
                        string.IsNullOrEmpty(path.TableOrTableValuedFunctionName))
                    {
                        throw new CloudException(string.Format(Properties.Resources.InvalidCatalogPath,
                            path.FullCatalogItemPath));
                    }

                    if (string.IsNullOrEmpty(path.TableStatisticsName))
                    {
                        isList = true;
                    }
                    break;
            }

            return isList;
        }

        #endregion
    }
}