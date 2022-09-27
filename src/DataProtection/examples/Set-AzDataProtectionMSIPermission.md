### Example 1: Grant Permissions for Azure Disks
```powershell
Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "ResourceGroup"

```

```output
Assigning Disk Backup Reader permission to the backup vault
Assigned Disk Backup Reader permission to the backup vault
Assigning Disk Snapshot Contributor permission to the backup vault
Assigned Disk Snapshot Contributor permission to the backup vault
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Resource Group" scope of the disk.


### Example 2: Grant Permissions for Azure Blobs
```powershell
Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "Subscription"
```

```output
Assigning Storage Account Backup Contributor permission to the backup vault
Assigned Storage Account Backup Contributor permission to the backup vault
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Subscription" scope of the blob.


### Example 3: Grant Permissions for Azure Database For PostgreSQL
```powershell
Set-AzDataProtectionMSIPermission -KeyVaultId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/Sqlrg/providers/Microsoft.KeyVault/vaults/testkeyvault"  -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "Resource"

```

```output
Confirm
Are you sure you want to perform this action?
Performing the operation "
                            1.'Allow All Azure services' under network connectivity in the Postgres Server
                            2.'Allow Trusted Azure services' under network connectivity in the Key vault" on target "KeyVault: oss-pstest-keyvault and PostgreSQLServer: oss-pstest-server".
[Y] Yes  [A] Yes to All  [N] No  [L] No to All  [S] Suspend  [?] Help (default is "Y"): A
Assigning Reader permission to the backup vault
Assigned Reader permission to the backup vault
Waiting for 60 seconds for roles to propogate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Resource" scope of the Azure Database For PostgreSQL.
It takes an additional KeyVaultId parameter to assign the necessary permissions to the backup vault on the keyvault.
