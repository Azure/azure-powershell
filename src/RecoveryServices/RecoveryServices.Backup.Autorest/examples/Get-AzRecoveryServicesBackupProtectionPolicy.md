### Example 1: Get all backup policies in a recovery services vault
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault"
$pol
```

```output
ETag Location Name
---- -------- ----
              HourlyLogBackup
              DefaultPolicy
              NewSQLPolicy
              SAPPolicy
              DailyPolicy-l6dtamab
              EnhancedPolicy
```

Gets all the backup policies in the specified vault in the specified resource group.

### Example 2: Get a backup policy by Name
```powershell
$pol = Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName "myresourcegroup" -VaultName "myvault" -Name "HourlyLogBackup"
 $pol | fl
```

```output
BackupManagementType          : AzureWorkload
ETag                          :
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupPolicies/HourlyLogBackup
Location                      :
Name                          : HourlyLogBackup
Property                      : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadProtectionPolicy
ProtectedItemsCount           : 3
ResourceGuardOperationRequest :
Tag                           : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                          : Microsoft.RecoveryServices/vaults/backupPolicies
```

Gets info for a specific backup policy by its name in the specified vault in the specified resource group.

### Example 3: Get all backup policies with given DatasourceType, PolicySubType and enabled Archive smart tiering
```powershell
$pol =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $ResourceGroupName -VaultName $VaultName -PolicySubType "Standard" -IsArchiveSmartTieringEnabled $true -DatasourceType MSSQL
 $pol
```

```output
ETag Location Name
---- -------- ----
              NewSQLPolicy
```

List all backup policies in the recovery services vault with DatasourceType MSSQL, PolicySubType Standard, and smart tiering enabled.
