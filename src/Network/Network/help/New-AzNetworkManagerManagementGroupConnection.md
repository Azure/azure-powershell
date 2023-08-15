---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagermanagementgroupconnection
schema: 2.0.0
---

# New-AzNetworkManagerManagementGroupConnection

## SYNOPSIS
Creates a network manager management group connection.

## SYNTAX

```
New-AzNetworkManagerManagementGroupConnection -ManagementGroupId <String> -Name <String>
 -NetworkManagerId <String> [-Description <String>] [-AsJob] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerManagementGroupConnection** cmdlet creates a network manager management group connection.

## EXAMPLES

### Example 1
```powershell
$networkManagerId = "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager"
$managementGroupId = "newMG"
New-AzNetworkManagerManagementGroupConnection -ManagementGroupId $managementGroupId -Name "psConnection" -NetworkManagerId $networkManagerId -Description "sample description"
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

Creates a network manager management group connection.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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
Do not ask for confirmation if you want to overwrite a resource.

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

### -ManagementGroupId
The management group ID.

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

### -NetworkManagerId
Network Manager Id of the resource you'd like to manage.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnection

## NOTES

## RELATED LINKS

[Set-AzNetworkManagerManagementGroupConnection](./Set-AzNetworkManagerManagementGroupConnection.md)

[Get-AzNetworkManagerManagementGroupConnection](./Get-AzNetworkManagerManagementGroupConnection.md)

[Remove-AzNetworkManagerManagementGroupConnection](./Remove-AzNetworkManagerManagementGroupConnection.md)