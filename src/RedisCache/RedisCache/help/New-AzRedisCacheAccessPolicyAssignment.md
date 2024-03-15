---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://learn.microsoft.com/powershell/module/az.rediscache/new-azrediscacheaccesspolicyassignment
schema: 2.0.0
---

# New-AzRedisCacheAccessPolicyAssignment

## SYNOPSIS
Add an Access Policy Assignment (Redis User) to the Redis Cache

## SYNTAX

### NormalParameterSet (Default)
```
New-AzRedisCacheAccessPolicyAssignment [-ResourceGroupName <String>] -Name <String>
 -AccessPolicyAssignmentName <String> -AccessPolicyName <String> -ObjectId <String> -ObjectIdAlias <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CacheObjectParameterSet
```
New-AzRedisCacheAccessPolicyAssignment -TopLevelResourceObject <RedisCacheAttributes>
 -AccessPolicyAssignmentName <String> -AccessPolicyName <String> -ObjectId <String> -ObjectIdAlias <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create an access policy assignment (redis user) for a Redis Cache.

## EXAMPLES

### Example 1
```powershell
New-AzRedisCacheAccessPolicyAssignment -Name "testCache" -AccessPolicyAssignmentName "testAccessPolicyAssignmentName" -AccessPolicyName "testAccessPolicyName" -ObjectId "69d700c5-ca77-4335-947e-xxxxxxxxxxxx" -ObjectIdAlias "testAlias"
```

This command creates access policy assignment (redis user) named testAccessPolicyAssignmentName on Redis Cache named testCache.

## PARAMETERS

### -AccessPolicyAssignmentName
Name of Access Policy Assignment being added to the cache.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccessPolicyName
Name of Access Policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -ObjectId
Name of Object Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectIdAlias
Name of Object Id Alias.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group under which cache exists.

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

### Microsoft.Azure.Commands.RedisCache.Models.RedisCacheAttributes

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicyAssignment

## NOTES

## RELATED LINKS
