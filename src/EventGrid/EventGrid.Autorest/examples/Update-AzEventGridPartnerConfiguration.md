### Example 1: Synchronously updates a partner configuration with the specified parameters.
```powershell
Update-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -DefaultMaximumExpirationTimeInDay 1 -Tag @{"abc"="123"}
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously updates a partner configuration with the specified parameters.