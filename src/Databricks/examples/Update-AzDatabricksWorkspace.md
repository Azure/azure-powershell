### Example 1: Updates the tags of a Databricks workspace
```powershell
PS C:\> $dbr = Get-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspaceopsc46 -Tag @{'key'=1}
PS C:\> Update-AzDatabricksWorkspace -InputObject $dbr -Tag @{key="value"}

Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command updates the tags of a Databricks workspace.

### Example 2: Enable encryption on a Databricks workspace
```powershell
PS C:\> Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -PrepareEncryption
PS C:\> Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -EncryptionKeySource 'Microsoft.KeyVault' -EncryptionKeyVaultUri https://keyvalult-j3kube.vault.azure.net/ -EncryptionKeyName key-p3bjsf -EncryptionKeyVersion 853999da89714fb4a1408681945135fd

Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

Enabling encryption on a Databricks workspace takes three steps:
1. Update the workspace with `-PrepareEncryption` (if it was not created so).
1. Find `StorageAccountIdentityPrincipalId` in the output of the last step. Grant key permissions to the principal.
1. Update the workspace again to fill in information about the encryption key:
    - `-EncryptionKeySource`
    - `-EncryptionKeyVaultUri`
    - `-EncryptionKeyName`
    - `-EncryptionKeyVersion`

### Example 3: Disable encryption on a Databricks workspace
```powershell
PS C:\> Update-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo -Name workspace3miaeb -EncryptionKeySource 'Default'
```

To disable encryption, simply set `-EncryptionKeySource` to `'Default'`.