### Example 1: Create the IpPrefix Resource
```powershell
$ipPrefixRules = @(@{
    action = "Permit"
    sequenceNumber = "1234"
    networkPrefix = "1.1.1.0/24"
    condition = "EqualTo"
    subnetMaskLength = "24"
})

New-AzNetworkFabricIPPrefix -Name $name -ResourceGroupName $resourceGroupName -Location $location -IPPrefixRule $ipPrefixRules
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the IpPrefix resource.

