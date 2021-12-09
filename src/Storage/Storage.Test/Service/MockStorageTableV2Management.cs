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
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Service
{
    public partial class MockStorageTableManagement : IStorageTableManagement
    {
        private List<TableItem> v2Tables = new List<TableItem>();

        private Dictionary<string, TableSignedIdentifier> signedIdentifiers = new Dictionary<string, TableSignedIdentifier>();

        /// <summary>
        /// Gets an instance of a AzureStorageTable wrapping TableClient configured with the current TableServiceClient options,
        /// affinitized to the specified tableName.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public AzureStorageTable GetAzureStorageTable(string tableName)
        {
            return new AzureStorageTable(new TableClient(new Uri($"{MockStorageTableManagement.TableEndPoint}{tableName}")));
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">Table name filter expression.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public IEnumerable<TableItem> QueryTables(string filter, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return this.v2Tables;
            }
            else
            {
                Match match = Regex.Match(filter, "^TableName eq '(.+?)'");
                if (match.Success)
                {
                    string tableName = match.Groups[1].Value;
                    return this.v2Tables.Where(t => t.Name.Equals(tableName, StringComparison.OrdinalIgnoreCase));
                }

                match = Regex.Match(filter, "^TableName ge '(.+?)'");
                if (match.Success)
                {
                    string tableNamePrefix = match.Groups[1].Value;
                    return this.v2Tables.Where(t => t.Name.StartsWith(tableNamePrefix, StringComparison.OrdinalIgnoreCase));
                }
            }

            Console.WriteLine($"Unsupported table query filter string: {filter}");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the properties of an account's Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Response<TableServiceProperties> GetProperties(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules.
        /// </summary>
        /// <param name="properties">The Table Service properties.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Response SetProperties(TableServiceProperties properties, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns>True if table was created; otherwise, false.</returns>
        public bool CreateTableIfNotExists(string tableName, CancellationToken cancellationToken)
        {
            if (this.v2Tables.Any(t => t.Name.Equals(tableName, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            this.v2Tables.Add(new TableItem(tableName));
            return true;
        }

        /// <summary>
        /// Deletes the table on the service.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if table was deleted; otherwise, false.</returns>
        public bool DeleteTable(string tableName, CancellationToken cancellationToken)
        {
            TableItem table = this.v2Tables
                .Where(t => t.Name.Equals(tableName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (table == null)
            {
                return false;
            }

            this.v2Tables.Remove(table);
            return true;
        }

        /// <summary>
        /// Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public IEnumerable<TableSignedIdentifier> GetAccessPolicies(string tableName, CancellationToken cancellationToken)
        {
            return this.signedIdentifiers.Values.ToList();
        }

        /// <summary>
        /// Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Task<IEnumerable<TableSignedIdentifier>> GetAccessPoliciesAsync(string tableName, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.GetAccessPolicies(tableName, cancellationToken));
        }

        /// <summary>
        /// Sets stored access policies for the table that may be used with Shared Access Signatures.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="identifiers">The access policies for the table.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public Response SetAccessPolicies(string tableName, IEnumerable<TableSignedIdentifier> identifiers, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements ITableEntity or an instance of TableEntity.</typeparam>
        /// <param name="tableName"></param>
        /// <param name="filter">Returns only entities that satisfy the specified OData filter. For example, "PartitionKey eq 'foo'".</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="selects">An IEnumerable<T> of entity property names that selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A CancellationToken controlling the request lifetime.</param>
        /// <returns></returns>
        public IEnumerable<T> QueryTableEntities<T>(string tableName, string filter, int maxPerPage, IEnumerable<string> selects, CancellationToken cancellationToken)
            where T : class, ITableEntity, new()
        {
            throw new NotImplementedException();
        }

        public void ClearAndAddTestTableV2(params string[] tableNames)
        {
            this.v2Tables.Clear();

            foreach (string tableName in tableNames)
            {
                this.v2Tables.Add(new TableItem(tableName));
            }
        }

        public void ClearTestSignedIdentifiers()
        {
            this.signedIdentifiers.Clear();
        }

        public void ClearAndAddTestSignedIdentifiers(params Tuple<string, TableAccessPolicy>[] accessPolicies)
        {
            this.signedIdentifiers.Clear();

            foreach (Tuple<string, TableAccessPolicy> accessPolicy in accessPolicies)
            {
                this.signedIdentifiers.Add(
                    accessPolicy.Item1,
                    new TableSignedIdentifier(accessPolicy.Item1, accessPolicy.Item2));
            }
        }
    }
}
