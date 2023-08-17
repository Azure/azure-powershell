### Example 1: Remove service principal by display name
```powershell
Remove-AzADServicePrincipal -DisplayName $name
```

Remove service principal by display name

### Example 2: Remove service principal by pipeline input
```powershell
Get-AzADServicePrincipal -ApplicationId $id | Remove-AzADServicePrincipal
```

Remove service principal by pipeline input