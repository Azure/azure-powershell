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

using Microsoft.Azure.Management.DataLake.Store.Models;
using System;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders.
    /// </summary>
    public class DataLakeStoreItem : FileStatusProperties
    {
        public DateTimeOffset LastWriteTime { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeStoreItem" /> class.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="optionalName">The optional name of the file or folder</param>
        /// <param name="optionalPath">The optional full path to the file or folder, excluding the file or folder name itself.</param>
        public DataLakeStoreItem(FileStatusProperties property, string optionalName = "", string optionalPath = "") :
            base(property.AccessTime, property.BlockSize, property.ChildrenNum, property.ExpirationTime, property.Group, property.Length, property.ModificationTime, property.Owner, string.IsNullOrEmpty(optionalName) ? property.PathSuffix : optionalName, property.Permission, property.Type)
        {
            // create two new properties
            try
            {
                this.LastWriteTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds((long)this.ModificationTime).ToLocalTime();
            }
            catch(ArgumentOutOfRangeException)
            {
                if(this.ModificationTime < 0)
                {
                    // set last write time to the min DateTime
                    this.LastWriteTime = DateTime.MinValue;
                }
                else
                {
                    this.LastWriteTime = DateTime.MaxValue;
                }
            }

            this.Name = property.PathSuffix;
            if(!string.IsNullOrEmpty(optionalPath))
            {
                this.Path = System.IO.Path.Combine(optionalPath, property.PathSuffix).Replace('\\', '/');
            }
        }
    }
}