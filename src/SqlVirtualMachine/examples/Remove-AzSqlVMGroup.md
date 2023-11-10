### Example 1
```powershell
Remove-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
```

### Example 2
```powershell
$group = Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
$group | Remove-AzSqlVMGroup
```

