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

namespace Microsoft.WindowsAzure.Commands.Storage.Table
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// base class for table cmdlet
    /// </summary>
    public class StorageCloudTableCmdletBase : StorageCloudCmdletBase<IStorageTableManagement>
    {
        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// create table storage service management channel.
        /// </summary>
        /// <returns>IStorageTableManagement object</returns>
        protected override IStorageTableManagement CreateChannel()
        {
            //Init storage table management channel
            if (Channel == null || !ShareChannel)
            {
                Channel = new StorageTableManagement(GetCmdletStorageContext());
            }

            return Channel;
        }

        /// <summary>
        /// Table request options
        /// </summary>
        public TableRequestOptions RequestOptions
        {
            get
            {
                return (TableRequestOptions)GetTableRequestOptions();
            }
        }

        protected bool TableIsEmpty(CloudTable table)
        {
            try
            {
                TableQuery<DynamicTableEntity> projectionQuery = new TableQuery<DynamicTableEntity>().Select(new string[] { "PartitionKey" });
                projectionQuery.TakeCount = 1;
                //https://ahmet.im/blog/azure-listblobssegmentedasync-listcontainerssegmentedasync-how-to/
                TableContinuationToken continuationToken = null;
                var results = new List<DynamicTableEntity>();
                do
                {
                    var response = table.ExecuteQuerySegmentedAsync(projectionQuery, continuationToken).Result;
                    continuationToken = response.ContinuationToken;
                    results.AddRange(response.Results);
                } while (continuationToken != null);
                using (IEnumerator<DynamicTableEntity> result = results.GetEnumerator())
                {
                    return !(result.MoveNext() && result.Current != null);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
