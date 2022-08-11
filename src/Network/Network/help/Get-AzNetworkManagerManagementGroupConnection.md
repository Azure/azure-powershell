---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagermanagementgroupconnection
schema: 2.0.0
---

# Get-AzNetworkManagerManagementGroupConnection

## SYNOPSIS
Gets a network manager management group connection.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerManagementGroupConnection** cmdlet gets a network manager connection on a management group.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId "newMG" -Name "psConnection"
```
```output
NetworkManagerId  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
ConnectionState   : Pending
DisplayName       :
Description       : sample description
Type              : Microsoft.Network/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : psConnection
Etag              :
Id                : /providers/Microsoft.Management/managementGroups/newMG/providers/Microsoft.Network/networkManagerConnections/psConnection
```
Gets a network manager connection on management group 'newMG'.

### Example 2
```powershell
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId "newMG"
```
```output
NetworkManagerId  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/jaredgorthy-testResources/providers/Microsoft.Network/networkManagers/jaredgorthy
ConnectionState   : Pending
DisplayName       :
Description       :
Type              : Microsoft.Network/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : mgConnection
Etag              :
Id                : /providers/Microsoft.Management/managementGroups/newMG/providers/Microsoft.Network/networkManagerConnections/mgConnection

NetworkManagerId  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
ConnectionState   : Pending
DisplayName       :
Description       : sample description
Type              : Microsoft.Network/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : psConnection
Etag              :
Id                : /providers/Microsoft.Management/managementGroups/newMG/providers/Microsoft.Network/networkManagerConnections/psConnection
```
Gets all network manager connections on management group 'newMG'.

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

### -ManagementGroupId
The management group ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnection

## NOTES

## RELATED LINKS

[New-AzNetworkManagerManagementGroupConnection](./New-AzNetworkManagerManagementGroupConnection.md)

[Set-AzNetworkManagerManagementGroupConnection](./Set-AzNetworkManagerManagementGroupConnection.md)

[Remove-AzNetworkManagerManagementGroupConnection](./Remove-AzNetworkManagerManagementGroupConnection.md)