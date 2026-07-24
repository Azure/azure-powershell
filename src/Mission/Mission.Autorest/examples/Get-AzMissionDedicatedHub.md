### Example 1: List all dedicated hubs in a community
```powershell
Get-AzMissionDedicatedHub -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name                 Location ResourceGroupName ProvisioningState
----                 -------- ----------------- -----------------
contoso-dedicatedhub eastus   mission-rg        Succeeded
```

Lists every dedicated hub defined under the `contoso-community` community in the `mission-rg` resource group.

### Example 2: Get a single dedicated hub by name
```powershell
Get-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg'
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Retrieves the `contoso-dedicatedhub` dedicated hub, including its designation.
