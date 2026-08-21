### Example 1: Update the IP Extended Community
```powershell
$ipExtendedCommunityRule = @(@{
    Action = "Permit"
    SequenceNumber = 1
    RouteTarget = @("1234:5678")
})
Update-AzNetworkFabricIPExtendedCommunity -Name $name -ResourceGroupName $resourceGroupName -IPExtendedCommunityRule $ipExtendedCommunityRule
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/example-ipextcommunity
```

This command updates the properties of the given IP Extended Community.
