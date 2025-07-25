### Example 1: Remove user by display name
```powershell
Remove-AzADUser -DisplayName $name
```

Remove user by display name

### Example 2: Remove user by pipeline input
```powershell
Get-AzADUser -UserPrincipalName $id | Remove-AzADUser
```

Remove user by pipeline input