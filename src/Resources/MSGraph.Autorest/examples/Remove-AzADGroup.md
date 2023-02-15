### Example 1: Remove group by display name
```powershell
Remove-AzADGroup -DisplayName $name
```

Remove group by display name

### Example 2: Remove group by pipeline input
```powershell
Get-AzADGroup -ObjectId $id | Remove-AzADGroup
```

Remove group by pipeline input