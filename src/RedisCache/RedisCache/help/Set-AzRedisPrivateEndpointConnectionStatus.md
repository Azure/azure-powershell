
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://docs.microsoft.com/powershell/module/az.rediscache/set-azredisprivateendpointconnectionstatus
schema: 2.0.0
---

# Set-AzRedisPrivateEndpointConnectionStatus

## SYNOPSIS
Set Private Endpoint Connection Status from a Redis Cache.

## SYNTAX

### NormalParameterSet (Default)
```
Set-AzRedisPrivateEndpointConnectionStatus [-ResourceGroupName <String>] -Name <String> -PrivateEndpointConnectionName <String> -ConnectionStatus <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRedisPrivateEndpointConnectionStatus** cmdlet will set private endpoint connection status for an Azure Redis Cache.

## EXAMPLES

### Example 1: Set a private endpoint connection (It only support "rejected")
```
PS C:\>Set-AzRedisPrivateEndpointConnectionStatus -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45" -ConnectionStatus "Rejected"
```

This command sets a private endpoint connection for an Azure Redis cache.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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
Name of Private Endpoint Connection.

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
Connection Status of Private Endpoint Connection.

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
