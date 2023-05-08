### Example 1: Abort classic cdn migrate to AFDx
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Abort classic cdn migrate to AFDx.
This will delete all the AFD Standard or Premium configurations


### Example 2: Abort classic cdn migrate to AFDx, when the subscription of the classic cdn is different from the local subscrition
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Abort classic cdn migrate to AFDx. When the subscription of the classic cdn is different from the local subscrition, You need to set the value of the subscription parameter.
This will delete all the AFD Standard or Premium configurations. 