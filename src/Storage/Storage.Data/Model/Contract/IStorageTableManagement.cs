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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Azure;
    using global::Azure.Data.Tables.Models;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using ITableEntity = global::Azure.Data.Tables.ITableEntity;
    using XTable = Microsoft.Azure.Cosmos.Table;

    /// <summary>
    /// Storage table management interface
    /// </summary>
    public interface IStorageTableManagement : IStorageManagement
    {
        bool IsTokenCredential { get; }

        /// <summary>
        /// List azure storage tables
        /// </summary>
        /// <param name="prefix">Table name prefix</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of tables that begin with the specified prefix</returns>
        IEnumerable<CloudTable> ListTables(string prefix, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">Table name filter expression.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        IEnumerable<TableItem> QueryTables(string filter, CancellationToken cancellationToken);

        /// <summary>
        /// Get a table reference
        /// </summary>
        /// <param name="name">Table name</param>
        /// <returns>Cloud table object</returns>
        CloudTable GetTableReference(string name);

        /// <summary>
        /// Gets an instance of a AzureStorageTable wrapping TableClient configured with the current TableServiceClient options,
        /// affinitized to the specified tableName.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        AzureStorageTable GetAzureStorageTable(string tableName);

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table exists; otherwise, false.</returns>
        bool DoesTableExist(CloudTable table, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Cloud a azure storage table if not exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        bool CreateTableIfNotExists(CloudTable table, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        bool CreateTableIfNotExists(string tableName, CancellationToken cancellationToken);

        /// <summary>
        /// Delete the specified azure storage table
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        void Delete(CloudTable table, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Deletes the table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns>True if table was deleted; otherwise, false.</returns>
        bool DeleteTable(string tableName, CancellationToken cancellationToken);

        /// <summary>
        /// Get table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        TablePermissions GetTablePermissions(CloudTable table, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Return a task that asynchronously fetch table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        Task<TablePermissions> GetTablePermissionsAsync(CloudTable table, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Set table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="tablePermissions">table permissions</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns></returns>
        void SetTablePermissions(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Return a task that asynchronously set table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="tablePermissions">permissions to set</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        Task SetTablePermissionsAsync(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions = null, XTable.OperationContext operationContext = null);

        /// <summary>
        /// Get the Table service properties
        /// </summary>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The service properties of the specified service type</returns>
        XTable.ServiceProperties GetStorageTableServiceProperties(XTable.TableRequestOptions options, XTable.OperationContext operationContext);

        /// <summary>
        /// Set Table service properties
        /// </summary>
        /// <param name="properties">Service properties</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        void SetStorageTableServiceProperties(XTable.ServiceProperties properties, XTable.TableRequestOptions options, XTable.OperationContext operationContext);

        /// <summary>
        /// Gets the properties of an account's Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        Response<TableServiceProperties> GetProperties(CancellationToken cancellationToken);

        /// <summary>
        /// Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="properties">The Table Service properties.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        Response SetProperties(TableServiceProperties properties, CancellationToken cancellationToken);

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
        IEnumerable<T> QueryTableEntities<T>(string tableName, string filter, int maxPerPage, IEnumerable<string> selects, CancellationToken cancellationToken)
            where T : class, ITableEntity, new();
    }
}