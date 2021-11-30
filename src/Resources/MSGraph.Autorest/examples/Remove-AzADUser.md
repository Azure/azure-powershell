### Example 1: Remove user by display name
```powershell
PS C:\> Remove-AzADUser -DisplayName $name
```

Remove user by display name

### Example 2: Remove user by pipeline input
```powershell
PS C:\> Get-AzADUser -UserPrincipalName $id | Remove-AzADUser
```

Remove user by pipeline input