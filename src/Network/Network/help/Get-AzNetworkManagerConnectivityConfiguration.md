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
Get-AzNetworkManagerConnectivityConfiguration -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -Name "psConnectivityConfig"
```
```output
ConnectivityTopology  : HubAndSpoke
Hubs                  : {/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub}
DeleteExistingPeering : True
IsGlobal              : False
AppliesToGroups       : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup,
                        /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2}
AppliesToGroupsText   : [
                          {
                            "NetworkGroupId":
                        "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          },
                          {
                            "NetworkGroupId":
                        "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          }
                        ]
HubsText              : [
                          {
                            "ResourceId": "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub",
                            "ResourceType": "Microsoft.Network/virtualNetworks"
                          }
                        ]
DisplayName           :
Description           :
Type                  : Microsoft.Network/networkManagers/connectivityConfigurations
ProvisioningState     : Succeeded
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "jaredgorthy@microsoft.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2022-08-07T04:37:43.1186543Z",
                          "LastModifiedBy": "jaredgorthy@microsoft.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2022-08-08T00:58:41.1751638Z"
                        }
Name                  : psConnectivityConfig
Etag                  : "02002303-0000-0700-0000-62f05fc10000"
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfig
```
Gets a connectivity configuration in a network manager.

### Example 2
```powershell
Get-AzNetworkManagerConnectivityConfiguration -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager"
```
```output
ConnectivityTopology  : HubAndSpoke
Hubs                  : {/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub}
DeleteExistingPeering : True
IsGlobal              : False
AppliesToGroups       : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup,
                        /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2}
AppliesToGroupsText   : [
                          {
                            "NetworkGroupId":
                        "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          },
                          {
                            "NetworkGroupId":
                        "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          }
                        ]
HubsText              : [
                          {
                            "ResourceId": "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884/resourceGroups/jaredgorthy-PowerShellTestResources/providers/Microsoft.Network/virtualNetworks/powerShellTestVnetHub",
                            "ResourceType": "Microsoft.Network/virtualNetworks"
                          }
                        ]
DisplayName           :
Description           :
Type                  : Microsoft.Network/networkManagers/connectivityConfigurations
ProvisioningState     : Succeeded
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "jaredgorthy@microsoft.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2022-08-07T04:37:43.1186543Z",
                          "LastModifiedBy": "jaredgorthy@microsoft.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2022-08-08T00:58:41.1751638Z"
                        }
Name                  : psConnectivityConfig
Etag                  : "02002303-0000-0700-0000-62f05fc10000"
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfig

ConnectivityTopology  : Mesh
Hubs                  : {}
DeleteExistingPeering : True
IsGlobal              : False
AppliesToGroups       : {/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup}
AppliesToGroupsText   : [
                          {
                            "NetworkGroupId":
                        "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup",
                            "UseHubGateway": "False",
                            "IsGlobal": "False",
                            "GroupConnectivity": "None"
                          }
                        ]
HubsText              : []
DisplayName           :
Description           :
Type                  : Microsoft.Network/networkManagers/connectivityConfigurations
ProvisioningState     : Succeeded
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "jaredgorthy@microsoft.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2022-08-07T04:43:00.9075845Z",
                          "LastModifiedBy": "jaredgorthy@microsoft.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2022-08-07T04:43:00.9075845Z"
                        }
Name                  : psConnectivityConfigMesh
Etag                  : "010010af-0000-0700-0000-62ef42d50000"
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfigMesh
```
Gets all connectivity configurations in a network manager.

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
Accept wildcard characters: True
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