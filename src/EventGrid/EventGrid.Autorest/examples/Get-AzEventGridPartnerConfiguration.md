### Example 1: List all the partner configurations under a resource group.
```powershell
Get-AzEventGridPartnerConfiguration
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

List all the partner configurations under a resource group.

### Example 2: List all the partner configurations under a resource group.
```powershell
Get-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

List all the partner configurations under a resource group.