### Example 1: List globally enabled APMs for a Service.
```powershell
Get-AzSpringServiceGloballyEnabledApm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
/subscriptions/{subId}/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apms/azps-apm
```

List globally enabled APMs for a Service.