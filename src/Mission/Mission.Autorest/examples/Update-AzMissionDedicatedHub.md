### Example 1: Patch a dedicated hub's tags
```powershell
Update-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Tag @{ costCenter = 'platform' }
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Updates only the tags on the existing `contoso-dedicatedhub` dedicated hub, leaving all other properties unchanged (PATCH semantics).
