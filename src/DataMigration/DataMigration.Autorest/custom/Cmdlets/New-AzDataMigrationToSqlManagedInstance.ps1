# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Create a new database migration to a given SQL Managed Instance.
#>
function New-AzDataMigrationToSqlManagedInstance 
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Models.Api20250630.IDatabaseMigrationSqlMi')]
    [CmdletBinding(PositionalBinding = $false, SupportsShouldProcess = $true)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Create a new database migration to a given SQL Managed Instance.')]

    param(
        [Parameter(Mandatory, HelpMessage = "Name of the target SQL Managed Instance.")]
        [string]${ManagedInstanceName},

        [Parameter(Mandatory, HelpMessage = "Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.")]
        [string]${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage = "The name of the target database.")]
        [string]${TargetDbName},

        [Parameter(HelpMessage = "Subscription ID that identifies an Azure subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [string]$SubscriptionId = (Get-AzContext).Subscription.Id,

        [Parameter(HelpMessage = "Storage Account Key.")]
        [string]${AzureBlobAccountKey},

        [Parameter(HelpMessage = "Authentication type used for accessing Azure Blob Storage.")]
        [ValidateSet("AccountKey", "ManagedIdentity")]
        [string]${AzureBlobAuthType},

        [Parameter(HelpMessage = "Blob container name where backups are stored.")]
        [string]${AzureBlobContainerName},

        [Parameter(HelpMessage = "Type of managed service identity.")]
        [ValidateSet("SystemAssigned", "UserAssigned")]
        [string]${AzureBlobIdentityType},

        [Parameter(HelpMessage = "Resource Id of the storage account where backups are stored.")]
        [string]${AzureBlobStorageAccountResourceId},

        [Parameter(HelpMessage = "Password for username to access file share location.")]
        [SecureString]${FileSharePassword},

        [Parameter(HelpMessage = "Location as SMB share or local drive where backups are placed.")]
        [string]${FileSharePath},

        [Parameter(HelpMessage = "Username to access the file share location for backups.")]
        [string]${FileShareUsername},

        [Parameter(HelpMessage = "The set of user assigned identities associated with the resource.")]
        [string[]]${AzureBlobUserAssignedIdentity},

        [Parameter(HelpMessage = "Resource type.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ResourceType]${Kind},

        [Parameter(HelpMessage = "Resource Id of the Migration Service.")]
        [string]${MigrationService},

        [Parameter(HelpMessage = "Offline migration.")]
        [switch]${Offline},

        [Parameter(HelpMessage = "Last backup name for offline migration. This is optional for migrations from file share. If it is not provided, then the service will determine the last backup file name based on latest backup files present in file share.")]
        [string]${OfflineConfigurationLastBackupName},

        [Parameter(HelpMessage = "Resource Id of the target resource.")]
        [string]${Scope},

        [Parameter(HelpMessage = "Name of the source database.")]
        [string]${SourceDatabaseName},

        [Parameter(HelpMessage = "Authentication type.")]
        [string]${SourceSqlConnectionAuthentication},

        [Parameter(HelpMessage = "Data source.")]
        [string]${SourceSqlConnectionDataSource},

        [Parameter(HelpMessage = "Whether to encrypt connection or not.")]
        [switch]${SourceSqlConnectionEncryptConnection},

        [Parameter(HelpMessage = "Password to connect to source SQL.")]
        [SecureString]${SourceSqlConnectionPassword},

        [Parameter(HelpMessage = "Whether to trust server certificate or not.")]
        [switch]${SourceSqlConnectionTrustServerCertificate},

        [Parameter(HelpMessage = "User name to connect to source SQL.")]
        [string]${SourceSqlConnectionUserName},

        [Parameter(HelpMessage = "Storage Account Key.")]
        [string]${StorageAccountKey},

        [Parameter(HelpMessage = "Resource Id of the storage account copying backups.")]
        [string]${StorageAccountResourceId},

        [Parameter(HelpMessage = "Database collation to be used for the target database.")]
        [string]${TargetDatabaseCollation},

        [Parameter(HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [Alias("AzureRMContext", "AzureCredential")]
        [System.Management.Automation.PSObject]$DefaultProfile,

        [Parameter(HelpMessage = "Run the command as a job")]
        [switch]$AsJob,

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [switch]$NoWait,

        [Parameter(HelpMessage = "Returns true when the command succeeds")]
        [switch]$PassThru
    )

    process {
        if($PSBoundParameters.ContainsKey("AzureBlobUserAssignedIdentity"))
        {
            $IdentityUserAssignedIdentity = @{}
            $identities = $PSBoundParameters["AzureBlobUserAssignedIdentity"]
            foreach ($identity in $identities) {
                $IdentityUserAssignedIdentity[$identity] = @{}
            }
            $PSBoundParameters["IdentityUserAssignedIdentity"] = $IdentityUserAssignedIdentity
            $null = $PSBoundParameters.Remove("AzureBlobUserAssignedIdentity")
        }

        Az.DataMigration.Internal\New-AzDataMigrationToSqlManagedInstance @PSBoundParameters
    }
}
