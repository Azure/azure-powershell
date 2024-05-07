### Example 1: Create/Update a resource provider default rollout.
```powershell
New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -CanarySkipRegion "brazilus" -NoWait
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Create/Update a resource provider default rollout.
