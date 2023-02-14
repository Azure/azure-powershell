### Example 1: Create/Update a resource provider default rollout.
```powershell
<<<<<<< HEAD
New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -CanarySkipRegion "brazilus" -NoWait
```

```output
=======
PS C:\> New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -CanarySkipRegion "brazilus" -NoWait

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Create/Update a resource provider default rollout.
