### Example 1
```powershell
Invoke-AzRedeploySqlVM -ResourceGroupName 'ResourceGroup01' -SqlVirtualMachineName 'sqlvm1'
```

### Example 2
```powershell
$sqlvm = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -GroupName 'sqlvmgroup01'
$sqlvm | Invoke-AzRedeploySqlVM
```

