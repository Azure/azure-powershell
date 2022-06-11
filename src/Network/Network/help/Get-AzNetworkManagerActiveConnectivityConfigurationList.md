---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanageractiveconnectivityconfigurationlist
schema: 2.0.0
---

# Get-AzNetworkManagerActiveConnectivityConfigurationList

## SYNOPSIS
Lists NetworkManager Active Connectivity Configurations in network manager.

## SYNTAX

```
Get-AzNetworkManagerActiveConnectivityConfigurationList -NetworkManagerName <String>
 -ResourceGroupName <String> [-Region <System.Collections.Generic.List`1[System.String]>] [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerActiveConnectivityConfigurationList** cmdlet lists NetworkManager Active Connectivity Configurations in network manager .

## EXAMPLES

### Example 1
```powershell
PS C:\> [System.Collections.Generic.List[String]]$regions = @()  
PS C:\> $regions.Add("centraluseuap")
PS C:\> Get-AzNetworkManagerActiveConnectivityConfigurationList -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -Region $regions -SkipToken "FakeSkipToken"
 
 Value     : [
              {
                "Region": "centraluseuap",
                "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/connectivityConfigurations/TestConn",
                "DisplayName": "Sample Config Name",
                "Description": "",
                "ConnectivityTopology": "HubAndSpoke",
                "Hubs": [
                  {
                    "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/provide
            rs/Microsoft.Network/virtualNetworks/hub",
                    "ResourceType": "Microsoft.Network/virtualNetworks"
                  }
                ],
                "IsGlobal": "False",
                "AppliesToGroups": [
                  {
                    "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/pro
            viders/Microsoft.Network/networkManagers/TestNMName/networkGroups/testNG",
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerActiveConnectivityConfigurationListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerActiveSecurityAdminRuleList](./Get-AzNetworkManagerActiveSecurityAdminRuleList.md)

[Get-AzNetworkManagerActiveSecurityUserRuleList](./Get-AzNetworkManagerActiveSecurityUserRuleList.md)
