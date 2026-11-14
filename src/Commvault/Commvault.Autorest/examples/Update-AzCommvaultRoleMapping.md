### Example 1: Update the role mapping of a cloud account
```powershell
$roles = @(
    @{ RoleName = 'BackupOperator'; Entity = @(@{ Id = '11111111-2222-3333-4444-555555555555'; DisplayName = 'Commvault-Operators'; EntityType = 'Group' }) }
)
Update-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Role $roles
```

Updates the role mapping so that the BackupOperator role is assigned to the specified Microsoft Entra group.

