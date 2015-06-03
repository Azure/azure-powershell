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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
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

        public AzureBackupVaultContextObject()
        {
        }

        public AzureBackupVaultContextObject(string resourceGroupName, string resourceName)
        {
            ResourceGroupName = resourceGroupName;
            ResourceName = resourceName;
        }
    }

    public class AzureBackupContainerContextObject : AzureBackupVaultContextObject
    {
        /// <summary>
        /// Type of the Azure Backup container
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        /// Name of the Azure Backup container
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Id of the Azure Backup Container
        /// </summary>
        public string ContainerId { get; set; }

        public AzureBackupContainerContextObject()
            : base()
        {
        }

        public AzureBackupContainerContextObject(AzureBackupContainerContextObject azureBackupContainerContextObject)
            : base(azureBackupContainerContextObject.ResourceGroupName, azureBackupContainerContextObject.ResourceName)
        {
            ContainerType = azureBackupContainerContextObject.ContainerType;
            ContainerName = azureBackupContainerContextObject.ContainerName;
            ContainerId = azureBackupContainerContextObject.ContainerId;
        }
    }

    public class AzureBackupItemContextObject : AzureBackupContainerContextObject
    {
        /// <summary>
        /// DataSourceId of Azure Backup Item
        /// </summary>
        public string DataSourceId { get; set; }

        /// <summary>
        /// DataSourceId of Azure Backup Item
        /// </summary>
        public string DataSourceType { get; set; }

        public AzureBackupItemContextObject()
            : base()
        {
        }

        public AzureBackupItemContextObject(AzureBackupItemContextObject azureBackupItemContextObject)
            : base(azureBackupItemContextObject)
        {
            DataSourceId = azureBackupItemContextObject.DataSourceId;
            DataSourceType = azureBackupItemContextObject.DataSourceType;
        }
    }
}
