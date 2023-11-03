### Example 1: Abort classic CDN migrate to AFDx
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Abort classic CDN migrate to AFDx.
This will delete all the AFD Standard or Premium configurations


### Example 2: Abort classic CDN migrate to AFDx, when the subscription of the classic CDN is different from the local subscrition
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName -SubscriptionId testSubId01
```

Abort classic CDN migrate to AFDx. When the subscription of the classic CDN is different from the local subscrition, You need to set the value of the subscription parameter.
This will delete all the AFD Standard or Premium configurations. 