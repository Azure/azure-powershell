---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://learn.microsoft.com/powershell/module/az.rediscache/remove-azrediscacheaccesspolicy
schema: 2.0.0
---

# Remove-AzRedisCacheAccessPolicy

## SYNOPSIS
Delete the Access Policy

## SYNTAX

### NormalParameterSet (Default)
```
Remove-AzRedisCacheAccessPolicy [-ResourceGroupName <String>] -Name <String> -AccessPolicyName <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzRedisCacheAccessPolicy -ResourceId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CacheObjectParameterSet
```
Remove-AzRedisCacheAccessPolicy -TopLevelResourceObject <RedisCacheAttributes> -AccessPolicyName <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RedisCacheAccessPolicyObject
```
Remove-AzRedisCacheAccessPolicy -InputObject <PSRedisAccessPolicy> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Remove an access policy from a Redis Cache.

## EXAMPLES

### Example 1
```powershell
Remove-AzRedisCacheAccessPolicy -Name "testCacheName" -AccessPolicyName "testAccessPolicyName"
```

This command removes access policy named testAccessPolicyName from Redis Cache named testCacheName. 

## PARAMETERS

### -AccessPolicyName
The name of the access policy that is being deleted from the Redis cache.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet, CacheObjectParameterSet
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

### -InputObject
Object of type RedisCacheAccessPolicy

```yaml
Type: Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicy
Parameter Sets: RedisCacheAccessPolicyObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of redis cache.

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

### -PassThru
{{ Fill PassThru Description }}

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

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicy

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
