### Example 1: Replace a community endpoint's rule collection (PUT)
```powershell
$rule = @{ destinationType = 'FQDNTag'; destination = 'api.contoso.com'; ports = '443'; protocols = @('TCP') }
Set-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -RuleCollection $rule -UpdateMode 'Manual'
```

```output
Name             Location ResourceGroupName ProvisioningState UpdateMode
----             -------- ----------------- ----------------- ----------
contoso-endpoint eastus   mission-rg        Succeeded         Manual
```

Replaces the full definition of the `contoso-endpoint` community endpoint, swapping in a new rule that permits HTTPS traffic to `api.contoso.com` and switching the update mode to manual.
