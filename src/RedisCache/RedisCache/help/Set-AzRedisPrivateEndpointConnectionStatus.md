---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version:
schema: 2.0.0
---

# Set-AzRedisPrivateEndpointConnectionStatus

## SYNOPSIS
Set private endpoint connection status on Azure Cache for Redis.

## SYNTAX

```
Set-AzRedisPrivateEndpointConnectionStatus [-ResourceGroupName <String>] -Name <String>
 -PrivateEndpointConnectionName <String> -ConnectionStatus <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRedisPrivateEndpointConnectionStatus** cmdlet sets private endpoint connection status for Azure Cache for Redis.

## EXAMPLES

### Example 1: Set a private endpoint connection (It only support "rejected")
```powershell
PS C:\> Set-AzRedisPrivateEndpointConnectionStatus -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45" -ConnectionStatus "Rejected"
```

This cmdlet sets a private endpoint connection for Azure Cache for Redis.

## PARAMETERS

### -ConnectionStatus
Connection status - Approved, Pending, Rejected

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
Name of Azure redis cache from private endpoint connection status is edited.

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

### -PrivateEndpointConnectionName
Name of private endpoint whose connection status to be edited.

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

### -ResourceGroupName
The resource group name of the private endpoint.

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

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisPrivateEndpoint

## NOTES

## RELATED LINKS

[Remove-AzRedisPrivateEndpointConnection](./Remove-AzRedisPrivateEndpointConnection.md)

[Get-AzRedisPrivateEndpointConnection](./Get-AzRedisPrivateEndpointConnection.md)