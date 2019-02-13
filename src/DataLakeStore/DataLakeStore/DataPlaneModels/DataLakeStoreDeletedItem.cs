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

using System;
using Microsoft.Azure.DataLake.Store;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// Object returned by Get-AzDataLakeStoreDeletedItem
    /// </summary>
    public class DataLakeStoreDeletedItem
    {
        public string TrashDirPath { get; }
        public string OriginalPath { get; }

        /// <summary>
        /// Gets the type of the path object. Possible values include: 'FILE', 'DIRECTORY'
        /// </summary>
        public DataLakeStoreEnums.FileType? Type { get; }

        public DateTime? CreationTime { get; }

        private long ToUnixTimeStampMs(DateTime dt)
        {
            // Assumes that datetime is UTC
            return (long)(dt - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public DataLakeStoreDeletedItem(TrashEntry entry)
        {
            TrashDirPath = entry.TrashDirPath;
            OriginalPath = entry.OriginalPath;
            Type = entry.Type == TrashEntryType.DIRECTORY ? DataLakeStoreEnums.FileType.DIRECTORY : DataLakeStoreEnums.FileType.FILE;
            CreationTime = entry.CreationTime;
        }
    }
}