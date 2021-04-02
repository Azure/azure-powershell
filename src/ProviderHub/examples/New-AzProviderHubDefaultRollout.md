### Example 1: Create/Update a resource provider default rollout.
```powershell
PS C:\> New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -CanarySkipRegion "brazilus" -NoWait
```

Target
------
https://management.azure.com/providers/Microsoft.ProviderHub/operationStatuses/00000000-0000-0000-0000-000000000000?api-version=2019-10-01

Create/Update a resource provider default rollout.
