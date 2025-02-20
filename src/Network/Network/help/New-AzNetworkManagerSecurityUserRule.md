---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecurityuserrule
schema: 2.0.0
---

# New-AzNetworkManagerSecurityUserRule

## SYNOPSIS
Creates a security user rule.

## SYNTAX

```
New-AzNetworkManagerSecurityUserRule -Name <String> -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-Description <String>] -Protocol <String> -Direction <String>
 [-SourceAddressPrefix <PSNetworkManagerAddressPrefixItem[]>]
 [-DestinationAddressPrefix <PSNetworkManagerAddressPrefixItem[]>] [-SourcePortRange <String[]>]
 [-DestinationPortRange <String[]>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityUserRule** cmdlet creates a security user rule.

## EXAMPLES

### Example 1: Create Custom Security User Rule
```powershell
$sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
$destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 
$sourcePortList = @("100")
$destinationPortList = @("99")
New-AzNetworkManagerSecurityUserRule -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -ConfigName "psSecurityUserConfig" -RuleCollectionName "psRuleCollection" -Name "psRule" -Description "TestDescription" -Protocol  "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefix -DestinationAddressPrefix $destinationAddressPrefix
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
                               "CreatedBy": "00000000-0000-0000-0000-000000000000",
                               "CreatedByType": "Application",
                               "CreatedAt": "2021-10-18T04:05:57",
                               "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                               "LastModifiedByType": "Application",
                               "LastModifiedAt": "2021-10-18T04:05:59"
                            }
Name                      : psRule
Etag                      :
Id                        : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityUserConfigurations/psSecurityUserConfig/ruleCollections/psRuleCollection/rules/psRule
```

Creates a security user rule.

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

### -DestinationAddressPrefix
Destination Address Prefixes.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationPortRange
Destination Port Ranges.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Direction
Direction of Rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Inbound, Outbound

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

### -Protocol
Protocol of Rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Tcp, Udp, Icmp, Esp, Any, Ah

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

### -RuleCollectionName
The network manager security user rule collection name.

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

### -SecurityUserConfigurationName
The network manager security user configuration name.

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

### -SourceAddressPrefix
Source Address Prefixes.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourcePortRange
Source Port Ranges.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]

### System.String[]	

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityUserRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserRule](./Get-AzNetworkManagerSecurityUserRule.md)

[Remove-AzNetworkManagerSecurityUserRule](./Remove-AzNetworkManagerSecurityUserRule.md)

[Set-AzNetworkManagerSecurityUserRule](./Set-AzNetworkManagerSecurityUserRule.md)