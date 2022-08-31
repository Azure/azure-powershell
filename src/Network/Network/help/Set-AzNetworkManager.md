---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanager
schema: 2.0.0
---

# Set-AzNetworkManager

## SYNOPSIS
Updates a network manager..

## SYNTAX

```
Set-AzNetworkManager -InputObject <PSNetworkManager> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManager** cmdlet updates a network manager.

## EXAMPLES

### Example 1
```powershell
$networkManager = Get-AzNetworkManager -ResourceGroupName "psResourceGroup" -Name "psNetworkManager"
$networkManager.Description = "updated description"
Set-AzNetworkManager -InputObject $networkManager
```
```output
Location                        : westus
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {Connectivity, SecurityAdmin}
NetworkManagerScopeAccessesText : [
                                    "Connectivity",
                                    "SecurityAdmin"
                                  ]
NetworkManagerScopesText        : {
                                    "ManagementGroups": [
                                      "/providers/Microsoft.Management/managementGroups/PowerShellTest"
                                    ],
                                    "Subscriptions": [
                                      "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
                                    ]
                                  }
TagsTable                       :
DisplayName                     :
Description                     : updated description
Type                            : Microsoft.Network/networkManagers
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText                  : {
                                    "CreatedBy": "jaredgorthy@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2022-08-07T04:12:51.7463424Z",
                                    "LastModifiedBy": "jaredgorthy@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2022-08-08T00:50:28.6707606Z"
                                  }
Name                            : psNetworkManager
Etag                            :
Id                              : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
```
Example to update the description of a network manager.

### Example 2
```powershell
$networkManager = Get-AzNetworkManager -ResourceGroupName "psResourceGroup" -Name "psNetworkManager"
$access  = @("Connectivity", "SecurityAdmin")
$networkManager.NetworkManagerScopeAccesses = $access
Set-AzNetworkManager -InputObject $networkManager
```
```output
Location                        : westus
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {Connectivity, SecurityAdmin}
NetworkManagerScopeAccessesText : [
                                    "Connectivity",
                                    "SecurityAdmin"
                                  ]
NetworkManagerScopesText        : {
                                    "ManagementGroups": [
                                      "/providers/Microsoft.Management/managementGroups/PowerShellTest"
                                    ],
                                    "Subscriptions": [
                                      "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
                                    ]
                                  }
TagsTable                       :
DisplayName                     :
Description                     : updated description
Type                            : Microsoft.Network/networkManagers
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText                  : {
                                    "CreatedBy": "jaredgorthy@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2022-08-07T04:12:51.7463424Z",
                                    "LastModifiedBy": "jaredgorthy@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2022-08-08T00:52:45.0100913Z"
                                  }
Name                            : psNetworkManager
Etag                            :
Id                              : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
```
Updates a network manager scope access.

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
The Network Manager

```yaml
Type: PSNetworkManager
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## NOTES

## RELATED LINKS
[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)