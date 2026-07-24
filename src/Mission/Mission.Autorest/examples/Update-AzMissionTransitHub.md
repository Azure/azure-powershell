### Example 1: Patch a transit hub's tags
```powershell
Update-AzMissionTransitHub -Name 'contoso-transithub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Tag @{ costCenter = 'network' }
```

```output
Name               Location ResourceGroupName ProvisioningState State
----               -------- ----------------- ----------------- -----
contoso-transithub eastus   mission-rg        Succeeded         PendingApproval
```

Updates only the tags on the existing `contoso-transithub` transit hub, leaving its transit option unchanged (PATCH semantics).
