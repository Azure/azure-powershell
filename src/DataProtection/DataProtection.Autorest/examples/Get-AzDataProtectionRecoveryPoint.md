### Example 1: Get all recovery points of a given backup instance
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name
```

```output
Name                             Type
----                             ----
aded40a562134f97b732f30d0b486fef Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
f458438d5ebb4098adbf67e9655cb624 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
515ba70e49d34b2bbff033dcc08593fe Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
e61293fdd1064fbdb4f42b7f5927a927 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
aecc362b85484f4eb905bb05ef445e3e Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
dc814d61a9624c36a1f9d635bc0b80f0 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
```

This command lists all available recovery points of a given backup instance

### Example 2: Get recovery point with given recovery point id.
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name -Id 892e5c5014dc4a96807d22924f5745c9
```

```output
Name                             Type
----                             ----
892e5c5014dc4a96807d22924f5745c9 Microsoft.DataProtection/backupVaults/backupInstances/recoveryPoints
```

This command returns a recovery point with given id.

### Example 3: Get all recovery points of a given backup instance from secondary region
```powershell
$instance = $instance = Search-AzDataProtectionBackupInstanceInAzGraph -DatasourceType AzureDatabaseForPostgreSQL -Subscription "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroup sarath-rg -Vault sarath-vault
$recoveryPoints = Get-AzDataProtectionRecoveryPoint -SubscriptionId "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[2].Name -UseSecondaryRegion
```

```output
Name                            
----                            
aded40a562134f97b732f30d0b486fef
aecc362b85484f4eb905bb05ef445e3e
dc814d61a9624c36a1f9d635bc0b80f0
```

This command lists all recovery points of a given backup instance from secondary region. One of these recovery points can be used to trigger cross region restore to secondary region.