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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders.
    /// </summary>
    public class DataLakeStoreItem : FileStatusProperties
    {
        public DateTimeOffset LastWriteTime { get; set; }
        public string Name { get; set; }
        public DataLakeStoreItem(FileStatusProperties property)
        {
            // copy over all initial properties
            this.PathSuffix = property.PathSuffix;
            this.BlockSize = property.BlockSize;
            this.ChildrenNum = property.ChildrenNum;
            this.FileId = property.FileId;
            this.Group = property.Group;
            this.Length = property.Length;
            this.ModificationTime = property.ModificationTime;
            this.Owner = property.Owner;
            this.Permission = property.Permission;
            this.AccessTime = property.AccessTime;
            this.Replication = property.Replication;
            this.Type = property.Type;

            // create two new properties
            this.LastWriteTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(this.ModificationTime).ToLocalTime();
            this.Name = this.PathSuffix;
        }
    }
}