### Example 1: Get all backup policies in a recovery services vault
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault"
$pol
```


```output
ETag Id                                                                                                                                                                           Location Name                Type
---- --                                                                                                                                                                           -------- ----                ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/policy1                          policy1             Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/HourlyLogBackup                  HourlyLogBackup     Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/DefaultPolicy                    DefaultPolicy       Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/policy2                          policy2             Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/testPolicy                       testPolicy          Microsoft.RecoveryServices/vaults/backupPolicies
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/EnhancedPolicy                   EnhancedPolicy      Microsoft.RecoveryServices/vaults/backupPolicies
```


Gets all the backup policies in the specified vault in the specified resource group.

### Example 2: Get info for a specific backup policy
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault" -Name "DefaultPolicy"
$pol 
```

```output
ETag Id                                                                                                                                                                           Location Name       Type
---- --                                                                                                                                                                           -------- ----       ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.RecoveryServices/vaults/myvault/backupPolicies/testPolicy                       testPolicy Microsoft.RecoveryServices/vaults/backupPolicies

```

Gets info for a specific backup policy by its name in the specified vault in the specified resource group.