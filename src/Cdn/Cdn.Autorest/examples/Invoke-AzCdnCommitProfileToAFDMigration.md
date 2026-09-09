### Example 1: Commit the Migration
```powershell
Invoke-AzCdnCommitProfileToAFDMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Commit the Classic CDN Migration, the Microsoft CDN (classic) profile will be upgraded AFD. After migration/upgrade, you won’t be able to view CDN resources.

### Example 2: Commit the migrated Microsoft CDN (classic) profile, when the subscription of the profile is different from the local subscription
```powershell
Invoke-AzCdnCommitProfileToAFDMigration -ProfileName name-migrated -ResourceGroupName rgName -SubscriptionId testSubId01
```

Commit the Classic CDN Migration with different Subscription ID in local env, the Microsoft CDN (classic) profile will be upgraded AFD. After migration/upgrade, you won’t be able to view CDN resources.