---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagerscopeconnection
schema: 2.0.0
---

# Set-AzNetworkManagerScopeConnection

## SYNOPSIS
Update a network manager scope connection.

## SYNTAX

```
Set-AzNetworkManagerScopeConnection -InputObject <PSNetworkManagerScopeConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerScopeConnection** cmdlet updates a network manager scope connection.

## EXAMPLES

### Example 1
```powershell
$scopeConnection = Get-AzNetworkManagerScopeConnection -ResourceGroupName "psResourceGroup" -NetworkManagerName "psNetworkManager" -Name "mgConnection"
$scopeConnection.description = "new description"
Set-AzNetworkManagerScopeConnection -InputObject $scopeConnection
```

```output
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
ResourceId        : /providers/Microsoft.Management/managementGroups/newMG
ConnectionState   : Pending
DisplayName       :
Description       : new description
Type              : Microsoft.Network/networkManagers/scopeConnections
ProvisioningState :
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-08T00:08:30.7250851Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-08T00:08:30.7250851Z"
                    }
Name              : mgConnection
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/scopeConnections/mgConnection
```

Updates a scope connection description.

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

### -InputObject
The NetworkManagerScopeConnection

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopeConnection
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopeConnection

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopeConnection

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerScopeConnection](./Get-AzNetworkManagerScopeConnection.md)

[New-AzNetworkManagerScopeConnection](./New-AzNetworkManagerScopeConnection.md)

[Remove-AzNetworkManagerScopeConnection](./Remove-AzNetworkManagerScopeConnection.md)
