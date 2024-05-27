### Example 1: List all default rollouts under the resource provider.
```powershell
Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
defaultRollout2021w11     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

List all default rollouts under the resource provider.

### Example 2: Get a specific rollout by name.
```powershell
Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Get a specific rollout by name.

