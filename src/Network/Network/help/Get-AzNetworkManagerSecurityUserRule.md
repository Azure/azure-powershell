---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityuserrule
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityUserRule

## SYNOPSIS
Gets a security user rule in a network manager.

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerSecurityUserRule -RuleCollectionName <String> -SecurityUserConfigurationName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerSecurityUserRule -Name <String> -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerSecurityUserRule -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityUserRule** cmdlets gets security user rule in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityUserRule  -Name "testRule" -RuleCollectionName "TestRC" -SecurityUserConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
Protocol              : Tcp
Direction             : Inbound
Sources               : [
                          {
                            "AddressPrefix": "Internet",
                            "AddressPrefixType": "ServiceTag"
                          }
                        ]
Destinations          : [
                          {
                            "AddressPrefix": "10.0.0.1",
                            "AddressPrefixType": "IPPrefix"
                          }
                        ]
SourcePortRanges      : [
                          "100"
                        ]
DestinationPortRanges : [
                          "99"
                        ]
Access                : Allow
Priority              : 100
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }
```

Gets a security user rule in a rule rollection.

### Example 2
```powershell
Get-AzNetworkManagerSecurityUserRule  -RuleCollectionName "TestRC" -SecurityUserConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```

```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
Protocol              : Tcp
Direction             : Inbound
Sources               : [
                          {
                            "AddressPrefix": "Internet",
                            "AddressPrefixType": "ServiceTag"
                          }
                        ]
Destinations          : [
                          {
                            "AddressPrefix": "10.0.0.1",
                            "AddressPrefixType": "IPPrefix"
                          }
                        ]
SourcePortRanges      : [
                          "100"
                        ]
DestinationPortRanges : [
                          "99"
                        ]
Access                : Allow
Priority              : 100
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }

                        Name                  : testRule2
Description           : Description
Type                  : Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityUserConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule2
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
Protocol              : Tcp
Direction             : Inbound
Sources               : [
                          {
                            "AddressPrefix": "Internet",
                            "AddressPrefixType": "ServiceTag"
                          }
                        ]
Destinations          : [
                          {
                            "AddressPrefix": "10.0.0.1",
                            "AddressPrefixType": "IPPrefix"
                          }
                        ]
SourcePortRanges      : [
                          "100"
                        ]
DestinationPortRanges : [
                          "99"
                        ]
Access                : Allow
Priority              : 100
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-18T04:06:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-18T04:06:06"
                        }
```

Gets all rules within a security user rule collection.

## PARAMETERS

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
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
Parameter Sets: ByList, ByName
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
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
NetworkManager SecurityUserRule Id

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: SecurityUserRuleId

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
Parameter Sets: ByList, ByName
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
Parameter Sets: ByList, ByName
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule

## NOTES

## RELATED LINKS

[New-AzNetworkManagerSecurityUserRule](./New-AzNetworkManagerSecurityUserRule.md)

[Remove-AzNetworkManagerSecurityUserRule](./Remove-AzNetworkManagerSecurityUserRule.md)

[Set-AzNetworkManagerSecurityUserRule](./Set-AzNetworkManagerSecurityUserRule.md)