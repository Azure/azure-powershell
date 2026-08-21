### Example 1: Patch a community endpoint's tags
```powershell
Update-AzMissionCommunityEndpoint -Name 'contoso-endpoint' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Tag @{ tier = 'edge' }
```

```output
Name             Location ResourceGroupName ProvisioningState UpdateMode
----             -------- ----------------- ----------------- ----------
contoso-endpoint eastus   mission-rg        Succeeded         Automatic
```

Updates only the tags on the existing `contoso-endpoint` community endpoint, leaving its rule collection intact (PATCH semantics).
