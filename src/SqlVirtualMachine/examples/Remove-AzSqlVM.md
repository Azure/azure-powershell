### Example 1
```powershell
Remove-AzSqlVM -ResourceGroupName 'ResourceGroup01' -GroupName 'sqlvmgroup01'
```

### Example 2
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -GroupName 'sqlvmgroup01'
$sqlVM | Remove-AzSqlVM
```

