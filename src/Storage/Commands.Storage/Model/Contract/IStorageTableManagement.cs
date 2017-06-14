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
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Storage table management interface
    /// </summary>
    public interface IStorageTableManagement : IStorageManagement
    {
        /// <summary>
        /// List azure storage tables
        /// </summary>
        /// <param name="prefix">Table name prefix</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of tables that begin with the specified prefix</returns>
        IEnumerable<CloudTable> ListTables(string prefix, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Get a table reference
        /// </summary>
        /// <param name="name">Table name</param>
        /// <returns>Cloud table object</returns>
        CloudTable GetTableReference(string name);

        /// <summary>
        /// Checks whether the table exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table exists; otherwise, false.</returns>
        bool DoesTableExist(CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Cloud a azure storage table if not exists.
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        bool CreateTableIfNotExists(CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Delete the specified azure storage table
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        void Delete(CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Get table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        TablePermissions GetTablePermissions(CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Return a task that asynchronously fetch table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        Task<TablePermissions> GetTablePermissionsAsync(CloudTable table, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Set table permission
        /// </summary>
        /// <param name="table">Cloud table object</param>
        /// <param name="tablePermissions">table permissions</param>
        /// <param name="requestOptions">Table request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns></returns>
        void SetTablePermissions(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// Return a task that asynchronously set table permissions
        /// </summary>
        /// <param name="table">target table</param>
        /// <param name="tablePermissions">permissions to set</param>
        /// <param name="requestOptions">request options</param>
        /// <param name="operationContext">context</param>
        /// <returns></returns>
        Task SetTablePermissionsAsync(CloudTable table, TablePermissions tablePermissions, TableRequestOptions requestOptions = null, OperationContext operationContext = null);
    }
}