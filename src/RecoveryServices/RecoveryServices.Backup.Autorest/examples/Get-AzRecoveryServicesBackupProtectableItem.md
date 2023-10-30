### Example 1: List protectable items for datasource type MSSQL
```powershell
$proItems = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType "MSSQL"
$proItems
```

```output
ETag Location Name                           AutoProtectionPolicy
---- -------- ----                           --------------------
              sqlinstance;mssqlserver
              sqldatabase;mssqlserver;master
              sqldatabase;mssqlserver;model
```

This command is used to fetch protectable items for DatasourceType MSSQL which can be protected by a recovery services vault.

### Example 2: Filter protectable items based on Container, Name, ServerName, ItemType
```powershell
$proItems = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -ItemType SQLInstance -ServerName $serverName -Container $container -Name $protectableItemName
$proItems[0] | fl
```

```output
AutoProtectionPolicy :
NodesList            :
BackupManagementType : AzureWorkload
ETag                 :
FriendlyName         : MSSQLSERVER
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupFabrics/Azure/protectionContainers/vmappcontainer;compute;hiagarg;sql-vm1/protectableItems/sqlinstance;mssqlserver
Location             :
Name                 : sqlinstance;mssqlserver
Property             : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSqlInstanceProtectableItem
ProtectableItemType  : SQLInstance
ProtectionState      : NotProtected
Tag                  : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                 : Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectableItems
WorkloadType         : SQL
```

The above command shows an example on how to filter protectable items based on Container, Name, ServerName, ItemType.
