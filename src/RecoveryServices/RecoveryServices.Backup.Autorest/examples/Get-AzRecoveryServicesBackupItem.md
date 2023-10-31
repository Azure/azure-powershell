### Example 1: Get backup items protected by recovery services vault
```powershell
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType AzureVM
$items
```

```output
ETag Location Name
---- -------- ----
              VM;iaasvmcontainerv2;hiagarg;hiagavm1
              VM;iaasvmcontainerv2;hiagarg;hiagavm2
              VM;iaasvmcontainerv2;hiagarg;hiagavm
```

This command fetches the backup items protected by a recovery services vault for DatasourceType AzureVM.

### Example 2: Get backup items for a particular container
```powershell
$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -Container $container
$items[0] | fl
```

```output
BackupManagementType             : AzureWorkload
BackupSetName                    :
ContainerName                    : VMAppContainer;Compute;hiagarg;sql-pstest-vm1
CreateMode                       :
DeferredDeleteTimeInUtc          :
DeferredDeleteTimeRemaining      :
ETag                             :
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupFabrics/Azure/protectionContainers/VMAppContainer;Compute;hiagarg;sql-pstest-vm1/protectedItems/SQLDataBase;MSSQLSERVER;model
IsArchiveEnabled                 : False
IsDeferredDeleteScheduleUpcoming :
IsRehydrate                      :
IsScheduledForDeferredDelete     :
LastRecoveryPoint                :
Location                         :
Name                             : SQLDataBase;MSSQLSERVER;model
PolicyId                         :
PolicyName                       :
Property                         : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSqlDatabaseProtectedItem
ProtectedItemType                : AzureVmWorkloadSQLDatabase
ResourceGuardOperationRequest    :
SoftDeleteRetentionPeriod        : 0
SourceResourceId                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.Compute/virtualMachines/sql-pstest-vm1
Tag                              : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                             : Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems
WorkloadType                     : SQLDataBase
```

The first command gets the backup container and second command fetches the backup items protected by a recovery services vault for DatasourceType MSSQL and belong to backup container $container.

### Example 3: Get backup items protected by a backup policy
```powershell
$policy =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -PolicySubType "Standard" -DatasourceType MSSQL | Where-Object { $_.Name -match "HourlyLogBackup"  }
$items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -Policy $policy
$items
```

```output
ETag Location Name
---- -------- ----
              SQLDataBase;mssqlserver;msdb
              SQLDataBase;MSSQLSERVER;mig-db1
              SQLDataBase;mssqlserver;model
```

The first command gets the backup policy and second command fetches the backup items protected by a recovery services vault with the policy.
