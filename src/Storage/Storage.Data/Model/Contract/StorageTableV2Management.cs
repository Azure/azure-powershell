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
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using global::Azure;
    using global::Azure.Data.Tables;
    using global::Azure.Data.Tables.Models;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;

    public partial class StorageTableManagement : IStorageTableManagement
    {
        /// <summary>
        /// Table servcie client from track 2 sdk
        /// </summary>
        private TableServiceClient tableServiceClient;

        /// <summary>
        /// Gets an instance of a AzureStorageTable wrapping TableClient configured with the current TableServiceClient options,
        /// affinitized to the specified tableName.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public AzureStorageTable GetAzureStorageTable(string tableName)
        {
            this.EnsureTableServiceClient();
            return new AzureStorageTable(this.tableServiceClient.GetTableClient(tableName));
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">Table name filter expression.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public IEnumerable<TableItem> QueryTables(string filter, CancellationToken cancellationToken)
        {
            this.EnsureTableServiceClient();
            return this.tableServiceClient.Query(filter, maxPerPage: null, cancellationToken);
        }

        /// <summary>
        /// Gets the properties of an account's Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Response<TableServiceProperties> GetProperties(CancellationToken cancellationToken)
        {
            this.EnsureTableServiceClient();
            return this.tableServiceClient.GetProperties(cancellationToken);
        }

        /// <summary>
        /// Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="properties">The Table Service properties.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Response SetProperties(TableServiceProperties properties, CancellationToken cancellationToken)
        {
            this.EnsureTableServiceClient();
            return this.tableServiceClient.SetProperties(properties, cancellationToken);
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        public bool CreateTableIfNotExists(string tableName, CancellationToken cancellationToken)
        {
            this.EnsureTableServiceClient();
            TableClient tableClient = this.tableServiceClient.GetTableClient(tableName);
            Response<TableItem> response = tableClient.CreateIfNotExists(cancellationToken);
            return response != null;
        }

        /// <summary>
        /// Deletes the table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if table was deleted; otherwise, false.</returns>
        public bool DeleteTable(string tableName, CancellationToken cancellationToken)
        {
            this.EnsureTableServiceClient();
            TableClient tableClient = this.tableServiceClient.GetTableClient(tableName);
            Response response = tableClient.Delete(cancellationToken);
            return response != null;
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements ITableEntity or an instance of TableEntity.</typeparam>
        /// <param name="tableName"></param>
        /// <param name="filter">Returns only entities that satisfy the specified OData filter. For example, "PartitionKey eq 'foo'".</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="selects">An IEnumerable&lt;T&gt; of entity property names that selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public IEnumerable<T> QueryTableEntities<T>(string tableName, string filter, int maxPerPage, IEnumerable<string> selects, CancellationToken cancellationToken)
            where T : class, ITableEntity, new()
        {
            this.EnsureTableServiceClient();
            TableClient tableClient = this.tableServiceClient.GetTableClient(tableName);
            return tableClient.Query<T>(filter, maxPerPage, selects, cancellationToken);
        }

        private void EnsureTableServiceClient()
        {
            if (this.tableServiceClient == null)
            {
                throw new ApplicationException($"{nameof(this.tableServiceClient)} is not initialized");
            }
        }
    }
}
