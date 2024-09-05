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
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.Azure.Storage;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    // wrapper of EncryptionScope
    public class PSEncryptionScope
    {
        public PSEncryptionScope(StorageModels.EncryptionScope scope)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(scope.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(scope.Id);
            this.Id = scope.Id;
            this.Name = scope.Name;
            this.Type = scope.Type;
            this.LastModifiedTime = scope.LastModifiedTime;
            this.CreationTime = scope.CreationTime;
            this.Source = scope.Source;
            this.State = scope.State;
            this.KeyVaultProperties = scope.KeyVaultProperties is null ? null : new PSEncryptionScopeKeyVaultProperties(scope.KeyVaultProperties);
            this.RequireInfrastructureEncryption = scope.RequireInfrastructureEncryption;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Source { get; set; }

        public string State { get; set; }

        public PSEncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }

        public bool? RequireInfrastructureEncryption { get; set; }

        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, Position = 4)]
        public DateTime? LastModifiedTime { get; set; }

        public DateTime? CreationTime { get; set; }

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

    }

    //wrapper of EncryptionScopeKeyVaultProperties
    public class PSEncryptionScopeKeyVaultProperties
    {
        public PSEncryptionScopeKeyVaultProperties(StorageModels.EncryptionScopeKeyVaultProperties keyVaultProperties)
        {
            if (keyVaultProperties != null)
            {
                this.keyUri = keyVaultProperties.KeyUri;
            }
        }

        public string keyUri { get; set; }
    }

  
}
