### Example 1: Start a Service.
```powershell
Start-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01 -PassThru
```

```output
True
```

Start a Service.
It can only be started after being stopped for more than 30 minutes.