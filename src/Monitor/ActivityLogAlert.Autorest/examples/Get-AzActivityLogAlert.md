### Example 1: List activity log alerts under current subscription
```powershell
Get-AzActivityLogAlert
```

List activity log alerts under current subscription

### Example 2: List activity log alerts under resource group
```powershell
Get-AzActivityLogAlert -ResourceGroupName $rg-name
```

List activity log alerts under resource group

### Example 3: Get activity log alert by name
```powershell
Get-AzActivityLogAlert -ResourceGroupName $rg-name -Name $alert-name
```

Get activity log alert by name