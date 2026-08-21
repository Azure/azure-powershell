### Example 1: Create a community endpoint with a destination rule
```powershell
$rule = @{ destinationType = 'FQDNTag'; destination = 'foo.example.com'; ports = '443'; protocols = @('TCP') }
New-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -RuleCollection $rule -UpdateMode 'Automatic'
```

```output
Name             Location ResourceGroupName ProvisioningState UpdateMode
----             -------- ----------------- ----------------- ----------
contoso-endpoint eastus   mission-rg        Succeeded         Automatic
```

Creates a community endpoint named `contoso-endpoint` in the `contoso-community` community, allowing HTTPS (port 443/TCP) traffic to `foo.example.com` and enabling automatic rule updates.
