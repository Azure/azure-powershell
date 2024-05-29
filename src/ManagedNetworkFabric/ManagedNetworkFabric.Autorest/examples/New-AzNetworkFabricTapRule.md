### Example 1: Create the Network Tap Rule Resource
```powershell
$matchConfiguration = @(@{
    Action = @(@{
        DestinationId = "/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/neighborGroups/NeighborGroupName"
        IsTimestampEnabled = "True"
        MatchConfigurationName = "match1"
        Truncate = "100"
        Type = "Drop"
    })
    IPAddressType = "IPv4"
    MatchCondition = @(@{
        EncapsulationType = "None"
        PortConditionLayer4Protocol = "TCP"
        PortConditionPort = @("100")
        PortConditionPortGroupName = @("portGroupName1")
        PortConditionPortType = "SourcePort"
        VlanMatchConditionInnerVlan = @("30")
        VlanMatchConditionVlan = @("20-30")
        VlanMatchConditionVlanGroupName = @("name")
        IPConditionIpgroupName = @("name")
        IPConditionIpprefixValue = @("10.20.20.20/12")
        IPConditionPrefixType = "Prefix"
        IPConditionType = "SourceIP"
    })
    MatchConfigurationName = "config1"
    SequenceNumber = 12
})

New-AzNetworkFabricTapRule -Name $name -ResourceGroupName $resourceGroupName -Location $location -ConfigurationType "Inline" -MatchConfiguration $matchConfiguration
```

```output
AdministrativeState Annotation ConfigurationState ConfigurationType DynamicMatchConfiguration Id
------------------- ---------- ------------------ ----------------- ------------------------- --
Disabled                       Succeeded          Inline                                      /subscriptions/<identity>/…
```

This command creates the Network Tap Rule resource with ConfigurationType as Inline.

