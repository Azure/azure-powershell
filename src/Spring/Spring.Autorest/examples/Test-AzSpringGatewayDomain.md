### Example 1: Check the domains are valid as well as not in use.
```powershell
Test-AzSpringGatewayDomain -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default -Name default
```

```output
IsValid Message
------- -------
  False Custom domain 'default' is invalid.
```

Check the domains are valid as well as not in use.