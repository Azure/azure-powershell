### Example 1: RemoveRecoveryPoints - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RemoveRecoveryPoints -NoWait
```

```output


```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item with NoWait.

### Example 2: RetainRecoveryPointsForever - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RetainRecoveryPointsForever
```

```output

```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item.

### Example 3: RetainRecoveryPointsAsPerPolicy - AzureVM
```powershell
$item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -RetainRecoveryPointsAsPerPolicy
```

```output

```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item.

### Example 4: RemoveRecoveryPoints - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RemoveRecoveryPoints
```

```output


```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item.

### Example 5: RetainRecoveryPointsForever - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RetainRecoveryPointsForever 
```

```output

```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item.

### Example 6: RetainRecoveryPointsAsPerPolicy - MSSQL
```powershell
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Disable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -RetainRecoveryPointsAsPerPolicy
```

```output

```

The first command fetches the protected item for which protection needs to be disabled. The second command disables the protection on the fetched item.
