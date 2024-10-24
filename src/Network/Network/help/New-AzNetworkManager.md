---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanager
schema: 2.0.0
---

# New-AzNetworkManager

## SYNOPSIS
Creates a network manager.

## SYNTAX

```
New-AzNetworkManager -Name <String> -ResourceGroupName <String> -Location <String> [-Description <String>]
 [-Tag <Hashtable>] -NetworkManagerScope <PSNetworkManagerScopes>
 -NetworkManagerScopeAccess <NetworkManagerScopeAccessType[]> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManager** cmdlet creates a network manager.

## EXAMPLES

### Example 1: Creates a connectivity network manager.
```powershell
$subscriptions  = @("/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884")
$managementGroups  = @("/providers/Microsoft.Management/managementGroups/PowerShellTest")
$scope = New-AzNetworkManagerScope -Subscription $subscriptions -ManagementGroup $managementGroups
$access  = @("Connectivity")
New-AzNetworkManager -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location "westus"
```

```output
Location                        : westus
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {Connectivity}
NetworkManagerScopeAccessesText : [
                                    "Connectivity"
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
Description                     :
Type                            : Microsoft.Network/networkManagers
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText                  : {
                                    "CreatedBy": "jaredgorthy@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2022-08-07T04:12:51.7463424Z",
                                    "LastModifiedBy": "jaredgorthy@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2022-08-07T04:12:51.7463424Z"
                                  }
Name                            : psNetworkManager
Etag                            :
Id                              : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
```

Creates a network manager with connectivity access in West US, with a subscription and management group in scope.

### Example 2: Creates a security admin network manager.
```powershell
$subscriptions  = @("/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884")
$scope = New-AzNetworkManagerScope -Subscription $subscriptions
$access  = @("SecurityAdmin")
New-AzNetworkManager -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location "westus"
```

```output
Location                        : westus
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {"SecurityAdmin"}
NetworkManagerScopeAccessesText : [
                                    "SecurityAdmin"
                                  ]
NetworkManagerScopesText        : {
                                    "Subscriptions": [
                                      "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884"
                                    ]
                                  }
TagsTable                       :
DisplayName                     :
Description                     :
Type                            : Microsoft.Network/networkManagers
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText                  : {
                                    "CreatedBy": "jaredgorthy@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2022-08-07T04:12:51.7463424Z",
                                    "LastModifiedBy": "jaredgorthy@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2022-08-07T04:12:51.7463424Z"
                                  }
Name                            : psNetworkManager
Etag                            :
Id                              : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/pr
                                  oviders/Microsoft.Network/networkManagers/psNetworkManager
```

Creates a network manager with security administrator access in West US, with a subscription in scope.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description.

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
location.

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerScope
Network Manager Scope

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerScopeAccess
Network Manager Scope Access.

```yaml
Type: Microsoft.Azure.Commands.Network.NewAzNetworkManagerCommand+NetworkManagerScopeAccessType[]
Parameter Sets: (All)
Aliases:
Accepted values: SecurityAdmin, Connectivity, Routing, SecurityUser

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### System.Collections.Hashtable

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## NOTES

## RELATED LINKS

[New-AzNetworkManagerScope](./New-AzNetworkManagerScope.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)