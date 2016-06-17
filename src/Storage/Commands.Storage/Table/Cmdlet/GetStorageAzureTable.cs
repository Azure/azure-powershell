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
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// list azure tables
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageNouns.Table, DefaultParameterSetName = NameParameterSet),
        OutputType(typeof(AzureStorageTable))]
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
                IEnumerable<CloudTable> tables = Channel.ListTables(prefix, requestOptions, OperationContext);
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

                if (Channel.DoesTableExist(table, requestOptions, OperationContext))
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
        /// list azure queues by prefix
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

            return Channel.ListTables(prefix, reqesutOptions, OperationContext);
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
                AzureStorageTable azureTable = new AzureStorageTable(table);
                WriteObjectWithStorageContext(azureTable);
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
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
    }
}
