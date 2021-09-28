---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version:
schema: 2.0.0
---

# Get-AzRedisPrivateEndpointConnection

## SYNOPSIS
Get Private Endpoint Connection from a Redis Cache.

## SYNTAX

```
Get-AzRedisPrivateEndpointConnection [-ResourceGroupName <String>] -Name <String>
 -PrivateEndpointConnectionName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
**Get-AzRedisPrivateEndpointConnection** cmdlet get details about the specified private endpoint connection on Azure Cache for Redis.

## EXAMPLES

### Example 1: Get a private endpoint connection
```powershell
PS C:\> Get-AzRedisPrivateEndpointConnection -Name "mycache" -PrivateEndpointConnectionName "MyPrivateEndpoint.abcd123e45"

		ResourceGroupName               : myGroup
		Name                            : myCache
		PrivateEndpointConnectionName   : MyPrivateEndpoint.abcd123e45	
		ConnectionStatus                : Approved
```

This cmdlet gets a private endpoint connection named **privateDemo.abcd1234e56** from Azure Cache for Redis named **mycache**. 

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisPrivateEndpoint

## NOTES

## RELATED LINKS

[Remove-AzRedisPrivateEndpointConnection](./Remove-AzRedisPrivateEndpointConnection.md)

[Set-AzRedisPrivateEndpointConnectionStatus](./Set-AzRedisPrivateEndpointConnectionStatus.md)
