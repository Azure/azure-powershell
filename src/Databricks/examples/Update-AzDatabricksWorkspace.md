### Example 1: Updates the tags of a Databricks workspace.
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t1 | Update-AzDatabricksWorkspace -Tag @{"key"="value"}
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t1 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t1
```

This command updates the tags of a Databricks workspace.

### Example 2: Enable encryption on a Databricks workspace.
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t2 -PrepareEncryption
$updWsp = Get-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t2
Set-AzKeyVaultAccessPolicy -VaultName azps-keyvault -ObjectId $updWsp.StorageAccountIdentityPrincipalId -PermissionsToKeys wrapkey,unwrapkey,get
Update-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t2 -EncryptionKeySource 'Microsoft.KeyVault' -EncryptionKeyVaultUri https://azps-keyvault.vault.azure.net/ -EncryptionKeyName azps-k1 -EncryptionKeyVersion a563a8021cba47109d93bd6d690621a7
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
```

Enabling encryption on a Databricks workspace takes three steps:
1.Please make sure that KeyVault has Purge protection enabled.
2.Update the workspace with `-PrepareEncryption` (if it was not created so).
3.Find `StorageAccountIdentityPrincipalId` in the output of the last step and grant key permissions to the principal.
4.Update the workspace again to fill in information about the encryption key:
   - `-EncryptionKeySource`
   - `-EncryptionKeyVaultUri`
   - `-EncryptionKeyName`
   - `-EncryptionKeyVersion`

### Example 3: Disable encryption on a Databricks workspace.
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t3 -EncryptionKeySource 'Default'
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t3 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t3
```

To disable encryption, simply set `-EncryptionKeySource` to `'Default'`.

### Example 4: Update NsgRule of the Databricks workspace.
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName azps_test_gp_db -Name azps-databricks-workspace-t2 -RequiredNsgRule 'AllRules'
```

```output
Name                         ResourceGroupName Location Managed Resource Group ID
----                         ----------------- -------- -------------------------
azps-databricks-workspace-t2 azps_test_gp_db   eastus   /subscriptions/{subId}/resourceGroups/azps_test_gp_kv_t2
```

This command updates NsgRule of the Databricks workspace.