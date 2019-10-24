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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Adapters;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSShare //: CloudFileShare
    {
        public PSShare(StorageModels.FileShare share)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(share.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(share.Id);
            this.Id = share.Id;
            this.Name = share.Name;
            this.Type = share.Type;
            this.Metadata = share.Metadata;
            this.Etag = share.Etag;
            this.LastModifiedTime = share.LastModifiedTime;
            this.QuotaGiB = share.ShareQuota;
        }

        public PSShare(FileShareItem share)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(share.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(share.Id);
            this.Id = share.Id;
            this.Name = share.Name;
            this.Type = share.Type;
            this.Metadata = share.Metadata;
            this.Etag = share.Etag;
            this.LastModifiedTime = share.LastModifiedTime;
            this.QuotaGiB = share.ShareQuota;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        [Ps1Xml(Label = "Etag", Target = ViewControl.List, Position = 3)]
        public string Etag { get; set; }

        [Ps1Xml(Label = "QuotaGiB", Target = ViewControl.List, Position = 4)]
        public int? QuotaGiB { get; set; }

        public IDictionary<string, string> Metadata { get; set; }       

        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, ScriptBlock = "$_.LastModifiedTime.ToString(\"u\")", Position = 5)]
        public DateTime? LastModifiedTime { get; set; }

      
        public static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }

        public static string ParseStorageAccountNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[7];
            }

            return null;
        }

        public static string ParseStorageContainerNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[11];
            }

            return null;
        }

        /// <summary>
        /// Return a string representation of this storage account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow listing storage contents through piping
            return null;
        }
    }   
}
