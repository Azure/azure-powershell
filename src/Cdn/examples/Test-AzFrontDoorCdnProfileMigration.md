### Example 1: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.


### Example 2: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId01/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName -SubscriptionId testSubId01 
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition. 
You need to set the value of the subscription parameter.