---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecurityadminrule
schema: 2.0.0
---

# New-AzNetworkManagerSecurityAdminRule

## SYNOPSIS
Creates a security admin rule.

## SYNTAX

### Custom (Default)
```
New-AzNetworkManagerSecurityAdminRule -Name <String> -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-Description <String>] -Protocol <String> -Direction <String> -Access <String>
 [-SourceAddressPrefix <Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]>]
 [-DestinationAddressPrefix <Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]>]
 [-SourcePortRange <String[]>]
 [-DestinationPortRange <String[]>] -Priority <Int32> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Default
```
New-AzNetworkManagerSecurityAdminRule -Name <String> -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -Flag <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityAdminRule** cmdlet creates a security admin rule.

## EXAMPLES


### Example 1: Create Custom Security Admin Rule
```powershell
$sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
$destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 
$sourcePortList = @("100")
$destinationPortList = @("99")
New-AzNetworkManagerSecurityAdminRule -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -ConfigName "psSecurityAdminConfig" -RuleCollectionName "psRuleCollection" -Name "psRule" -Description "TestDescription" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -SourceAddressPrefix $sourceAddressPrefix -DestinationAddressPrefix $destinationAddressPrefix 
```
```output
Protocol                  : Tcp
Direction                 : Inbound
Sources                   : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
Destinations              : {Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem}
SourcePortRanges          : {100}
DestinationPortRanges     : {99}
Access                    : Allow
Priority                  : 100
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
                              "LastModifiedAt": "2022-08-08T00:39:56.4512419Z"
                            }
Name                      : psRule
Etag                      :
Id                        : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig/ruleCollections/psRuleCollection/rules/psRule
```
Creates a security admin rule.

## PARAMETERS

### -Access
Access of Rule.

```yaml
Type: String
Parameter Sets: Custom
Aliases:
Accepted values: Allow, Deny, and AlwaysAllow

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Description
Description.

```yaml
Type: String
Parameter Sets: Custom
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
Parameter Sets: Custom
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
Parameter Sets: Custom
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
Type: String
Parameter Sets: Custom
Aliases:
Accepted values: Inbound, Outbound

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Flag
Default Flag Type.

```yaml
Type: String
Parameter Sets: Default
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
Type: SwitchParameter
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
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -Priority
Priority of Rule.

```yaml
Type: Int32
Parameter Sets: Custom
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Protocol
Protocol of Rule.

```yaml
Type: String
Parameter Sets: Custom
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleCollectionName
The network manager security admin rule collection name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -SecurityAdminConfigurationName
The network manager security admin configuration name.

```yaml
Type: String
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
Parameter Sets: Custom
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
Parameter Sets: Custom
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem[]

### System.String[]	

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityAdminRule](./Get-AzNetworkManagerSecurityAdminRule.md)

[Remove-AzNetworkManagerSecurityAdminRule](./Remove-AzNetworkManagerSecurityAdminRule.md)

[Set-AzNetworkManagerSecurityAdminRule](./Set-AzNetworkManagerSecurityAdminRule.md)