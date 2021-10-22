---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagerconnectivityconfiguration
schema: 2.0.0
---

# Get-AzNetworkManagerConnectivityConfiguration

## SYNOPSIS
Gets a connectivity configuration in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerConnectivityConfiguration [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerConnectivityConfiguration -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerConnectivityConfiguration** cmdlet gets one or more connectivity configurations in a network manager.


## EXAMPLES

### Example 1
```powershell
Expand
PS C:\> Get-AzNetworkManagerConnectivityConfiguration  -Name "TestConn" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"

Name                  : TestNMName
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsof
                        t.Network/networkManagers/TestNMName/connectivityConfigurations/TestConn
DisplayName           : Sample Config Name
Description           :
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
ConnectivityTopology  : HubAndSpoke
DeleteExistingPeering : True
IsGlobal              : True
Hubs                  : [
                          {
                            "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/hub",
                            "ResourceType": "Microsoft.Network/virtualNetworks"
                          }
                        ]
AppliesToGroups       : [
                          {
                            "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng",
                            "UseHubGateway": "True",
                            "IsGlobal": "True",
                            "GroupConnectivity": "None"
                          }
                        ]
DeleteExistingPeering : True
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-17T21:13:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-17T21:13:08"
                        }
```

### Example 2
```powershell
NoExpand
PS C:\> Get-AzNetworkManagerConnectivityConfiguration -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"

Name                  : TestNMName
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsof
                        t.Network/networkManagers/TestNMName/connectivityConfigurations/TestConn
DisplayName           : Sample Config Name
Description           :
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
ConnectivityTopology  : HubAndSpoke
DeleteExistingPeering : True
IsGlobal              : True
Hubs                  : [
                          {
                            "ResourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/hub",
                            "ResourceType": "Microsoft.Network/virtualNetworks"
                          }
                        ]
AppliesToGroups       : [
                          {
                            "NetworkGroupId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/testng",
                            "UseHubGateway": "True",
                            "IsGlobal": "True",
                            "GroupConnectivity": "None"
                          }
                        ]
DeleteExistingPeering : True
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-17T21:13:05",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-17T21:13:08"
                        }
```

{{ Add example description here }}

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
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityConfiguration

## NOTES

## RELATED LINKS

[New-AzNetworkManagerConnectivityConfiguration](./New-AzNetworkManagerConnectivityConfiguration.md)

[Remove-AzNetworkManagerConnectivityConfiguration](./Remove-AzNetworkManagerConnectivityConfiguration.md)

[Set-AzNetworkManagerConnectivityConfiguration](./Set-AzNetworkManagerConnectivityConfiguration.md)