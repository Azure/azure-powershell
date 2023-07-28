### Example 1: Remove Spring Cloud Service by name.
```powershell
Remove-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring
```

Remove Spring Cloud Service by name.

### Example 2: Remove Spring Cloud Service by pipeline.
```powershell
Get-AzSpring -ResourceGroupName azps_test_group_spring -Name azps-spring | Remove-AzSpring
```

Remove Spring Cloud Service by pipeline.