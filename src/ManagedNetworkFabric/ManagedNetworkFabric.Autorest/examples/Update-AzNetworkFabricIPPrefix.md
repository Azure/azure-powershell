### Example 1: Update the IP Prefix
```powershell
$ipPrefixRule = @(@{
    Action = "Permit"
    SequenceNumber = 1
    NetworkPrefix = "10.10.0.0/15"
})
Update-AzNetworkFabricIPPrefix -Name $name -ResourceGroupName $resourceGroupName -IPPrefixRule $ipPrefixRule
```

```output
Annotation ConfigurationState Id
---------- ------------------ --
           Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/example-ipprefix
```

This command updates the properties of the given IP Prefix.
