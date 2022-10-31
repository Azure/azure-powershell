---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanagerconnectivityconfiguration
schema: 2.0.0
---

# Set-AzNetworkManagerConnectivityConfiguration

## SYNOPSIS
Updates a connectivity configuration.

## SYNTAX

```
Set-AzNetworkManagerConnectivityConfiguration
 -InputObject <PSNetworkManagerConnectivityConfiguration> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerConnectivityConfiguration** cmdlet updates a connectivity configuration.

## EXAMPLES

### Example 1
```powershell
$ConnectivityConfiguration = Get-AzNetworkManagerConnectivityConfiguration -Name "psConnectivityConfig" -NetworkManagerName "psNetworkManager" -ResourceGroupName "psResourceGroup"
$connectivityGroupItem = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup"
$connectivityGroupItem2 = New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/networkGroups/psNetworkGroup2"
[System.Collections.Generic.List[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem]]$connectivityGroup  = @()  
$connectivityGroup.Add($connectivityGroupItem)
$connectivityGroup.Add($connectivityGroupItem2)
$ConnectivityConfiguration.AppliesToGroups = $connectivityGroup
Set-AzNetworkManagerConnectivityConfiguration -InputObject $ConnectivityConfiguration
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
Etag                  :
Id                    : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfig
```
Updates a connectivity configuration's group members.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
The NetworkManagerConnectivityConfiguration

```yaml
Type: PSNetworkManagerConnectivityConfiguration
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityConfiguration

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityConfiguration

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerConnectivityConfiguration](./Get-AzNetworkManagerConnectivityConfiguration.md)

[New-AzNetworkManagerConnectivityConfiguration](./New-AzNetworkManagerConnectivityConfiguration.md)

[Remove-AzNetworkManagerConnectivityConfiguration](./Remove-AzNetworkManagerConnectivityConfiguration.md)