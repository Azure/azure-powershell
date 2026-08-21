### Example 1: List all transit hubs in a community
```powershell
Get-AzMissionTransitHub -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState
----               -------- ----------------- -----------------
contoso-transithub eastus   mission-rg        Succeeded
```

Lists every transit hub defined under the `contoso-community` community in the `mission-rg` resource group.

### Example 2: Get a single transit hub by name
```powershell
Get-AzMissionTransitHub -Name 'contoso-transithub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name               Location ResourceGroupName ProvisioningState State
----               -------- ----------------- ----------------- -----
contoso-transithub eastus   mission-rg        Succeeded         PendingApproval
```

Retrieves the `contoso-transithub` transit hub, including its transit option and approval state.
