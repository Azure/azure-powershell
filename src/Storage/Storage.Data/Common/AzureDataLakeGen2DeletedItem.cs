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
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using System;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureDataLakeGen2DeletedItem : AzureStorageBase
    {
        /// <summary>
        /// Deleted DatalakeGen2 Item
        /// </summary>
        public PathDeletedItem DeletedItem { get; set; }

        /// <summary>
        /// DatalakeGen2 FileSystem Name
        /// </summary>
        public string FileSystemName { get; set; }

        /// <summary>
        /// The Path of the Deleted item
        /// </summary>
        [Ps1Xml(Label = "Path", Target = ViewControl.Table, Position = 0, TableColumnWidth = 20)]
        public string Path { get; set; }

        /// <summary>
        /// Datalake Deleted Item  DeletionId 
        /// </summary>
        public string DeletionId { get; set; }

        /// <summary>
        /// When the path was deleted. 
        /// </summary>
        public DateTimeOffset? DeletedOn { get; set; }

        /// <summary>
        /// The number of days left before the soft deleted path will be permanently deleted.
        /// </summary>
        public int? RemainingRetentionDays { get; set; }

        /// <summary>
        /// Datalake Item list  ContinuationToken
        /// </summary>
        public string ContinuationToken { get; set; }

        /// <summary>
        /// Azure DataLakeGen2 Deleted Item constructor
        /// </summary>
        /// <param name="deletedItem">Deleted Item</param>
        /// <param name="fileSystem">DataLakeFileSystemClient</param>
        public AzureDataLakeGen2DeletedItem(PathDeletedItem deletedItem, DataLakeFileSystemClient fileSystem)
        {
            this.Name = deletedItem.Path;
            this.Path = deletedItem.Path;
            this.DeletedItem = deletedItem;
            this.DeletedOn = deletedItem.DeletedOn;
            this.DeletionId = deletedItem.DeletionId;
            this.RemainingRetentionDays = deletedItem.RemainingRetentionDays;
            this.FileSystemName = fileSystem.Name;
        }
    }
}
