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

using Microsoft.Azure.Commands.AzureBackup.Properties;
using System;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Represents Azure Backup vault
    /// </summary>
    public class AzureRMBackupVault
    {
        public string ResourceId { get; set; }

        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string Region { get; set; }

        // TODO: Add support for tags
        //public Hashtable[] Tags { get; set; }

        public string Storage { get; set; }

        public AzureRMBackupVault() : base() { }

        public AzureRMBackupVault(string resourceGroupName, string resourceName, string region)
        {
            ResourceGroupName = resourceGroupName;
            Name = resourceName;
            Region = region;
        }

        internal void Validate()
        {
            if (String.IsNullOrEmpty(ResourceGroupName))
            {
                throw new ArgumentException(Resources.BackupVaultRGNameNullOrEmpty);
            }

            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentException(Resources.BackupVaultResNameNullOrEmpty);
            }
        }
    }
}
