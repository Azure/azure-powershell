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
 [-Tag <Hashtable>] [-TapRulesUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricTapRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create Network Tap Rule resource.

## EXAMPLES

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
Default value: None
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
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
Default value: (Get-AzContext).Subscription.Id
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

## RELATED LINKS
