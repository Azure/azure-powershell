### Example 1: Remove group by display name
```powershell
PS C:\> Remove-AzADGroup -DisplayName $name
```

Remove group by display name

### Example 2: Remove group by pipeline input
```powershell
PS C:\> Get-AzADGroup -ObjectId $id | Remove-AzADGroup
```

Remove group by pipeline input