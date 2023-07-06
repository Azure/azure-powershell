### Example 1: Modify Protection AzureVM
```powershell
$pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -PolicyName EnhancedBackupTesting
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Enable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -PolicyId $pol.Id 
```

```output


```
The first command fetches the policy with which item needs to be protected. The second command fetches the protected item for which protection needs to be modified. The third command modifies the protection on the fetched item.


### Example 2: Configure Protection AzureVM
```powershell
$pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -PolicyName EnhancedBackupTesting
Enable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -VMName arohijain-vm -PolicyId $pol.Id
```

```output

```

The first command fetches the policy with which virtual machine needs to be protected. The second command configures the protection on the virtual machine.

### Example 3: Protection along with Disk settings
```powershell
$pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -PolicyName EnhancedBackupTesting
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match "arohijain-vm"}
Enable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName arohijain-rg -VaultName arohijain-backupvault -Item $item -PolicyId $pol.Id -InclusionDisksList @("1","2")
```

```output

```

The first command fetches the policy with which virtual machine needs to be protected. The second command enables the protection along with setting the disk exclusion settings.

### Example 4: Modify Protection MSSQL
```powershell
$pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName hiagarg -VaultName hiagaVault -PolicyName hiagaSQLPolicy
$item = Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName hiagarg -VaultName hiagaVault -SubscriptionId "38304e13-357e-405e-9e9a-220351dcce8c" -Filter "backupManagementType eq 'AzureWorkload' and WorkloadType -eq 'MSSQL'" | Where-Object { $_.Name -match "SQLDataBase;MSSQLSERVER;model_restored_5_31_2023_1254"}
Enable-AzRecoveryServicesProtection -DatasourceType MSSQL -ResourceGroupName hiagarg -VaultName hiagaVault -Item $item -PolicyId $pol.Id 
```

```output

```

The first command fetches the policy with which item needs to be protected. The second command fetches the protected item for which protection needs to be modified. The third command modifies the protection on the fetched item.


