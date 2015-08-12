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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Management.BackupServices.Models;
using System;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    public class AzureBackupVaultContextObject
    {
        /// <summary>
        /// ResourceGroupName of the azurebackup object
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// ResourceName of the azurebackup object
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// ResourceName of the azurebackup object
        /// </summary>
        public string Location { get; set; }

        public AzureBackupVaultContextObject() { }

        public AzureBackupVaultContextObject(string resourceGroupName, string resourceName, string locationName)
        {
            ResourceGroupName = resourceGroupName;
            ResourceName = resourceName;
            Location = locationName;
        }

        public AzureBackupVaultContextObject(AzurePSBackupVault vault)
            : this(vault.ResourceGroupName, vault.Name, vault.Region) { }
    }

    /// <summary>
    /// This class encapsulates all the properties of the container object 
    /// that are needed by higher level objects (data source, recovery point etc). 
    /// </summary>
    public class AzureBackupContainerContextObject : AzureBackupVaultContextObject
    {
        /// <summary>
        /// Type of the Azure Backup container
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        /// Unique name of the Azure Backup Container
        /// </summary>
        public string ContainerUniqueName { get; set; }

        public AzureBackupContainerContextObject()
            : base()
        {
        }

        public AzureBackupContainerContextObject(AzurePSBackupVault vault, MarsContainerResponse marsContainerResponse)
            : base(vault)
        {
            ContainerType = ContainerHelpers.GetContainerType(marsContainerResponse.Properties.CustomerType).ToString();
            //ContainerUniqueName = marsContainerResponse.UniqueName;
        }

        public AzureBackupContainerContextObject(AzureBackupContainerContextObject azureBackupContainerContextObject)
            : base(azureBackupContainerContextObject.ResourceGroupName, azureBackupContainerContextObject.ResourceName, azureBackupContainerContextObject.Location)
        {
            ContainerType = azureBackupContainerContextObject.ContainerType;
            ContainerUniqueName = azureBackupContainerContextObject.ContainerUniqueName;
        }
        public AzureBackupContainerContextObject(AzureBackupContainer azureBackupContainer)
            : base(azureBackupContainer.ResourceGroupName, azureBackupContainer.ResourceName, azureBackupContainer.Location)
        {
            ContainerType = azureBackupContainer.ContainerType;
            ContainerUniqueName = azureBackupContainer.ContainerUniqueName;
        }

        public AzureBackupContainerContextObject(AzurePSBackupVault vault, CSMContainerResponse containerInfo)
            : base(vault.ResourceGroupName, vault.Name, vault.Region)
        {
            ContainerType = ContainerHelpers.GetTypeForManagedContainer(containerInfo.Properties.ContainerType).ToString();
            ContainerUniqueName = containerInfo.Name;
        }
    }

    public class AzureBackupItemContextObject : AzureBackupContainerContextObject
    {
        /// <summary>
        /// DataSourceName of Azure Backup Item
        /// </summary>
        public string ItemName { get; set; }

        public AzureBackupItemContextObject()
            : base()
        {
        }

        public AzureBackupItemContextObject(AzureBackupItemContextObject azureBackupItemContextObject)
            : base(azureBackupItemContextObject)
        {
            ItemName = azureBackupItemContextObject.ItemName;
        }

        public AzureBackupItemContextObject(CSMProtectedItemResponse item, AzureBackupContainer azureBackupContainer)
            : base(azureBackupContainer)
        {
            ItemName = item.Name;
        }

        public AzureBackupItemContextObject(CSMItemResponse item, AzureBackupContainer azureBackupContainer)
            : base(azureBackupContainer)
        {
            ItemName = item.Name;
        }
    }
}
