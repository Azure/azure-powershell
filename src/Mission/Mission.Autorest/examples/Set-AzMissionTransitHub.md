### Example 1: Replace a transit hub definition (PUT)
```powershell
Set-AzMissionTransitHub -Name 'contoso-transithub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -TransitOptionType 'ExpressRoute' -ParamScaleUnit 2 -SecurityProvider 'AzureFirewall'
```

```output
Name               Location ResourceGroupName ProvisioningState State
----               -------- ----------------- ----------------- -----
contoso-transithub eastus   mission-rg        Succeeded         PendingApproval
```

Replaces the full definition of the `contoso-transithub` transit hub, scaling the ExpressRoute transit option up to 2 scale units.
