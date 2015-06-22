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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Represents Azure Backup vault
    /// </summary>
    public class AzurePSBackupVault
    {
        public string ResourceId { get; set; }

        public string Name { get; set; }

        public string ResourceGroupName { get; set; }

        public string Region { get; set; }

        // public Hashtable[] Tags { get; protected set; }

        public string Sku { get; set; }

        public string Storage { get; set; }

        public AzurePSBackupVault() : base() { }

        public AzurePSBackupVault(string resourceGroupName, string resourceName, string region)
        {
            ResourceGroupName = resourceGroupName;
            Name = resourceName;
            Region = region;
        }

        internal void Validate()
        {
            if (String.IsNullOrEmpty(ResourceGroupName))
            {
                throw new ArgumentException("AzureBackupVault.ResourceGroupName");
            }

            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("AzureBackupVault.Name");
            }
        }
    }
}
