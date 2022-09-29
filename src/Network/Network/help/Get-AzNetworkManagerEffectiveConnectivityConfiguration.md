---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagereffectiveconnectivityconfiguration
schema: 2.0.0
---

# Get-AzNetworkManagerEffectiveConnectivityConfiguration

## SYNOPSIS
Lists NetworkManager Effective Connectivity Configurations applied on a virtual networks.

## SYNTAX

```
Get-AzNetworkManagerEffectiveConnectivityConfiguration -VirtualNetworkName <String>
 -VirtualNetworkResourceGroupName <String> [-SkipToken <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerEffectiveConnectivityConfiguration** cmdlet lists NetworkManager Effective Connectivity Configurations applied on a virtual network.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerEffectiveConnectivityConfiguration -VirtualNetworkName "TestVnet" -VirtualNetworkResourceGroupName "TestRG" -SkipToken "FakeSkipToken"
```
```output
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
Lists NetworkManager Effective Connectivity Configurations applied on a virtual network 'TestVnet'.

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerEffectiveConnectivityConfigurationListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerEffectiveSecurityAdminRule](./Get-AzNetworkManagerEffectiveSecurityAdminRule.md)