---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanageractivesecurityadminrulelist
schema: 2.0.0
---

# Get-AzNetworkManagerActiveSecurityAdminRuleList

## SYNOPSIS
Lists NetworkManager Active Security Admin Rules in network manager.

## SYNTAX

```
Get-AzNetworkManagerActiveSecurityAdminRuleList -NetworkManagerName <String> -ResourceGroupName <String>
 [-Region <System.Collections.Generic.List`1[System.String]>] [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerActiveSecurityAdminRuleList** cmdlet lists NetworkManager Active Security Admin Rules in network manager.

## EXAMPLES

### Example 1
```powershell
PS C:\> [System.Collections.Generic.List[String]]$regions = @()  
PS C:\> $regions.Add("centraluseuap")
PS C:\> Get-AzNetworkManagerActiveSecurityAdminRuleList -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -Region $regions -SkipToken "FakeSkipToken"

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
                "Region": "eastus2euap",
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
                        "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/testvnet"
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
Accept wildcard characters: False
```

### -Region
List of regions.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
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

### -SkipToken
SkipToken.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerActiveSecurityAdminRuleListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerActiveConnectivityConfigurationList](./Get-AzNetworkManagerActiveConnectivityConfigurationList.md)

[Get-AzNetworkManagerActiveConnectivityConfigurationList](./Get-AzNetworkManagerActiveConnectivityConfigurationList.md)