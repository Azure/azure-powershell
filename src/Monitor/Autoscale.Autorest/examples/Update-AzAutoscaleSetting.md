### Example 1: Update Tag and Enable existing autoscale setting
```powershell
Update-AzAutoscaleSetting -ResourceGroupName test-group -Name test-autoscalesetting -Tag @{'key'='val'} -Enabled $true
```

Update Tag and Enable existing autoscale setting