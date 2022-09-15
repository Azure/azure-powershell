---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanagersubscriptionconnection
schema: 2.0.0
---

# Set-AzNetworkManagerSubscriptionConnection

## SYNOPSIS
Update a network manger subscription connection.

## SYNTAX

```
Set-AzNetworkManagerSubscriptionConnection -InputObject <PSNetworkManagerConnection>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerSubscriptionConnection** cmdlet update a network manger subscription connection.

## EXAMPLES

### Example 1
```powershell
$networkManagerConnection = Get-AzNetworkManagerSubscriptionConnection -Name "subConnection"
$networkManagerConnection.description = " new description"
Set-AzNetworkManagerSubscriptionConnection -InputObject $networkManagerConnection
```
```output
NetworkManagerId  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
ConnectionState   : Conflict
DisplayName       :
Description       :  new description
Type              : Microsoft.Network/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : subConnection
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/providers/Microsoft.Network/networkManagerConnections/subConnection
```
Updates a network manger subscription connection description.

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
The NetworkManagerSubscriptionConnection

```yaml
Type: PSNetworkManagerConnection
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnection

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnection

## NOTES

## RELATED LINKS

[Remove-AzNetworkManagerManagementGroupConnection](./Remove-AzNetworkManagerManagementGroupConnection.md)

[Get-AzNetworkManagerManagementGroupConnection](./Get-AzNetworkManagerManagementGroupConnection.md)

[New-AzNetworkManagerManagementGroupConnection](./New-AzNetworkManagerManagementGroupConnection.md)