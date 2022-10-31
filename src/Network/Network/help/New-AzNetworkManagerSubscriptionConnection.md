---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagersubscriptionconnection
schema: 2.0.0
---

# New-AzNetworkManagerSubscriptionConnection

## SYNOPSIS
Creates a network manager subscription connection.

## SYNTAX

```
New-AzNetworkManagerSubscriptionConnection -Name <String> -NetworkManagerId <String> [-Description <String>]
 [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSubscriptionConnection** cmdlet creates a network manager subscription connection.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerSubscriptionConnection -Name "subConnection" -NetworkManagerId "/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager" -Description "SampleDescription"
```
```output
NetworkManagerId  : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager
ConnectionState   : Pending
DisplayName       :
Description       : SampleDescription
Type              : Microsoft.Network/networkManagerConnections
ProvisioningState :
SystemData        :
SystemDataText    : null
Name              : subConnection
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/providers/Microsoft.Network/networkManagerConnections/subConnection
```
Creates a network manager connection to a subscription.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -Description
Description.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

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
Type: String
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnection

## NOTES

## RELATED LINKS
[Set-AzNetworkManagerManagementGroupConnection](./Set-AzNetworkManagerManagementGroupConnection.md)

[Get-AzNetworkManagerManagementGroupConnection](./Get-AzNetworkManagerManagementGroupConnection.md)

[Remove-AzNetworkManagerManagementGroupConnection](./Remove-AzNetworkManagerManagementGroupConnection.md)