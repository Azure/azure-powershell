### Example 1: Remove application by display name
```powershell
Remove-AzADApplication -DisplayName $name
```

Remove application by display name

### Example 2: Remove application by pipeline input
```powershell
Get-AzADApplication -ObjectId $id | Remove-AzADApplication
```

Remove application by pipeline input