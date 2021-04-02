### Example 1: List all default rollouts under the resource provider.
```powershell
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"
```

Name                Type
----                ----
defaultRollout2021w10
defaultRollout2021w11

List all default rollouts under the resource provider.

### Example 2: Get a specific rollout by name.
```powershell
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
```

Name                Type
----                ----
defaultRollout2021w10

Get a specific rollout by name.

