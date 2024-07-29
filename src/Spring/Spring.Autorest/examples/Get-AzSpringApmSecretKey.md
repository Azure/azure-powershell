### Example 1: List keys of APM sensitive properties.
```powershell
Get-AzSpringApmSecretKey -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApmName azps-apm
```

```output
connection-string
```

List keys of APM sensitive properties.