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

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using System;
    using global::Azure;
    using global::Azure.Data.Tables;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Microsoft.WindowsAzure.Commands.Storage.Common;

    /// <summary>
    /// Azure storage table object
    /// </summary>
    public class AzureStorageTable : AzureStorageBase
    {
        /// <summary>
        /// Cloud table object
        /// </summary>
        [Ps1Xml(Label = "Table End Point", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudTable.ServiceClient.BaseUri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0)]
        public CloudTable CloudTable { get; }

        /// <summary>
        /// Track 2 Table Client object
        /// </summary>
        public TableClient TableClient { get; }

        /// <summary>
        /// Table uri
        /// </summary>
        [Ps1Xml(Label = "Uri", Target = ViewControl.Table, ScriptBlock = "$_.Uri", Position = 1)]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Constructs AzureStorageTable from track 1 CloudTable.
        /// Internally it constructs track 2 TableClient used by data plane cmdlets.
        /// </summary>
        /// <param name="table">Cloud table object.</param>
        /// <param name="storageContext">Storage context containing account information used to construct TableClient.</param>
        /// <param name="options">Table client options which should contain powershell user agent.</param>
        public AzureStorageTable(CloudTable table, AzureStorageContext storageContext, TableClientOptions options)
        {
            this.CloudTable = table;
            this.Name = table.Name;
            this.Uri = table.Uri;
            
            this.Context = storageContext;

            // construct track 2 table client from track 1 cloud table instance
            this.TableClient = AzureStorageTable.ConstructTableClientFromCloudTable(this.CloudTable, options);
        }

        /// <summary>
        /// Constructs AzureSTorageTable from track 2 TableClient.
        /// Internally it construcs track 1 CloudTable for property display purpose only.
        /// </summary>
        /// <param name="tableClient"></param>
        public AzureStorageTable(TableClient tableClient)
        {
            this.TableClient = tableClient;
            this.Name = tableClient.Name;

            Uri uri = (Uri)typeof(TableClient)
                .GetField("_endpoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(tableClient);
            this.Uri = new Uri($"{uri.AbsoluteUri}{(uri.AbsoluteUri.EndsWith("/") ? string.Empty : "/")}{Name}");
            
            // This constructed CloudTable is only for display purpose.
            // Without credential content, it wouldn't work for data plane operations.
            // Customer, who uses oauth, should use track 2 TableClient instead.
            this.CloudTable = new CloudTable(Uri);
        }

        private static TableClient ConstructTableClientFromCloudTable(CloudTable cloudTable, TableClientOptions options)
        {
            TableClient tableClient;

            if (cloudTable.ServiceClient.Credentials.IsSAS)
            {
                AzureSasCredential sasCredential = new AzureSasCredential(cloudTable.ServiceClient.Credentials.SASToken);
                tableClient = new TableClient(cloudTable.Uri, sasCredential, options);
            }
            else if (cloudTable.ServiceClient.Credentials.IsSharedKey)
            {
                TableSharedKeyCredential keyCredential = new TableSharedKeyCredential(
                    cloudTable.ServiceClient.Credentials.AccountName,
                    cloudTable.ServiceClient.Credentials.Key);
                tableClient = new TableClient(cloudTable.Uri, cloudTable.Name, keyCredential, options);
            }
            else // IsAnonymous
            {
                tableClient = new TableClient(cloudTable.Uri, options);
            }

            return tableClient;
        }
    }
}
