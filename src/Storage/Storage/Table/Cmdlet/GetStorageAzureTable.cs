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

namespace Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Linq;
    using global::Azure.Data.Tables.Models;

    /// <summary>
    /// list azure tables
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageTable", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageTable))]
    public class GetAzureStorageTableCommand : StorageCloudTableCmdletBase
    {
        /// <summary>
        /// default parameter set name
        /// </summary>
        private const string NameParameterSet = "TableName";

        /// <summary>
        /// prefix parameter set name
        /// </summary>
        private const string PrefixParameterSet = "TablePrefix";

        [Alias("N", "Table")]
        [Parameter(Position = 0, HelpMessage = "Table name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet)]
        [SupportsWildcards()]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Table Prefix",
            ParameterSetName = PrefixParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageTableCommand class.
        /// </summary>
        public GetAzureStorageTableCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageTableCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public GetAzureStorageTableCommand(IStorageTableManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// list azure tables by table name
        /// </summary>
        /// <param name="name">table name</param>
        /// <returns>An enumerable collection of CloudTable object</returns>
        internal IEnumerable<CloudTable> ListTablesByName(string name)
        {
            TableRequestOptions requestOptions = RequestOptions;
            String prefix = String.Empty;

            if (String.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
            {
                IEnumerable<CloudTable> tables = Channel.ListTables(prefix, requestOptions, TableOperationContext);
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!string.IsNullOrEmpty(name))
                {
                    wildcard = new WildcardPattern(name, options);
                }

                foreach (CloudTable table in tables)
                {
                    if (wildcard == null || wildcard.IsMatch(table.Name))
                    {
                        yield return table;
                    }
                }
            }
            else
            {
                if (!NameUtil.IsValidTableName(name))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidTableName, name));
                }

                CloudTable table = Channel.GetTableReference(name);

                if (Channel.DoesTableExist(table, requestOptions, TableOperationContext))
                {
                    yield return table;
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(Resources.TableNotFound, name));
                }
            }
        }

        /// <summary>
        /// list azure tables by prefix
        /// </summary>
        /// <param name="prefix">table prefix</param>
        /// <returns>An enumerable collection of CloudTable object</returns>
        internal IEnumerable<CloudTable> ListTablesByPrefix(string prefix)
        {
            TableRequestOptions reqesutOptions = RequestOptions;

            if (!NameUtil.IsValidTablePrefix(prefix))
            {
                throw new ArgumentException(String.Format(Resources.InvalidTableName, prefix));
            }

            return Channel.ListTables(prefix, reqesutOptions, TableOperationContext);
        }

        /// <summary>
        /// list azure table clients by full name or simple regular expression
        /// </summary>
        /// <param name="localChannel">IStorageTableManagement channel object</param>
        /// <param name="tableName">table name or simple regular expression</param>
        /// <returns></returns>
        internal IEnumerable<AzureStorageTable> ListTablesByNameV2(IStorageTableManagement localChannel, string tableName)
        {
            if (String.IsNullOrEmpty(tableName) || WildcardPattern.ContainsWildcardCharacters(tableName))
            {
                WildcardPattern wildcard = null;
                if (!string.IsNullOrEmpty(tableName))
                {
                    wildcard = new WildcardPattern(tableName, WildcardOptions.IgnoreCase | WildcardOptions.Compiled);
                }

                foreach (AzureStorageTable table in this.ListTablesByQueryV2(localChannel, query: null))
                {
                    if (wildcard == null || wildcard.IsMatch(table.Name))
                    {
                        yield return table;
                    }
                }
            }
            else
            {
                if (!NameUtil.IsValidTableName(tableName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidTableName, tableName));
                }

                string query = $"TableName eq '{tableName}'";
                List<AzureStorageTable> tables = this.ListTablesByQueryV2(localChannel, query).ToList();
                if (tables.Count == 0)
                {
                    throw new ResourceNotFoundException(String.Format(Resources.TableNotFound, tableName));
                }

                foreach (AzureStorageTable table in tables)
                {
                    yield return table;
                }
            }
        }

        /// <summary>
        /// list azure table clients by prefix using track2 sdk
        /// </summary>
        /// <param name="localChannel">IStorageTableManagement channel object</param>
        /// <param name="prefix">table prefix</param>
        /// <returns></returns>
        internal IEnumerable<AzureStorageTable> ListTablesByPrefixV2(IStorageTableManagement localChannel, string prefix)
        {
            if (!NameUtil.IsValidTablePrefix(prefix))
            {
                throw new ArgumentException(String.Format(Resources.InvalidTableName, prefix));
            }

            // append '{' as upper bound as it is the first ASCII char after the largest legal table name character
            string query = $"TableName ge '{prefix}' and TableName lt '{prefix}{{'";
            return this.ListTablesByQueryV2(localChannel, query);
        }

        /// <summary>
        /// list azure table clients by query
        /// </summary>
        /// <param name="localChannel">IStorageTableManagement channel object</param>
        /// <param name="query">table query string</param>
        /// <returns></returns>
        internal IEnumerable<AzureStorageTable> ListTablesByQueryV2(IStorageTableManagement localChannel, string query)
        {
            IEnumerable<TableItem> tableItems = localChannel.QueryTables(query, this.CmdletCancellationToken);
            foreach (TableItem tableItem in tableItems)
            {
                yield return localChannel.GetAzureStorageTable(tableItem.Name);
            }
        }

        /// <summary>
        /// write cloud table with storage context
        /// </summary>
        /// <param name="tableList">An enumerable collection of CloudTable object</param>
        internal void WriteTablesWithStorageContext(IEnumerable<CloudTable> tableList)
        {
            if (null == tableList)
            {
                return;
            }

            foreach (CloudTable table in tableList)
            {
                AzureStorageTable azureTable = new AzureStorageTable(table, this.Channel.StorageContext, this.tableClientOptions);
                WriteObjectWithStorageContext(azureTable);
            }
        }

        /// <summary>
        /// write table with storage context
        /// </summary>
        /// <param name="tableList">An enumerable collection of AzureStorageTable object</param>
        internal void WriteTablesWithStorageContext(IEnumerable<AzureStorageTable> tableList)
        {
            if (null == tableList)
            {
                return;
            }

            foreach (AzureStorageTable table in tableList)
            {
                WriteObjectWithStorageContext(table);
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (!this.Channel.IsTokenCredential)
            {
                IEnumerable<CloudTable> tableList = null;

                if (PrefixParameterSet == ParameterSetName)
                {
                    tableList = ListTablesByPrefix(Prefix);
                }
                else
                {
                    tableList = ListTablesByName(Name);
                }

                WriteTablesWithStorageContext(tableList);
            }
            else
            {
                IEnumerable<AzureStorageTable> tableList = null;

                if (PrefixParameterSet == ParameterSetName)
                {
                    tableList = this.ListTablesByPrefixV2(Channel, Prefix);
                }
                else
                {
                    tableList = this.ListTablesByNameV2(Channel, Name);
                }

                this.WriteTablesWithStorageContext(tableList);
            }
        }
    }
}
