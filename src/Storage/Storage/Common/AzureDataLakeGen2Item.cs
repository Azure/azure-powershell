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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureDataLakeGen2Item : AzureStorageBase
    {
        /// <summary>
        /// File Properties
        /// </summary>
        public DataLakeFileClient File { get; set; }

        /// <summary>
        /// Directory Properties
        /// </summary>
        public DataLakeDirectoryClient Directory { get; private set; }

        /// <summary>
        /// The Path of the item
        /// </summary>
        [Ps1Xml(Label = "Path", Target = ViewControl.Table, Position = 0, TableColumnWidth = 20)]
        public string Path { get; set; }

        /// <summary>
        /// CloudBlobDirectory object
        /// </summary>
        [Ps1Xml(Label = "IsDirectory", Target = ViewControl.Table, Position = 1, TableColumnWidth = 12)]
        public bool IsDirectory { get; private set; }

        /// <summary>
        /// Datalake Gen2 Item path Permissions
        /// </summary>
        [Ps1Xml(Label = "Permissions", Target = ViewControl.Table, ScriptBlock = "$_.Permissions.ToSymbolicPermissions()", Position = 5, TableColumnWidth = 12)]
        public PathPermissions Permissions { get; set; }

        /// <summary>
        /// Datalake Gen2 Item ACL
        /// </summary>
        public PSPathAccessControlEntry[] ACL { get; set; }

        /// <summary>
        /// Datalake Item PathProperties 
        /// </summary>
        public PathProperties Properties { get; private set; }

        /// <summary>
        /// Datalake Item PathAccessControl 
        /// </summary>
        public PathAccessControl AccessControl { get; private set; }

        /// <summary>
        /// Datalake Item list  ContinuationToken
        /// </summary>
        public string ContinuationToken { get; set; }

        /// <summary>
        /// Blob length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, ScriptBlock = "if ($_.IsDirectory -eq $false) {$_.Length}", Position = 2, TableColumnWidth = 15)]
        public long Length { get; private set; }

        /// <summary>
        /// Blob content type
        /// </summary>
        [Ps1Xml(Label = "ContentType", Target = ViewControl.Table, Position = 3, TableColumnWidth = 30)]
        public string ContentType { get; private set; }

        /// <summary>
        /// Blob last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 4, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// The owner of the item
        /// </summary>
        [Ps1Xml(Label = "Owner", Target = ViewControl.Table, Position = 6, TableColumnWidth = 10)]
        public string Owner { get; set; }

        /// <summary>
        /// The Group of the item
        /// </summary>
        [Ps1Xml(Label = "Group", Target = ViewControl.Table, Position = 7, TableColumnWidth = 10)]
        public string Group { get; set; }

        /// <summary>
        /// The PathItem properties of the item, the property only exist if the item is listout
        /// </summary>
        public PathItem ListPathItem { get; set; }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="fileClient">CloudBlockBlob blob object</param>
        public AzureDataLakeGen2Item(DataLakeFileClient fileClient)
        {
            Name = fileClient.Name;
            Path = fileClient.Path;
            File = fileClient;
            IsDirectory = false;
            try
            {
                Properties = fileClient.GetProperties();
                Length = Properties.ContentLength;
                ContentType = Properties.ContentType;
                LastModified = Properties.LastModified;
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
            {
                // skip get file properties if don't have read permission
            }
            try
            {
                AccessControl = File.GetAccessControl();
                Permissions = AccessControl.Permissions;
                ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(AccessControl.AccessControlList);
                Owner = AccessControl.Owner;
                Group = AccessControl.Group;
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
            {
                // skip get file ACL if don't have read permission
            }
        }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="directoryClient">Cloud blob Directory object</param>
        public AzureDataLakeGen2Item(DataLakeDirectoryClient directoryClient)
        {
            Name = directoryClient.Name;
            Path = directoryClient.Path;
            Directory = directoryClient;
            IsDirectory = true;
            if (directoryClient.Path != "/" || string.IsNullOrEmpty(directoryClient.Path)) //if root directory, GetProperties() will fail. Skip until this is fixed.
            {
                try
                {


                    Properties = directoryClient.GetProperties();
                    Length = Properties.ContentLength;
                    ContentType = Properties.ContentType;
                    LastModified = Properties.LastModified;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
                {
                    // skip get dir properties if don't have read permission
                }
            }

            try
            {

                AccessControl = directoryClient.GetAccessControl();
                Permissions = AccessControl.Permissions;
                ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(AccessControl.AccessControlList);
                Owner = AccessControl.Owner;
                Group = AccessControl.Group;
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
            {
                // skip get dir ACL if don't have read permission

            }
        }


        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="item">datalake gen2 listout item</param>
        /// <param name="fetchProperties"></param>
        /// <param name="fileSystem"></param>
        public AzureDataLakeGen2Item(PathItem item, DataLakeFileSystemClient fileSystem, bool fetchProperties = false)
        {
            this.Name = item.Name;
            this.Path = item.Name;
            this.ListPathItem = item;
            this.IsDirectory = item.IsDirectory is null ? false : item.IsDirectory.Value;
            DataLakePathClient pathclient = null;
            if (this.IsDirectory) // Directory
            {
                this.Directory = fileSystem.GetDirectoryClient(item.Name);
                pathclient = this.Directory;
            }
            else //File
            {
                this.File = fileSystem.GetFileClient(item.Name);
                pathclient = this.File;
            }

            this.Owner = item.Owner;
            this.Group = item.Group;
            this.Permissions = PathPermissions.ParseSymbolicPermissions(item.Permissions);
            this.LastModified = item.LastModified;
            this.Length = item.ContentLength is null ? 0 : item.ContentLength.Value;

            if (fetchProperties)
            {
                this.Properties = pathclient.GetProperties();
                this.AccessControl = pathclient.GetAccessControl();
                this.ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(this.AccessControl.AccessControlList);
                this.ContentType = Properties.ContentType;
            }
        }
    }
}
