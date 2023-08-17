### Example 1: List scheduled query rules under current subscription
```powershell
Get-AzScheduledQueryRule
```

List scheduled query rules under current subscription

### Example 2: List scheduled query rules for resource group
```powershell
Get-AzScheduledQueryRule -ResourceGroupName "test-group"
```

List scheduled query rules for resource group: "test-group"

### Example 3: Get scheduled query rule by name
```powershell
Get-AzScheduledQueryRule -ResourceGroupName "test-group" -Name "test-rule"
```

Get scheduled query rule by name