---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagereffectiveconnectivityconfigurationlist
schema: 2.0.0
---

# Get-AzNetworkManagerEffectiveConnectivityConfigurationList

## SYNOPSIS
Lists NetworkManager Effective Connectivity Configurations applied on a virtual networks.

## SYNTAX

```
Get-AzNetworkManagerEffectiveConnectivityConfigurationList -VirtualNetworkName <String>
 -ResourceGroupName <String> [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerEffectiveConnectivityConfigurationList** cmdlet lists NetworkManager Effective Connectivity Configurations applied on a virtual network.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzNetworkManagerEffectiveConnectivityConfigurationList -VirtualNetworkName "TestVnet" -ResourceGroupName "TestRG" -SkipToken "FakeSkipToken"
 
 Value     : [
              {
                "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/connectivityConfigurations/TestConn",
                "DisplayName": "Sample Config Name",
                "Description": "",
                "ConnectivityTopology": "HubAndSpoke",
                "Hubs": [
                  {
                    "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/hub",
                    "ResourceType": "Microsoft.Network/virtualNetworks"
                  }
                ],
                "IsGlobal": "False",
                "AppliesToGroups": [
                  {
                    "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testNG",
                    "UseHubGateway": "False",
                    "IsGlobal": "True",
                    "GroupConnectivity": "None"
                  }
                ],
                "ProvisioningState": "Succeeded",
                "DeleteExistingPeering": "True",
                "ConfigurationGroups": [
                  {
                    "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testNG",
                    "DisplayName": "DISplayName",
                    "Description": "SampleDESCRIption",
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

### -VirtualNetworkName
The vnet name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerEffectiveConnectivityConfigurationListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerEffectiveSecurityAdminRuleList](./Get-AzNetworkManagerEffectiveSecurityAdminRuleList.md)