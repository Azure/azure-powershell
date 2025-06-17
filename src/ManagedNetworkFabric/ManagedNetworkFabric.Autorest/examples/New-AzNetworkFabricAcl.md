### Example 1: Create the Access Control List Resource
```powershell
$dynamicMatchConfiguration = @(@{
    IPGroup = @(@{
        IPAddressType = "IPv4"
        IPPrefix = @("10.20.3.1/20")
        Name = "ipGroupName"
    })
    PortGroup = @(@{
        Name = "portGroupName"
        Port = @("100-200")
    })
    VlanGroup = @(@{
        Name = "valnGroupName"
        Vlan = @("20-30")
    })
})

$matchConfiguration = @(@{
    Action = @(@{
        Type = "Count"
        CounterName = "counterName"
    })
    IPAddressType = "IPv4"
    MatchCondition = @(@{
        DscpMarking = @("32")
        EtherType = @("0x1")
        Fragment = @("0xff00-0xffff")
        IPLength = @("4094-9214")
        TtlValue =  @("23")
        PortConditionFlag = @("established")
        PortConditionLayer4Protocol = "TCP"
        PortConditionPortGroupName = @("portGroupName")
        PortConditionPortType = "SourcePort"
        VlanMatchConditionInnerVlan = @("30")
        VlanMatchConditionVlan = @("20-30")
        VlanMatchConditionVlanGroupName = @("name")
        IPConditionIpgroupName = @("name")
        IPConditionIpprefixValue = @("10.20.20.20/12")
        IPConditionPrefixType = "Prefix"
        IPConditionType = "SourceIP"

    })
    MatchConfigurationName = "matchConfName"
    SequenceNumber = 13
})

New-AzNetworkFabricAcl -Name $name -ResourceGroupName $resourceGroupName -Location $location -ConfigurationType "Inline" -DefaultAction "Permit" -DynamicMatchConfiguration $dynamicMatchConfiguration -MatchConfiguration $matchConfiguration
```

```output
AclsUrl AdministrativeState Annotation ConfigurationState ConfigurationType DefaultAction DynamicMatchConfiguration
------- ------------------- ---------- ------------------ ----------------- ------------- -------------------------
        Disabled                       Succeeded          Inline            Permit        
```

This command creates the Access Control List resource.

