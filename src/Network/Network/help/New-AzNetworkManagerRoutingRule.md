---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerroutingrule
schema: 2.0.0
---

# New-AzNetworkManagerRoutingRule

## SYNOPSIS
Creates a routing rule.

## SYNTAX

```
New-AzNetworkManagerRoutingRule -Name <String> -RuleCollectionName <String> -RoutingConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> -Destination <PSNetworkManagerRoutingRuleDestination>
 -NextHop <PSNetworkManagerRoutingRuleNextHop> [-Description <String>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerRoutingRule** cmdlet creates a routing rule.

## EXAMPLES

### Example 1: Create Custom routing Rule
```powershell
$destination = New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "10.1.1.1/32" -Type "AddressPrefix" 
$nextHop = New-AzNetworkManagerRoutingRuleNextHop -NextHopType "VirtualAppliance" -NextHopAddress "2.2.2.2"
New-AzNetworkManagerRoutingRule -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -ConfigName "psRoutingConfig" -RuleCollectionName "psRuleCollection" -Name "psRule" -Description "TestDescription" -Destination $destination -NextHop $nextHop
```

```output
Destination               : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleDestination}
NextHop                   : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleNextHop}
DisplayName               :
Description               : TestDescription
Type                      : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules
ProvisioningState         : Succeeded
SystemData                : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText            : {
                               "CreatedBy": "00000000-0000-0000-0000-000000000000",
                               "CreatedByType": "Application",
                               "CreatedAt": "2021-10-18T04:05:57",
                               "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                               "LastModifiedByType": "Application",
                               "LastModifiedAt": "2021-10-18T04:05:59"
                            }
Name                      : psRule
Etag                      :
Id                        : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/routingConfigurations/psRoutingConfig/ruleCollections/psRuleCollection/rules/psRule
```

Creates a routing rule.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Destination
Destination Address and type.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleDestination
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NextHop
Next hop address and type.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleNextHop
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoutingConfigurationName
The network manager routing configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -RuleCollectionName
The network manager routing rule collection name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### System.String

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]

### System.String[]	

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerRoutingRule](./Get-AzNetworkManagerRoutingRule.md)

[Remove-AzNetworkManagerRoutingRule](./Remove-AzNetworkManagerRoutingRule.md)

[Set-AzNetworkManagerRoutingRule](./Set-AzNetworkManagerRoutingRule.md)