### Example 1: Synchronously Create a partner configuration with the specified parameters.
```powershell
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously Create a partner configuration with the specified parameters.