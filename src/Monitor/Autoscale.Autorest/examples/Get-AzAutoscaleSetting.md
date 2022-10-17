### Example 1: List autoscale setting under current subscription
```powershell
Get-AzAutoscaleSetting
```

List autoscale setting under current subscription

### Example 2: List autoscale setting under resource group
```powershell
Get-AzAutoscaleSetting -ResourceGroupName test-group
```

List autoscale setting under resource group

### Example 2: Get autoscale setting by name
```powershell
Get-AzAutoscaleSetting -ResourceGroupName test-group -Name test-autoscalesetting
```

Get autoscale setting by name