---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://learn.microsoft.com/powershell/module/az.rediscache/get-azrediscacheaccesspolicy
schema: 2.0.0
---

# Get-AzRedisCacheAccessPolicy

## SYNOPSIS
Get the detailed information about Access Policy(s) of the Redis Cache

## SYNTAX

### NormalParameterSet
```
Get-AzRedisCacheAccessPolicy [-ResourceGroupName <String>] -Name <String> [-AccessPolicyName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzRedisCacheAccessPolicy -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CacheObjectParameterSet
```
Get-AzRedisCacheAccessPolicy -TopLevelResourceObject <RedisCacheAttributes> [-AccessPolicyName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
If **AccessPolicyName** parameter provided, **Get-AzRedisCacheAccessPolicy** cmdlet gets details about the specified access policy. If only **Name** is specified this operation gets all access policies of the Redis Cache.

## EXAMPLES

### Example 1: Get information of an access policy
```powershell
Get-AzRedisCacheAccessPolicy -Name "testCache" -AccessPolicyName "testAccessPolicy"
```

This command gets information on access policy named testAccessPolicy from Redis Cache named testCache

### Example 2: Get information of all access policies
```powershell
Get-AzRedisCacheAccessPolicy -Name "testCache"
```

This command gets information on all access policies from Redis Cache named testCache.

## PARAMETERS

### -AccessPolicyName
Name of Access Policy.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet, CacheObjectParameterSet
Aliases:

Required: False
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
Name of Redis Cache.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet
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
Parameter Sets: NormalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
ARM Id of Redis Cache Access Policy

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TopLevelResourceObject
Object of type RedisCacheAttributes

```yaml
Type: Microsoft.Azure.Commands.RedisCache.Models.RedisCacheAttributes
Parameter Sets: CacheObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicy

## NOTES

## RELATED LINKS
