---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagerroutingrule
schema: 2.0.0
---

# Set-AzNetworkManagerRoutingRule

## SYNOPSIS
Updates a network manager routing rule.

## SYNTAX

### ByInputObject (Default)
```
Set-AzNetworkManagerRoutingRule -InputObject <PSNetworkManagerRoutingRule> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByNameParameters
```
Set-AzNetworkManagerRoutingRule -Name <String> -ResourceGroupName <String> -NetworkManagerName <String>
 -RoutingConfigurationName <String> -RuleCollectionName <String> -DestinationAddress <String>
 -DestinationType <String> [-NextHopAddress <String>] -NextHopType <String> [-Description <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Set-AzNetworkManagerRoutingRule -ResourceId <String> -DestinationAddress <String> -DestinationType <String>
 [-NextHopAddress <String>] -NextHopType <String> [-Description <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerRoutingRule** cmdlet updates a network manager routing rule.

## EXAMPLES

### Example 1
```powershell
$destination = New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "10.1.1.1/32" -Type "AddressPrefix" 
$RoutingRule = Get-AzNetworkManagerRoutingRule  -Name "psRule" -RuleCollectionName "psRuleCollection" -RoutingConfigurationName "psRoutingConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
Set-AzNetworkManagerRoutingRule -InputObject $RoutingRule
```

```output
Destination               : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleDestination}
NextHop                   : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleNextHop}
DestinationText           : [
                              {
                                "DestinationAddress": "10.1.1.1/32",
                                "Type": "AddressPrefix"
                              }
                            ]
NextHopText               : [
                              {
                                "AddressNextHopType": "NoNextHop"
                              }
                            ]
DisplayName               :
Description               : TestDescription
Type                      : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules
ProvisioningState         : Succeeded
SystemData                : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataTest            : {
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

Updates a network manager routing rule's destination.

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
Parameter Sets: ByNameParameters, ByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationAddress
The routing rule destination address.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationType
The routing rule destination type.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The Network Manager Routing Rule

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRule
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
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
Parameter Sets: ByNameParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextHopAddress
The routing rule next hop address.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextHopType
The routing rule next hop type.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByResourceId
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
Parameter Sets: ByNameParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
NetworkManager RoutingRule Id

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: RoutingRuleId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoutingConfigurationName
The routing configuration name.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleCollectionName
The rule collection name.

```yaml
Type: System.String
Parameter Sets: ByNameParameters
Aliases:

Required: True
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

### System.String

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRule

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerRoutingRule](./Get-AzNetworkManagerRoutingRule.md)

[New-AzNetworkManagerRoutingRule](./New-AzNetworkManagerRoutingRule.md)

[Remove-AzNetworkManagerRoutingRule](./Remove-AzNetworkManagerRoutingRule.md)