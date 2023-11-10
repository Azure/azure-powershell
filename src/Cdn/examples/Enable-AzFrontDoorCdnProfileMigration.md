### Example 1: Commit the migrated Azure Front Door(Standard/Premium) profile.
```powershell
Enable-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Commit the migrated Azure Front Door(Standard/Premium) profile.

### Example 2: Commit the migrated Azure Front Door(Standard/Premium) profile., when the subscription of the profile is different from the local subscrition
```powershell
Enable-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName -SubscriptionId testSubId01
```

Commit the migrated Azure Front Door(Standard/Premium) profile., when the subscription of the profile is different from the local subscrition