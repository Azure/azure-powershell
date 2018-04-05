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
    /// The object that is used to manage permissions for files and folders. Moved the members of it's parent class to the current class. 
    /// This is an exposed model to public so it should be independent of SDK models. We will never be able to remove members. In future if we have a different sdk then
    /// we just need to map the SDK model to this model.
    /// </summary>
    public class DataLakeStoreItem
    {
        public DateTimeOffset LastWriteTime { get; }
        public DateTimeOffset LastAccessTime { get; }

        public DateTimeOffset? Expiration { get;}

        public string Name { get; internal set; }

        public string Path { get; internal set; }

        public long? AccessTime { get; }

        /// <summary>Gets the block size for the file.</summary>
        public long? BlockSize { get; }

        /// <summary>Gets the number of children in the directory.</summary>
        public long? ChildrenNum { get; }

        /// <summary>
        /// Gets the expiration time, if any, as ticks since the epoch. If the
        /// value is 0 or DateTime.MaxValue there is no expiration.
        /// </summary>
        public long? ExpirationTime { get; }

        /// <summary>Gets the group owner.</summary>
        public string Group { get; }

        /// <summary>Gets the number of bytes in a file.</summary>
        public long? Length { get; }

        /// <summary>Gets the modification time as ticks since the epoch.</summary>
        public long? ModificationTime { get; }

        /// <summary>Gets the user who is the owner.</summary>
        public string Owner { get; }

        /// <summary>Gets the path suffix.</summary>
        public string PathSuffix { get; }

        /// <summary>Gets the permission represented as an string.</summary>
        public string Permission { get; }

        /// <summary>
        /// Gets the type of the path object. Possible values include: 'FILE',
        /// 'DIRECTORY'
        /// </summary>
        public DataLakeStoreEnums.FileType? Type { get; }

        /// <summary>Gets flag to indicate if extended acls are enabled</summary>
        public bool? AclBit { get; }

        private long ToUnixTimeStampMs(DateTime dt)
        {
            // Assumes that datetime is UTC
            return (long)(dt - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public DataLakeStoreItem(DirectoryEntry entry)
        {
            Length = entry.Length;
            Path = entry.FullName;
            PathSuffix = System.IO.Path.GetFileName(entry.FullName);
            Name = string.IsNullOrEmpty(entry.Name) ? PathSuffix : entry.Name;
            if (entry.LastAccessTime.HasValue)
            {
                LastAccessTime = entry.LastAccessTime.Value;
                AccessTime = ToUnixTimeStampMs(entry.LastAccessTime.Value);
            }
            if (entry.LastModifiedTime.HasValue)
            {
                LastWriteTime = entry.LastModifiedTime.Value;
                ModificationTime = ToUnixTimeStampMs(entry.LastModifiedTime.Value);
            }
            if (entry.ExpiryTime.HasValue)
            {
                Expiration = entry.ExpiryTime.Value;
                ExpirationTime = ToUnixTimeStampMs(entry.ExpiryTime.Value);
            }
            Group = entry.Group;
            BlockSize = 256 * 1024 * 1024;
            Owner = entry.User;
            Permission = entry.Permission;
            AclBit = entry.HasAcl;
            Type = entry.Type==DirectoryEntryType.DIRECTORY?DataLakeStoreEnums.FileType.DIRECTORY : DataLakeStoreEnums.FileType.FILE;
        }
        
    }
}