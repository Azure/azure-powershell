
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: [Get-AzRedisPrivateEndpointConnection](./Get-AzRedisPrivateEndpointConnection)
schema: 2.0.0
---

# Get-AzRedisPrivateEndpointConnection

## SYNOPSIS
Get Private Endpoint Connection from a Redis Cache.

## SYNTAX

### NormalParameterSet (Default)
```
Get-AzRedisPrivateEndpointConnection [-ResourceGroupName <String>] -Name <String> [-PrivateEndpointConnectionName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
If **PrivateEndpointConnectionName** parameter if provided, **Get-AzRedisPrivateEndpointConnection** cmdlet gets detail about the specified private endpoint connection on Azure Redis Cache. If only **Name** is specified this operation gets all private endpoint connections available on that Redis Cache.


## EXAMPLES

### Example 1: Get a private endpoint connection
```
PS C:\>Get-AzRedisPrivateEndpointConnection -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45"

		ResourceGroupName					:		myGroup
		Name								:		myCache
		PrivateEndpointConnectionName		:		MyPrivateEndpoint.abcd123e45	
		ConnectionStatus					:		Approved
```

This command gets a private endpoint connection named privateDemo.abcd1234e56 from Redis Cache named mycache. 

### Example 2: Get all private endpoint connections
```
PS C:\>Remove-AzRedisPrivateEndpointConnection -Name "mycache"



```

This command gets all private endpoint connections from Redis Cache named mycache.

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



### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Remove-AzRedisPrivateEndpointConnection](./Remove-AzRedisPrivateEndpointConnection.md)

[Set-AzRedisPrivateEndpointConnectionStatus](./Set-AzRedisPrivateEndpointConnectionStatus.md)
