﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Storage table management
    /// </summary>
    public class StorageTableManagement : IStorageTableManagement
    {
        /// <summary>
        /// Cloud table client
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

        /// <summary>
        /// Storage table management constructor
        /// </summary>
        /// <param name="client">Cloud table client</param>
        public StorageTableManagement(AzureStorageContext context)
        {
            internalStorageContext = context;
            tableClient = internalStorageContext.StorageAccount.CreateCloudTableClient();
        }

        /// <summary>
        /// List azure storage tables
        /// </summary>
        /// <param name="prefix">Table name prefix</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of tables that begin with the specified prefix</returns>
        public IEnumerable<CloudTable> ListTables(string prefix, TableRequestOptions requestOptions, OperationContext operationContext)
        {
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
                catch (AggregateException e) when (e.InnerException is StorageException)
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
            return tableClient.GetTableReference(name);
        }

        /// <summary>
        /// Cloud a azure storage table if not exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        public bool CreateTableIfNotExists(CloudTable table, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            try
            {
                return table.CreateIfNotExistsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
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
        public void Delete(CloudTable table, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            try
            {
                Task.Run(() => table.DeleteAsync(requestOptions, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
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
        public bool DoesTableExist(CloudTable table, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            try
            {
                return table.ExistsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
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
        public TablePermissions GetTablePermissions(CloudTable table, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            try
            {
                return table.GetPermissionsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
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
        public Task<TablePermissions> GetTablePermissionsAsync(CloudTable table, TableRequestOptions requestOptions, OperationContext operationContext)
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
        public void SetTablePermissions(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            try
            {
                Task.Run(() => table.SetPermissionsAsync(tablePermissions, requestOptions, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
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
        public Task SetTablePermissionsAsync(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return table.SetPermissionsAsync(tablePermissions, requestOptions, operationContext);
        }
    }
}