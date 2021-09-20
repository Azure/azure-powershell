
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://docs.microsoft.com/powershell/module/az.rediscache/set-azredisprivateendpointconnectionstatus
schema: 2.0.0
---

# Set-AzRedisPrivateEndpointConnectionStatus

## SYNOPSIS
Set private endpoint connection status on Azure Cache for Redis.

## SYNTAX

### NormalParameterSet (Default)
```
Set-AzRedisPrivateEndpointConnectionStatus [-ResourceGroupName <String>] -Name <String> -PrivateEndpointConnectionName <String> -ConnectionStatus <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRedisPrivateEndpointConnectionStatus** cmdlet sets private endpoint connection status for Azure Cache for Redis.

## EXAMPLES

### Example 1: Set a private endpoint connection (It only support "rejected")
```
PS C:\>Set-AzRedisPrivateEndpointConnectionStatus -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45" -ConnectionStatus "Rejected"
```

This cmdlet sets a private endpoint connection for Azure Cache for Redis.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used to communicate with Azure.

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
Name of redis cache.

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
Name of resource group in which cache exists.

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

### -PrivateEndpointConnectionName
Name of private endpoint connection.

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

### -ConnectionStatus
The connection status of a private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Allowed value: Rejected
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Remove-AzRedisPrivateEndpointConnection](./Remove-AzRedisPrivateEndpointConnection.md)

[Get-AzRedisPrivateEndpointConnection](./Get-AzRedisPrivateEndpointConnection.md)
