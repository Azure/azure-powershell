### Example 1: Create the role mapping of a cloud account
```powershell
$roles = @(
    @{ RoleName = 'BackupAdmin'; Entity = @(@{ Id = 'a1b2c3d4-e5f6-7890-abcd-ef1234567890'; DisplayName = 'Backup Admins Group'; EntityType = 'Group' }) },
    @{ RoleName = 'BackupUser'; Entity = @(@{ Id = '22222222-3333-4444-5555-666666666666'; DisplayName = 'Jane Doe'; EntityType = 'User' }) }
)
New-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Role $roles
```

Maps the BackupAdmin and BackupUser roles to a Microsoft Entra group and user.

### Example 2: Create the role mapping by using a JSON file
```powershell
New-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -JsonFilePath '.\role-mapping.json'
```

Creates the role mapping from the request body in the JSON file.

