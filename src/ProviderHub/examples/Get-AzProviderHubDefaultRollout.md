### Example 1: List all default rollouts under the resource provider.
```powershell
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"
```

List all default rollouts under the resource provider.

### Example 2: Get a specific rollout by name.
```powershell
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
```

Get a specific rollout by name.

