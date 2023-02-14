### Example 1: List all default rollouts under the resource provider.
```powershell
<<<<<<< HEAD
Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"
```

```output
=======
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
defaultRollout2021w11     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

List all default rollouts under the resource provider.

### Example 2: Get a specific rollout by name.
```powershell
<<<<<<< HEAD
Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
```

```output
=======
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Get a specific rollout by name.

