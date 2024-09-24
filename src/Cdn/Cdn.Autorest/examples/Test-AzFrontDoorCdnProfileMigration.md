### Example 1: Checks if a classic AFD instance can be migrated to Azure Front Door(Standard/Premium) profile.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName
```

```output
CanMigrate DefaultSku              Error
---------- ----------              -----
True       Standard_AzureFrontDoor {}
```

Checks if a classic AFD instance can be migrated to Azure Front Door(Standard/Premium) profile.


### Example 2: Checks if a classic AFD instance can be migrated to Azure Front Door(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId01/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName -SubscriptionId testSubId01 
```

```output
CanMigrate DefaultSku              Error
---------- ----------              -----
True       Standard_AzureFrontDoor {}
```

Checks if a classic AFD instance can be migrated to Azure Front Door(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition. 
You need to set the value of the subscription parameter.