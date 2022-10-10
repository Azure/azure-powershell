---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanagersecurityadminrule
schema: 2.0.0
---

# Set-AzNetworkManagerSecurityAdminRule

## SYNOPSIS
Updates a network manager security admin rule.

## SYNTAX

```
Set-AzNetworkManagerSecurityAdminRule
 -InputObject <PSNetworkManagerSecurityBaseAdminRule> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSecurityAdminRule** cmdlet updates a network manager security admin rule.

## EXAMPLES

### Example 1
```powershell
$SecurityAdminRule = Get-AzNetworkManagerSecurityAdminRule  -Name "psRule" -RuleCollectionName "psRuleCollection" -SecurityAdminConfigurationName "psSecurityAdminConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
$SecurityAdminRule.priority = 50
Set-AzNetworkManagerSecurityAdminRule -InputObject $SecurityAdminRule
```
```output
Protocol                  : Tcp
Direction                 : Inbound
Sources                   : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
Destinations              : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
SourcePortRanges          : {100}
DestinationPortRanges     : {99}
Access                    : Allow
Priority                  : 50
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
Type                      : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules
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
Id                        : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig/ruleCollections/psRuleCollection/rules/psRule
```
Updates a network manager security admin rule's priority'.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Network Manager Security Admin Rule

```yaml
Type: PSNetworkManagerSecurityBaseAdminRule
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerSecurityAdminRule](./Get-AzNetworkManagerSecurityAdminRule.md)

[New-AzNetworkManagerSecurityAdminRule](./New-AzNetworkManagerSecurityAdminRule.md)

[Remove-AzNetworkManagerSecurityAdminRule](./Remove-AzNetworkManagerSecurityAdminRule.md)