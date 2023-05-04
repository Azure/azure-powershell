### Example 1: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxx//resourcegroups/testrg//providers/Microsoft.Network/Frontdoors/frontdoorName -SubscriptionId xxxxxxxxxxxxxxx 
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.
