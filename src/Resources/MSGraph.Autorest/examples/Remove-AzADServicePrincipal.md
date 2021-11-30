### Example 1: Remove service principal by display name
```powershell
PS C:\> Remove-AzADServicePrincipal -DisplayName $name
```

Remove service principal by display name

### Example 2: Remove service principal by pipeline input
```powershell
PS C:\> Get-AzADServicePrincipal -Application $id | Remove-AzADServicePrincipal
```

Remove service principal by pipeline input