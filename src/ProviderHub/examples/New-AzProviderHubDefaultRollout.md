### Example 1: Create/Update a resource provider default rollout.
```powershell
PS C:\> New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -RestOfTheWorldGroupTwoWaitDuration New-TimeSpan -Hours 24 -CanarySkipRegion "brazilus" -NoWait
```

