### Example 1: Update a resource provider default rollout.
```powershell
Update-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -SpecificationCanarySkipRegion "brazilus" -NoWait
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Update a resource provider default rollout.
