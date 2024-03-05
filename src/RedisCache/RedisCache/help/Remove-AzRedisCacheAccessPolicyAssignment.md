---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://learn.microsoft.com/powershell/module/az.rediscache/remove-azrediscacheaccesspolicyassignment
schema: 2.0.0
---

# Remove-AzRedisCacheAccessPolicyAssignment

## SYNOPSIS
Delete the Access Policy Assignment (Redis User)

## SYNTAX

### NormalParameterSet (Default)
```
Remove-AzRedisCacheAccessPolicyAssignment [-ResourceGroupName <String>] -Name <String>
 -AccessPolicyAssignmentName <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CacheObjectParameterSet
```
Remove-AzRedisCacheAccessPolicyAssignment -AccessPolicyAssignmentName <String>
 -TopLevelResourceObject <RedisCacheAttributes> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzRedisCacheAccessPolicyAssignment -ResourceId <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RedisCacheAccessPolicyAssignmentObject
```
Remove-AzRedisCacheAccessPolicyAssignment -InputObject <PSRedisAccessPolicyAssignment> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Remove an Access Policy Assignment (Redis User) from a Redis Cache.

## EXAMPLES

### Example 1
```powershell
Remove-AzRedisCacheAccessPolicyAssignment -Name "testCacheName" -AccessPolicyAssignmentName "testAccessPolicyAssignmentName"
```

This command removes an Access Policy Assignment (Redis User) named testAccessPolicyAssignmentName from Redis Cache named testCacheName. 

## PARAMETERS

### -AccessPolicyAssignmentName
The name of the Access Policy Assignment that is being deleted from the Redis cache.

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
Object of type RedisCacheAccessPolicyAssignment

```yaml
Type: Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicyAssignment
Parameter Sets: RedisCacheAccessPolicyAssignmentObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
ARM Id of Redis Cache Access Policy Assignment

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

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicyAssignment

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
