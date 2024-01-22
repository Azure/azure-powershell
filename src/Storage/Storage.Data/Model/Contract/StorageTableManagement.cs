// ----------------------------------------------------------------------------------
//
// Copyright 2012 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Cosmos.Table;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Azure.Data.Tables;
    using Microsoft.WindowsAzure.Commands.Common;
    using global::Azure.Core;

    /// <summary>
    /// Storage table management
    /// </summary>
    public partial class StorageTableManagement : IStorageTableManagement
    {
        /// <summary>
        /// Cloud table client from track 1 sdk
        /// </summary>
        private CloudTableClient tableClient;

        /// <summary>
        /// Internal storage context
        /// </summary>
        private AzureStorageContext internalStorageContext;

        /// <summary>
        /// The azure storage context assoicated with this IStorageBlobManagement
        /// </summary>
        public AzureStorageContext StorageContext
        {
            get
            {
                return internalStorageContext;
            }
        }

        public bool IsTokenCredential
        {
            get
            {
                return internalStorageContext.StorageAccount.Credentials.IsToken;
            }
        }

        /// <summary>
        /// Storage table management constructor
        /// </summary>
        /// <param name="context">Cloud table client</param>
        public StorageTableManagement(AzureStorageContext context)
        {
            internalStorageContext = context;

            TableClientOptions clientOptions = new TableClientOptions();
            clientOptions.AddPolicy(new UserAgentPolicy(ApiConstants.UserAgentHeaderValue), HttpPipelinePosition.PerCall);

            if (!context.StorageAccount.Credentials.IsToken)
            {
                tableClient = internalStorageContext.TableStorageAccount.CreateCloudTableClient();
            }
            else
            {
                tableServiceClient = new TableServiceClient(context.StorageAccount.TableEndpoint, context.Track2OauthToken, clientOptions);
            }
        }

        /// <summary>
        /// List azure storage tables
        /// </summary>
        /// <param name="prefix">Table name prefix</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of tables that begin with the specified prefix</returns>
        public IEnumerable<CloudTable> ListTables(string prefix, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            EnsureCloudTableClient();

            //https://ahmet.im/blog/azure-listblobssegmentedasync-listcontainerssegmentedasync-how-to/
            TableContinuationToken continuationToken = null;
            var results = new List<CloudTable>();
            do
            {
                try
                {
                    var response = tableClient.ListTablesSegmentedAsync(prefix, null, continuationToken, requestOptions, operationContext).Result;
                    continuationToken = response.ContinuationToken;
                    results.AddRange(response.Results);
                }
                catch (AggregateException e) when (e.InnerException is XTable.StorageException)
                {
                    throw e.InnerException;
                }
            } while (continuationToken != null);
            return results;
        }

        /// <summary>
        /// Get a table reference
        /// </summary>
        /// <param name="name">Table name</param>
        /// <returns>Cloud table object</returns>
        public CloudTable GetTableReference(string name)
        {
            EnsureCloudTableClient();
            return tableClient.GetTableReference(name);
        }

        /// <summary>
        /// Cloud a azure storage table if not exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        public bool CreateTableIfNotExists(CloudTable table, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            try
            {
                return table.CreateIfNotExistsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Delete the specified azure storage table
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        public void Delete(CloudTable table, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => table.DeleteAsync(requestOptions, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table exists; otherwise, false.</returns>
        public bool DoesTableExist(CloudTable table, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            try
            {
                return table.ExistsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Get table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        public TablePermissions GetTablePermissions(CloudTable table, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            try
            {
                return table.GetPermissionsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Return a task that asynchronously fetch table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        public Task<TablePermissions> GetTablePermissionsAsync(CloudTable table, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            return table.GetPermissionsAsync(requestOptions, operationContext);
        }

        /// <summary>
        /// Set table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="tablePermissions">table permissions</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns></returns>
        public void SetTablePermissions(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => table.SetPermissionsAsync(tablePermissions, requestOptions, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }


        /// <summary>
        /// Return a task that asynchronously set table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="tablePermissions">permissions to set</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        public Task SetTablePermissionsAsync(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions, XTable.OperationContext operationContext)
        {
            return table.SetPermissionsAsync(tablePermissions, requestOptions, operationContext);
        }

        /// <summary>
        /// Get the Table service properties
        /// </summary>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The service properties of the specified service type</returns>
        public XTable.ServiceProperties GetStorageTableServiceProperties(XTable.TableRequestOptions options, XTable.OperationContext operationContext)
        {
            XTable.CloudStorageAccount account = StorageContext.TableStorageAccount;
            try
            {
                return account.CreateCloudTableClient().GetServicePropertiesAsync(options, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Set Table service properties
        /// </summary>
        /// <param name="properties">Service properties</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        public void SetStorageTableServiceProperties(XTable.ServiceProperties properties, XTable.TableRequestOptions options, XTable.OperationContext operationContext)
        {
            XTable.CloudStorageAccount account = StorageContext.TableStorageAccount;
            try
            {
                Task.Run(() => account.CreateCloudTableClient().SetServicePropertiesAsync(properties, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XTable.StorageException)
            {
                throw e.InnerException;
            }
        }

        private void EnsureCloudTableClient()
        {
            if (tableClient == null)
            {
                throw new ApplicationException($"{nameof(tableClient)} is not initialized");
            }
        }
    }
}