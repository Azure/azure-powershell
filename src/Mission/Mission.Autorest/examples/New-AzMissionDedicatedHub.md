### Example 1: Create a dedicated hub in a community
```powershell
New-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -Designation 'Reserved' -Tag @{ environment = 'production' }
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Creates a dedicated hub named `contoso-dedicatedhub` in the `contoso-community` community with a `Reserved` designation.
