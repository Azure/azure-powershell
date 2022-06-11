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
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId <String> -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId "SDKTestMG" -Name "testsc"

NetworkManagerId  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSTestResources/providers/Micros
                    oft.Network/networkManagers/PSTestNM
ConnectionState   : Pending
Description       : SampleDescription
Type              : Microsoft.Network/networkManagers/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : testsc
Etag              :
Id                : /providers/Microsoft.Management/managementGroups/SDKTestMG/providers/Microsoft.Network/networkManagerConne
                    ctions/testsc
```

```powershell
PS C:\> Get-AzNetworkManagerManagementGroupConnection -ManagementGroupId "SDKTestMG"

NetworkManagerId  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PSTestResources/providers/Micros
                    oft.Network/networkManagers/PSTestNM
ConnectionState   : Pending
Description       : SampleDescription
Type              : Microsoft.Network/networkManagers/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : testsc
Etag              :
Id                : /providers/Microsoft.Management/managementGroups/SDKTestMG/providers/Microsoft.Network/networkManagerConne
                    ctions/testsc
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

### -ManagementGroupId
The management group ID.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: True
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