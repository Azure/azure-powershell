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

namespace Microsoft.Azure.Commands.Storage.Table.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.Azure.Commands.Storage.Common;
    using Microsoft.Azure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create an new azure table
    /// </summary>
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile("latest-2019-04-30")]
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageTable!V2"),OutputType(typeof(AzureStorageTable))]
    public class NewAzureStorageTableCommand : StorageCloudTableCmdletBase
    {
        [Alias("N", "Table")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Table name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableCommand class.
        /// </summary>
        public NewAzureStorageTableCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public NewAzureStorageTableCommand(IStorageTableManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// create an azure table
        /// </summary>
        /// <param name="name">An AzureStorageTable object</param>
        internal AzureStorageTable CreateAzureTable(string name)
        {
            if (!NameUtil.IsValidTableName(name))
            {
                throw new ArgumentException(String.Format(ResourceV2.InvalidTableName, name));
            }

            TableRequestOptions requestOptions = RequestOptions;
            CloudTable table = Channel.GetTableReference(name);
            bool created = Channel.CreateTableIfNotExists(table, requestOptions, TableOperationContext);

            if (!created)
            {
                throw new ResourceAlreadyExistException(String.Format(ResourceV2.TableAlreadyExists, name));
            }

            return new AzureStorageTable(table);
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureStorageTable azureTable = CreateAzureTable(Name);

            WriteObjectWithStorageContext(azureTable);
        }
    }
}
