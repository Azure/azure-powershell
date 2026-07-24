### Example 1: Patch a community's tags
```powershell
Update-AzMissionCommunity -Name 'contoso-community' -ResourceGroupName 'mission-rg' -Tag @{ environment = 'production'; costCenter = 'platform' }
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-community eastus   mission-rg        Succeeded
```

Updates only the tags on the existing `contoso-community` community, leaving all other properties unchanged (PATCH semantics).
