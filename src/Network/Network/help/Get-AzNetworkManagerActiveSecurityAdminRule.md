---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanageractivesecurityadminrule
schema: 2.0.0
---

# Get-AzNetworkManagerActiveSecurityAdminRule

## SYNOPSIS
Lists NetworkManager Active Security Admin Rules in network manager.

## SYNTAX

```
Get-AzNetworkManagerActiveSecurityAdminRule -NetworkManagerName <String> -ResourceGroupName <String>
 [-Region <String[]>] [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerActiveSecurityAdminRule** cmdlet lists NetworkManager Active Security Admin Rules in network manager.

## EXAMPLES

### Example 1
```powershell
$regions = @("centraluseuap")  
Get-AzNetworkManagerActiveSecurityAdminRule -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -Region $regions -SkipToken "FakeSkipToken"
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
Lists NetworkManager Active Security Admin Rules in network manager for region centraluseuap.

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

### -Region
List of regions.

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
Accept wildcard characters: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]	

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerActiveSecurityAdminRuleListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerActiveConnectivityConfiguration](./Get-AzNetworkManagerActiveConnectivityConfiguration.md)
