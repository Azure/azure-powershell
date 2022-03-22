---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagerscopeconnection
schema: 2.0.0
---

# Get-AzNetworkManagerScopeConnection

## SYNOPSIS
Gets a scope connection in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerScopeConnection [-Name <String>] -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
 
```

### Expand
```
Get-AzNetworkManagerScopeConnection -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerScopeConnection** cmdlet gets one or more scope connections in a network manager.

## EXAMPLES

### Example 1: Retrieve a scope connection
```powershell
PS C:\> Get-AzNetworkManagerScopeConnection -ResourceGroupName "TestResourceGroup" -NetworkManagerName "TestNM" -Name "testsc"

TenantId          : 00000000-0000-0000-0000-000000000000
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000
ConnectionState   : Pending
Description       : SampleDescription
DisplayName       :
Type              : Microsoft.Network/networkManagers/scopeConnections
ProvisioningState :
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "user@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-03-16T03:01:26.397158Z",
                      "LastModifiedBy": "user@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-03-16T03:01:26.397158Z"
                    }
Name              : testsc
Etag              :
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/providers/Microsoft.Netwo
                    rk/networkManagers/TestNM/scopeConnections/testsc
```

### Example 2: List scope connections
```powershell
PS C:\> Get-AzNetworkManagerScopeConnection -ResourceGroupName "TestResourceGroup" -NetworkManagerName "TestNM" 

TenantId          : 00000000-0000-0000-0000-000000000000
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000000
ConnectionState   : Pending
Description       : SampleDescription
DisplayName       :
Type              : Microsoft.Network/networkManagers/scopeConnections
ProvisioningState :
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "user@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-03-16T03:01:26.397158Z",
                      "LastModifiedBy": "user@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-03-16T03:01:26.397158Z"
                    }
Name              : testsc
Etag              :
Id                : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/providers/Microsoft.Netwo
                    rk/networkManagers/TestNM/scopeConnections/testsc
```

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
Accept wildcard characters: False
```

```yaml
Type: String
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
Type: String
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
Type: String
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopeConnection

## NOTES

## RELATED LINKS
[New-AzNetworkManagerScopeConnection](./New-AzNetworkManagerScopeConnection.md)

[Remove-AzNetworkManagerScopeConnection](./Remove-AzNetworkManagerScopeConnection.md)

[Set-AzNetworkManagerScopeConnection](./Set-AzNetworkManagerScopeConnection.md)