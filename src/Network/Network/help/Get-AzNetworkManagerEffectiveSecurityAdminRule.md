---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagereffectivesecurityadminrule
schema: 2.0.0
---

# Get-AzNetworkManagerEffectiveSecurityAdminRule

## SYNOPSIS
Lists NetworkManager Effective Security Admin Rules applied on a virtual networks.

## SYNTAX

```
Get-AzNetworkManagerEffectiveSecurityAdminRule -VirtualNetworkName <String>
 -VirtualNetworkResourceGroupName <String> [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerEffectiveSecurityAdminRule** cmdlet lists NetworkManager Effective Security Admin Rules applied on a virtual network.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerEffectiveSecurityAdminRule -VirtualNetworkName "TestVnet" -VirtualNetworkResourceGroupName "TestRG" -SkipToken "FakeSkipToken"
```
```output
Value     : [
              {
                "DisplayName": "Sample Rule Name",
                "Description": "Description",
                "Protocol": "Tcp",
                "Sources": [
                  {
                    "AddressPrefix": "Internet",
                    "AddressPrefixType": "ServiceTag"
                  }
                ],
                "Destinations": [
                  {
                    "AddressPrefix": "10.0.0.1",
                    "AddressPrefixType": "IPPrefix"
                  }
                ],
                "SourcePortRanges": [
                  "100"
                ],
                "DestinationPortRanges": [
                  "99"
                ],
                "Access": "Allow",
                "Priority": 100,
                "Direction": "Inbound",
                "ProvisioningState": "Succeeded",
                "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/TestAdminConfig/ruleCollections/TestRuleCollection/rules/TestRule",
                "ConfigurationDisplayName": "sample Config DisplayName",
                "ConfigurationDescription": "DESCription",
                "RuleCollectionDisplayName": "Sample rule Collection displayName",
                "RuleCollectionDescription": "Sample rule Collection Description",
                "RuleCollectionAppliesToGroups": [
                  {
                    "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testNG"
                  }
                ],
                "RuleGroups": [
                  {
                    "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testNG",
                    "DisplayName": "DISplayName",
                    "Description": "SampleConfigDESCRIption",
                    "GroupMembers": [
                      {
                        "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/TestVnet"
                      }
                    ],
                    "ConditionalMembership": "",
                    "ProvisioningState": "Succeeded"
                  }
                ]
              }
            ]
SkipToken :
```

Lists NetworkManager Effective Security Admin Rules applied on a virtual network 'TestVnet'.

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

### -SkipToken
SkipToken.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkName
The vnet name.

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

### -VirtualNetworkResourceGroupName
The resource group name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerEffectiveSecurityAdminRuleListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerEffectiveConnectivityConfiguration](./Get-AzNetworkManagerEffectiveConnectivityConfiguration.md)