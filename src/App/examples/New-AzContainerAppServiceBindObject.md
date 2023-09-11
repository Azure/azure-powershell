### Example 1: Create an in-memory object for ServiceBind.
```powershell
New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1"
```

```output
Name         ServiceId
----         ---------
redisService /subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1
```

Create an in-memory object for ServiceBind.