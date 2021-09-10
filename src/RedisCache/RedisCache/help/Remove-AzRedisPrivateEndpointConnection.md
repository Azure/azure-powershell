
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: [Remove-AzRedisPrivateEndpointConnection](./Remove-AzRedisPrivateEndpointConnection)
schema: 2.0.0
---

# Remove-AzRedisPrivateEndpointConnection

## SYNOPSIS
Remove a Private Endpoint Connection from a Redis Cache.

## SYNTAX

### NormalParameterSet (Default)
```
Remove-AzRedisPrivateEndpointConnection [-ResourceGroupName <String>] -Name <String> -PrivateEndpointConnectionName <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a private endpoint connection from a Redis Cache.

## EXAMPLES

### Example 1: Remove a private endpoint connection and return the result
```
PS C:\>Remove-AzRedisPrivateEndpointConnection -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45" -Force -PassThru
True
```

This command removes a private endpoint connection named MyPrivateEndpoint.abcd123e45 from Redis Cache named mycache and displays whether the operation is successful. 

### Example 2: Remove a private endpoint connection and do not display the result
```
PS C:\>Remove-AzRedisPrivateEndpointConnection -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45" -Force
```

This command removes a private endpoint connection named MyPrivateEndpoint.abcd123e45 from Redis Cache named mycache.
Because the *PassThru* parameter is not specified, the result of the operation is not displayed.

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

### -Force
Forces the command to run without asking for user confirmation.

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

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
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

[Get-AzRedisPrivateEndpointConnection](./Get-AzRedisPrivateEndpointConnection.md)

[Set-AzRedisPrivateEndpointConnectionStatus](./Set-AzRedisPrivateEndpointConnectionStatus.md)
