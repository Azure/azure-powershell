---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkinterfacetapconfig
schema: 2.0.0
---

# Get-AzNetworkManager

## SYNOPSIS
Gets a network manager in a resource group.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManager [-Name <String>] [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManager -Name <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManager** cmdlet gets one or more virtual networks in a resource group.

## EXAMPLES

### Example 1: Retrieve a network manager
```powershell
Get-AzNetworkManager -ResourceGroupName "TestResourceGroup" -Name "TestNM"

DisplayName                     :
Description                     :
Location                        : eastus2euap
Type                            : Microsoft.Network/networkManagers
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {SecurityAdmin, SecurityUser}
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
NetworkManagerScopeAccessesText : [
                                    "SecurityAdmin",
                                    "SEcurityUser"
                                  ]
NetworkManagerScopesText        : {
                                    "ManagementGroups": [],
                                    "Subscriptions": [
                                      "/subscriptions/00000000-0000-0000-0000-000000000000"
                                    ]
                                  }
SystemDataText                  : {
                                    "CreatedBy": "user@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2021-10-05T04:15:42",
                                    "LastModifiedBy": "user@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2021-10-05T04:15:42"
                                  }
TagsTable                       :
Name                            : TestNM
Etag                            : W/"00000000-0000-0000-0000-000000000000"
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/provider
                                  s/Microsoft.Network/networkManagers/TestNM
```

### Example 2: List network managers
```powershell
Get-AzNetworkManager -ResourceGroupName "TestResourceGroup" -Name "TestNM"

DisplayName                     :
Description                     :
Location                        : eastus2euap
Type                            : Microsoft.Network/networkManagers
Tag                             : {}
NetworkManagerScopes            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes
NetworkManagerScopeAccesses     : {SecurityAdmin, SecurityUser}
ProvisioningState               : Succeeded
SystemData                      : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
NetworkManagerScopeAccessesText : [
                                    "SecurityAdmin",
                                    "SecurityUser"
                                  ]
NetworkManagerScopesText        : {
                                    "ManagementGroups": [],
                                    "Subscriptions": [
                                      "/subscriptions/00000000-0000-0000-0000-000000000000"
                                    ]
                                  }
SystemDataText                  : {
                                    "CreatedBy": "user@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2021-10-05T04:15:42",
                                    "LastModifiedBy": "user@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2021-10-05T04:15:42"
                                  }
TagsTable                       :
Name                            : TestNM
Etag                            : W/"00000000-0000-0000-0000-000000000000"
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/provider
                                  s/Microsoft.Network/networkManagers/TestNM
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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: NoExpand
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Expand
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## NOTES

## RELATED LINKS
[New-AzNetworkManager]()

[Remove-AzNetworkManager]()

[Update-AzNetworkManager]()