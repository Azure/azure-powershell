---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagersecurityadminrule
schema: 2.0.0
---

# Get-AzNetworkManagerSecurityAdminRule

## SYNOPSIS
Gets a security admin rule in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerSecurityAdminRule [-Name <String>] -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerSecurityAdminRule -Name <String> -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerSecurityAdminRule** cmdlets gets security admin rule in a network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerSecurityAdminRule  -Name "testRule" -RuleCollectionName "TestRC" -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule
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
Gets a security admin rule in a rule rollection.

### Example 2
```powershell
Get-AzNetworkManagerSecurityAdminRule  -RuleCollectionName "TestRC" -SecurityAdminConfigurationName "TestSecConfig" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"
```
```output
Name                  : testRule
Description           : Description
Type                  : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule
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
Type                  : Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestSecConfig/ruleCollections/TestRC/rules/testRule2
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
Gets all rules within a security admin rule collection.

## PARAMETERS

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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: String
Parameter Sets: Expand
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule

## NOTES

## RELATED LINKS
[New-AzNetworkManagerSecurityAdminRule](./New-AzNetworkManagerSecurityAdminRule.md)

[Remove-AzNetworkManagerSecurityAdminRule](./Remove-AzNetworkManagerSecurityAdminRule.md)

[Set-AzNetworkManagerSecurityAdminRule](./Set-AzNetworkManagerSecurityAdminRule.md)