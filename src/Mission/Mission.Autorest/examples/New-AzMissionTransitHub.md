### Example 1: Create an ExpressRoute transit hub in a community
```powershell
New-AzMissionTransitHub -Name 'contoso-transithub' -CommunityName 'contoso-community' -ResourceGroupName 'mission-rg' -Location 'eastus' -TransitOptionType 'ExpressRoute' -ParamScaleUnit 1 -SecurityProvider 'AzureFirewall'
```

```output
Name               Location ResourceGroupName ProvisioningState State
----               -------- ----------------- ----------------- -----
contoso-transithub eastus   mission-rg        Succeeded         PendingApproval
```

Creates a transit hub named `contoso-transithub` in the `contoso-community` community using an ExpressRoute transit option (1 scale unit) secured by Azure Firewall.
