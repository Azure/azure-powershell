### Example 1: Grant Permissions for Azure Disks
```powershell
PS C:\> Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG"" -VaultName "Vaultname"" -PermissionsScope "ResourceGroup"

```
The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Rresource Group" scope of the disk.



### Example 2: Grant Permissions for Azure Blobs
```powershell
PS C:\> Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG"" -VaultName "Vaultname"" -PermissionsScope "Subscription"
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Subscription" scope of the blob.


### Example 3: Grant Permissions for Azure Database For PostgreSQL
```powershell
PS C:\> Set-AzDataProtectionMSIPermission -KeyVaultId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/Sqlrg/providers/Microsoft.KeyVault/vaults/testjeyvault"  -BackupInstance $instance -VaultResourceGroup "VaultRG"" -VaultName "Vaultname"" -PermissionsScope "Resource"

```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Rresource" scope of the  Azure Database For PostgreSQL.
It takes an additional KeyVaultId parameter to assign the necessary permissions to the backup vault on the keyvault.



