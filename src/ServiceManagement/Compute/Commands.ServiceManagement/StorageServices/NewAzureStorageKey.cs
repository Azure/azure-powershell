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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Regenerates storage keys with the key-type parameter specifying 
    /// which key to regenerate. Should have the storage account resource specified.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorageKey"), OutputType(typeof(StorageServiceKeyOperationContext))]
    public class NewAzureStorageKeyCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Key to regenerate. Primary | Secondary")]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string KeyType
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string StorageAccountName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            var regenerateKeys = new StorageAccountRegenerateKeysParameters
            {
                Name = this.StorageAccountName,
                KeyType = string.IsNullOrEmpty(this.KeyType) ? StorageKeyType.Primary : (StorageKeyType)Enum.Parse(typeof(StorageKeyType), this.KeyType, true)
            };

            ExecuteClientActionNewSM(
                regenerateKeys,
                this.CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.RegenerateKeys(regenerateKeys),
                (s, r) =>
                {
                    return new StorageServiceKeyOperationContext
                    {
                        StorageAccountName = this.StorageAccountName,
                        Primary = r.PrimaryKey,
                        Secondary = r.SecondaryKey,
                        OperationDescription = this.CommandRuntime.ToString(),
                        OperationId = s.Id,
                        OperationStatus = s.Status.ToString()
                    };
                });
        }
    }
}
