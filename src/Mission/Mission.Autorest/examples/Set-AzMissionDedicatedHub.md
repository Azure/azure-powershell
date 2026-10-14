### Example 1: Replace a dedicated hub definition (PUT)
```powershell
Set-AzMissionDedicatedHub -Name 'contoso-dedicatedhub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -Designation 'Reserved' -Tag @{ environment = 'production' }
```

```output
Name                 Location ResourceGroupName ProvisioningState Designation
----                 -------- ----------------- ----------------- -----------
contoso-dedicatedhub eastus   mission-rg        Succeeded         Reserved
```

Replaces the full definition of the `contoso-dedicatedhub` dedicated hub. Any properties not supplied are reset to their defaults.
