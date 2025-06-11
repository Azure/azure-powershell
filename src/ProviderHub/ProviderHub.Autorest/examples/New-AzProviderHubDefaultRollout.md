### Example 1: Create a resource provider default rollout.
```powershell
New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -SpecificationCanarySkipRegion "brazilus" -NoWait
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Create a resource provider default rollout.
