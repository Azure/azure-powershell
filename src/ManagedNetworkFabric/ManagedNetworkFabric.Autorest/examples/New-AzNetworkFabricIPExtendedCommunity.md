### Example 1: Create the IpExtendedCommunity Resource
```powershell
$ipExtendedCommunityRule = @(@{
    action = "Permit"
    sequenceNumber = 4321
    routeTarget = @("1024:219","1001:200")
})

New-AzNetworkFabricIPExtendedCommunity -Name $name -ResourceGroupName $resourceGroupName -Location $location -IPExtendedCommunityRule $ipExtendedCommunityRule
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the IpExtendedCommunity resource.
