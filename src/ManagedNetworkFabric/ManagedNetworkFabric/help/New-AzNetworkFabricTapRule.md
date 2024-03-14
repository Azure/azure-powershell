---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabrictaprule
schema: 2.0.0
---

# New-AzNetworkFabricTapRule

## SYNOPSIS
Create Network Tap Rule resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-Annotation <String>] [-ConfigurationType <String>]
 [-DynamicMatchConfiguration <ICommonDynamicMatchConfiguration[]>]
 [-MatchConfiguration <INetworkTapRuleMatchConfiguration[]>] [-PollingIntervalInSecond <Int32>]
 [-Tag <Hashtable>] [-TapRulesUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create Network Tap Rule resource.

## EXAMPLES

### EXAMPLE 1
```
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
```

New-AzNetworkFabricTapRule -Name $name -ResourceGroupName $resourceGroupName -Location $location -ConfigurationType "Inline" -MatchConfiguration $matchConfiguration

## PARAMETERS

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationType
Input method to configure Network Tap Rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMatchConfiguration
List of dynamic match configurations.
To construct, see NOTES section for DYNAMICMATCHCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommonDynamicMatchConfiguration[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchConfiguration
List of match configurations.
To construct, see NOTES section for MATCHCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkTapRuleMatchConfiguration[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network Tap Rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkTapRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PollingIntervalInSecond
Polling interval in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TapRulesUrl
Network Tap Rules file URL.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkTapRule
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

DYNAMICMATCHCONFIGURATION \<ICommonDynamicMatchConfiguration\[\]\>: List of dynamic match configurations.
  \[IPGroup \<List\<IIPGroupProperties\>\>\]: List of IP Groups.
    \[IPAddressType \<String\>\]: IP Address type.
    \[IPPrefix \<List\<String\>\>\]: List of IP Prefixes.
    \[Name \<String\>\]: IP Group name.
  \[PortGroup \<List\<IPortGroupProperties\>\>\]: List of the port groups.
    \[Name \<String\>\]: The name of the port group.
    \[Port \<List\<String\>\>\]: List of the ports that need to be matched.
  \[VlanGroup \<List\<IVlanGroupProperties\>\>\]: List of vlan groups.
    \[Name \<String\>\]: Vlan group name.
    \[Vlan \<List\<String\>\>\]: List of vlans.

MATCHCONFIGURATION \<INetworkTapRuleMatchConfiguration\[\]\>: List of match configurations.
  \[Action \<List\<INetworkTapRuleAction\>\>\]: List of actions that need to be performed for the matched conditions.
    \[DestinationId \<String\>\]: Destination Id.
The ARM resource Id may be either Network To Network Interconnect or NeighborGroup.
    \[IsTimestampEnabled \<String\>\]: The parameter to enable or disable the timestamp.
    \[MatchConfigurationName \<String\>\]: The name of the match configuration.
This is used when Goto type is provided.
If Goto type is selected and no match configuration name is provided.
It goes to next configuration.
    \[Truncate \<String\>\]: Truncate.
0 indicates do not truncate.
    \[Type \<String\>\]: Type of actions that can be performed.
  \[IPAddressType \<String\>\]: Type of IP Address.
IPv4 or IPv6
  \[MatchCondition \<List\<INetworkTapRuleMatchCondition\>\>\]: List of the match conditions.
    \[EncapsulationType \<String\>\]: Encapsulation Type that needs to be matched.
    \[PortConditionLayer4Protocol \<String\>\]: Layer4 protocol type that needs to be matched.
    \[PortConditionPort \<List\<String\>\>\]: List of the Ports that need to be matched.
    \[PortConditionPortGroupName \<List\<String\>\>\]: List of the port Group Names that need to be matched.
    \[PortConditionPortType \<String\>\]: Port type that needs to be matched.
  \[MatchConfigurationName \<String\>\]: The name of the match configuration.
  \[SequenceNumber \<Int64?\>\]: Sequence Number of the match configuration..

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabrictaprule](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabrictaprule)

