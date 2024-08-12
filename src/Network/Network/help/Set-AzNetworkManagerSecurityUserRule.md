---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityuserrule
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityUserRule

## SYNOPSIS
Updates a network manager security user rule.

## SYNTAX

```
Set-AzNetworkManagerSecurityUserRule -InputObject <PSNetworkManagerSecurityBaseUserRule> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityUserRule** cmdlet updates a network manager security user rule.

## EXAMPLES

### Example 1
```powershell
$SecurityUserRule = Get-AzNetworkManagerSecurityUserRule  -Name "psRule" -RuleCollectionName "psRuleCollection" -SecurityUserConfigurationName "psSecurityUserConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
Set-AzNetworkManagerSecurityUserRule -InputObject $SecurityUserRule
```

```output
Protocol                  : Tcp
Direction                 : Inbound
Sources                   : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
Destinations              : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
SourcePortRanges          : {100}
DestinationPortRanges     : {99}
SourcesText               : [
                              {
                                "AddressPrefix": "Internet",
                                "AddressPrefixType": "ServiceTag"
                              }
                            ]
DestinationsText          : [
                              {
                                "AddressPrefix": "10.0.0.1",
                                "AddressPrefixType": "IPPrefix"
                              }
                            ]
SourcePortRangesText      : [
                              "100"
                            ]
DestinationPortRangesText : [
                              "99"
                            ]
DisplayName               :
Description               : TestDescription
Type                      : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules
ProvisioningState         : Succeeded
SystemData                : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText            : {
                              "CreatedBy": "jaredgorthy@microsoft.com",
                              "CreatedByType": "User",
                              "CreatedAt": "2022-08-08T00:39:56.4512419Z",
                              "LastModifiedBy": "jaredgorthy@microsoft.com",
                              "LastModifiedByType": "User",
                              "LastModifiedAt": "2022-08-08T01:23:18.6454664Z"
                            }
Name                      : psRule
Etag                      :
Id                        : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityUserConfigurations/psSecurityUserConfig/ruleCollections/psRuleCollection/rules/psRule
```

Updates a network manager security user rule's priority'.

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

### -InputObject
The Network Manager Security User Rule

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserRule](./Get-AzNetworkManagerSecurityUserRule.md)

[New-AzNetworkManagerSecurityUserRule](./New-AzNetworkManagerSecurityUserRule.md)

[Remove-AzNetworkManagerSecurityUserRule](./Remove-AzNetworkManagerSecurityUserRule.md)