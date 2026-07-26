### Example 1: Update the IP Community
```powershell
$ipCommunityRule = @(@{
    Action = "Permit"
    SequenceNumber = 1
    CommunityMember = @("1234:5678")
})
Update-AzNetworkFabricIPCommunity -Name $name -ResourceGroupName $resourceGroupName -IPCommunityRule $ipCommunityRule
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/ipCommunities/example-ipcommunity
```

This command updates the properties of the given IP Community.
