### Example 1: Updates the tags of a Databricks workspace
```powershell
$dbr = Get-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspaceopsc46
Update-AzDatabricksWorkspace -InputObject $dbr -Tag @{key="value"}
```

```output
Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command updates the tags of a Databricks workspace.

### Example 2: Enable encryption on a Databricks workspace
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -PrepareEncryption
Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -EncryptionKeySource 'Microsoft.KeyVault' -EncryptionKeyVaultUri https://keyvalult-j3kube.vault.azure.net/ -EncryptionKeyName key-p3bjsf -EncryptionKeyVersion 853999da89714fb4a1408681945135fd
```

```output
Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
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

### Example 3: Disable encryption on a Databricks workspace
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -EncryptionKeySource 'Default'
```

To disable encryption, simply set `-EncryptionKeySource` to `'Default'`.

### Example 4: Update NsgRule of the Databricks workspace
```powershell
Update-AzDatabricksWorkspace -ResourceGroupName lucas-rg-test -Name databricks-t01 -RequiredNsgRule 'NoAzureDatabricksRules'
```

This command updates NsgRule of the Databricks workspace.