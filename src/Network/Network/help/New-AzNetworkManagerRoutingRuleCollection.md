---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerroutingrulecollection
schema: 2.0.0
---

# New-AzNetworkManagerRoutingRuleCollection

## SYNOPSIS
Creates a routing rule collection.

## SYNTAX

```
New-AzNetworkManagerRoutingRuleCollection -Name <String> -RoutingConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-Description <String>]
 -AppliesTo <PSNetworkManagerRoutingGroupItem[]> -DisableBgpRoutePropagation <String> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerRoutingConfiguration** cmdlet creates a routing rule collection.

## EXAMPLES

### Example 1
```powershell
$groupItem = New-AzNetworkManagerRoutingGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
$configGroup = @($groupItem) 
New-AzNetworkManagerRoutingRuleCollection -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -ConfigName "psRoutingConfig" -Name "psRuleCollection" -AppliesTo $configGroup
```

```output
AppliesTo           : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup}
AppliesTo           : [
                        {
                          "NetworkGroupId": "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
                        }
                      ]
DisplayName         :
Description         :
Type                : Microsoft.Network/networkManagers/routingConfigurations/ruleCollections
ProvisioningState   : Succeeded
SystemData          : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText      : {
                       "CreatedBy": "00000000-0000-0000-0000-000000000000",
                       "CreatedByType": "Application",
                       "CreatedAt": "2021-10-18T04:05:57",
                       "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                       "LastModifiedByType": "Application",
                       "LastModifiedAt": "2021-10-18T04:05:59"
                     }
Name                : psRuleCollection
Etag                :
Id                  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/routingConfigurations/psRoutingConfig/ruleCollections/psRuleCollection
```

Creates a routing rule collection with a network group member.

## PARAMETERS

### -AppliesTo
Network group to apply the routing rule collection to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingGroupItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -DisableBgpRoutePropagation
DisableBgpRoutePropagation.

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingGroupItem[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleCollection

## NOTES

## RELATED LINKS

[New-AzNetworkManagerRoutingGroupItem](./New-AzNetworkManagerRoutingGroupItem.md)

[Get-AzNetworkManagerRoutingRuleCollection](./Get-AzNetworkManagerRoutingRuleCollection.md)

[Remove-AzNetworkManagerRoutingRuleCollection](./Remove-AzNetworkManagerRoutingRuleCollection.md)

[Set-AzNetworkManagerRoutingRuleCollection](./Set-AzNetworkManagerRoutingRuleCollection.md)