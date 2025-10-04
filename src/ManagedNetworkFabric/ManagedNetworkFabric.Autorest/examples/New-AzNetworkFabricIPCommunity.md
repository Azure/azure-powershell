### Example 1: Create the IpCommunity Resource
```powershell
$ipCommunityRule = @(@{
    action = "Permit"
    sequenceNumber = 1234
    communityMember = @("1:1")
    wellKnownCommunity = @("Internet","GShut")
})

New-AzNetworkFabricIPCommunity -Name $name -ResourceGroupName $resourceGroupName -Location $location -IPCommunityRule $ipCommunityRule
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the IpCommunity resource.
