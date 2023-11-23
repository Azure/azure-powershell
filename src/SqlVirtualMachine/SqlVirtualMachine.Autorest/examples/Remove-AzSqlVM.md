### Example 1
```powershell
Remove-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
```

### Example 2
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Remove-AzSqlVM
```

