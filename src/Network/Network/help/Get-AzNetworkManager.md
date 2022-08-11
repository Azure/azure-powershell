---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanager
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
The **Get-AzNetworkManager** cmdlet gets one or more network managers in a resource group.

## EXAMPLES

### Example 1: Retrieve a network manager
```powershell
Get-AzNetworkManager -ResourceGroupName "TestResourceGroup" -Name "TestNM"
```
```output
DisplayName                     :
Description                     :
Location                        : eastus2euap
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/provider
                                  s/Microsoft.Network/networkManagers/TestNM
Type                            : Microsoft.Network/networkManagers
Tag                             : {}
ProvisioningState               : Succeeded
NetworkManagerScopeAccesses     : [
                                    "SecurityAdmin",
                                    "SecurityUser"
                                  ]
NetworkManagerScopes            : {
                                    "ManagementGroups": [],
                                    "Subscriptions": [
                                      "/subscriptions/00000000-0000-0000-0000-000000000000"
                                    ]
                                  }
SystemData                      : {
                                    "CreatedBy": "user@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2021-10-05T04:15:42",
                                    "LastModifiedBy": "user@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2021-10-05T04:15:42"
                                  }
Name                            : TestNM
Etag                            : W/"00000000-0000-0000-0000-000000000000"
```
Retrieve a network manager.

### Example 2: List all network managers in a resource group
```powershell
Get-AzNetworkManager -ResourceGroupName "TestResourceGroup"
```
```output
DisplayName                     :
Description                     :
Location                        : eastus2euap
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/provider
                                  s/Microsoft.Network/networkManagers/TestNM
Type                            : Microsoft.Network/networkManagers
Tag                             : {}
ProvisioningState               : Succeeded
NetworkManagerScopeAccesses     : [
                                    "SecurityAdmin",
                                    "SEcurityUser"
                                  ]
NetworkManagerScopes            : {
                                    "ManagementGroups": [],
                                    "Subscriptions": [
                                      "/subscriptions/00000000-0000-0000-0000-000000000000"
                                    ]
                                  }
SystemData                      : {
                                    "CreatedBy": "user@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2021-10-05T04:15:42",
                                    "LastModifiedBy": "user@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2021-10-05T04:15:42"
                                  }
Name                            : TestNM
Etag                            : W/"00000000-0000-0000-0000-000000000000"
```
List all network managers in a resource group.

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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: String
Parameter Sets: Expand
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## NOTES

## RELATED LINKS
